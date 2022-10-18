using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class PostController : Controller
    {

        private readonly BlogDbContext context;
        private readonly ILogger<PostController> logger;
        public PostController(BlogDbContext _context, ILogger<PostController> _logger)
        {
            context = _context;
            logger = _logger;
        }

        [Route("/")]
        public IActionResult Index()
        {
            var posts = context.Posts?.OrderByDescending(p => p.CreatedDateTime);
            return View(posts);
        }

        [Route("/AddNewPost")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/AddNewPost")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                context.Posts?.Add(post);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("/UpdatePost/{id:int:min(1)}")]
        public IActionResult Update(int id)
        {
            var post = context.Posts?.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        [Route("/UpdatePost/{id:int:min(1)}")]
        public IActionResult Update(Post post)
        {
            var postFromForm = post;
            if(postFromForm != null)
            {
                var postFromDB = context.Posts?.FirstOrDefault(p => p.Id == postFromForm.Id);
                if(postFromDB != null)
                {
                    postFromDB.Title = postFromForm.Title;
                    postFromDB.Content = postFromForm.Content;
                    postFromDB.CreatedDateTime = postFromForm.CreatedDateTime;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(post);
        }


        [Route("/DetailPost/{id:int:min(1)}")]
        public IActionResult Detail(int id)
        {
            var post = context.Posts?.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [Route("/Remove/{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {
            var post = context.Posts?.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            context.Posts?.Remove(post);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

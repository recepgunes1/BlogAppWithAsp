using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen başlık giriniz.")]
        [Display(Name = "Başlık")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Lütfen içerik giriniz.")]
        [Display(Name = "İçerik")]
        public string? Content { get; set; }

        [Required(ErrorMessage = "Lütfen tarih biligisi giriniz.")]
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}

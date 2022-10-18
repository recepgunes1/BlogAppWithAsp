﻿using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post>? Posts { get; set; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }
    }
}

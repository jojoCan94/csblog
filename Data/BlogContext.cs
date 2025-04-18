using Microsoft.EntityFrameworkCore;
using BlogProject.Models;

namespace BlogProject.Data
{
    public class BlogContext(DbContextOptions<BlogContext> options) : DbContext(options)
    {
        public DbSet<Post> Posts { get; set; }
    }
}

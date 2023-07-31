using BlogDataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Category = BlogDataAccess.Data.Entities.Category;

namespace BlogDataAccess.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<BlogPost> BlogPost { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
#if DEBUG
        optionsBuilder.LogTo(Console.WriteLine);
#endif

    }






}



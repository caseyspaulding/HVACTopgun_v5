using HVACTopGun.UI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Category = HVACTopGun.UI.Data.Entities.Category;

namespace HVACTopGun.UI.Data;

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

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);



        modelBuilder.Entity<User>()
            .HasData(
            new User
            {
                Id = 1,
                FirstName = "Casey",
                LastName = "Spaulding",
                Email = "casey.spaulding@me.com",
                Salt = "1234567890",
                Hash = "1234567890"

            }

            );




    }

}

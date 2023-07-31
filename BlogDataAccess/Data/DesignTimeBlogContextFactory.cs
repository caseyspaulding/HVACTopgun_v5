using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlogDataAccess.Data;

internal class DesignTimeBlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
{

    public BlogContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();

        var connectionString = "Server=tcp:hvactopgun.database.windows.net,1433;Initial Catalog=Blog_Db;Persist Security Info=False;User ID=cspaulding;Password=GoNavyChief1893!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        optionsBuilder.UseSqlServer(connectionString);

        return new BlogContext(optionsBuilder.Options);
    }


}

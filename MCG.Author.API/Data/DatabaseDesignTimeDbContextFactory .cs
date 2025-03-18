using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace MSG.Author.API.Data
{
    public class DatabaseDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var Configbuilder = WebApplication.CreateBuilder(args);
            builder.UseSqlServer(Configbuilder.Configuration.GetConnectionString("AuthorConnectionString"));
            return new ApplicationDbContext(builder.Options);
        }
    }
    
    
}

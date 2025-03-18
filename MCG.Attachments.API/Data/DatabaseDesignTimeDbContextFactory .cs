using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using MSG.Attachment.Data;


namespace MSG.Attachment.API.Data
{
    public class DatabaseDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var Configbuilder = WebApplication.CreateBuilder(args);
            builder.UseSqlServer(Configbuilder.Configuration.GetConnectionString("PatientAttachmentsConnectionString"));
            return new ApplicationDbContext(builder.Options);
        }
    }
    
    
}

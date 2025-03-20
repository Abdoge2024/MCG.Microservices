using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace MSG.MedicalHistory.API.Data
{
    public class DatabaseDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MSG.MedicalHistory.API.Data.MedicalHistoryDbContext>
    {
        public MedicalHistoryDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MedicalHistoryDbContext>();
            var Configbuilder = WebApplication.CreateBuilder(args);
            builder.UseSqlServer(Configbuilder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"));
            return new MedicalHistoryDbContext(builder.Options);
        }
    }
    
    
}

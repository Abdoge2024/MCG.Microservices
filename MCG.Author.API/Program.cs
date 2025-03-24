using MCG.Author.API.Models;
using MCG.Author.API.Repositories.Implementations;
using MCG.Author.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MSG.Author.API.Data;
using MSG.Author.API.Mappings;


var builder = WebApplication.CreateBuilder(args);

// Add services Connection to the API
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));

builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<ITokenGenerator, TokenGenerator>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
ApplyMigration();
app.Run();


//this is just for temp to keep adding dummy data 
void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var db_ = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        if (db_.Database.GetPendingMigrations().Count() > 0)
        {
            db_.Database.Migrate();

        }
    }

}

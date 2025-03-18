using Microsoft.EntityFrameworkCore;
using MSG.API.Data;
using MSG.Profile.API.Mappings;
using MSG.Profile.API.Repositories.Implemantation;
using MSG.Profile.API.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services Connection to the API
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("PatientProfileConnectionString"));
});

builder.Services.AddTransient<IPatientRepository, PatientRepository>();
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
app.UseAuthorization();
app.MapControllers();


app.UseCors(optios =>
{
    optios.AllowAnyHeader();
    optios.AllowAnyOrigin();
    optios.AllowAnyMethod();
});
ApplyMigration();
app.Run();


//this is just for temp to keep adding dummy data 
void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var db_ = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        if(db_.Database.GetPendingMigrations().Count()>0)
        {
            db_.Database.Migrate();

        }
    }

}

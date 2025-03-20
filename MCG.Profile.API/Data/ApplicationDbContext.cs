using MCG.Profile.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using MSG.API.Models.Domain;
using static MSG.API.Models.Domain.Patient;


namespace MSG.API.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientHistory> PatientHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var todaysDate = new DateTime();
            todaysDate = DateTime.Today;

            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                PatientID = 1000,
                PatFirstName = "Georges",
                PatMiddleName = "H",
                PatLastName = "Whiteman",
                PatDateOfBirth = "06/07/1935",
                PatEmail = "ghabdo@att.net",
                PatPhoneNumber = "2162251525",
                PatAddress = "6110 Sturbridge lane",
                PatCity = "Cumming",
                PatState = "Georgia",
                PatZipCode = 30040,
                PatGender = Gender.Male,
                PatEmergencyContact = "Janet",
                PatEmergencyContactEmail = "jnet@net.com",
                PatEmergencyContactPhone = "2162251525",
                DateCreated = todaysDate


            });

            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                PatientID = 1001,
                PatFirstName = "Jack",
                PatMiddleName = "M",
                PatLastName = "Sheriff",
                PatDateOfBirth = "06/07/1935",
                PatEmail = "jacko@att.net",
                PatPhoneNumber = "2162251525",
                PatAddress = "6110 Sturbridge lane",
                PatCity = "Alpahretta",
                PatState = "Georgia",
                PatZipCode = 30040,
                PatGender = Gender.Male,
                PatEmergencyContact = "Ghazi",
                PatEmergencyContactEmail = "Jackt@net.com",
                PatEmergencyContactPhone = "2162251525",
                DateCreated = todaysDate


            });

        }
    }

}


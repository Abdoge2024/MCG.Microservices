using MCG.MedicalHisotry.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using MSG.MedicalHistory.API.Models.Domain;

namespace MSG.MedicalHistory.API.Data
{
    public class MedicalHistoryDbContext: DbContext
    {
        public MedicalHistoryDbContext(DbContextOptions<MedicalHistoryDbContext> options) : base(options)
        {
        }

        public DbSet<PatientMedicalHistory> PatientMedicalHistory { get; set; }

   
   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var todaysDate = new DateTime();
            todaysDate = DateTime.Today;

            modelBuilder.Entity<MCGDoctorsList>().HasData(new MCGDoctorsList
            {

                DoctorsID = 1,
                DoctorsName = "Xlander, Xandr",
                DateCreated = todaysDate,
                //need an emmployeeID here
                CreatedBy = 1


            });

            modelBuilder.Entity<PatientMedicalHistory>().HasData(new PatientMedicalHistory
            {
                MedicalHistoryID = 1,
                PatientID = 1000,
                DoctorId = 1,
                Diagnosis = "this patient has the flu.",
                Treatment = "Gave them antibiotics",
                Notes = "we will check on them later",
                VisitDate = todaysDate,
                DateCreated = todaysDate,
                CreatedBy = 1


            });

            modelBuilder.Entity<PatientMedicalHistory>().HasData(new PatientMedicalHistory
            {

                MedicalHistoryID = 2,
                PatientID = 1000,
                DoctorId = 1,
                Diagnosis = "Patient Has a rash on his feet, red spots.",
                Treatment = "Gave them antibiotics",
                Notes = "we will check on them later",
                VisitDate = todaysDate,
                DateCreated = todaysDate,
                CreatedBy = 1
            });

        }
    }

}


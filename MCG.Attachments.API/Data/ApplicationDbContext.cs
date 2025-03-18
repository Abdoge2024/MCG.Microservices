using MCG.Attachments.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MSG.Attachment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DocumentsType> DocumentsType { get; set; }
        public DbSet<FileTypes> FileTypes { get; set; }
        public DbSet<PatientAttachments> PatientAttachments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var todaysDate = new DateTime();
            todaysDate = DateTime.Today;

            modelBuilder.Entity<DocumentsType>().HasData(new DocumentsType
            {
                DocumentKey = DocTypes.MRI,
                DocumentName = "MRI"
            });


            modelBuilder.Entity<FileTypes>().HasData(new FileTypes
            {
                FileKey = FileTypesExt.PDF,
                FileName = "PDF"
            });

            modelBuilder.Entity<PatientAttachments>().HasData(new PatientAttachments
            {
                AttachmentID = 1,
                PatientID = 1000,
                FileName="MRI_03082025_1048.PDF",
                FilePath= "E:\\MCG\\API\\MCG.API\\Files",
                FileType= FileTypesExt.PDF,
                DocType=DocTypes.MRI,
                DateUploaded=todaysDate,
                CreatedBy=1

            });

            modelBuilder.Entity<PatientAttachments>().HasData(new PatientAttachments
            {
                AttachmentID = 2,
                PatientID = 1001,
                FileName = "CAT_03082025_1040.PDF",
                FilePath = "E:\\MCG\\API\\MCG.API\\Files",
                FileType = FileTypesExt.PDF,
                DocType=DocTypes.CAT,
                DateUploaded = todaysDate,
                CreatedBy = 1
            });

            modelBuilder.Entity<PatientAttachments>().HasData(new PatientAttachments
            {
                AttachmentID = 3,
                PatientID = 1001,
                FileName = "CAT_03082025_1040.PDF",
                FilePath = "E:\\MCG\\API\\MCG.API\\Files",
                FileType = FileTypesExt.CSV,
                DocType = DocTypes.CAT,
                DateUploaded = todaysDate,
                CreatedBy = 1
            });

        }
        }
        
    }


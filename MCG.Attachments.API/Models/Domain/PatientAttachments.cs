using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCG.Attachments.API.Models.Domain
{
    public class PatientAttachments
    {
        [Key]
        public int AttachmentID { get; set; }

        [Required, ForeignKey("PatientID")]
        public int PatientID { get; set; }

        [Required,MaxLength(255)]
        public string FileName { get; set; }

        [Required]
        public FileTypesExt FileType { get; set; }

        [Required]
        public DocTypes DocType { get; set; }

        [Required, MaxLength(255)]
        public string FilePath { get; set; }

        [Required]
        public DateTime DateUploaded { get; set; }

        public int CreatedBy { get; set; }

    }
}

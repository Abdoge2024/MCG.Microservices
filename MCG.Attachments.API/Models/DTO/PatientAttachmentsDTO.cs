using MCG.Attachments.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MCG.Attachments.API.Models.DTO
{
    public class PatientAttachmentsDTO
    {
        public int AttachmentID { get; set; }
        public int PatientID { get; set; }
        public string FileName { get; set; }
        public FileTypesExt FileType { get; set; }
        public DocTypes DocType { get; set; }
        public string FilePath { get; set; }
        public DateTime DateUploaded { get; set; }
        public int CreatedBy { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MCG.Attachments.API.Models.Domain
{

    public enum FileTypesExt
    {
        PDF = 0,
        XLSX=1,
        CSV=2,
        DOCX=3

    }
    public class FileTypes
    {
        [Key]
        public FileTypesExt FileKey { get; set; }

        public string FileName { get; set; } = string.Empty;
    }
}

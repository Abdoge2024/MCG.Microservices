using MCG.Attachments.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MCG.Attachments.API.Models.DTO
{
    public class FileTypesDTO
    {

        public FileTypesExt FileKey { get; set; }

        public string FileName { get; set; } 
    }
}

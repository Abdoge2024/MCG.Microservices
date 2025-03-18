using MCG.Attachments.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MCG.Attachments.API.Models.DTO
{
    public class DocumentsTypeDTO
    {
        public class DocumentsType
        {
            public DocTypes DocumentKey { get; set; }

            public string DocumentName { get; set; } 
        }
    }
}
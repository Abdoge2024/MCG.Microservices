using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace MCG.Attachments.API.Models.Domain
{
    public enum DocTypes
    {
        MRI=0,
        CAT=1,
        XRAYS=2,
        REPORT=3

    }
    public class DocumentsType
    {
        [Key]
        public DocTypes DocumentKey { get; set; }

      public string DocumentName { get; set; } = string.Empty;
}
}

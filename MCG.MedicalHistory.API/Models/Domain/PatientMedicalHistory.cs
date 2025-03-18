using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCG.MedicalHisotry.API.Models.Domain
{
    public class PatientMedicalHistory
    {

        [Key]
        public int MedicalHistoryID { get; set; }
        [ForeignKey("PatientID")]
        public int PatientID { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Treatment { get; set; } = string.Empty;
        [Required,ForeignKey("DoctorsID")]
        public int DoctorId { get; set; }
        [Required]
        public DateTime VisitDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        [MaxLength(100)]
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

    }
}

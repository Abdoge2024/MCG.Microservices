using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MSG.MedicalHistory.API.Models.DTO
{
    public class MedicalHistoryDTO
    {   
        public int MedicalHistoryID { get; set; }
        public int PatientID { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Treatment { get; set; } = string.Empty;    
        public int DoctorId { get; set; }
        public DateTime VisitDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MSG.MedicalHistory.API.Models.Domain
{
    public class MCGDoctorsList
    {
        [Key]
        public int DoctorsID { get; set; }

        [Required]
        public string DoctorsName { get; set; }

        public DateTime DateCreated { get; set; }
        [Required]
        public int CreatedBy { get; set; }
    }
}

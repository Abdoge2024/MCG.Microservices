using static MSG.API.Models.Domain.Patient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCG.Profile.API.Models.Domain
{
    public class PatientHistory
    {

        [Key]
        public int HistoryID { get; set; }

        [ForeignKey("PatientID")]
        public int PatientID { get; set; }

        [Required, MaxLength(100)]
        public string PatFirstName { get; set; }


        [MaxLength(100)]
        public string PatMiddleName { get; set; } = string.Empty;


        [Required, MaxLength(100)]
        public string PatLastName { get; set; }


        [Required, MaxLength(10)]
        public string PatDateOfBirth { get; set; }



        [Required, MaxLength(150)]
        public string PatEmail { get; set; }


        [Required, MaxLength(10)]
        public string PatPhoneNumber { get; set; }


        public Gender PatGender { get; set; }


        [Required, MaxLength(100)]
        public string PatAddress { get; set; }


        [Required, MaxLength(100)]
        public string PatCity { get; set; }

        [Required, MaxLength(100)]
        public string PatState { get; set; }


        [Required, MaxLength(10)]
        public int PatZipCode { get; set; }

        [MaxLength(100)]
        public string PatEmergencyContact { get; set; } = string.Empty;

        [MaxLength(10)]
        public string PatEmergencyContactPhone { get; set; } = string.Empty;

        [MaxLength(150)]
        public string PatEmergencyContactEmail { get; set; } = string.Empty;

        [MaxLength(100)]
        public string UpdatedBy { get; set; } = string.Empty;

        /// <summary>
        /// this will be populated from update date in patient table
        /// </summary>
        public DateTime? DateUpdated { get; set; }

    }
}

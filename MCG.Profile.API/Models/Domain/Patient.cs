using MCG.Profile.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MSG.API.Models.Domain
{

    public class Patient
    {

       public  enum Gender
        {
            Male=0,
            Female=1,
            Other=2            
        }


        [Key]
        public int PatientID { get; set; }

        [Required, MaxLength(100)]
        public string PatFirstName { get; set; }


        [MaxLength(75)]
        public string PatMiddleName { get; set; } = string.Empty;


        [Required,MaxLength(100)]
        public string PatLastName { get; set; }

     
        [Required,MaxLength(10)]
        public string PatDateOfBirth { get; set; }


        [Required, MaxLength(150)]
        public string PatEmail { get; set; }


        [Required, MaxLength(10)]
        public string PatPhoneNumber { get; set; }


        public Gender PatGender { get; set; } = Gender.Other;

                
        [Required,MaxLength(100)]
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

        /// <summary>
        /// this is the day was entered and created and will not  change
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// when the patient first time  created this todays date than it will be updated as the patient is updated 
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// this is one to many 
        /// </summary>
        public List<PatientHistory> PatientHistory { get; set; }



    }
}

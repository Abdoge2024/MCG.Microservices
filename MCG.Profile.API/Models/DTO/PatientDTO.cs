using MCG.Profile.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MSG.Profile.API.Models.DTO
{
    public class PatientDTO
    {

     
        public int PatientID { get; set; }
        public string PatFirstName { get; set; }
        public string PatMiddleName { get; set; } = string.Empty;
        public string PatLastName { get; set; }
        public string PatDateOfBirth { get; set; }
        public string PatEmail { get; set; }
        public string PatPhoneNumber { get; set; }
        public string PatGender { get; set; } = string.Empty;
        public string PatAddress { get; set; }
        public string PatCity { get; set; }
        public string PatState { get; set; }
        public int PatZipCode { get; set; }
        public DateTime DateCreated { get; set; }
        public string PatEmergencyContact { get; set; } = string.Empty;
        public string PatEmergencyContactPhone { get; set; } = string.Empty;
        public string PatEmergencyContactEmail { get; set; } = string.Empty;
        public List<PatientHistory> PatientHistory { get; set; }

    }
}

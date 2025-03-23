using Moq;
using Xunit;
using FluentAssertions;
using MSG.Profile.API.Repositories.Interface;
using MSG.API.Models.Domain;
using static MSG.API.Models.Domain.Patient;

namespace MCG.Profile.API.Test.Tests
{
    public class PatientProfileTest
    {
        private readonly Mock<IPatientRepository> _repositoryMock;
        DateTime todaysDate = new DateTime();


        public PatientProfileTest()
        {
            _repositoryMock = new Mock<IPatientRepository>();
            todaysDate = DateTime.Today;
        }

        [Fact]
        public async Task GetAllProfilePatients_ShouldReturnPatients()
        {
            //Arrange 
            var patients = new List<Patient>();
            {
              
                patients.Add(new Patient
                {
                    PatientID = 1000,
                    PatFirstName = "Georges",
                    PatMiddleName = "H",
                    PatLastName = "Whiteman",
                    PatDateOfBirth = "06/07/1935",
                    PatEmail = "ghabdo@att.net",
                    PatPhoneNumber = "2162251525",
                    PatAddress = "6110 Sturbridge lane",
                    PatCity = "Cumming",
                    PatState = "Georgia",
                    PatZipCode = 30040,
                    PatGender = Gender.Male,
                    PatEmergencyContact = "Janet",
                    PatEmergencyContactEmail = "jnet@net.com",
                    PatEmergencyContactPhone = "2162251525",
                    DateCreated = todaysDate
                });
            }

            _repositoryMock.Setup(a=> a.GetAllPatientsAsync()).ReturnsAsync(patients);
           
            //Act
             var result = await _repositoryMock.Object.GetAllPatientsAsync();
            Assert.NotNull(result);         
        }


        [Fact]
        public async Task GetAPatientByIdAsync_ShouldReturnCorrectPatient()
        {
            //Arrange
            var patient = new Patient
            {
                PatientID = 1000,
                PatFirstName = "Georges",
                PatMiddleName = "H",
                PatLastName = "Whiteman",
                PatDateOfBirth = "06/07/1935",
                PatEmail = "ghabdo@att.net",
                PatPhoneNumber = "2162251525",
                PatAddress = "6110 Sturbridge lane",
                PatCity = "Cumming",
                PatState = "Georgia",
                PatZipCode = 30040,
                PatGender = Gender.Male,
                PatEmergencyContact = "Janet",
                PatEmergencyContactEmail = "jnet@net.com",
                PatEmergencyContactPhone = "2162251525",
                DateCreated = todaysDate
            };
            _repositoryMock.Setup( a => a.GetAPatientByIdAsync(1000)).ReturnsAsync(patient);

            //Act
            var result = await _repositoryMock.Object.GetAPatientByIdAsync(1000);
            //Assert
            result.Should().NotBeNull();
            result.PatientID.Should().Be(1000);
            result.PatFirstName.Should().Be("Georges");
        }

        [Fact]
        public async Task CreatePatientsAsync_ShouldReturnAddedPatient()
        {
            //Arrange
            var newPatient = new Patient
            {
                PatientID = 1010,
                PatFirstName = "Scott",
                PatMiddleName = "H",
                PatLastName = "Whiteman",
                PatDateOfBirth = "06/07/1935",
                PatEmail = "ghabdo@att.net",
                PatPhoneNumber = "2162251525",
                PatAddress = "6110 Sturbridge lane",
                PatCity = "Cumming",
                PatState = "Georgia",
                PatZipCode = 30040,
                PatGender = Gender.Male,
                PatEmergencyContact = "Janet",
                PatEmergencyContactEmail = "jnet@net.com",
                PatEmergencyContactPhone = "2162251525",
                DateCreated = todaysDate
            };

            _repositoryMock.Setup(a => a.CreatePatientsAsync(It.IsAny<Patient>())).ReturnsAsync(newPatient);

            //Act 
            var result = await _repositoryMock.Object.CreatePatientsAsync(newPatient);
            //Assert
            result.Should().NotBeNull();
            result.PatientID.Should().Be(1010);
            result.PatFirstName.Should().Be("Scott");

        }

    }
}

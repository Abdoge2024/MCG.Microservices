using Microsoft.EntityFrameworkCore;
using MSG.API.Data;
using MSG.API.Models.Domain;
using MSG.Profile.API.Repositories.Interface;

namespace MSG.Profile.API.Repositories.Implemantation
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientRepository (ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Patient> CreatePatientsAsync(Patient patient)
        {
            await _dbContext.Patient.AddAsync(patient);
            await _dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient?> DeletePatientAsync(int PatientId)
        {
            var existingPatient = await _dbContext.Patient.FirstOrDefaultAsync(x => x.PatientID == PatientId);

            if (existingPatient == null)
            {
                return null;
            }

            _dbContext.Patient.Remove(existingPatient);
            await _dbContext.SaveChangesAsync();
            return existingPatient;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            var patients = await _dbContext.Patient.ToListAsync();
            return patients;
        }

        public async Task<Patient?> GetAPatientByIdAsync(int PatientId)
        {
            return await _dbContext.Patient.FirstOrDefaultAsync(c => c.PatientID == PatientId);
        }


      
        public async Task<IEnumerable<Patient>> GetPatientByLastNameAsync(string Lname)
        {

           return await _dbContext.Patient.Where(r => r.PatLastName.ToLower().Contains(Lname.ToLower())).ToListAsync();
    
        }

        public async Task<Patient?> UpdatePatientAsync(int PatientId, Patient patient)
        {
            var existingPatient = await _dbContext.Patient.FirstOrDefaultAsync(x => x.PatientID == PatientId);

            if (existingPatient == null) 
            {
                return null;
            }

            existingPatient.PatFirstName = patient.PatFirstName;
            existingPatient.PatMiddleName = patient.PatMiddleName;
            existingPatient.PatLastName = patient.PatLastName;
            existingPatient.PatEmergencyContactEmail = patient.PatEmergencyContactEmail;
            existingPatient.PatEmergencyContact = patient.PatEmergencyContact;
            existingPatient.PatEmergencyContactPhone = patient.PatEmergencyContactPhone;
            existingPatient.PatGender = patient.PatGender;
            existingPatient.PatDateOfBirth = patient.PatDateOfBirth;
            existingPatient.PatEmail = patient.PatEmail;
            existingPatient.PatAddress = patient.PatAddress;
            existingPatient.PatCity = patient.PatCity;
            existingPatient.PatZipCode = patient.PatZipCode;
            existingPatient.PatPhoneNumber = patient.PatPhoneNumber;
            existingPatient.DateCreated = patient.DateCreated;
            existingPatient.UpdatedDate = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            // we need to enter the older record of patient in history. 

            return existingPatient;
                
        }

     
    }
}

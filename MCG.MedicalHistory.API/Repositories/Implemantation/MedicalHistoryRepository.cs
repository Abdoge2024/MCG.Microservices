using MCG.MedicalHisotry.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using MSG.MedicalHistory.API.Data;
using MSG.MedicalHistory.API.Repositories.Interface;
using MSG.MedicalHistory;


namespace MSG.MSG_MedicalHistory.API.Repositories.Implemantation
{
    public class MedicalHistoryRepository : IMedicalHistoryRepository
    {
        private readonly MedicalHistoryDbContext _dbContext;

        public MedicalHistoryRepository (MedicalHistoryDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<PatientMedicalHistory> CreateMedicalHistorysAsync(PatientMedicalHistory patientmedical)
        {
            await _dbContext.PatientMedicalHistory.AddAsync(patientmedical);
            await _dbContext.SaveChangesAsync();
            return patientmedical;
        }

        public async Task<PatientMedicalHistory?> DeleteMedicalHistoryAsync(int HistoryID)
        {
            var existingHistory = await _dbContext.PatientMedicalHistory.FirstOrDefaultAsync(x => x.MedicalHistoryID == HistoryID);

            if (existingHistory == null)
            {
                return null;
            }

            _dbContext.PatientMedicalHistory.Remove(existingHistory);
            await _dbContext.SaveChangesAsync();
            return existingHistory;
        }


        public async Task<IEnumerable<PatientMedicalHistory>> GetAllMedicalHistoryAsync()
        {
            var patients = await _dbContext.PatientMedicalHistory.ToListAsync();
            return patients;
        }

           

        public async Task<IEnumerable<PatientMedicalHistory>> GetAMedicalHistoryByPatientIdAsync(int PatientId)
        {
            return await _dbContext.PatientMedicalHistory.Where(c => c.PatientID == PatientId).ToListAsync();
        }


      
        public async Task<PatientMedicalHistory?> UpdateMedicalHistoryAsync(int HistorytID, PatientMedicalHistory patient)
        {
            var existingHistory = await _dbContext.PatientMedicalHistory.FirstOrDefaultAsync(x => x.MedicalHistoryID == HistorytID);

            if (existingHistory == null) 
            {
                return null;
            }     
            await _dbContext.SaveChangesAsync();
            // we need to enter the older record of patient in history. 
            return existingHistory;                
        }

     
    }
}

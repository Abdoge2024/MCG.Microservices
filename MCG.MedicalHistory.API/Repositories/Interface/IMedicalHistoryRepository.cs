

using MCG.MedicalHisotry.API.Models.Domain;

namespace MSG.MedicalHistory.API.Repositories.Interface
{
    public interface IMedicalHistoryRepository
    {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
        Task<IEnumerable<PatientMedicalHistory>> GetAllMedicalHistoryAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<PatientMedicalHistory>> GetAMedicalHistoryByPatientIdAsync(int PatientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        Task<PatientMedicalHistory> CreateMedicalHistorysAsync(PatientMedicalHistory patientmedical);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        Task<PatientMedicalHistory?> UpdateMedicalHistoryAsync(int PatientId, PatientMedicalHistory medicalHistory);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PatientMedicalHistory?> DeleteMedicalHistoryAsync(int id);

    


    }
}

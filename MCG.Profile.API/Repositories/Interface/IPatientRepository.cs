using MSG.API.Models.Domain;

namespace MSG.Profile.API.Repositories.Interface
{
    public interface IPatientRepository
    {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
        Task<IEnumerable<Patient>> GetAllPatientsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Patient?> GetAPatientByIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        Task<Patient> CreatePatientsAsync(Patient patient);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        Task<Patient?> UpdatePatientAsync(int PatientId, Patient patient);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Patient?> DeletePatientAsync(int id);

        Task<IEnumerable<Patient>> GetPatientByLastNameAsync(string Lname);


    }
}


using MCG.Attachments.API.Models.Domain;
using Microsoft.Extensions.FileProviders;

namespace MSG.Attachment.API.Repositories.Interface
{
    public interface IAttachementsRepository
    {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
        Task<IEnumerable<PatientAttachments>> GetAllAttachmentsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<PatientAttachments>> GetAttachmentsByPatientIdAsync(int PatientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        Task<PatientAttachments> CreateAttachmentsAsync(PatientAttachments patientmedical);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        Task<PatientAttachments?> UpdateAttachmentsAsync(int attachmentID, PatientAttachments medicalHistory);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PatientAttachments?> DeleteAttachmentsAsync(int id);


    }
}

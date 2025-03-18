using MCG.Attachments.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.FileProviders;
using MSG.Attachment.API.Repositories.Interface;
using MSG.Attachment.Data;

namespace MSG.Attachment.API.Repositories.Implemantation
{
    public class AttachmentsRepository : IAttachementsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AttachmentsRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientAttachments"></param>
        /// <returns></returns>
        public async Task<PatientAttachments> CreateAttachmentsAsync(PatientAttachments patientAttachments)
        {
            await _dbContext.PatientAttachments.AddAsync(patientAttachments);
            await _dbContext.SaveChangesAsync();
            return patientAttachments;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attachmentID"></param>
        /// <returns></returns>
        public async Task<PatientAttachments?> DeleteAttachmentsAsync(int attachmentID)
        {
            var existingAttachment = await _dbContext.PatientAttachments.FirstOrDefaultAsync(x => x.AttachmentID == attachmentID);

            if (existingAttachment == null)
            {
                return null;
            }

            _dbContext.PatientAttachments.Remove(existingAttachment);
            await _dbContext.SaveChangesAsync();
            return existingAttachment;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PatientAttachments>> GetAllAttachmentsAsync()
        {
            var attachments = await _dbContext.PatientAttachments.ToListAsync();
            return attachments;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PatientId"></param>
        /// <returns></returns>

        public async Task<IEnumerable<PatientAttachments>> GetAttachmentsByPatientIdAsync(int PatientId)
        {
            return await _dbContext.PatientAttachments.Where(c => c.PatientID == PatientId).ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attachmentID"></param>
        /// <param name="medicalHistory"></param>
        /// <returns></returns>
        public async Task<PatientAttachments?> UpdateAttachmentsAsync(int attachmentID, PatientAttachments medicalHistory)
        {
            var existingAttachment = await _dbContext.PatientAttachments.FirstOrDefaultAsync(x => x.AttachmentID == attachmentID);

            if (existingAttachment == null)
            {
                return null;
            }
            await _dbContext.SaveChangesAsync();
            // we need to enter the older record of patient in history. 
            return existingAttachment;
        }  
    }
}

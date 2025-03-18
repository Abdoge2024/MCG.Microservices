using AutoMapper;
using MCG.Attachments.API.Models.Domain;
using MCG.Attachments.API.Models.DTO;



namespace MSG.Attachment.API.Mappings
{
    public class AutoMapperProfiles :  Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PatientAttachments,PatientAttachmentsDTO>().ReverseMap();

        }
    }
}

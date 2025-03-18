using AutoMapper;
using MCG.MedicalHisotry.API.Models.Domain;
using MSG.MedicalHistory.API.Models.DTO;


namespace MSG.MedicalHistory.API.Mappings
{
    public class AutoMapperProfiles :  AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PatientMedicalHistory, MedicalHistoryDTO>().ReverseMap();
        }
    }
}

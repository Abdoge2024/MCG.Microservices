using AutoMapper;
using MSG.API.Models.Domain;
using MSG.Profile.API.Models.DTO;

namespace MSG.Profile.API.Mappings
{
    public class AutoMapperProfiles :  AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
        }
    }
}

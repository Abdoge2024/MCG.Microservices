using AutoMapper;
using MCG.Author.API.Models;
using MCG.Author.API.Models.DTO;


namespace MSG.Author.API.Mappings
{
    public class AutoMapperProfiles :  AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}

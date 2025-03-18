using MCG.Author.API.Models.DTO;

namespace MCG.Author.API.Repositories.Interface
{
    public interface IAuthorRepository
    {

        Task<string> Register(RegistrationDTO registrationDTO);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTOcs);

        Task<bool> AssignRole(string email, string roleName);

    }
}

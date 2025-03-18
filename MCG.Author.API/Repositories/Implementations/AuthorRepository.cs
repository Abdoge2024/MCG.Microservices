using AutoMapper;
using MCG.Author.API.Models;
using MCG.Author.API.Models.DTO;
using MCG.Author.API.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using MSG.Author.API.Data;

namespace MCG.Author.API.Repositories.Implementations
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager <ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;

        public AuthorRepository(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,IMapper mapper, ITokenGenerator tokenGenerator)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var userToReturn = _applicationDbContext.ApplicationUsers.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            if(userToReturn !=null)
            {
                if (_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult());
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();

                }
                await _userManager.AddToRoleAsync(userToReturn, roleName);
                return true;
            }
            return false;
                
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var userToReturn = _applicationDbContext.ApplicationUsers.FirstOrDefault(x => x.UserName.ToLower() == loginRequestDTO.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(userToReturn, loginRequestDTO.Password);

            if(userToReturn == null || isValid == false)
             {
                return new LoginResponseDTO() { User = null ,Token=""};
            }

            //if user is found generate token
            var token = _tokenGenerator.GenerateToken(userToReturn);

            var userDto = new UserDTO();
            userDto = _mapper.Map<UserDTO>(userToReturn);

            var loginResponse = new LoginResponseDTO
            {
                User = userDto,
                Token =  token
            };
            return loginResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registrationDTO"></param>
        /// <returns></returns>
        public async Task<string> Register(RegistrationDTO registrationDTO)
        {
            var user = new ApplicationUser
            {
               UserName =registrationDTO.Name,
               Email= registrationDTO.Email,
               NormalizedEmail=registrationDTO.Email.ToUpper(),
               Name=registrationDTO.Name,
               PhoneNumber=registrationDTO.PhoneNumber
            };

            try
            {
                var userDto = new UserDTO();
                var result = await _userManager.CreateAsync(user, registrationDTO.Password);
                if(result.Succeeded)
                {
                    var userToReturn = _applicationDbContext.ApplicationUsers.First(x => x.UserName == registrationDTO.Email);
                    userDto = _mapper.Map<UserDTO>(userToReturn);
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }
            catch(Exception ex)
            {
                return "Error";
            }
        }
    }
}

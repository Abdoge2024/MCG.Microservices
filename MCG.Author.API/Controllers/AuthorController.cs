using Azure;
using MCG.Author.API.Models.DTO;
using MCG.Author.API.Repositories.Implementations;
using MCG.Author.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MCG.Author.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _AuthorRepository;
        protected ReponseDTO _response;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _AuthorRepository = authorRepository;
            _response = new();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registrationDTO"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDTO registrationDTO)
        {
            var error = await _AuthorRepository.Register(registrationDTO);
            if(!string.IsNullOrEmpty(error))
            {
                _response.IsSuccess = false;
                _response.Message = error;
                return BadRequest(_response);

            }
            return Ok(_response);
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="loginRequestDTO"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
       {

            var login = await _AuthorRepository.Login(loginRequestDTO);
            if(login.User==null)
            {
                _response.IsSuccess = false;
                _response.Message = "username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Results=login;
            return Ok(_response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registrationDTO"></param>
        /// <returns></returns>
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole(RegistrationDTO registrationDTO)
        {
            var assignRole = await _AuthorRepository.AssignRole(registrationDTO.Email,registrationDTO.Role.ToUpper());
            if (!assignRole)
            {
                _response.IsSuccess = false;
                _response.Message = "Error Generated";
                return BadRequest(_response);
            }           
            return Ok(_response);
        }


    }
}

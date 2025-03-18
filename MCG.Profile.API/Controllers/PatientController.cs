using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSG.API.Data;
using MSG.API.Models.Domain;
using MSG.Profile.API.Models.DTO;
using MSG.Profile.API.Repositories.Interface;
using System.Runtime.CompilerServices;

namespace MSG.Profile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();
              return Ok(_mapper.Map<List<PatientDTO>>(patients));         
        }


        /// <summary>
        /// get patient by passing an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAPatientByIdAsync(int patientId)
        {
            
            var patient = await _patientRepository.GetAPatientByIdAsync(patientId);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PatientDTO>(patient));

        }

        /// <summary>
        /// add patient
        /// </summary>
        /// <param name="patientDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreatePatientsAsync(PatientDTO patientDTO)
        {
            //Map DTO to domain model
            var domain= _mapper.Map<Patient>(patientDTO);
            var createdPatient = await _patientRepository.CreatePatientsAsync(domain);
            var DTO= _mapper.Map<PatientDTO>(createdPatient);
            return Ok(DTO);

        }

        /// <summary>
        /// update Patient
        /// </summary>
        /// <param name="PatientID"></param>
        /// <param name="patientDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdatePatientAsync(int PatientID,PatientDTO patientDTO)
        {
            // map here
            var domain = _mapper.Map<Patient>(patientDTO);
            //update
            domain= await _patientRepository.UpdatePatientAsync(PatientID, domain);
             if (domain ==null)
            {
                return NotFound();
            }

            var DTO = _mapper.Map<PatientDTO>(domain);
            return Ok(DTO);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePatientAsync(int PatientId)
        {
            var patientDomainModel = await _patientRepository.DeletePatientAsync(PatientId);

            if (patientDomainModel == null)
            {
                return NotFound();
            }

            var DTO = _mapper.Map<PatientDTO>(patientDomainModel);
            return Ok(DTO);
        }


        [HttpGet("{Lname}")]
        public async Task<ActionResult> GetPatientByLastName(string Lname)
        {
            var patients = await _patientRepository.GetPatientByLastNameAsync(Lname);
            return Ok(_mapper.Map<List<PatientDTO>>(patients));
        }
    }
}

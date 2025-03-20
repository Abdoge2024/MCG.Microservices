using AutoMapper;
using MCG.MedicalHisotry.API.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using MSG.MedicalHistory.API.Models.DTO;
using MSG.MedicalHistory.API.Repositories.Interface;

namespace MSG.MedicalHistory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;
        private readonly IMapper _mapper;
        public MedicalHistoryController(IMedicalHistoryRepository patientRepository, IMapper mapper)
        {
            _medicalHistoryRepository = patientRepository;
            _mapper = mapper;
        }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMedicalHistoryAsync()
        {
             var medicals = await _medicalHistoryRepository.GetAllMedicalHistoryAsync();
             return Ok(_mapper.Map<List<MedicalHistoryDTO>>(medicals));         
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="HistoryID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{PatientId:int}")]
        public async Task<IActionResult> GetAMedicalHistoryByPatientIdAsync(int PatientId) { 
             var medicals = await _medicalHistoryRepository.GetAMedicalHistoryByPatientIdAsync(PatientId);
             if (medicals == null)
             {
                 return NotFound();
              }
            return Ok(_mapper.Map<List<MedicalHistoryDTO>>(medicals));

        }

       /// <summary>
       /// /
       /// </summary>
       /// <param name="patientMedicalDTO"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMedicalHistorysAsync(MedicalHistoryDTO patientMedicalDTO)
        {
            //Map DTO to domain model
            var domain = _mapper.Map<PatientMedicalHistory>(patientMedicalDTO);
            var createdPatientMedical = await _medicalHistoryRepository.CreateMedicalHistorysAsync(domain);
            var DTO = _mapper.Map<MedicalHistoryDTO>(createdPatientMedical);
            return Ok(DTO);

        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="HistoryID"></param>
    /// <param name="HistoryDTO"></param>
    /// <returns></returns>
        [HttpPut("{MedicalHistoryID:int}")]
        public async Task<IActionResult> UpdateMedicalHistoryAsync(int MedicalHistoryID, MedicalHistoryDTO HistoryDTO)
        {
            // map here
            var domain = _mapper.Map<PatientMedicalHistory>(HistoryDTO);
          //  update
              domain = await _medicalHistoryRepository.UpdateMedicalHistoryAsync(MedicalHistoryID, domain);
            if (domain == null)
            {
                return NotFound();
            }

            var DTO = _mapper.Map<MedicalHistoryDTO>(domain);
            return Ok(DTO);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="HistoryID"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeletePMedicalHistoryAsync(int MedicalHistoryID)
        {
            var historyDomainModel = await _medicalHistoryRepository.DeleteMedicalHistoryAsync(MedicalHistoryID);

            if (historyDomainModel == null)
            {
                return NotFound();
            }

            var DTO = _mapper.Map<MedicalHistoryDTO>(historyDomainModel);
            return Ok(DTO);
        }


    }
}

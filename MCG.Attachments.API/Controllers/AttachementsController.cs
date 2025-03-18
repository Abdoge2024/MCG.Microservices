using AutoMapper;
using MCG.Attachments.API.Models.Domain;
using MCG.Attachments.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSG.Attachment.API.Repositories.Implemantation;
using MSG.Attachment.API.Repositories.Interface;
using System.Runtime.CompilerServices;

namespace MSG.Attachment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachementsController : ControllerBase
    {
        private readonly IAttachementsRepository _attachmentsRepository;
        private readonly IMapper _mapper;
        private readonly IFormFile _file;
        public AttachementsController(IAttachementsRepository attachmentsRepository, IMapper mapper,IFormFile formFile)
        {
            _attachmentsRepository = attachmentsRepository;
            _mapper = mapper;
            _file = formFile;
        }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAttachmentsAsync()
        {
             var domain = await _attachmentsRepository.GetAllAttachmentsAsync();
             return Ok(_mapper.Map<List<PatientAttachmentsDTO>>(domain));         
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{PatientId:int}")]
        public async Task<IActionResult> GetAttachmentsByPatientIdAsync(int PatientId)
        {
            if (PatientId <=0)
            {
                return BadRequest("Patient id cannot be null");
            }
            var domain = await _attachmentsRepository.GetAttachmentsByPatientIdAsync(PatientId);
            if (domain == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<PatientAttachmentsDTO>>(domain));

        }

       /// <summary>
       /// if you wan to just store filepath. we could create a byte filed in DB and store files. 
       /// </summary>
       /// <param name="PatientAttachmentsDTO"></param>
       /// <returns></returns>
        [HttpPost("Upload")]
        public async Task<IActionResult> CreateAttachmentsAsync(PatientAttachmentsDTO PatientAttachmentsDTO)
        {
            if (PatientAttachmentsDTO.FileName == null || PatientAttachmentsDTO.FileName.Length == 0)
            {
                return BadRequest("No File Uploaded");
                    
            }
            using var memorytream = new MemoryStream();
            await PatientAttachmentsDTO.FormFile.CopyToAsync(memorytream);
            var filedata = memorytream.ToArray();
           
            //Map DTO to domain model
            var domain = _mapper.Map<PatientAttachments>(PatientAttachmentsDTO);
            var attachments = await _attachmentsRepository.CreateAttachmentsAsync(domain);
            var DTO = _mapper.Map<PatientAttachmentsDTO>(attachments);
            return Ok(DTO);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AttachmentID"></param>
        /// <param name="PatientAttachmentsDTO"></param>
        /// <returns></returns>
        [HttpPut("{MedicalHistoryID:int}")]
        public async Task<IActionResult> UpdateAttachmentsAsync(int AttachmentID, PatientAttachmentsDTO PatientAttachmentsDTO)
        {
            // map here
            var domain = _mapper.Map<PatientAttachments>(PatientAttachmentsDTO);
            //  update
            domain = await _attachmentsRepository.UpdateAttachmentsAsync(AttachmentID, domain);
            if (domain == null)
            {
                return NotFound();
            }

            var DTO = _mapper.Map<PatientAttachmentsDTO>(domain);
            return Ok(DTO);
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteAttachmentsAsync(int AttachmentID)
        {
            var domain = await _attachmentsRepository.DeleteAttachmentsAsync(AttachmentID);

            if (domain == null)
            {
                return NotFound();
            }

            var DTO = _mapper.Map<PatientAttachmentsDTO>(domain);
            return Ok(DTO);
        }




    }
}

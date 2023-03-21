using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Contracts;
using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA2ApiNET6._1_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {
        private readonly ILogger<SpecialistController> _logger;
        private readonly ISpecialistService _specialistService;

        public SpecialistController(ILogger<SpecialistController> logger, ISpecialistService specialistService)
        {
            _logger = logger;
            _specialistService = specialistService;
        }

        [HttpGet("getSpecialists")]
        public ActionResult<List<SpecialistDto>> GetSpecialists()
        {
            try
            {
                List<SpecialistDto> specialists = _specialistService.GetSpecialistDtoList();
                if (specialists.Count > 0)
                {
                    _logger.LogWarning("Method GetSpecialists invoked.");
                    return Ok(specialists);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }

        }

        [HttpGet("Getspecialist")]
        public ActionResult<SpecialistDto> GetSpecialist(int id)
        {
            try
            {
                SpecialistDto specialistDto = _specialistService.GetSpecialistDto(id);
                if (specialistDto == null)
                {
                    return BadRequest("Error");
                }
                else
                {
                    return Ok(specialistDto);
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("add")]
        public ActionResult AddSpecialist(SpecialistDto specialist)
        {
            try
            {
                bool SpecialistStatus = _specialistService.AddSpecialistDto(specialist);
                if (SpecialistStatus)
                {
                    return Ok("Specialist added");
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }
        }
    }
}


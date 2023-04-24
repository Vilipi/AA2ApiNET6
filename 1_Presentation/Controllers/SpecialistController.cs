using AA2ApiNet6.Mapper;
using AA2ApiNet6.Models;
using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Contracts;
using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA2ApiNET6._1_Presentation.Controllers
{

    //add-migration migration1
    //update-database


    [Route("aa2")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {
        private readonly ILogger<SpecialistController> _logger;
        private readonly ISpecialistService _specialistService;
        private readonly ISpecialistInputToDto _specialistInputToDto;

        public SpecialistController(ILogger<SpecialistController> logger, ISpecialistService specialistService, ISpecialistInputToDto specialistInputToDto)
        {
            _logger = logger;
            _specialistService = specialistService;
            _specialistInputToDto = specialistInputToDto;
        }

        [HttpGet("Specialists")]
        public ActionResult<List<SpecialistBasicInfo>> GetSpecialists()
        {
            try
            {
                List<SpecialistBasicInfo> specialists = _specialistService.GetSpecialistBasicInfoList();
                if (specialists.Count > 0)
                {
                    _logger.LogWarning("Method GetSpecialists invoked.");
                    return Ok(specialists);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }

        }

        [Authorize]
        [HttpGet("Specialist/{id}")]
        public ActionResult<SpecialistDto> GetSpecialist(int id)
        {
            try
            {
                string specialistIdValidated = HttpContext.User.Identity.Name;

                if(id == Int32.Parse(specialistIdValidated))
                {
                    SpecialistDto specialistDto = _specialistService.GetSpecialistDto(id);
                    if (specialistDto == null || specialistDto.Name == null)
                    {
                        return BadRequest("Error");
                    }
                    else
                    {
                        return Ok(specialistDto);
                    }
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

        [HttpPost("/AUTH/REGISTER")]
        public ActionResult AddSpecialist(SpecialistInputModel specialistInput)
        {
            try
            {
                _logger.LogWarning($"Method AddSpecialist invoked.");
                var specialistDto = _specialistInputToDto.mapSpecialistInputToDto(specialistInput);
                bool SpecialistStatus = _specialistService.AddSpecialistDto(specialistDto);
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

        [Authorize]
        [HttpDelete("Specialist/{id}")]
        public ActionResult DeleteSpecialist(int id)
        {
            try
            {
                _logger.LogWarning($"Method deleteSpecialist invoked.");

                string specialistIdValidated = HttpContext.User.Identity.Name;
                if (id == Int32.Parse(specialistIdValidated))
                {
                    var deletedSpecialist = _specialistService.DeleteSpecialistDto(id);
                    if (deletedSpecialist)
                    {
                        return Ok("Specialist removed");
                    }
                    else
                    {
                        return NotFound("This Specialist does not exist");
                    }
                } else
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

        [Authorize]
        [HttpPut("Specialist/{id}")]
        public ActionResult UpdateSpecialist(int id, SpecialistInputModel specialistInput)
        {
            try
            {
                _logger.LogWarning("Method UpdateSpecialist invoked.");

                string specialistIdValidated = HttpContext.User.Identity.Name;
                if (id == Int32.Parse(specialistIdValidated))
                {
                    var specialistDto = _specialistInputToDto.mapSpecialistInputToDto(specialistInput);

                    var specilaistUpdatedto = _specialistService.UpdateSpecialistDto(id, specialistDto);
                    if (specilaistUpdatedto.Id > 1)
                    {
                        return Ok("Specilaist updated.");

                    }
                    else
                    {
                        return BadRequest("Error");
                    }
                } else 
                {
                    return BadRequest("Error");
                }
                
            } 
            catch(Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }   
        }
    }
}


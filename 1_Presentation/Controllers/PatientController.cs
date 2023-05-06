using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Contracts;
using AA2ApiNet6.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AA2ApiNET6._1_Presentation.Mapper;
using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Models;
using AA2ApiNET6._2_Domain.ServiceLibrary.Impl.Impl;
using AA2ApiNet6.Models;
using AA2ApiNET6._1_Presentation.Models;
using Microsoft.AspNetCore.Authorization;

namespace AA2ApiNET6._1_Presentation.Controllers
{
    [Route("aa2")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patienttService;
        private readonly IPatientInputToDto _patientInputToDto;

        public PatientController(ILogger<PatientController> logger, IPatientService patientService, IPatientInputToDto patientInputToDto)
        {
            _logger = logger;
            _patienttService = patientService;
            _patientInputToDto = patientInputToDto;
        }

        [HttpGet("Patients")]
        public ActionResult<List<PatientDto>> GetPatients()
        {
            try
            {
                List<PatientDto> patients = _patienttService.GetPatientsDto();
                if (patients.Count > 0)
                {
                    _logger.LogWarning("Method GetPatients invoked.");
                    return Ok(patients);
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

        [HttpGet("Patient/{id}")]
        public ActionResult<PatientDto> GetPatient(int id)
        {
            try
            {
                //string specialistIdValidated = HttpContext.User.Identity.Name;

                PatientDto patientDto = _patienttService.GetPatientDto(id);
                if (patientDto == null || patientDto.Name == null)
                {
                    return BadRequest("Error");
                }
                else
                {
                    return Ok(patientDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("/Patient/AUTH/REGISTER")]
        public ActionResult AddPatient(PatientInputModel patientInputModel)
        {
            try
            {
                _logger.LogWarning($"Method AddSpecialist invoked.");
                var patientDto = _patientInputToDto.mapPatientInputToDto(patientInputModel);
                bool patientStatus = _patienttService.AddPatientDto(patientDto);
                if (patientStatus)
                {
                    return Ok("Patient added");
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

        [HttpDelete("Patient/{id}")]
        public ActionResult DeletePatient(int id)
        {
            try
            {
                _logger.LogWarning($"Method DeletePatient invoked.");
                {
                    var deletedPatient = _patienttService.DeletePatientDto(id);
                    if (deletedPatient)
                    {
                        return Ok("Patient removed");
                    }
                    else
                    {
                        return NotFound("This Patient does not exist");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("Patient/{id}")]
        public ActionResult UpdatePatient(int id, PatientInputModel patientInput)
        {
            try
            {
                _logger.LogWarning("Method UpdatePatient invoked.");

                {
                    var patientDto = _patientInputToDto.mapPatientInputToDto(patientInput);

                    var patientUpdatedto = _patienttService.UpdatePatientDto(id, patientDto);
                    if (patientUpdatedto.Id > 1)
                    {
                        return Ok("Patient updated.");

                    }
                    else
                    {
                        return BadRequest("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }
        }

        // ver todos los apointments
        // ver appintments selecionado
        // crear appointment(patient, specialist)

        //specialist
        //editar appointments

    }
}

using AA2ApiNET6._2_Domain.Infrastructure.Contracts.Contracts;
using AA2ApiNET6._2_Domain.Infrastructure.Contracts.Models;
using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Contracts;
using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Models;
using AA2ApiNET6._2_Domain.ServiceLibrary.Impl.Mapper;
using AA2ApiNET6._3_Infrastructure.Infrastructure.Impl.Impl;

namespace AA2ApiNET6._2_Domain.ServiceLibrary.Impl.Impl
{
    public class PatientService : IPatientService
    {
        private readonly ILogger<PatientService> _logger;
        private readonly IPatientRepository _patientRepository;
        private readonly IPatientRepositoryModelToDto _patientRepositoryModelToDto;

        public PatientService(ILogger<PatientService> logger, IPatientRepository patientRepository, IPatientRepositoryModelToDto patientRepositoryModelToDto)
        {
            _logger = logger;
            _patientRepository = patientRepository;
            _patientRepositoryModelToDto = patientRepositoryModelToDto;
        }

        public bool AddPatientDto(PatientDto patienttDto)
        {
            PatientRepositoryModel patientRepository = new PatientRepositoryModel();
            //patientRepository.Id = patienttDto.Id;
            patientRepository.Name = patienttDto.Name;
            patientRepository.LastName = patienttDto.LastName;
            patientRepository.Gender = patienttDto.Gender;
            patientRepository.BirthDate = patienttDto.BirthDate;
            patientRepository.IsUnderage = patienttDto.IsUnderage;
            patientRepository.isActive = patienttDto.isActive;
            patientRepository.Password = patienttDto.Password;
            patientRepository.Email = patienttDto.Email;

            bool specialistAdded = _patientRepository.AddPatient(patientRepository);

            if (specialistAdded == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeletePatientDto(int id)
        {
            try
            {
                bool patientDeleted = _patientRepository.DeletePatient(id);
                if (patientDeleted == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return false;
            }
        }

        public PatientDto GetPatientDto(int id)
        {
            try
            {
                var singleSpecialistRepository = _patientRepository.GetSinglePatient(id);

                if (singleSpecialistRepository == null)
                {
                    return new PatientDto();
                }
                else
                {
                    var patientDto = _patientRepositoryModelToDto.mapPatientRepositoryModelToDto(singleSpecialistRepository);


                    return patientDto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new PatientDto();
            }
        }

        public List<PatientDto> GetPatientsDto()
        {
            try
            {
                List<PatientRepositoryModel> patientsRepository = _patientRepository.GetPatients();
                if (patientsRepository.Count == 0)
                {
                    List<PatientDto> emptyPatientsDto = new List<PatientDto>();
                    return emptyPatientsDto;
                }
                else
                {
                    var patientsDto = new List<PatientDto>();
                    foreach (var patient in patientsRepository)
                    {
                        var patientDto = _patientRepositoryModelToDto.mapPatientRepositoryModelToDto(patient);
                        patientsDto.Add(patientDto);
                    }
                    return patientsDto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new List<PatientDto>();
            }
        }

        public PatientDto UpdatePatientDto(int id, PatientDto patientDto)
        {
            try
            {
                var patientRepository = new PatientRepositoryModel();
                patientRepository.Name = patientDto.Name;
                patientRepository.LastName = patientDto.LastName;
                patientRepository.Gender = patientDto.Gender;
                patientRepository.BirthDate = patientDto.BirthDate;
                patientRepository.IsUnderage = patientDto.IsUnderage;
                patientRepository.isActive = patientDto.isActive;
                patientRepository.Password = patientDto.Password;
                patientRepository.Email = patientDto.Email;

                var patienttRepos = _patientRepository.UpdatePatient(id, patientRepository);
                var patientDtoChanged = _patientRepositoryModelToDto.mapPatientRepositoryModelToDto(patienttRepos);
                if (patientDtoChanged.Id < 1)
                {
                    return new PatientDto();
                }
                else
                {
                    return patientDtoChanged;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new PatientDto();
            }
        }
    }
}

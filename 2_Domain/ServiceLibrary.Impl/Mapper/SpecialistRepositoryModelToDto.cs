using AA2ApiNet6.Mapper;
using AA2ApiNET6._2_Domain.Infrastructure.Contracts.Models;
using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Models;

namespace AA2ApiNET6._2_Domain.ServiceLibrary.Impl.Mapper
{
    public class SpecialistRepositoryModelToDto : ISpecialistRepositoryModelToDto
    {
        private readonly ILogger<SpecialistRepositoryModelToDto> _logger;
        public SpecialistRepositoryModelToDto(ILogger<SpecialistRepositoryModelToDto> logger)
        {
            _logger = logger;
        }
        public SpecialistDto mapSpecialistRepositoryModelToDto(SpecialistRepositoryModel repositoryModel)
        {
            try
            {
                var specialistDto = new SpecialistDto();
                specialistDto.Id= repositoryModel.Id;
                specialistDto.Name = repositoryModel.Name;
                specialistDto.LastName = repositoryModel.LastName;
                specialistDto.IsRetired = repositoryModel.IsRetired;
                specialistDto.Rating = repositoryModel.Rating;
                specialistDto.BirthDate = repositoryModel.BirthDate;
                specialistDto.Speciality = repositoryModel.Speciality;
                specialistDto.Email = repositoryModel.Email;
                specialistDto.Password = repositoryModel.Password;

                return specialistDto;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new SpecialistDto();
            }
        }
    }
}

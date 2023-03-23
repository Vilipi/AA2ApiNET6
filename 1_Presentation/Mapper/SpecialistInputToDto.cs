using AA2ApiNet6.Models;
using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Models;

namespace AA2ApiNet6.Mapper
{
    public class SpecialistInputToDto : ISpecialistInputToDto
    {
        public SpecialistDto mapSpecialistInputToDto(SpecialistInputModel input)
        {
            var specialistDto = new SpecialistDto();
            specialistDto.Name = input.Name;
            specialistDto.LastName = input.LastName;
            specialistDto.IsRetired = bool.Parse(input.IsRetired);
            specialistDto.Rating = input.Rating.Contains('.') ? decimal.Parse(input.Rating.Replace('.', ',')) : decimal.Parse(input.Rating);
            specialistDto.BirthDate = DateTime.Parse(input.BirthDate);  
            specialistDto.Speciality = input.Speciality;
            specialistDto.UserName = input.UserName;
            specialistDto.Password = input.Password;

            return specialistDto;
        }
    }
}

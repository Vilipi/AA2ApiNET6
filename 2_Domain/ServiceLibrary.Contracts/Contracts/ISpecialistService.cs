using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Models;

namespace AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Contracts
{
    public interface ISpecialistService
    {
        bool AddSpecialistDto(SpecialistDto specialistDto);
        bool DeleteSpecialistDto(int id);
        SpecialistDto GetSpecialistDto(int id);
        List<SpecialistDto> GetSpecialistDtoList();
        SpecialistDto UpdateSpecialistDto(int id, SpecialistDto specialistDto);
    }
}


using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Models;
using AA2ApiNet6.Models;

namespace AA2ApiNet6.Mapper
{
    public interface ISpecialistInputToDto
    {
        SpecialistDto mapSpecialistInputToDto(SpecialistInputModel input);
    }
}

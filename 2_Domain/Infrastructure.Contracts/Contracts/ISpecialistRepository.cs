using AA2ApiNET6._2_Domain.Infrastructure.Contracts.Models;

namespace AA2ApiNET6._2_Domain.Infrastructure.Contracts.Contracts
{
    public interface ISpecialistRepository
    {
            List<SpecialistRepositoryModel> GetSpecialists();
            bool AddSpecialist(SpecialistRepositoryModel specialist);
            SpecialistRepositoryModel GetSingleSpecialist(int id);
            bool DeleteSpecialist(int id);
            SpecialistRepositoryModel UpdateSpecialist(int id, SpecialistRepositoryModel specialist);
    }
}

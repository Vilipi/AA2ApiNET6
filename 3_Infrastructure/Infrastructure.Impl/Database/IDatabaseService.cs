using AA2ApiNET6._2_Domain.Infrastructure.Contracts.Models;

namespace AA2ApiNET6._3_Infrastructure.Infrastructure.Impl.Data
{
    public interface IDataBaseService
    {
        List<SpecialistRepositoryModel> GetSPecialistsDb();
        bool AddSpecialistDb(SpecialistRepositoryModel specialist);
        SpecialistRepositoryModel GetSingleSpecialistDb(int id);
        SpecialistRepositoryModel UpdateSpecialistDb(int id, SpecialistRepositoryModel specialist);
        bool DeleteSpecialistDb(int id);
    }
}

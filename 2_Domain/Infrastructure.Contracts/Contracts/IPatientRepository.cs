using AA2ApiNET6._2_Domain.Infrastructure.Contracts.Models;

namespace AA2ApiNET6._2_Domain.Infrastructure.Contracts.Contracts
{
    public interface IPatientRepository
    {
        List<PatientRepositoryModel> GetPatients();
        bool AddPatient(PatientRepositoryModel patient);
        PatientRepositoryModel GetSinglePatient(int id);
        bool DeletePatient(int id);
        PatientRepositoryModel UpdatePatient(int id, PatientRepositoryModel patient);
    }
}

using AA2ApiNET6._2_Domain.Infrastructure.Contracts.Models;

namespace AA2ApiNET6._3_Infrastructure.Infrastructure.Impl.Data
{
    public interface IDataBaseService
    {
        //Specialist
        List<SpecialistRepositoryModel> GetSPecialistsDb();
        bool AddSpecialistDb(SpecialistRepositoryModel specialist);
        SpecialistRepositoryModel GetSingleSpecialistDb(int id);
        SpecialistRepositoryModel UpdateSpecialistDb(int id, SpecialistRepositoryModel specialist);
        bool DeleteSpecialistDb(int id);

        //Patient
        List<PatientRepositoryModel> GetPatientsDb();
        bool AddPatienttDb(PatientRepositoryModel patient);
        PatientRepositoryModel GetSinglePatientDb(int id);
        PatientRepositoryModel UpdatePatientDb(int id, PatientRepositoryModel patient);
        bool DeletePatientDb(int id);

        //Appointment
        List<AppointmentRepositoryModel> GetAppointmentsDb();
        bool AddAppointmentDb(AppointmentRepositoryModel appointment);
        AppointmentRepositoryModel GetSingleAppointmentDb(int id);
        AppointmentRepositoryModel UpdateAppointmentDb(int id, AppointmentRepositoryModel appointment);
        bool DeleteAppointmentDb(int id);
    }
}

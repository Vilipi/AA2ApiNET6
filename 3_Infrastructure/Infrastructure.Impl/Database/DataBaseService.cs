﻿using AA2ApiNET6._2_Domain.Infrastructure.Contracts.Models;
using AA2ApiNET6._3_Infrastructure.Infrastructure.Impl.Data;

namespace AA2ApiNET6._3_Infrastructure.Infrastructure.Impl.Database
{
    public class DataBaseService : IDataBaseService
    {
        private readonly ILogger<DataBaseService> _logger;

        private readonly DataContext _dataContext;

        public DataBaseService(ILogger<DataBaseService> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

       
        //Specialist
        public bool AddSpecialistDb(SpecialistRepositoryModel specialist)
        {
            try
            {
                var existingSpecialist = _dataContext.Specialists.Where(x => x.Id == specialist.Id).FirstOrDefault();
                var existingSpecialistEmail = _dataContext.Specialists.Where(x => x.Email == specialist.Email).FirstOrDefault();

                if (existingSpecialist != null || existingSpecialistEmail != null)
                {
                    return false;
                }
                else
                {
                    _dataContext.Specialists.Add(specialist);
                    _dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return false;
            }
        }

        public bool DeleteSpecialistDb(int id)
        {
            try
            {
                SpecialistRepositoryModel deleteSpecialistRepository = _dataContext.Specialists.Where(e => e.Id == id).FirstOrDefault();
                if (deleteSpecialistRepository == null)
                {
                    return false;
                }
                else
                {
                    _dataContext.Specialists.Remove(deleteSpecialistRepository);
                    _dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return false;
            }
        }

        public SpecialistRepositoryModel GetSingleSpecialistDb(int id)
        {
            try
            {
                SpecialistRepositoryModel singleSpecialistRepository = _dataContext.Specialists?.Where(e => e.Id == id).FirstOrDefault();
                if (singleSpecialistRepository == null)
                {
                    return new SpecialistRepositoryModel();
                }
                else
                {
                    return singleSpecialistRepository;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new SpecialistRepositoryModel();
            }
        }

        public List<SpecialistRepositoryModel> GetSPecialistsDb()
        {
            try
            {
                return _dataContext.Specialists.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new List<SpecialistRepositoryModel>();
            }
        }

        public SpecialistRepositoryModel UpdateSpecialistDb(int id, SpecialistRepositoryModel specialist)
        {
            try
            {
                SpecialistRepositoryModel updateSpecialistRepository = _dataContext.Specialists?.Where(e => e.Id == id).FirstOrDefault();
                SpecialistRepositoryModel updateSpecialistRepositoryEmail = _dataContext.Specialists?.Where(e => e.Email == specialist.Email).FirstOrDefault();

                if (updateSpecialistRepository.Id == null || updateSpecialistRepositoryEmail != null && updateSpecialistRepositoryEmail.Id != updateSpecialistRepository.Id)
                {
                    return new SpecialistRepositoryModel();
                }
                else
                {
                    updateSpecialistRepository.Id = id;
                    updateSpecialistRepository.Name = specialist.Name;
                    updateSpecialistRepository.LastName = specialist.LastName;
                    updateSpecialistRepository.IsRetired = specialist.IsRetired;
                    updateSpecialistRepository.Rating = specialist.Rating;
                    updateSpecialistRepository.BirthDate = specialist.BirthDate;
                    updateSpecialistRepository.Speciality = specialist.Speciality;
                    updateSpecialistRepository.Email = specialist.Email;
                    updateSpecialistRepository.Password = specialist.Password;

                    _dataContext.SaveChanges();
                    return updateSpecialistRepository;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new SpecialistRepositoryModel();
            }
        }

        
        //Patient
        public bool AddPatienttDb(PatientRepositoryModel patient)
        {
            try
            {
                var existingPatient = _dataContext.Patients.Where(x => x.Id == patient.Id).FirstOrDefault();
                var existingPatientEmail = _dataContext.Patients.Where(x => x.Email == patient.Email).FirstOrDefault();

                if (existingPatient != null || existingPatientEmail != null)
                {
                    return false;
                }
                else
                {
                    patient.isActive = true;
                    _dataContext.Patients.Add(patient);
                    _dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return false;
            }
        }
        public bool DeletePatientDb(int id)
        {
            try
            {
                var deletePatientRepository = _dataContext.Patients.Where(e => e.Id == id).FirstOrDefault();
                if (deletePatientRepository == null)
                {
                    return false;
                }
                else
                {
                    deletePatientRepository.isActive = false;
                    _dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return false;
            }
        }
        public PatientRepositoryModel GetSinglePatientDb(int id)
        {
            try
            {
                var singlePatientRepository = _dataContext.Patients?.Where(e => e.Id == id).FirstOrDefault();
                if (singlePatientRepository == null)
                {
                    return new PatientRepositoryModel();
                }
                else
                {
                    return singlePatientRepository;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new PatientRepositoryModel();
            }
        }
        public List<PatientRepositoryModel> GetPatientsDb()
        {
            try
            {
                return _dataContext.Patients.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new List<PatientRepositoryModel>();
            }
        }
        public PatientRepositoryModel UpdatePatientDb(int id, PatientRepositoryModel patient)
        {
            try
            {
                PatientRepositoryModel updatePatientRepository = _dataContext.Patients?.Where(e => e.Id == id).FirstOrDefault();
                PatientRepositoryModel updatePatientRepositoryEmail = _dataContext.Patients?.Where(e => e.Email == patient.Email).FirstOrDefault();

                if (updatePatientRepository.Id == null || updatePatientRepositoryEmail != null && updatePatientRepositoryEmail.Id != updatePatientRepository.Id)
                {
                    return new PatientRepositoryModel();
                }
                else
                {
                    updatePatientRepository.Id = id;
                    updatePatientRepository.Name = patient.Name;
                    updatePatientRepository.LastName = patient.LastName;
                    updatePatientRepository.Gender = patient.Gender;
                    updatePatientRepository.BirthDate = patient.BirthDate;
                    updatePatientRepository.IsUnderage = patient.IsUnderage;
                    updatePatientRepository.Email = patient.Email;
                    updatePatientRepository.Password = patient.Password;

                    _dataContext.SaveChanges();
                    return updatePatientRepository;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new PatientRepositoryModel();
            }
        }

        
        //Appointment
        public bool AddAppointmentDb(AppointmentRepositoryModel appointment)
        {
            try
            {
                var existingAppointment = _dataContext.Patients.Where(x => x.Id == appointment.Id).FirstOrDefault();

                if (existingAppointment != null)
                {
                    return false;
                }
                else
                {
                    _dataContext.Appointments.Add(appointment);
                    _dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return false;
            }
        }
        public bool DeleteAppointmentDb(int id)
        {
            try
            {
                var deleteAppointmentRepository = _dataContext.Appointments.Where(e => e.Id == id).FirstOrDefault();
                if (deleteAppointmentRepository == null)
                {
                    return false;
                }
                else
                {
                    deleteAppointmentRepository.IsCompleted = true;
                    _dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return false;
            }
        }
        public AppointmentRepositoryModel GetSingleAppointmentDb(int id)
        {
            try
            {
                var singleAppointmentRepository = _dataContext.Appointments?.Where(e => e.Id == id).FirstOrDefault();
                if (singleAppointmentRepository == null)
                {
                    return new AppointmentRepositoryModel();
                }
                else
                {
                    return singleAppointmentRepository;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new AppointmentRepositoryModel();
            }
        }
        public List<AppointmentRepositoryModel> GetAppointmentsDb()
        {
            try
            {
                return _dataContext.Appointments.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new List<AppointmentRepositoryModel>();
            }
        }

        public AppointmentRepositoryModel UpdateAppointmentDb(int id, AppointmentRepositoryModel appointment)
        {
            try
            {
                AppointmentRepositoryModel updatePatientRepository = _dataContext.Appointments?.Where(e => e.Id == id).FirstOrDefault();

                if (updatePatientRepository.Id == null)
                {
                    return new AppointmentRepositoryModel();
                }
                else
                {
                    updatePatientRepository.Id = id;
                    updatePatientRepository.Name = appointment.Name;
                    updatePatientRepository.AppointmentCreationDate = appointment.AppointmentCreationDate;
                    updatePatientRepository.IsCompleted = appointment.IsCompleted;
                    updatePatientRepository.Price = appointment.Price;
                    updatePatientRepository.SpecialistComment = appointment.SpecialistComment;

                    _dataContext.SaveChanges();
                    return updatePatientRepository;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new AppointmentRepositoryModel();
            }
        }
    }
}

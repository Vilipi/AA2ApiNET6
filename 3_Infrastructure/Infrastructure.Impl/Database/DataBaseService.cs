using AA2ApiNET6._2_Domain.Infrastructure.Contracts.Models;
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
                    updateSpecialistRepository.Id= id;
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
    }
}

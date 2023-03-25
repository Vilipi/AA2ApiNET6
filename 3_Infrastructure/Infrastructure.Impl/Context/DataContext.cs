using AA2ApiNET6._2_Domain.Infrastructure.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace AA2ApiNET6._3_Infrastructure.Infrastructure.Impl.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<SpecialistRepositoryModel>? Specialists { get; set; }

    }
}

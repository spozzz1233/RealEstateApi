using Microsoft.EntityFrameworkCore;
using Web.DataAccess;
using Web.Models;

namespace Web.Data
{
    public class SDbContext : DbContext
    {

        public DbSet<Agents> Agents { get; set; }
        public DbSet<Trades> Trades { get; set; }
        public DbSet<RealEstates> RealEstates { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Owners> Owners { get; set; }
        public DbSet<Customers> Customers { get; set; }


        public SDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Код выполняет конфигурацию модели данных для создания базы данных.
            base.OnModelCreating(modelBuilder);
            //Метод ApplyConfiguration() применяет указанную конфигурацию для соответствующей сущности модели данных.
            //Это позволяет настроить свойства каждой сущности, установить соответствующие ограничения, реализовать связи между сущностями и др.
            modelBuilder.ApplyConfiguration(new AddressesMap());
            modelBuilder.ApplyConfiguration(new AgentsMap());
            modelBuilder.ApplyConfiguration(new CustomersMap());
            modelBuilder.ApplyConfiguration(new OwnersMap());
            modelBuilder.ApplyConfiguration(new RealEstatesMap());
            modelBuilder.ApplyConfiguration(new TradesMap());

        }

    }
}

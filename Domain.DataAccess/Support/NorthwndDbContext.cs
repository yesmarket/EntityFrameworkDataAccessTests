using System.Data.Entity;
using Domain.DataAccess.Contracts.Model;
using Domain.DataAccess.Support.Mappings;

namespace Domain.DataAccess.Support
{
    public class NorthwndDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

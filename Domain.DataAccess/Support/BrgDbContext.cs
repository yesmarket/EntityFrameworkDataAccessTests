using System.Data.Common;
using System.Data.Entity;
using Domain.DataAccess.Contracts.Model;
using Domain.DataAccess.Support.Mappings;

namespace Domain.DataAccess.Support
{
    public class BrgDbContext : DbContext
    {
        public BrgDbContext()
        {
        }

        public BrgDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public BrgDbContext(DbConnection existingConnection)
            : base(existingConnection, false)
        {
        }

        public DbSet<Rule> Rules { get; set; }
        public DbSet<RuleProperty> RuleProperties { get; set; }
        public DbSet<vRuleProperty> vRuleProperties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RuleMap());
            modelBuilder.Configurations.Add(new RulePropertyMap());
            modelBuilder.Configurations.Add(new vRulePropertyMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
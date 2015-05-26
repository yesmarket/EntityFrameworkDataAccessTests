using System.Data.Entity.ModelConfiguration;
using Domain.DataAccess.Contracts.Model;

namespace Domain.DataAccess.Support.Mappings
{
    public class RuleMap : EntityTypeConfiguration<Rule>
    {
        public RuleMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.ShortName)
                .HasMaxLength(20);

            // Table & Column Mappings
            ToTable("brg_rule");
            Property(t => t.Id).HasColumnName("id");
            Property(t => t.Description).HasColumnName("description");
            Property(t => t.ShortName).HasColumnName("shortName");
            Property(t => t.IsPropertiesPage).HasColumnName("propertiesPage");
        }
    }
}
using System.Data.Entity.ModelConfiguration;
using Domain.DataAccess.Contracts.Model;

namespace Domain.DataAccess.Support.Mappings
{
    public class RulePropertyMap : EntityTypeConfiguration<RuleProperty>
    {
        public RulePropertyMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.PropertyName)
                .HasMaxLength(50);

            Property(t => t.PropertyValue)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("brg_rule_properties");
            Property(t => t.Id).HasColumnName("id");
            Property(t => t.brg_rule_id).HasColumnName("brg_rule_id");
            Property(t => t.PropertyName).HasColumnName("property_name");
            Property(t => t.PropertyValue).HasColumnName("property_value");
            Property(t => t.DateTime).HasColumnName("datetime");
            Property(t => t.Description).HasColumnName("Description");
        }
    }
}
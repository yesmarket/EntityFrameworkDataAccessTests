using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.DataAccess.Contracts.Model;

namespace Domain.DataAccess.Support.Mappings
{
    public class vRulePropertyMap : EntityTypeConfiguration<vRuleProperty>
    {
        public vRulePropertyMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.PropertyName)
                .HasMaxLength(50);

            Property(t => t.PropertyValue)
                .HasMaxLength(50);

            Property(t => t.ShortName)
                .HasMaxLength(20);

            // Table & Column Mappings
            ToTable("vbrg_rule_properties");
            Property(t => t.Id).HasColumnName("id");
            Property(t => t.brg_rule_id).HasColumnName("brg_rule_id");
            Property(t => t.PropertyName).HasColumnName("property_name");
            Property(t => t.PropertyValue).HasColumnName("property_value");
            Property(t => t.DateTime).HasColumnName("datetime");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.ShortName).HasColumnName("shortName");
        }
    }
}
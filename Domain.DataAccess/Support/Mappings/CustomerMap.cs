using System.Data.Entity.ModelConfiguration;
using Domain.DataAccess.Contracts.Model;

namespace Domain.DataAccess.Support.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            HasKey(customer => customer.CustomerID);
            Property(_ => _.Country).HasMaxLength(15);
            Property(_ => _.Phone).HasMaxLength(24);
            Property(_ => _.Fax).HasMaxLength(24);
        }
    }
}
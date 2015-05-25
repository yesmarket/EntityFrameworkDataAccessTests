using System.Collections.Generic;
using Domain.DataAccess.Contracts.Model;

namespace Domain.DataAccess.Contracts.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomerByName(string name);
    }
}

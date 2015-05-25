using System.Collections.Generic;
using System.Linq;
using Domain.DataAccess.Contracts.Model;
using Domain.DataAccess.Contracts.Repository;
using Domain.DataAccess.Support;

namespace Domain.DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContextFactory _dbContextFactory;

        public CustomerRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<Customer> GetCustomerByName(string name)
        {
            List<Customer> customers;
            using (var dbContext = _dbContextFactory.GetContext())
            {
                customers = dbContext.Customers.Where(c => c.ContactName == "Ryan").ToList();
            }
            return customers;
        }
    }
}
using System;
using System.Data.Entity;
using System.Linq;
using Domain.DataAccess;
using Domain.DataAccess.Migrations;
using Domain.DataAccess.Repository;
using Domain.DataAccess.Support;

namespace Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NorthwndDbContext, Configuration>());
            var customerRepository = new CustomerRepository(new DbContextFactory());
            var customers = customerRepository.GetCustomerByName("Ryan");
            Console.WriteLine(customers.FirstOrDefault());
        }
    }
}

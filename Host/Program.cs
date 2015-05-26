using System;
using Domain.DataAccess.Repository;
using Domain.DataAccess.Support;

namespace Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BrgDbContext, Configuration>());
            var coefficientRepository = new CoefficientRepository(new DbContextFactory());
            var coefficients = coefficientRepository.GetCoefficientByShortName("ARG");
            foreach (var coefficient in coefficients)
            {
                Console.WriteLine("{0}={1}", coefficient.PropertyName, coefficient.PropertyValue);
            }
        }
    }
}

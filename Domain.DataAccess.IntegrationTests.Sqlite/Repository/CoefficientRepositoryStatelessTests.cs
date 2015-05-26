using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Domain.DataAccess.Contracts.Model;
using Domain.DataAccess.IntegrationTests.Sqlite.Support;
using Domain.DataAccess.Repository;
using Domain.DataAccess.Support;
using NSubstitute;
using Ploeh.AutoFixture;
using SharpTestsEx;
using Xunit;

namespace Domain.DataAccess.IntegrationTests.Sqlite.Repository
{
    public class CoefficientRepositoryStatelessTests : IUseFixture<object>
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly CoefficientRepository _sut;
        private BrgDbContext _dbContext;

        public CoefficientRepositoryStatelessTests()
        {
            _dbContextFactory = Substitute.For<IDbContextFactory>();
            _sut = new CoefficientRepository(_dbContextFactory);
        }

        public void SetFixture(object data)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data"));

            if (_dbContext != null)
                _dbContext.Dispose();

            _dbContext = new BrgDbContext("stateless");
            _dbContext.Database.Connection.Open();

            Database.SetInitializer(new SqliteDatabaseInitializerFromSql());
            _dbContext.Database.Initialize(true);

            _dbContextFactory.GetContext().Returns(_dbContext);
        }

        [Fact]
        public void GetCoefficientByShortName_MatchingShortName_ReturnsCorrectNumberOfResults()
        {
            CreateRuleProperties(10);
            CreateRuleProperties(1, "ARG");

            var coefficients = _sut.GetCoefficientByShortName("ARG");
            coefficients.Count().Should().Be.EqualTo(1);
        }

        [Fact]
        public void GetCoefficientByShortName_NoMatchingShortName_ReturnsCorrectNumberOfResults()
        {
            CreateRuleProperties(10);

            var coefficients = _sut.GetCoefficientByShortName("XXX");
            coefficients.Count().Should().Be.EqualTo(0);
        }

        private void CreateRuleProperties(int number, string shortName = null)
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new vRulePropertySpecimenBuilder(shortName));
            var vRuleProperties = fixture.CreateMany<vRuleProperty>(number);
            _dbContext.vRuleProperties.AddRange(vRuleProperties);
            _dbContext.SaveChanges();
        }
    }
}
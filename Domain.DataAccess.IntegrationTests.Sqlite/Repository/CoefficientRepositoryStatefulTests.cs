using System;
using System.IO;
using System.Linq;
using Domain.DataAccess.Repository;
using Domain.DataAccess.Support;
using NSubstitute;
using SharpTestsEx;
using Xunit;

namespace Domain.DataAccess.IntegrationTests.Sqlite.Repository
{
    public class CoefficientRepositoryStatefulTests : IUseFixture<object>
    {
        private readonly CoefficientRepository _sut;
        private readonly IDbContextFactory _dbContextFactory;
        private BrgDbContext _dbContext;

        public CoefficientRepositoryStatefulTests()
        {
            _dbContextFactory = Substitute.For<IDbContextFactory>();
            _sut = new CoefficientRepository(_dbContextFactory);
        }

        public void SetFixture(object data)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data"));
            if (_dbContext != null)
                _dbContext.Dispose();
            _dbContext = new BrgDbContext("stateful");
            _dbContextFactory.GetContext().Returns(_dbContext);
        }

        [Fact]
        public void GetCoefficientByShortName_MatchingShortName_ReturnsCorrectNumberOfResults()
        {
            var coefficients = _sut.GetCoefficientByShortName("ARG");
            coefficients.Count().Should().Be.EqualTo(1);
        }

        [Fact]
        public void GetCoefficientByShortName_NoMatchingShortName_ReturnsCorrectNumberOfResults()
        {
            var coefficients = _sut.GetCoefficientByShortName("XXX");
            coefficients.Count().Should().Be.EqualTo(0);
        }
    }
}

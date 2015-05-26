using System;
using System.Threading;
using Domain.DataAccess.Contracts.Model;
using Domain.DataAccess.IntegrationTests.Sqlite.Support.Extensions;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

namespace Domain.DataAccess.IntegrationTests.Sqlite.Support
{
    public class vRulePropertySpecimenBuilder : ISpecimenBuilder
    {
        private readonly string _shortName;
        private static int _id;

        public vRulePropertySpecimenBuilder(string shortName = null)
        {
            _shortName = shortName;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var t = request as Type;
            if (typeof (vRuleProperty) != t) return new NoSpecimen(request);
            var fixture = new Fixture();
            return fixture.Build<vRuleProperty>()
                .With(_ => _.Id, Interlocked.Increment(ref _id))
                .With(_ => _.PropertyName, fixture.Create<string>().Truncate(50))
                .With(_ => _.PropertyValue, fixture.Create<string>().Truncate(50))
                .With(_ => _.ShortName, _shortName ?? fixture.Create<string>().Truncate(20))
                .Create();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Domain.DataAccess.Contracts.Model;
using Domain.DataAccess.Contracts.Repository;
using Domain.DataAccess.Support;

namespace Domain.DataAccess.Repository
{
    public class CoefficientRepository : ICoefficientRepository
    {
        private readonly IDbContextFactory _dbContextFactory;

        public CoefficientRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<vRuleProperty> GetCoefficientByShortName(string shortName)
        {
            List<vRuleProperty> properties;
            using (var dbContext = _dbContextFactory.GetContext())
            {
                properties = dbContext.vRuleProperties.Where(_ => _.ShortName == shortName).ToList();
            }
            return properties;
        }
    }
}
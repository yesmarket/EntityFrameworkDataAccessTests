using System.Collections.Generic;
using Domain.DataAccess.Contracts.Model;

namespace Domain.DataAccess.Contracts.Repository
{
    public interface ICoefficientRepository
    {
        IEnumerable<vRuleProperty> GetCoefficientByShortName(string shortName);
    }
}

using System;

namespace Domain.DataAccess.Contracts.Model
{
    public class vRuleProperty
    {
        public int Id { get; set; }
        public Nullable<int> brg_rule_id { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public DateTime? DateTime { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
    }
}

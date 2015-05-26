using System;

namespace Domain.DataAccess.Contracts.Model
{
    public class Rule
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public Nullable<bool> IsPropertiesPage { get; set; }
    }
}

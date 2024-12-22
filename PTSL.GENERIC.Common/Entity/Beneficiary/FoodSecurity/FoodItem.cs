using PTSL.GENERIC.Common.Entity.CommonEntity;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class FoodItem : BaseEntity
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public List<FoodSecurityItem>? FoodSecurityItems { get; set; }
    }
}
using PTSL.GENERIC.Common.Entity.AIG;

using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Trades
{
    public class Trade : BaseEntity
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public List<AIGBasicInformation>? AIGBasicInformations { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Entity.SocialForestry
{
    public class NurseryCostInformation : BaseEntity
    {

        public long NurseryInformationId { get; set; }
        public NurseryInformation? NurseryInformation{ get; set; }
        public long? CostTypeId { get; set; }
        public CostType? CostType { get; set; }
        public DateTime CostDate { get; set; }
        public double CostAmount { get; set; }
        public string? Remarks { get; set; }
        public List<NurseryCostInformationFile>? CostInformationFiles { get; set; }

    }
}

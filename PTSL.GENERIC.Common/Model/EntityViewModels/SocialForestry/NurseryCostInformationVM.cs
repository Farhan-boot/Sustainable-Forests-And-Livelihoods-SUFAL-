using System;

using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry
{
    public class NurseryCostInformationVM : BaseModel
    {

        public long NurseryInformationId { get; set; }
        public NurseryInformationVM? NurseryInformation { get; set; }
        public long? CostTypeId { get; set; }
        public CostTypeVM? CostType { get; set; }
        public DateTime CostDate { get; set; }
        public double CostAmount { get; set; }
        public string? Remarks { get; set; } 
        public List<NurseryCostInformationFileVM>? CostInformationFiles { get; set; }

    }
}

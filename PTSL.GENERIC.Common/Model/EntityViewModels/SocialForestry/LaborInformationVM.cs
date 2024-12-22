using System;

using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class LaborInformationVM : BaseModel
{
    public long LaborCostTypeId { get; set; }
    public LaborCostTypeVM? LaborCostType { get; set; }

    public DateTime LaborCostDate { get; set; }
    public int TotalMale { get; set; }
    public int TotalFemale { get; set; }
    public string? Remarks { get; set; }

    [SwaggerExclude]
    public List<LaborInformationFileVM>? LaborInformationFiles { get; set; }
}

using System;

using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class CostInformationVM : BaseModel
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }

    public long CostTypeId { get; set; }
    public CostTypeVM? CostType { get; set; }
    public DateTime CostDate { get; set; }
    public double CostAmount { get; set; }
    public string Remarks { get; set; } = string.Empty;
    [SwaggerExclude]
    public List<CostInformationFileVM>? CostInformationFiles { get; set; }
}

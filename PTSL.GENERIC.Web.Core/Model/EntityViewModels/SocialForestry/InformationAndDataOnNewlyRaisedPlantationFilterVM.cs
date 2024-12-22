using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class InformationAndDataOnNewlyRaisedPlantationFilterVM : ForestCivilLocationFilter
{
    public int? FinancialYearId { get; set; }
    public bool HasYear => FinancialYearId is not null && FinancialYearId > 1600;

    public string? PlantationId { get; set; }
}

using Humanizer;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;

public class ReplantationVM : BaseModel
{
    public long NewRaisedPlantationId { get; set; }

    [SwaggerExclude]
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }

    public long FinancialYearId { get; set; }

    [SwaggerExclude]
    public FinancialYearVM? FinancialYear { get; set; }

    public int RotationNo { get; set; }
    public string RotationNoDisplay => RotationNo.Ordinalize();
    public int RotationYears { get; set; }
    public long PlantationTypeId { get; set; }

    [SwaggerExclude]
    public PlantationTypeVM? PlantationType { get; set; }

    public string? PlantationArea { get; set; } = string.Empty;

    public bool SocialForestryManagementCommitteeFormed { get; set; }
    public string? SocialForestryManagementCommitteeFormedFile { get; set; }

    public bool FundManagementSubCommitteeFormed { get; set; }
    public string? FundManagementSubCommitteeFormedFile { get; set; }

    public bool AdvisoryCommitteeFormed { get; set; }
    public string? AdvisoryCommitteeFormedFile { get; set; }

    public string? PlantationJournalUploadUrl { get; set; } = string.Empty;
    public string? MonitoringReportUrl { get; set; } = string.Empty;
    public string? Remarks { get; set; } = string.Empty;

    [SwaggerExclude]
    public List<ReplantationNurseryInfoVM>? ReplantationNurseryInfos { get; set; }

    [SwaggerExclude]
    public List<ReplantationInspectionMapVM>? ReplantationInspectionMaps { get; set; }

    [SwaggerExclude]
    public List<ReplantationCostInfoVM>? ReplantationCostInfos { get; set; }

    [SwaggerExclude]
    public List<ReplantationLaborInfoVM>? ReplantationLaborInfos { get; set; }

    [SwaggerExclude]
    public List<ReplantationSocialForestryBeneficiaryMapVM>? ReplantationSocialForestryBeneficiaryMaps { get; set; }

    [SwaggerExclude]
    public List<ReplantationDamageInfoVM>? ReplantationDamageInfos { get; set; }
}

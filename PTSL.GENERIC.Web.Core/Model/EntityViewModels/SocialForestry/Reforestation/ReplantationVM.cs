using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Reforestation;

public class ReplantationVM : BaseModel
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }

    public long FinancialYearId { get; set; }
    public FinancialYearVM? FinancialYear { get; set; }

    public int RotationNo { get; set; }
    public string RotationNoDisplay { get; set; } = string.Empty;
    public int RotationYears { get; set; }
    public long PlantationTypeId { get; set; }
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

    public List<ReplantationNurseryInfoVM>? ReplantationNurseryInfos { get; set; }
    public List<ReplantationInspectionMapVM>? ReplantationInspectionMaps { get; set; }
    public List<ReplantationCostInfoVM>? ReplantationCostInfos { get; set; }
    public List<ReplantationLaborInfoVM>? ReplantationLaborInfos { get; set; }
    public List<ReplantationSocialForestryBeneficiaryMapVM>? ReplantationSocialForestryBeneficiaryMaps { get; set; }
    public List<ReplantationDamageInfoVM>? ReplantationDamageInfos { get; set; }
}

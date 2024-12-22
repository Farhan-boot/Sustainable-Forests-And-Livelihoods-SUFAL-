using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

public class Replantation : BaseEntity
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantation? NewRaisedPlantation { get; set; }

    public long FinancialYearId { get; set; }
    public FinancialYear? FinancialYear { get; set; }

    public int RotationNo { get; set; }
    public int RotationYears { get; set; }
    public long PlantationTypeId { get; set; }
    public PlantationType? PlantationType { get; set; }

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

    public List<ReplantationNurseryInfo>? ReplantationNurseryInfos { get; set; }
    public List<ReplantationInspectionMap>? ReplantationInspectionMaps { get; set; }
    public List<ReplantationCostInfo>? ReplantationCostInfos { get; set; }
    public List<ReplantationLaborInfo>? ReplantationLaborInfos { get; set; }
    public List<ReplantationSocialForestryBeneficiaryMap>? ReplantationSocialForestryBeneficiaryMaps { get; set; }
    public List<ReplantationDamageInfo>? ReplantationDamageInfos { get; set; }
}

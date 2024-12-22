using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class NewRaisedPlantation : BaseEntity
{
    #region Plantation Information
    public long ForestCircleId { get; set; }
    public ForestCircle? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    public ForestDivision? ForestDivision { get; set; }
    public long ForestRangeId { get; set; }
    public ForestRange? ForestRange { get; set; }
    public long ForestBeatId { get; set; }
    public ForestBeat? ForestBeat { get; set; }
    public long? ZoneOrAreaId { get; set; }
    public ZoneOrArea? ZoneOrArea { get; set; }

    // Civil administration
    public long DivisionId { get; set; }
    public Division? Division { get; set; }
    public long DistrictId { get; set; }
    public District? District { get; set; }
    public long UpazillaId { get; set; }
    public Upazilla? Upazilla { get; set; }
    public long? UnionId { get; set; }
    public Union? Union { get; set; }

    public long? LandOwningAgencyId { get; set; }
    public LandOwningAgency? LandOwningAgency { get; set; }

    public long PlantationTypeId { get; set; }
    public PlantationType? PlantationType { get; set; }
    public int CurrentRotationNo { get; set; }
    public string PlantationId { get; set; } = string.Empty;

    public string? PlantationArea { get; set; } = string.Empty;
    public long PlantationUnitId { get; set; }
    public PlantationUnit? PlantationUnit { get; set; }

    public string? LocationWithCoordinate { get; set; } = string.Empty;
    public string? MoujaAndJLNumber { get; set; }
    public string? SheetNo { get; set; } = string.Empty;
    public string? PlotNo { get; set; } = string.Empty;

    public string? SanctionNo { get; set; } = string.Empty;
    public string? SoilType { get; set; } = string.Empty;
    public string? NaturalTreeSpecies { get; set; } = string.Empty;

    public long? PlantationTopographyId { get; set; }
    public PlantationTopography? PlantationTopography { get; set; }

    public string? ClimateOfPlantationSite { get; set; } = string.Empty;
    #endregion

    public string? PlantationImage { get; set; }
    public string? NurseryImage { get; set; }

    public long? SocialForestryNgoId { get; set; }
    public SocialForestryNgo? SocialForestryNgo { get; set; }

    public long PlantedFinancialYearId { get; set; }
    public FinancialYear? PlantedFinancialYear { get; set; }

    public long ProjectTypeId { get; set; }
    public ProjectType? ProjectType { get; set; } // Source of Funding / Name of Project

    public int RotationNo { get; set; }
    public int RotationInYear { get; set; }
    public int ExpectedCuttingYear { get; set; }

    public bool SocialForestryManagementCommitteeFormed { get; set; }
    public string? SocialForestryManagementCommitteeFormedFile { get; set; }

    public bool FundManagementSubCommitteeFormed { get; set; }
    public string? FundManagementSubCommitteeFormedFile { get; set; }

    public bool AdvisoryCommitteeFormed { get; set; }
    public string? AdvisoryCommitteeFormedFile { get; set; }

    public string? PlantationJournalUploadUrl { get; set; } = string.Empty;
    public string? MonitoringReportUrl { get; set; } = string.Empty;
    public string? Remarks { get; set; } = string.Empty;

    public List<PlantationFile>? PlantationFiles { get; set; }
    public List<PlantationPlant>? PlantationPlants { get; set; }
    public List<CostInformation>? CostInformation { get; set; }
    public List<LaborInformation>? LaborInformation { get; set; }
    public List<PlantationSocialForestryBeneficiaryMap>? PlantationSocialForestryBeneficiaryMaps { get; set; }
    public List<PlantationDamageInformation>? PlantationDamageInformation { get; set; }
    public List<ConcernedOfficialMap>? ConcernedOfficialMap { get; set; }
    public List<InspectionDetailsMap>? InspectionDetailsMap { get; set; }

    public List<CuttingPlantation>? CuttingPlantations { get; set; }
    public List<Replantation>? Replantations { get; set; }
}

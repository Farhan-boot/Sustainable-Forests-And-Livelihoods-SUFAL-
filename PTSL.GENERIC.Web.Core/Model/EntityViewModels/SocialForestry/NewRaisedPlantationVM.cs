using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class NewRaisedPlantationVM : BaseModel
{
    #region Plantation Information
    public long ForestCircleId { get; set; }
    public ForestCircleVM? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    public ForestDivisionVM? ForestDivision { get; set; }
    public long ForestRangeId { get; set; }
    public ForestRangeVM? ForestRange { get; set; }
    public long ForestBeatId { get; set; }
    public ForestBeatVM? ForestBeat { get; set; }
    public long? ZoneOrAreaId { get; set; }
    public ZoneOrAreaVM? ZoneOrArea { get; set; }

    // Civil administration
    public long DivisionId { get; set; }
    public DivisionVM? Division { get; set; }
    public long DistrictId { get; set; }
    public DistrictVM? District { get; set; }
    public long UpazillaId { get; set; }
    public UpazillaVM? Upazilla { get; set; }
    public long? UnionId { get; set; }
    public UnionVM? Union { get; set; }

    public long? LandOwningAgencyId { get; set; }
    public LandOwningAgencyVM? LandOwningAgency { get; set; }

    public long PlantationTypeId { get; set; }
    public PlantationTypeVM? PlantationType { get; set; }
    public int CurrentRotationNo { get; set; }
    public string CurrentRotationNoDisplay { get; set; } = string.Empty;
    public string PlantationId { get; set; } = string.Empty;

    public string? PlantationArea { get; set; }
    public long PlantationUnitId { get; set; }
    public PlantationUnitVM? PlantationUnit { get; set; }

    public string? LocationWithCoordinate { get; set; }
    public string? MoujaAndJLNumber { get; set; }
    public string? SheetNo { get; set; } = string.Empty;
    public string? PlotNo { get; set; } = string.Empty;

    public string? SanctionNo { get; set; }
    public string? SoilType { get; set; }
    public string? NaturalTreeSpecies { get; set; }

    public long? PlantationTopographyId { get; set; }
    public PlantationTopographyVM? PlantationTopography { get; set; }

    public string? ClimateOfPlantationSite { get; set; }
    #endregion
    public string? PlantationImage { get; set; }
    public string? NurseryImage { get; set; }

    public long? SocialForestryNgoId { get; set; }
    public SocialForestryNgoVM? SocialForestryNgo { get; set; }

    public long PlantedFinancialYearId { get; set; }
    public FinancialYearVM? PlantedFinancialYear { get; set; }

    public long ProjectTypeId { get; set; }
    public ProjectTypeVM? ProjectType { get; set; } // Source of Funding / Name of Project

    public int RotationNo { get; set; }
    public string RotationNoDisplay { get; set; } = string.Empty;
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
    public string? Remarks { get; set; }

    public List<PlantationFileVM>? PlantationFiles { get; set; }
    public List<PlantationPlantVM>? PlantationPlants { get; set; }
    public List<CostInformationVM>? CostInformation { get; set; }
    public List<LaborInformationVM>? LaborInformation { get; set; }
    public List<PlantationSocialForestryBeneficiaryMapVM>? PlantationSocialForestryBeneficiaryMaps { get; set; }
    public List<PlantationDamageInformationVM>? PlantationDamageInformation { get; set; }
    public List<ConcernedOfficialMapVM>? ConcernedOfficialMap { get; set; }
    public List<InspectionDetailsMapVM>? InspectionDetailsMap { get; set; }
    public List<CuttingPlantationVM>? CuttingPlantations { get; set; }
}


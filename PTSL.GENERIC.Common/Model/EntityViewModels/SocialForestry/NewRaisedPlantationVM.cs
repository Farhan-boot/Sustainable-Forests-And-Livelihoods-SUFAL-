using Humanizer;

using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class NewRaisedPlantationVM : BaseModel
{
    #region Plantation Information
    public long ForestCircleId { get; set; }
    [SwaggerExclude]
    public ForestCircleVM? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    [SwaggerExclude]
    public ForestDivisionVM? ForestDivision { get; set; }
    public long ForestRangeId { get; set; }
    [SwaggerExclude]
    public ForestRangeVM? ForestRange { get; set; }
    public long ForestBeatId { get; set; }
    [SwaggerExclude]
    public ForestBeatVM? ForestBeat { get; set; }
    public long? ZoneOrAreaId { get; set; }
    [SwaggerExclude]
    public ZoneOrAreaVM? ZoneOrArea { get; set; }

    // Civil administration
    public long DivisionId { get; set; }
    [SwaggerExclude]
    public DivisionVM? Division { get; set; }
    public long DistrictId { get; set; }
    [SwaggerExclude]
    public DistrictVM? District { get; set; }
    public long UpazillaId { get; set; }
    [SwaggerExclude]
    public UpazillaVM? Upazilla { get; set; }
    public long? UnionId { get; set; }
    [SwaggerExclude]
    public UnionVM? Union { get; set; }

    public long? LandOwningAgencyId { get; set; }
    [SwaggerExclude]
    public LandOwningAgencyVM? LandOwningAgency { get; set; }

    public long PlantationTypeId { get; set; }
    [SwaggerExclude]
    public PlantationTypeVM? PlantationType { get; set; }
    public int CurrentRotationNo { get; set; }
    public string CurrentRotationNoDisplay => CurrentRotationNo.Ordinalize();
    public string PlantationId { get; set; } = string.Empty;

    public string? PlantationArea { get; set; } = string.Empty;
    public long PlantationUnitId { get; set; }
    [SwaggerExclude]
    public PlantationUnitVM? PlantationUnit { get; set; }

    public string? LocationWithCoordinate { get; set; } = string.Empty;
    public string? MoujaAndJLNumber { get; set; }
    public string? SheetNo { get; set; } = string.Empty;
    public string? PlotNo { get; set; } = string.Empty;

    public string? SanctionNo { get; set; } = string.Empty;
    public string? SoilType { get; set; } = string.Empty;
    public string? NaturalTreeSpecies { get; set; } = string.Empty;

    public long? PlantationTopographyId { get; set; }
    [SwaggerExclude]
    public PlantationTopographyVM? PlantationTopography { get; set; }

    public string? ClimateOfPlantationSite { get; set; } = string.Empty;
    #endregion
    public string? PlantationImage { get; set; }
    public string? NurseryImage { get; set; }

    public long? SocialForestryNgoId { get; set; }
    [SwaggerExclude]
    public SocialForestryNgoVM? SocialForestryNgo { get; set; }

    public long PlantedFinancialYearId { get; set; }
    [SwaggerExclude]
    public FinancialYearVM? PlantedFinancialYear { get; set; }

    public long ProjectTypeId { get; set; }
    [SwaggerExclude]
    public ProjectTypeVM? ProjectType { get; set; } // Source of Funding / Name of Project

    public int RotationNo { get; set; }
    public string RotationNoDisplay => RotationNo.Ordinalize();
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

    [SwaggerExclude]
    public List<PlantationFileVM>? PlantationFiles { get; set; }
    [SwaggerExclude]
    public List<PlantationPlantVM>? PlantationPlants { get; set; }
    [SwaggerExclude]
    public List<CostInformationVM>? CostInformation { get; set; }
    [SwaggerExclude]
    public List<LaborInformationVM>? LaborInformation { get; set; }
    [SwaggerExclude]
    public List<PlantationSocialForestryBeneficiaryMapVM>? PlantationSocialForestryBeneficiaryMaps { get; set; }
    [SwaggerExclude]
    public List<PlantationDamageInformationVM>? PlantationDamageInformation { get; set; }
    [SwaggerExclude]
    public List<ConcernedOfficialMapVM>? ConcernedOfficialMap { get; set; }
    [SwaggerExclude]
    public List<InspectionDetailsMapVM>? InspectionDetailsMap { get; set; }

    public List<CuttingPlantationVM>? CuttingPlantations { get; set; }
}

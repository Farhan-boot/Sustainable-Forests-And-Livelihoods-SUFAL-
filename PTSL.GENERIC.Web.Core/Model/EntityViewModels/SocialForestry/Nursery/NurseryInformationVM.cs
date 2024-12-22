using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;

public class NurseryInformationVM : BaseModel
{
    // Forest
    public long ForestCircleId { get; set; }
    public ForestCircleVM? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    public ForestDivisionVM? ForestDivision { get; set; }
    public long ForestRangeId { get; set; }
    public ForestRangeVM? ForestRange { get; set; }
    public long ForestBeatId { get; set; }
    public ForestBeatVM? ForestBeat { get; set; }
    public long? ForestFcvVcfId { get; set; }
    public ForestFcvVcfVM? ForestFcvVcf { get; set; }

    // Civil administration
    public long DivisionId { get; set; }
    public DivisionVM? Division { get; set; }
    public long DistrictId { get; set; }
    public DistrictVM? District { get; set; }
    public long UpazillaId { get; set; }
    public UpazillaVM? Upazilla { get; set; }
    public long? UnionId { get; set; }
    public UnionVM? Union { get; set; }

    public string NurseryName { get; set; } = string.Empty;
    public long FinancialYearId { get; set; }
    public FinancialYearVM? FinancialYear { get; set; }
    public int SeedlingRaisingTargetNumber { get; set; }
    public string? NursaryImageFilePath { get; set; }

    public long ProjectTypeId { get; set; }
    public ProjectTypeVM? ProjectType { get; set; }

    public DateTime EstablishmentDate { get; set; }
    public string SanctionNo { get; set; }
    public string? NursaryJournalFilePath { get; set; }


    public long NurseryTypeId { get; set; }
    public NurseryTypeVM? NurseryType { get; set; }

    public string Location { get; set; }
    public string? LocationLat { get; set; }
    public string? LocationLon { get; set; }

    public int TotalNumberOfBed { get; set; }
    public int NumberOfSeedlingsPerBed { get; set; }
    public string? NursaryLayoutFilePath { get; set; }


    public long NurseryRaisingSectorId { get; set; }
    public NurseryRaisingSectorVM? NurseryRaisingSector { get; set; }


    public List<NurseryRaisedSeedlingInformationVM>? NurseryRaisedSeedlingInformation { get; set; }
    public List<ConcernedOfficialMapVM>? ConcernedOfficialMap { get; set; }
    public List<InspectionDetailsMapVM>? InspectionDetailsMap { get; set; }
    public List<NurseryCostInformationVM>? CostInformations { get; set; }
    public List<NurseryDistributionVM>? NurseryDistributionDetails { get; set; }

}

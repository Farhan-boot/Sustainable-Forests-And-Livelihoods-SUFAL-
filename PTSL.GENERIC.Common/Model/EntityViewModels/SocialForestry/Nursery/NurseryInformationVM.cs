using System;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;

public class NurseryInformationVM : BaseModel
{
    // Forest
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

    public long? ForestFcvVcfId { get; set; }
    [SwaggerExclude]
    public ForestFcvVcf? ForestFcvVcf { get; set; }

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

    public string NurseryName { get; set; } = string.Empty;
    public long FinancialYearId { get; set; }
    [SwaggerExclude]
    public FinancialYearVM? FinancialYear { get; set; }
    public int SeedlingRaisingTargetNumber { get; set; }
    public string? NursaryImageFilePath { get; set; }

    public long ProjectTypeId { get; set; }
    [SwaggerExclude]
    public ProjectTypeVM? ProjectType { get; set; }

    public DateTime EstablishmentDate { get; set; }
    public string SanctionNo { get; set; }
    public string? NursaryJournalFilePath { get; set; }


    public long NurseryTypeId { get; set; }
    [SwaggerExclude]
    public NurseryTypeVM? NurseryType { get; set; }

    public string Location { get; set; }
    public string? LocationLat { get; set; }
    public string? LocationLon { get; set; }

    public int TotalNumberOfBed { get; set; }
    public int NumberOfSeedlingsPerBed { get; set; }
    public string? NursaryLayoutFilePath { get; set; }


    public long NurseryRaisingSectorId { get; set; }
    [SwaggerExclude]
    public NurseryRaisingSectorVM? NurseryRaisingSector { get; set; }


    [SwaggerExclude]
    public List<NurseryRaisedSeedlingInformationVM>? NurseryRaisedSeedlingInformation { get; set; }

    [SwaggerExclude]
    public List<ConcernedOfficialMapVM>? ConcernedOfficialMap { get; set; }
    [SwaggerExclude]
    public List<InspectionDetailsMapVM>? InspectionDetailsMap { get; set; }
    [SwaggerExclude]
    public List<NurseryCostInformationVM>? CostInformations { get; set; }
    [SwaggerExclude]
    public List<NurseryDistributionVM>? NurseryDistributionDetails { get; set; }

}

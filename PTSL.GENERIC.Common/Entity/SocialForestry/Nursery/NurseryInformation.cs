using System;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

public class NurseryInformation : BaseEntity
{
    // Forest
    public long ForestCircleId { get; set; }
    public ForestCircle? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    public ForestDivision? ForestDivision { get; set; }
    public long ForestRangeId { get; set; }
    public ForestRange? ForestRange { get; set; }
    public long ForestBeatId { get; set; }
    public ForestBeat? ForestBeat { get; set; }
    public long? ForestFcvVcfId { get; set; }
    public ForestFcvVcf? ForestFcvVcf { get; set; }

    // Civil administration
    public long DivisionId { get; set; }
    public Division? Division { get; set; }
    public long DistrictId { get; set; }
    public District? District { get; set; }
    public long UpazillaId { get; set; }
    public Upazilla? Upazilla { get; set; }
    public long? UnionId { get; set; }
    public Union? Union { get; set; }

    public string NurseryName { get; set; } = string.Empty;
    public long FinancialYearId { get; set; }
    public FinancialYear? FinancialYear { get; set; }
    public int SeedlingRaisingTargetNumber { get; set; }
    public string? NursaryImageFilePath { get; set; }


    public long ProjectTypeId { get; set; }
    public ProjectType? ProjectType { get; set; }

    public DateTime EstablishmentDate { get; set; }
    public string SanctionNo { get; set; }
    public string? NursaryJournalFilePath { get; set; }


    public long NurseryTypeId { get; set; }
    public NurseryType? NurseryType { get; set; }

    public string Location { get; set; }
    public string? LocationLat { get; set; }
    public string? LocationLon { get; set; }

    public int TotalNumberOfBed { get; set; }
    public int NumberOfSeedlingsPerBed { get; set; }
    public string? NursaryLayoutFilePath { get; set; }


    public long NurseryRaisingSectorId { get; set; }
    public NurseryRaisingSector? NurseryRaisingSector { get; set; }


    public List<NurseryRaisedSeedlingInformation>? NurseryRaisedSeedlingInformation { get; set; }
    public List<ConcernedOfficialMap>? ConcernedOfficialMap { get; set; }
    public List<InspectionDetailsMap>? InspectionDetailsMap { get; set; }
    public List<NurseryCostInformation>? CostInformations { get; set; }
    public List<NurseryDistribution>? NurseryDistributionDetails { get; set; }
    public List<NurseryDamageInformation>? NurseryDamageInformations { get; set; }

}

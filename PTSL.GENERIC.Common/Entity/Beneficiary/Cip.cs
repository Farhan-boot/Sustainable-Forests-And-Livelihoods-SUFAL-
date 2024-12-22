using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.Beneficiary;

namespace PTSL.GENERIC.Common.Entity.Beneficiary;

public class Cip : BaseEntity
{
    // Forest administration
    public long? ForestCircleId { get; set; }
    public ForestCircle? ForestCircle { get; set; }
    public long? ForestDivisionId { get; set; }
    public ForestDivision? ForestDivision { get; set; }
    public long? ForestRangeId { get; set; }
    public ForestRange? ForestRange { get; set; }
    public long? ForestBeatId { get; set; }
    public ForestBeat? ForestBeat { get; set; }
    public long? ForestFcvVcfId { get; set; }
    public ForestFcvVcf? ForestFcvVcf { get; set; }

    // Civil administration
    public long? DivisionId { get; set; }
    public Division? Division { get; set; }
    public long? DistrictId { get; set; }
    public District? District { get; set; }
    public long? UpazillaId { get; set; }
    public Upazilla? Upazilla { get; set; }
    public long? UnionId { get; set; }
    public Union? Union { get; set; }

    public long? NgoId { get; set; }
    public Ngo? Ngo { get; set; }

    public string? ForestVillageName { get; set; }
    public string? HouseholdSerialNo { get; set; }
    public string? BeneficiaryName { get; set; }
    public Gender? Gender { get; set; }
    public string? FatherOrSpouseName { get; set; }

    public long? EthnicityId { get; set; }
    public Ethnicity? Ethnicity { get; set; }

    public string? NID { get; set; }
    public string? MobileNumber { get; set; }

    public CIPHouseType? HouseType { get; set; }
    public CipWealth? CipWealth { get; set; }

    public long? TypeOfHouseNewId { get; set; }
    public TypeOfHouse? TypeOfHouseNew { get; set; }

    public string? TypeOfHouse { get; set; }
    public string? CipGeneratedId { get; set; }

    public Survey? Survey { get; set; }
    public List<CipFile>? CipFiles { get; set; }

    public List<CipTeamMember>? CipTeamMembers { get; set; }
    public List<ApprovalLogForCfm>? ApprovalLogForCfms { get; set; }

    //Approval Status
    public long? ApprovalStatus { get; set; }
}

using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Enum.Beneficiary;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.CipManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

public class CipVM : BaseModel
{
    // Forest administration
    public long? ForestCircleId { get; set; }
    public ForestCircleVM? ForestCircle { get; set; }
    public long? ForestDivisionId { get; set; }
    public ForestDivisionVM? ForestDivision { get; set; }
    public long? ForestRangeId { get; set; }
    public ForestRangeVM? ForestRange { get; set; }
    public long? ForestBeatId { get; set; }
    public ForestBeatVM? ForestBeat { get; set; }
    public long? ForestFcvVcfId { get; set; }
    public ForestFcvVcfVM? ForestFcvVcf { get; set; }

    // Civil administration
    public long? DivisionId { get; set; }
    public DivisionVM? Division { get; set; }
    public long? DistrictId { get; set; }
    public DistrictVM? District { get; set; }
    public long? UpazillaId { get; set; }
    public UpazillaVM? Upazilla { get; set; }
    public long? UnionId { get; set; }
    public UnionVM? Union { get; set; }

    public long? NgoId { get; set; }
    public NgoVM? Ngo { get; set; }

    public string? ForestVillageName { get; set; }
    public string? HouseholdSerialNo { get; set; }
    public string? BeneficiaryName { get; set; }
    public Gender? Gender { get; set; }
    public string? FatherOrSpouseName { get; set; }

    public long? EthnicityId { get; set; }
    public EthnicityVM? Ethnicity { get; set; }

    public string? NID { get; set; }
    public string? MobileNumber { get; set; }

    public CIPHouseType? HouseType { get; set; }
    public CipWealth? CipWealth { get; set; }

    public long? TypeOfHouseNewId { get; set; }
    public TypeOfHouseVM? TypeOfHouseNew { get; set; }

    public string? TypeOfHouse { get; set; }
    public string? CipGeneratedId { get; set; }

    public SurveyVM? Survey { get; set; }
    public List<CipFileVM>? CipFiles { get; set; }

    public List<CipTeamMemberVM>? CipTeamMembers { get; set; }
    public List<ApprovalLogForCfm>? ApprovalLogForCfms { get; set; }

    //Approval Status
    public long? ApprovalStatus { get; set; }
}

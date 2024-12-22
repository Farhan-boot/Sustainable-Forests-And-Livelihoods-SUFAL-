using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ApprovalLog;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

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

    public List<CipFileVM> CipFiles = new List<CipFileVM>();
    public List<ApprovalLogForCfmVM>? ApprovalLogForCfms { get; set; }

    public long? ApprovalStatus { get; set; }


    //new proparty
    public string? GenderName { get; set; }
    public string? CipWealthName { get; set; }
    public string? ApprovalStatusName { get; set; }

}

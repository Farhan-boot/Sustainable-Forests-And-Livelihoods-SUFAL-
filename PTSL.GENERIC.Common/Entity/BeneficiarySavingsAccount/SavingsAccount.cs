using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Helper;

using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;

public class SavingsAccount : BaseEntity
{
    public List<BeneficiarySubmissionHistory>? BeneficiarySubmissionHistorys { get; set; }
    // Forest administration
    public long? ForestCircleId { get; set; }
    public ForestCircle? ForestCircle { get; set; }
    public long? ForestDivisionId { get; set; }
    public ForestDivision? ForestDivision { get; set; }
    public long? ForestRangeId { get; set; }
    public ForestRange? ForestRange { get; set; }
    public long? ForestBeatId { get; set; }
    public ForestBeat? ForestBeat { get; set; }
    public long? FcvId { get; set; }

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
    public Ngo? Ngos { get; set; }

    //Others
    public long? SurveyId { get; set; }
    public Survey? Survey { get; set; }
    public long? StatusId { get; set; }

    public long? AccountTypeId { get; set; }
    public decimal? AmountLimit { get; set; }

    public List<SavingsAmountInformation>? SavingsAmountInformations { get; set; }
    public List<WithdrawAmountInformation>? WithdrawAmountInformations { get; set; }
}

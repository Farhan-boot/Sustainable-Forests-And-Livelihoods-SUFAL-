using System;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Entity.Trades;
using PTSL.GENERIC.Common.Enum.AIG;
using PTSL.GENERIC.Common.Helper;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class AIGBasicInformation : BaseEntity, IHasForestLocation
{
    // Forest administration
    public long ForestCircleId { get; set; }
    public ForestCircle? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    public ForestDivision? ForestDivision { get; set; }
    public long ForestRangeId { get; set; }
    public ForestRange? ForestRange { get; set; }
    public long ForestBeatId { get; set; }
    public ForestBeat? ForestBeat { get; set; }
    public long ForestFcvVcfId { get; set; }
    public ForestFcvVcf? ForestFcvVcf { get; set; }

    // Civil administration
    public long DivisionId { get; set; }
    public Division? Division { get; set; }
    public long DistrictId { get; set; }
    public District? District { get; set; }
    public long UpazillaId { get; set; }
    public Upazilla? Upazilla { get; set; }
    public long UnionId { get; set; }
    public Union? Union { get; set; }

    public long NgoId { get; set; }
    public Ngo? Ngo { get; set; }
    public long SurveyId { get; set; }
    public Survey? Survey { get; set; }
    public long? TradeId { get; set; }
    public Trade? Trade { get; set; }

    public int LDFCount { get; set; }

    // Trademarks
    public bool IsRecievedTrainingInTrade { get; set; }

    // Loan Info
    public double TotalAllocatedLoanAmount { get; set; }
    public int MaximumRepaymentMonth { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double ServiceChargePercentage { get; set; }
    public double SecurityChargePercentage { get; set; }

    public BadLoanType BadLoanType { get; set; }

    public long? IndividualLDFInfoFormId { get; set; }
    public IndividualLDFInfoForm? IndividualLDFInfoForm { get; set; }

    public long? AccountId { get; set; }
    public Account? Account { get; set; }

    public FirstSixtyPercentageLDF? FirstSixtyPercentageLDF { get; set; }
    public SecondFourtyPercentageLDF? SecondFourtyPercentageLDF { get; set; }
    public List<RepaymentLDF>? RepaymentLDFs { get; set; }
    public List<LDFProgress>? LDFProgresses { get; set; }
    public List<BeneficiarySubmissionHistory>? BeneficiarySubmissionHistorys { get; set; }
}

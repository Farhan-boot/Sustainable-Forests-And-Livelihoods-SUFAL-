using System;
using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;

namespace PTSL.GENERIC.Common.Entity.InternalLoan;

public class InternalLoanInformation : BaseEntity
{
    public List<BeneficiarySubmissionHistory>? BeneficiarySubmissionHistorys { get; set; }
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
    public long? UnionId { get; set; }
    public Union? Union { get; set; }

    public long NgoId { get; set; }
    public Ngo? Ngo { get; set; }
    public long SurveyId { get; set; }
    public Survey? Survey { get; set; }

    public int LDFCount { get; set; }

    // Loan Info
    public double TotalAllocatedLoanAmount { get; set; }
    public int MaximumRepaymentMonth { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double ServiceChargePercentage { get; set; }
    public double SecurityChargePercentage { get; set; }

    public List<RepaymentInternalLoan>? RepaymentInternalLoans { get; set; }
    public List<InternalLoanInformationFile>? InternalLoanInformationFiles { get; set; }

    //Approval Status
    public long? ApprovalStatus { get; set; }
    public List<ApprovalLogForCfm>? ApprovalLogForCfms { get; set; }
}

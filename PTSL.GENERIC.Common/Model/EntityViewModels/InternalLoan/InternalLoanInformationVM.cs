using System;
using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Common.Model.EntityViewModels.Trade;

namespace PTSL.GENERIC.Common.Entity.InternalLoan;

public class InternalLoanInformationVM : BaseModel
{
    [SwaggerExclude]
    public List<BeneficiarySubmissionHistory>? BeneficiarySubmissionHistorys { get; set; }
    // Forest administration
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
    public long ForestFcvVcfId { get; set; }
    [SwaggerExclude]
    public ForestFcvVcfVM? ForestFcvVcf { get; set; }

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

    public long NgoId { get; set; }
    [SwaggerExclude]
    public NgoVM? Ngo { get; set; }
    public long SurveyId { get; set; }
    [SwaggerExclude]
    public SurveyVM? Survey { get; set; }

   // public long? TradeId { get; set; }
   // [SwaggerExclude]
   // public TradeVM? Trade { get; set; }

    public int LDFCount { get; set; }

    // Trademarks
    //public bool IsRecievedTrainingInTrade { get; set; }

    // Loan Info
    public double TotalAllocatedLoanAmount { get; set; }
    public int MaximumRepaymentMonth { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public double ServiceChargePercentage { get; set; }
    public double SecurityChargePercentage { get; set; }

    [SwaggerExclude]
    public List<RepaymentInternalLoanVM>? RepaymentInternalLoans { get; set; }
    public List<InternalLoanInformationFile>? InternalLoanInformationFiles { get; set; }

    //Approval Status
    public long? ApprovalStatus { get; set; }
}

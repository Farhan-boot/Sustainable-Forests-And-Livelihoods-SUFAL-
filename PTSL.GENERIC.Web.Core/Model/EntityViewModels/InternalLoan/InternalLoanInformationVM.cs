﻿using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Trades;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.InternalLoan;

public class InternalLoanInformationVM : BaseModel
{
    // Forest administration
    public long ForestCircleId { get; set; }
    public ForestCircleVM? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    public ForestDivisionVM? ForestDivision { get; set; }
    public long ForestRangeId { get; set; }
    public ForestRangeVM? ForestRange { get; set; }
    public long ForestBeatId { get; set; }
    public ForestBeatVM? ForestBeat { get; set; }
    public long ForestFcvVcfId { get; set; }
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

    public long NgoId { get; set; }
    public NgoVM? Ngo { get; set; }
    public long SurveyId { get; set; }
    public SurveyVM? Survey { get; set; }
    //public long? TradeId { get; set; }
    //public TradeVM? Trade { get; set; }

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

    public List<RepaymentInternalLoanVM>? RepaymentInternalLoans { get; set; }

    public List<InternalLoanInformationFileVM> InternalLoanInformationFiles = new List<InternalLoanInformationFileVM>();

    //Approval Status
    public long? ApprovalStatus { get; set; }
    public string? ApprovalStatusText { get; set; }


    //DataTable Get List using server site Pagination

    public string? SecurityChargeTkText { get; set; }
    public string? ServiceChargeTkText { get; set; }

}

using System;

using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;

public class TransactionVM : BaseModel
{
    public long ForestCircleId { get; set; }
    public ForestCircleVM? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    public ForestDivisionVM? ForestDivision { get; set; }

    public long FundTypeId { get; set; }
    public FundTypeVM? FundType { get; set; }

    public long FinancialYearId { get; set; }
    public FinancialYearVM? FinancialYear { get; set; }

    public long AccountId { get; set; }
    public AccountVM? Account { get; set; }

    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }

    public double TotalExpense { get; set; }
    public DateTime ExpenseDate { get; set; }
    public Months ExpenseMonth { get; set; }

    public List<TransactionFilesVM>? TransactionFiles { get; set; }

    // CDF
    // Here CDF is special type of Fund Type -> For CDF Related properties are added here
    // In fund type there is a checkbox to add if fund type is CDF or not
    public long? ForestRangeId { get; set; }
    public ForestRangeVM? ForestRange { get; set; }
    public long? ForestBeatId { get; set; }
    public ForestBeatVM? ForestBeat { get; set; }
    public long? ForestFcvVcfId { get; set; }
    public ForestFcvVcfVM? ForestFcvVcf { get; set; }
    public string? ExpenseYear { get; set; }

    public List<ExpenseDetailsForCDFVM>? ExpenseDetailsForCDFs { get; set; }
    // CDF
}

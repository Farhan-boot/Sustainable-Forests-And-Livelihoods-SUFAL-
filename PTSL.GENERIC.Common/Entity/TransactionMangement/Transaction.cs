using System;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.Entity.TransactionMangement;

public class Transaction : BaseEntity
{
    public long ForestCircleId { get; set; }
    public ForestCircle? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    public ForestDivision? ForestDivision { get; set; }

    public long FundTypeId { get; set; }
    public FundType? FundType { get; set; }

    public long FinancialYearId { get; set; }
    public FinancialYear? FinancialYear { get; set; }

    public long AccountId { get; set; }
    public Account? Account { get; set; }

    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }

    public double TotalExpense { get; set; }
    public DateTime ExpenseDate { get; set; }
    public Months ExpenseMonth { get; set; }

    public List<TransactionFiles>? TransactionFiles { get; set; }

    // CDF
    // Here CDF is special type of Fund Type -> For CDF Related properties are added here
    // In fund type there is a checkbox to add if fund type is CDF or not
    public long? ForestRangeId { get; set; }
    public ForestRange? ForestRange { get; set; }
    public long? ForestBeatId { get; set; }
    public ForestBeat? ForestBeat { get; set; }
    public long? ForestFcvVcfId { get; set; }
    public ForestFcvVcf? ForestFcvVcf { get; set; }
    public string? ExpenseYear { get; set; }

    public List<ExpenseDetailsForCDF>? ExpenseDetailsForCDFs { get; set; } = new List<ExpenseDetailsForCDF>();
    // CDF
}

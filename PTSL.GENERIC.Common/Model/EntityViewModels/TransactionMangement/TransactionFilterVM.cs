using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;

public class TransactionFilterVM
{
    public long? ForestCircleId { get; set; }
    public long? ForestDivisionId { get; set; }
    public long? FinancialYearId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }

    public bool HasForestCircleId => ForestCircleId.HasValue && ForestCircleId.Value > 0;
    public bool HasForestDivisionId => ForestDivisionId.HasValue && ForestDivisionId.Value > 0;
    public bool HasFinancialYearId => FinancialYearId.HasValue && FinancialYearId.Value > 0;
    public bool HasFromDate => FromDate.HasValue;
    public bool HasToDate => ToDate.HasValue;
}

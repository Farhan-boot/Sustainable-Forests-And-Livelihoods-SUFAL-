using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.TransactionMangement;

public class ExpenseDetailsForCDF : BaseEntity
{
    public long TransactionId { get; set; }
    public Transaction? Transaction { get; set; }

    public string? ExpenseScheme { get; set; } // Project or Khat
    public double ExpenseAmount { get; set; }
    public DateTime ExpenseDate { get; set; }

    public string? DocumentFileURL { get; set; }
    public string? Remarks { get; set; }
}


using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Labour;

public class LabourWork : BaseEntity
{
    public long LabourDatabaseId { get; set; }
    public LabourDatabase? LabourDatabase { get; set; }

    public string? WorkType { get; set; }
    public double ManDays { get; set; }
    public double PaymentAmountPerDay { get; set; }
    public double TotalAmount { get; set; }
    public string? PaymentType { get; set; }
    public string? Remarks { get; set; }

    //New Field Add
    public DateTime FormDate { get; set; }
    public DateTime ToDate { get; set; }
}


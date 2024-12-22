using System;

using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Labour;

public class LabourWorkVM : BaseModel
{
    public long LabourDatabaseId { get; set; }
    public LabourDatabaseVM? LabourDatabase { get; set; }

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


using System;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

public class DepartmentalTrainingFilterVM
{
    public long? FinancialYearId { get; set; }
    public long? EventTypeId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;

public class DepartmentalTrainingFilterVM
{
    public long? FinancialYearId { get; set; }
    public long? EventTypeId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public bool HasFinancialYearId => FinancialYearId.HasValue && FinancialYearId.Value > 0;
    public bool HasEventTypeId => EventTypeId.HasValue && EventTypeId.Value > 0;
    public bool HasStartDate => StartDate.HasValue;
    public bool HasEndDate => EndDate.HasValue;

    //DataTable Get List using server site Pagination
    public int? iDisplayStart { get; set; }
    public int? iDisplayLength { get; set; }
    public string? sSearch { get; set; }
}

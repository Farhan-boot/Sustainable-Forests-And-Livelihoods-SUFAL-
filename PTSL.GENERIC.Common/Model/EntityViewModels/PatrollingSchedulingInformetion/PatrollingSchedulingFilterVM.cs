using System;

using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion;

public class PatrollingSchedulingFilterVM : ForestCivilLocationFilter
{
    public long? EventTypeId { get; set; }
    public long? PatrollingSchedulingTypeId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    //Extra Filter
    public Gender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }
    public long? EthnicityId { get; set; }
    public long? NgoId { get; set; }
}

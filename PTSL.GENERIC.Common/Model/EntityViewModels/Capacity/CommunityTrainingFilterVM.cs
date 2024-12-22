using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;

public class CommunityTrainingFilterVM : ForestCivilLocationFilter
{
    public long? CommunityTrainingTypeId { get; set; }
    public long? TrainingOrganizerId { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long? NgoId { get; set; }
    public long? EventTypeId { get; set; }

    public bool HasNgoId => NgoId.HasValue && NgoId.Value > 0;
    public bool HasTrainingOrganizerId => TrainingOrganizerId.HasValue && TrainingOrganizerId.Value > 0;
    public bool HasEventTypeId => EventTypeId.HasValue && EventTypeId.Value > 0;
    public bool HasStartDate => StartDate.HasValue;
    public bool HasEndDate => EndDate.HasValue;
}

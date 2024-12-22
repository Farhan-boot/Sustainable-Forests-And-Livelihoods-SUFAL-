using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;

public class SocialForestryMeetingFilterVM
{
    public long? FinancialYearForTrainingId { get; set; }
    public long? EventTypeForTrainingId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public bool HasFinancialYearId => FinancialYearForTrainingId.HasValue && FinancialYearForTrainingId.Value > 0;
    public bool HasEventTypeId => EventTypeForTrainingId.HasValue && EventTypeForTrainingId.Value > 0;
    public bool HasStartDate => StartDate.HasValue;
    public bool HasEndDate => EndDate.HasValue;
}

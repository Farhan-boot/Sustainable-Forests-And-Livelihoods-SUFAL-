using System;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

public class SocialForestryTrainingFilterVM
{
    public long? FinancialYearForTrainingId { get; set; }
    public long? EventTypeForTrainingId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

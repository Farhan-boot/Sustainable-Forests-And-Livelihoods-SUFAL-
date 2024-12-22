using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestryTraining;

public class FinancialYearForTraining : BaseEntity
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public int StartYear { get; set; }
    public int EndYear { get; set; }

    public List<SocialForestryTraining>? SocialForestryTrainings { get; set; }
}


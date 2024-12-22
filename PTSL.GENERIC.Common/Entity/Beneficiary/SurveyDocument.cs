using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary;

public class SurveyDocument : BaseEntity
{
    public long SurveyId { get; set; }
    public Survey? Survey { get; set; }

    public string? DocumentName { get; set; }
    public string? DocumentNameURL { get; set; }
}

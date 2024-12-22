using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Common.Entity.Beneficiary;

public class SurveyDocumentVM : BaseModel
{
    public long SurveyId { get; set; }
    [SwaggerExclude]
    public SurveyVM? Survey { get; set; }

    public string? DocumentName { get; set; }
    public string? DocumentNameURL { get; set; }
}

using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class AnnualHouseholdExpenditureVM : BaseModel
    {
        public long? ExpenditureTypeId { get; set; }

        [SwaggerExclude]
        public ExpenditureTypeVM? ExpenditureType { get; set; }
        public string? ExpenditureTypeTxt { get; set; }

        public double ExpenditureCost { get; set; }
        public string? ExpenditureRemarks { get; set; }

        public long SurveyId { get; set; }

        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
    }
}
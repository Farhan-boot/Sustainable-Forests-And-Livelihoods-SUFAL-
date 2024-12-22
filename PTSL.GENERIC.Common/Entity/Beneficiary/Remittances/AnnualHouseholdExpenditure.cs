using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class AnnualHouseholdExpenditure : BaseEntity
    {
        public long? ExpenditureTypeId { get; set; }
        public ExpenditureType? ExpenditureType { get; set; }
        public string? ExpenditureTypeTxt { get; set; }

        public double ExpenditureCost { get; set; }
        public string? ExpenditureRemarks { get; set; }

        public long SurveyId { get; set; }
        public Survey? Survey { get; set; }
    }
}
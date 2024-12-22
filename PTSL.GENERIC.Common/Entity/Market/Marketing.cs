using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class Marketing : BaseEntity
    {
        public string? MarketingName { get; set; }
        public string? MarketingNameBn { get; set; }
        public long? DistrictId { get; set; }
        public District? District { get; set; }
        public long? DivisionId { get; set; }
        public Division? Division { get; set; }
    }
}
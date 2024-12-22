using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Nursery
{
    public class NurseryDistribution : BaseEntity
    {
        public long NurseryInformationId { get; set; }
        public NurseryInformation? NurseryInformation { get; set; }

        public long? NurseryRaisedSeedlingId { get; set; }
        public NurseryRaisedSeedlingInformation? NurseryRaisedSeedling { get; set; }

        public DateTime DistributionDate { get; set; }

        public long? NumberOfSeedlingToBeDistributed { get; set; }
        public string? DistributedTo { get; set; } = string.Empty;
        public string? BeneficiaryNid { get; set; } = string.Empty;
        public string? MobileNo { get; set; } = string.Empty;
        public string? Address { get; set; }
    }
}

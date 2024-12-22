using System;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery
{
    public class NurseryDistributionVM : BaseModel
    {

        public long NurseryInformationId { get; set; }
        public NurseryInformationVM? NurseryInformation { get; set; }

        public long? NurseryRaisedSeedlingId { get; set; }
        public NurseryRaisedSeedlingInformation? NurseryRaisedSeedling { get; set; }
        public DateTime DistributionDate { get; set; }

        public long NumberofSeedlingTobeDistributed { get; set; }
        public string DistributedTo { get; set; }
        public string BeneficiaryNid { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
    }

    public class NurseryDistributionListVM
    {
        public List<NurseryDistributionVM>? NurseryDistributionList { get; set; }
    }

    //For index Page Custom model
    public class DistributionVM
    {
        public long Id { get; set; }
        public string NurseryName { get; set; }
        public DateTime DistributionDate { get; set; }
        public string SpeciesName { get; set; }
        public int TotalSeedlingRaised { get; set; }
        public long TotalNumberOfSeedlingToBeDistributed { get; set; }
        public long Available { get; set; }

    }

    public class DistributionFilter
    {
        public long? NurseryId { get; set; }
        public DateTime DistributionDate { get; set; }
    }
}

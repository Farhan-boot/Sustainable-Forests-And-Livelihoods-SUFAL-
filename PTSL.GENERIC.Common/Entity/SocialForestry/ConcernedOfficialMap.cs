using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Entity.SocialForestry
{
    public class ConcernedOfficialMap : BaseEntity
    {

        public long ConcernedOfficialId { get; set; }
        public ConcernedOfficial? ConcernedOfficial { get; set; }

        public long? NewRaisedPlantationId { get; set; }
        public NewRaisedPlantation? NewRaisedPlantation { get; set; }

        public long? NursaryInformationId { get; set; }
        public NurseryInformation? NursaryInformation { get; set; }
    }
}

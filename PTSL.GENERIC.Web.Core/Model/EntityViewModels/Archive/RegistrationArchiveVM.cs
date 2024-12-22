using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Archive
{
    public class RegistrationArchiveVM : BaseModel
    {

        // Forest administration
        public long? ForestCircleId { get; set; }
        public ForestCircleVM? ForestCircle { get; set; }
        public long? ForestDivisionId { get; set; }
        public ForestDivisionVM? ForestDivision { get; set; }
        public long? ForestRangeId { get; set; }
        public ForestRangeVM? ForestRange { get; set; }
        public long? ForestBeatId { get; set; }
        public ForestBeatVM? ForestBeat { get; set; }
        public long? ForestFcvVcfId { get; set; }
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        public DivisionVM? Division { get; set; }
        public long? DistrictId { get; set; }
        public DistrictVM? District { get; set; }
        public long? UpazillaId { get; set; }
        public UpazillaVM? Upazilla { get; set; }
        public long? UnionId { get; set; }
        public UnionVM? Union { get; set; }

        //Other Info
        public string? ArchiveName { get; set; }
        public string? DocumentDescription { get; set; }
        public DateTime? UploadDate { get; set; }
        public List<RegistrationArchiveFileVM>? RegistrationArchiveFiles { get; set; } = new List<RegistrationArchiveFileVM>();
    }
}
using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryMeeting
{
    public class SocialForestryMeetingFileVM : BaseModel
    {
        public string? FileName { get; set; }
        public string? FileNameUrl { get; set; }
        public FileType FileType { get; set; }

        public long SocialForestryMeetingId { get; set; }
        public SocialForestryMeetingVM? SocialForestryMeeting { get; set; }
    }
}

using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;

namespace PTSL.GENERIC.Web.Core.Entity.MeetingManagement
{
    public class MeetingFileVM : BaseModel
	{
        public string FileName { get; set; }
        public string FileNameUrl { get; set; }
        public FileType? FileType { get; set; }

		public long MeetingId { get; set; }
		public MeetingVM? Meeting { get; set; }
	}
}

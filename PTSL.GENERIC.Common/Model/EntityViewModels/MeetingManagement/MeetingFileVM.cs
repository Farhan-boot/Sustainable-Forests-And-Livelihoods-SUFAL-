using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Entity.MeetingManagement
{
	public class MeetingFileVM : BaseModel
	{
        public string? FileName { get; set; }
        public string? FileNameUrl { get; set; }
        public FileType FileType { get; set; }

		public long MeetingId { get; set; }
		public MeetingVM? Meeting { get; set; }
	}
}

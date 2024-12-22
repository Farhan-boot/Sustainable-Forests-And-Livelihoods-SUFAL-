using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Common.Entity.MeetingManagement
{
	public class MeetingFile : BaseEntity
	{
        public string? FileName { get; set; }
        public string? FileNameUrl { get; set; }
        public FileType FileType { get; set; }

		public long MeetingId { get; set; }
		public Meeting? Meeting { get; set; }
	}
}

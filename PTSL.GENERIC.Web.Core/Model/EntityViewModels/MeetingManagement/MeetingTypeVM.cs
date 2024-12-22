using PTSL.GENERIC.Web.Core.Model;

namespace PTSL.GENERIC.Web.Core.Entity.MeetingManagement
{
    public class MeetingTypeVM : BaseModel
	{
		public string Name { get; set; }
		public string NameBn { get; set; }

		public List<MeetingVM>? Meetings { get; set; }
	}
}

using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.MeetingManagement
{
	public class MeetingTypeVM : BaseModel
	{
		public string? Name { get; set; }
		public string? NameBn { get; set; }

		public List<MeetingVM>? Meetings { get; set; }
	}
}

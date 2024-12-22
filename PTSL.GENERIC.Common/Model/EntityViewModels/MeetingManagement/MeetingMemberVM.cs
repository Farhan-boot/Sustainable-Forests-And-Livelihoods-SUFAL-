using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.MeetingManagement
{
	public class MeetingMemberVM : BaseModel
	{
		public string? MemberName { get; set; }
		public Gender MemberGender { get; set; }
		public int MemberAge { get; set; }
		public string? MemberPhone { get; set; }
		public string? MemberAddress { get; set; }

		public List<MeetingParticipantsMapVM>? MeetingParticipantsMaps { get; set; }
	}
}

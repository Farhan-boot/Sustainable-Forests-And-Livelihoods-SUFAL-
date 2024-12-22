using PTSL.GENERIC.Web.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using System.Collections.Generic;
using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Entity.MeetingManagement
{
	public class MeetingMemberVM : BaseModel
	{
		public string MemberName { get; set; }
		public Gender MemberGender { get; set; }
		public int MemberAge { get; set; }
		public string MemberPhone { get; set; }
		public string MemberAddress { get; set; }

		public List<MeetingParticipantsMapVM>? MeetingParticipantsMaps { get; set; }
	}
}

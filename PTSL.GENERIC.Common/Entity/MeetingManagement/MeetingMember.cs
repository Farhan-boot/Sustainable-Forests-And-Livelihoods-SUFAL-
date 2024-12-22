using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;

using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.MeetingManagement
{
	public class MeetingMember : BaseEntity
	{
		public string? MemberName { get; set; }
		public Gender MemberGender { get; set; }
		public int MemberAge { get; set; }
		public string? MemberPhone { get; set; }
		public string? MemberAddress { get; set; }

        [SwaggerExclude]
		public List<MeetingParticipantsMap>? MeetingParticipantsMaps { get; set; }
	}
}

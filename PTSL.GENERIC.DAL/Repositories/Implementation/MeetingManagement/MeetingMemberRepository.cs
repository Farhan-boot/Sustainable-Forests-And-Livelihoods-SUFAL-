using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.DAL.Repositories.Interface;

namespace PTSL.GENERIC.DAL.Repositories.Implementation
{
	public class MeetingMemberRepository : BaseRepository<MeetingMember>, IMeetingMemberRepository
	{
		public MeetingMemberRepository(
			GENERICWriteOnlyCtx ecommarceWriteOnlyCtx,
			GENERICReadOnlyCtx ecommarceReadOnlyCtx)
			: base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx) { }
	}
}


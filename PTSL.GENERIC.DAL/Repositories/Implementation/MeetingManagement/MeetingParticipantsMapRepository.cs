using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.DAL.Repositories.Interface;

namespace PTSL.GENERIC.DAL.Repositories.Implementation
{
	public class MeetingParticipantsMapRepository : BaseRepository<MeetingParticipantsMap>, IMeetingParticipantsMapRepository
	{
		public MeetingParticipantsMapRepository(
			GENERICWriteOnlyCtx ecommarceWriteOnlyCtx,
			GENERICReadOnlyCtx ecommarceReadOnlyCtx)
			: base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx) { }
	}
}


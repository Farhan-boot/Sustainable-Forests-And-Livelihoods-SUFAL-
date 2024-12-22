using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.DAL.Repositories.Interface;

namespace PTSL.GENERIC.DAL.Repositories.Implementation
{
	public class MeetingRepository : BaseRepository<Meeting>, IMeetingRepository
	{
		public MeetingRepository(
			GENERICWriteOnlyCtx ecommarceWriteOnlyCtx,
			GENERICReadOnlyCtx ecommarceReadOnlyCtx)
			: base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx) { }
	}
}


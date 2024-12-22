using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation
{
	public class MeetingMemberBusiness : BaseBusiness<MeetingMember>, IMeetingMemberBusiness
	{
		public readonly GENERICUnitOfWork _unitOfWork;
		public MeetingMemberBusiness(GENERICUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}


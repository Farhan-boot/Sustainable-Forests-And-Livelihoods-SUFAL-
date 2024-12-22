using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation
{
	public class MeetingFileBusiness : BaseBusiness<MeetingFile>, IMeetingFileBusiness
	{
		public readonly GENERICUnitOfWork _unitOfWork;
		public MeetingFileBusiness(GENERICUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}


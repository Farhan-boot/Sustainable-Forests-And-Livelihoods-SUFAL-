using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Patrolling
{
    public class OtherPatrollingMemberVM : BaseModel
    {
        public string FullName { get; set; }
        public string FatherOrSpouse { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string NID { get; set; }
        public string Address { get; set; }

        // Forest Administration
        public long ForestCircleId { get; set; }
        public ForestCircleVM? ForestCircle { get; set; }
        public long ForestDivisionId { get; set; }
        public ForestDivisionVM? ForestDivision { get; set; }
        public long ForestRangeId { get; set; }
        public ForestRangeVM? ForestRange { get; set; }
        public long ForestBeatId { get; set; }
        public ForestBeatVM? ForestBeat { get; set; }
        public long ForestFcvVcfId { get; set; }
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        public long? EthnicityId { get; set; }
        public EthnicityVM? Ethnicity { get; set; }

        // Civil Administration
        public long DivisionId { get; set; }
        public DivisionVM? Division { get; set; }
        public long DistrictId { get; set; }
        public DistrictVM? District { get; set; }
        public long UpazillaId { get; set; }
        public UpazillaVM? Upazilla { get; set; }
    }
}

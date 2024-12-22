using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SystemUser;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model
{
	public class UserVM : BaseModel
	{
        public string? AccountsInformationsJson { get; set; }
        public List<BankAccountsInformationVM>? BankAccountsInformations { get; set; }
        public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? RoleName { get; set; }
		public string? UserName { get; set; }
		public string? UserEmail { get; set; }
		public string? UserPassword { get; set; }
		public string? ImageUrl { get; set; }
		public string? UserPhone { get; set; }
		public string? UserGroup { get; set; }
		public bool UserStatus { get; set; }
		public long PmsGroupID { get; set; }
		public long? GroupID { get; set; }
		public virtual UserGroupVM? Group { get; set; }
		public virtual PmsGroupVM? PmsGroup { get; set; }

        // Forest administration
        public long? ForestCircleId { get; set; }
        public ForestCircleVM? ForestCircle { get; set; }
        public long? ForestDivisionId { get; set; }
        public ForestDivisionVM? ForestDivision { get; set; }
        public long? ForestRangeId { get; set; }
        public ForestRangeVM? ForestRange { get; set; }
        public long? ForestBeatId { get; set; }
        public ForestBeatVM? ForestBeat { get; set; }
        public long? ForestFcvVcfId { get; set; }
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        public DivisionVM? Division { get; set; }
        public long? DistrictId { get; set; }
        public DistrictVM? District { get; set; }
        public long? UpazillaId { get; set; }
        public UpazillaVM? Upazilla { get; set; }
        public long? UnionId { get; set; }
        public UnionVM? Union { get; set; }

        public long? SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }

        public long? UserRoleId { get; set; }
        public UserRoleVM? UserRole { get; set; }

        public UserType UserType { get; set; }

        public List<RepaymentLDFHistoryVM>? RepaymentLDFHistories { get; set; }

        // Map To Account into User
        public long? AccountsId { get; set; }
        public AccountVM? Accounts { get; set; }
    }

	public class LoginVM
	{
		public string? UserEmail { get; set; }
		public string? UserPassword { get; set; }
	}

	public class LoginResultVM
	{
		public long UserId { get; set; }
		public string? UserName { get; set; }
		public string? UserEmail { get; set; }
		public string? Token { get; set; }
		public string? RoleName { get; set; }
        public long? SurveyId { get; set; }

        // Forest administration
        public long? ForestCircleId { get; set; }
        public long? ForestDivisionId { get; set; }
        public long? ForestRangeId { get; set; }
        public long? ForestBeatId { get; set; }
        public long? ForestFcvVcfId { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        public long? DistrictId { get; set; }
        public long? UpazillaId { get; set; }
        public long? UnionId { get; set; }

        public long? UserRoleId { get; set; }
    }
}

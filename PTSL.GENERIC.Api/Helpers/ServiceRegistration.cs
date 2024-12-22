using Microsoft.Extensions.DependencyInjection;

using PTSL.GENERIC.Business.Businesses.Implementation;
using PTSL.GENERIC.Business.Businesses.Implementation.BeneficiarySavingsAccount;
using PTSL.GENERIC.Business.Businesses.Implementation.Capacity;
using PTSL.GENERIC.Business.Businesses.Implementation.ForestManagement;
using PTSL.GENERIC.Business.Businesses.Implementation.InternalLoan;
using PTSL.GENERIC.Business.Businesses.Implementation.Labour;
using PTSL.GENERIC.Business.Businesses.Implementation.Market;
using PTSL.GENERIC.Business.Businesses.Implementation.Patrolling;
using PTSL.GENERIC.Business.Businesses.Implementation.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Business.Businesses.Implementation.Students;
using PTSL.GENERIC.Business.Businesses.Implementation.Trades;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Business.Businesses.Interface.BeneficiarySavingsAccount;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Business.Businesses.Interface.InternalLoan;
using PTSL.GENERIC.Business.Businesses.Interface.Labour;
using PTSL.GENERIC.Business.Businesses.Interface.Market;
using PTSL.GENERIC.Business.Businesses.Interface.Patrolling;
using PTSL.GENERIC.Business.Businesses.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Business.Businesses.Interface.Trades;
using PTSL.GENERIC.DAL.Repositories.Implementation;
using PTSL.GENERIC.DAL.Repositories.Implementation.InternalLoan;
using PTSL.GENERIC.DAL.Repositories.Implementation.Labour;
using PTSL.GENERIC.DAL.Repositories.Implementation.PatrollingSchedulingInformetion;
using PTSL.GENERIC.DAL.Repositories.Interface;
using PTSL.GENERIC.DAL.Repositories.Interface.InternalLoan;
using PTSL.GENERIC.DAL.Repositories.Interface.Labour;
using PTSL.GENERIC.DAL.Repositories.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.BeneficiarySavingsAccount;
using PTSL.GENERIC.Service.Services.ForestManagement;
using PTSL.GENERIC.Service.Services.Implementation;
using PTSL.GENERIC.Service.Services.Implementation.Capacity;
using PTSL.GENERIC.Service.Services.Implementation.Labour;
using PTSL.GENERIC.Service.Services.Implementation.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Service.Services.Interface;
using PTSL.GENERIC.Service.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Service.Services.Interface.Labour;
using PTSL.GENERIC.Service.Services.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Service.Services.InternalLoan;
using PTSL.GENERIC.Service.Services.Labour;
using PTSL.GENERIC.Service.Services.Market;
using PTSL.GENERIC.Service.Services.Patrolling;
using PTSL.GENERIC.Service.Services.Students;
using PTSL.GENERIC.Service.Services.Trades;

namespace PTSL.GENERIC.Api.Helpers
{
    public static class ServiceRegistration
    {
        public static void RegisterAllServices(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterBusniesses(services);
            RegisterRepositorys(services);
        }
        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserGroupService, UserGroupService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IDivisionService, DivisionService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IAccesslistService, AccesslistService>();
            services.AddScoped<IAccessMapperService, AccessMapperService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IPmsGroupService, PmsGroupService>();
            services.AddScoped<IMarketingService, MarketingService>();
            services.AddScoped<IUnionService, UnionService>();
            //ForestManagement

            //Student
            services.AddScoped<IStudentService, StudentService>();

            //Labour
            services.AddScoped<IOtherLabourMemberService, OtherLabourMemberService>();
            services.AddScoped<ILabourDatabaseService, LabourDatabaseService>();
            services.AddScoped<ILabourDatabaseFileService, LabourDatabaseFileService>();
            services.AddScoped<ILabourWorkService, LabourWorkService>();

            //Trade
            services.AddScoped<ITradeService, TradeService>();

            // Beneficiary Savings Account
            services.AddScoped<ISavingsAccountService, SavingsAccountService>();
            services.AddScoped<ISavingsAmountInformationService, SavingsAmountInformationService>();
            services.AddScoped<IWithdrawAmountInformationService, WithdrawAmountInformationService>();

            // Patrolling
            services.AddScoped<IPatrollingScheduleInformetionService, PatrollingScheduleInformetionService>();
            services.AddScoped<IOtherPatrollingMemberService, OtherPatrollingMemberService>();

            // InternalLoan
            services.AddScoped<IInternalLoanInformationService, InternalLoanInformationService>();
            services.AddScoped<IRepaymentInternalLoanService, RepaymentInternalLoanService>();
            services.AddScoped<IInternalLoanInformationFileService, InternalLoanInformationFileService>();

            // PatrollingSchedulingInformetion
            services.AddScoped<IPatrollingSchedulingMemberService, PatrollingSchedulingMemberService>();
            services.AddScoped<IPatrollingSchedulingParticipentsMapService, PatrollingSchedulingParticipentsMapService>();
            services.AddScoped<IPatrollingSchedulingService, PatrollingSchedulingService>();
            services.AddScoped<IPatrollingSchedulingFileService, PatrollingSchedulingFileService>();
        }
        private static void RegisterBusniesses(IServiceCollection services)
        {
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IUserGroupBusiness, UserGroupBusiness>();
            services.AddScoped<ICategoryBusiness, CategoryBusiness>();
            services.AddScoped<IDistrictBusiness, DistrictBusiness>();
            services.AddScoped<IDivisionBusiness, DivisionBusiness>();
            services.AddScoped<IColorBusiness, ColorBusiness>();
            services.AddScoped<IUserRoleBusiness, UserRoleBusiness>();
            services.AddScoped<IAccesslistBusiness, AccesslistBusiness>();
            services.AddScoped<IAccessMapperBusiness, AccessMapperBusiness>();
            services.AddScoped<IModuleBusiness, ModuleBusiness>();
            services.AddScoped<IPmsGroupBusiness, PmsGroupBusiness>();
            services.AddScoped<IMarketingBusiness, MarketingBusiness>();
            services.AddScoped<IUnionBusiness, UnionBusiness>();
            //ForestManagement
            //Student
            services.AddScoped<IStudentBusiness, StudentBusiness>();

            //Labour
            services.AddScoped<IOtherLabourMemberBusiness, OtherLabourMemberBusiness>();
            services.AddScoped<ILabourDatabaseBusiness, LabourDatabaseBusiness>();
            services.AddScoped<ILabourDatabaseFileBusiness, LabourDatabaseFileBusiness>();
            services.AddScoped<ILabourWorkBusiness, LabourWorkBusiness>();

            //Trade
            services.AddScoped<ITradeBusiness, TradeBusiness>();

            // Beneficiary Savings Account
            services.AddScoped<ISavingsAccountBusiness, SavingsAccountBusiness>();
            services.AddScoped<ISavingsAmountInformationBusiness, SavingsAmountInformationBusiness>();
            services.AddScoped<IWithdrawAmountInformationBusiness, WithdrawAmountInformationBusiness>();

            // Patrolling
            services.AddScoped<IPatrollingScheduleInformetionBusiness, PatrollingScheduleInformetionBusiness>();
            services.AddScoped<IOtherPatrollingMemberBusiness, OtherPatrollingMemberBusiness>();

            // InternalLoan
            services.AddScoped<IInternalLoanInformationBusiness, InternalLoanInformationBusiness>();
            services.AddScoped<IRepaymentInternalLoanBusiness, RepaymentInternalLoanBusiness>();
            services.AddScoped<IInternalLoanInformationFileBusiness, InternalLoanInformationFileBusiness>();


            // PatrollingSchedulingInformetion
            services.AddScoped<IPatrollingSchedulingMemberBusiness, PatrollingSchedulingMemberBusiness>();
            services.AddScoped<IPatrollingSchedulingParticipentsMapBusiness, PatrollingSchedulingParticipentsMapBusiness>();
            services.AddScoped<IPatrollingSchedulingBusiness, PatrollingSchedulingBusiness>();
            services.AddScoped<IPatrollingSchedulingFileBusiness, PatrollingSchedulingFileBusiness>();
        }
        private static void RegisterRepositorys(IServiceCollection services)
        {
            services.AddScoped<IGENERICUnitOfWork, GENERICUnitOfWork>();
            services.AddScoped<IUserGroupRepository, UserGroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDivisionRepository, DivisionRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IAccesslistRepository, AccesslistRepository>();
            services.AddScoped<IAccessMapperRepository, AccessMapperRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IPmsGroupRepository, PmsGroupRepository>();
            services.AddScoped<IMarketingRepository, MarketingRepository>();
            services.AddScoped<IUnionRepository, UnionRepository>();
            //ForestManagement
            //Student
            services.AddScoped<IStudentRepository, StudentRepository>();

            //Labour
            services.AddScoped<IOtherLabourMemberRepository, OtherLabourMemberRepository>();
            services.AddScoped<ILabourDatabaseRepository, LabourDatabaseRepository>();
            services.AddScoped<ILabourDatabaseFileRepository, LabourDatabaseFileRepository>();
            services.AddScoped<ILabourWorkRepository, LabourWorkRepository>();
            //Trade
            services.AddScoped<ITradeRepository, TradeRepository>();


            // Beneficiary Savings Account
            services.AddScoped<ISavingsAccountRepository, SavingsAccountRepository>();
            services.AddScoped<ISavingsAmountInformationRepository, SavingsAmountInformationRepository>();
            services.AddScoped<IWithdrawAmountInformationRepository, WithdrawAmountInformationRepository>();

            // Patrolling
            services.AddScoped<IPatrollingScheduleInformetionRepository, PatrollingScheduleInformetionRepository>();
            services.AddScoped<IOtherPatrollingMemberRepository, OtherPatrollingMemberRepository>();

            // InternalLoan
            services.AddScoped<IInternalLoanInformationRepository, InternalLoanInformationRepository>();
            services.AddScoped<IRepaymentInternalLoanRepository, RepaymentInternalLoanRepository>();
            services.AddScoped<IInternalLoanInformationFileRepository, InternalLoanInformationFileRepository>();


            // PatrollingSchedulingInformetion
            services.AddScoped<IPatrollingSchedulingMemberRepository, PatrollingSchedulingMemberRepository>();
            services.AddScoped<IPatrollingSchedulingParticipentsMapRepository, PatrollingSchedulingParticipentsMapRepository>();
            services.AddScoped<IPatrollingSchedulingRepository, PatrollingSchedulingRepository>();
            services.AddScoped<IPatrollingSchedulingFileRepository, PatrollingSchedulingFileRepository>();
        }
    }
}

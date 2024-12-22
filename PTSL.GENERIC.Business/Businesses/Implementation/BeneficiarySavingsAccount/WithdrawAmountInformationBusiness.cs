using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Business.Businesses.Interface.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.BeneficiarySavingsAccount
{
    public class WithdrawAmountInformationBusiness : BaseBusiness<WithdrawAmountInformation>, IWithdrawAmountInformationBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public WithdrawAmountInformationBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public override Task<(ExecutionState executionState, IQueryable<SavingsAccount> entity, string message)> List(QueryOptions<SavingsAccount> queryOptions = null)
        //{
        //    var savingsAccount = new QueryOptions<SavingsAccount>();
        //    savingsAccount.IncludeExpression = x => x.Include(y => y.Ngos).OrderByDescending(x => x.Id).Include(x => x.Survey);
        //    return base.List(savingsAccount);
        //}

        public override Task<(ExecutionState executionState, IQueryable<WithdrawAmountInformation> entity, string message)> List(QueryOptions<WithdrawAmountInformation> queryOptions = null)
        {

            var withdrawAmountInformation = new QueryOptions<WithdrawAmountInformation>();
            withdrawAmountInformation.IncludeExpression = x => x.OrderByDescending(x => x.Id).Include(s => s.SavingsAccounts.Survey!).Include(n => n.SavingsAccounts.Ngos!)
            .Include(x=>x.SavingsAccounts!).ThenInclude(x=>x.ForestCircle!)
            .Include(x => x.SavingsAccounts!).ThenInclude(x => x.ForestDivision!)
            .Include(x => x.SavingsAccounts!).ThenInclude(x => x.ForestRange!)
            .Include(x => x.SavingsAccounts!).ThenInclude(x => x.ForestBeat!);
            
            //.Include(n => n.SavingsAccounts.SavingsAmountInformations).Include(n => n.SavingsAccounts.WithdrawAmountInformations);

            return base.List(withdrawAmountInformation);
        }



    }
}

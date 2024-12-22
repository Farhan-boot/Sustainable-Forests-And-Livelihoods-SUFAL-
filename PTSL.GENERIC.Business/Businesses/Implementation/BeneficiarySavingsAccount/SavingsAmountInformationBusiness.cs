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
    public class SavingsAmountInformationBusiness : BaseBusiness<SavingsAmountInformation>, ISavingsAmountInformationBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public SavingsAmountInformationBusiness(GENERICUnitOfWork unitOfWork)
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


    }
}

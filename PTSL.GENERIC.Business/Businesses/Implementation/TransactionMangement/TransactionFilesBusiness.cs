using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.TransactionMangement;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.TransactionMangement
{
    public class TransactionFilesBusiness : BaseBusiness<TransactionFiles>, ITransactionFilesBusiness
    {
        public TransactionFilesBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
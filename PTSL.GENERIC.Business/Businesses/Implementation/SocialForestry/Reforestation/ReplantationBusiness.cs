using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Reforestation
{
    public class ReplantationBusiness : BaseBusiness<Replantation>, IReplantationBusiness
    {
        private readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public ReplantationBusiness(GENERICUnitOfWork unitOfWork, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _writeOnlyCtx = writeOnlyCtx;
        }

        public Task<(ExecutionState executionState, Replantation data, string message)> GetDetails(long id)
        {
            return _unitOfWork.ReplantationRepository.GetDetails(id);
        }

        public override Task<(ExecutionState executionState, IQueryable<Replantation> entity, string message)> List(QueryOptions<Replantation> queryOptions = null)
        {
            return base.List(new QueryOptions<Replantation>
            {
                IncludeExpression = e => e.Include(x => x.FinancialYear!)
            });
        }

        public override async Task<(ExecutionState executionState, Replantation entity, string message)> CreateAsync(Replantation entity)
        {
            try
            {
                using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

                var newRaisedPlantation = await _writeOnlyCtx.Set<NewRaisedPlantation>()
                    .FirstOrDefaultAsync(x => x.Id == entity.NewRaisedPlantationId);
                if (newRaisedPlantation is null)
                {
                    return (ExecutionState.Failure, null!, "Invalid new raised plantation");
                }

                foreach (var item in entity.ReplantationSocialForestryBeneficiaryMaps ?? Enumerable.Empty<ReplantationSocialForestryBeneficiaryMap>())
                {
                    if (item.SocialForestryBeneficiary is not null)
                    {
                        item.SocialForestryBeneficiaryId = item.SocialForestryBeneficiary.Id;
                        item.SocialForestryBeneficiary = null;
                    }
                }

                newRaisedPlantation.CurrentRotationNo += 1;
                entity.RotationNo = newRaisedPlantation.CurrentRotationNo;

                _writeOnlyCtx.Set<Replantation>().Add(entity);
                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Created, entity, "Created");
            }
            catch
            {
                return (ExecutionState.Failure, null!, "Unexpected error occurred");
            }
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AIG
{
    public class LDFProgressBusiness : BaseBusiness<LDFProgress>, ILDFProgressBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public LDFProgressBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
            _writeOnlyCtx = writeOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<LDFProgress> entity, string message)> List(QueryOptions<LDFProgress> queryOptions = null)
        {
            return base.List(new QueryOptions<LDFProgress>
            {
                IncludeExpression = e => e.Include(x => x.RepaymentLDF!)
            });
        }

        public override async Task<(ExecutionState executionState, LDFProgress entity, string message)> CreateAsync(LDFProgress entity)
        {
            var currentRepaymentSerial = await _readOnlyCtx.Set<RepaymentLDF>()
                .Where(x => x.AIGBasicInformationId == entity.AIGBasicInformationId)
                .Where(x => x.Id == entity.RepaymentLDFId)
                .Select(x => x.RepaymentSerial)
                .FirstOrDefaultAsync();
            var ldfProgressCount = await _readOnlyCtx.Set<LDFProgress>()
                .Where(x => x.AIGBasicInformationId == entity.AIGBasicInformationId)
                .CountAsync();
            if (currentRepaymentSerial - 1 != ldfProgressCount)
            {
                return (ExecutionState.Failure, null!, "Previous progress is not added");
            }

            var lastProgress = await _readOnlyCtx.Set<LDFProgress>()
                .Where(x => x.AIGBasicInformationId == entity.AIGBasicInformationId)
                .Select(x => new { x.RepaymentSerial, x.AIGBasicInformationId })
                .OrderByDescending(x => x.RepaymentSerial)
                .FirstOrDefaultAsync();
            if (lastProgress is null)
            {
                entity.GrowthPercentage = 0;
            }
            else
            {
                var previousSerial = lastProgress.RepaymentSerial;
                var previousAmount = await _readOnlyCtx.Set<LDFProgress>()
                    .Where(x => x.AIGBasicInformationId == lastProgress.AIGBasicInformationId)
                    .Where(x => x.RepaymentSerial == previousSerial)
                    .Select(x => x.ProgressAmount)
                    .FirstOrDefaultAsync();

                var growth = ((entity.ProgressAmount - previousAmount) / previousAmount) * 100;
                entity.GrowthPercentage = Math.Round(growth, 1);
            }

            return await base.CreateAsync(entity);
        }

        public override async Task<(ExecutionState executionState, LDFProgress entity, string message)> UpdateAsync(LDFProgress entity)
        {
            var updateResult = await base.UpdateAsync(entity);
            var allLDFProgress = await _writeOnlyCtx.Set<LDFProgress>()
                .AsTracking()
                .Where(x => x.AIGBasicInformationId == entity.AIGBasicInformationId)
                .OrderBy(x => x.RepaymentSerial)
                .ToListAsync();

            if (allLDFProgress.Count > 1)
            {
                using var transaction = _writeOnlyCtx.Database.BeginTransaction();

                try
                {
                    LDFProgress? previous = default;

                    foreach (var currentLdfProgress in allLDFProgress)
                    {
                        if (previous is null)
                        {
                            currentLdfProgress.GrowthPercentage = 0;
                        }
                        else
                        {
                            var growth = ((currentLdfProgress.ProgressAmount - previous.ProgressAmount) / previous.ProgressAmount) * 100;
                            currentLdfProgress.GrowthPercentage = Math.Round(growth, 1);
                        }

                        previous = currentLdfProgress;
                    }

                    _writeOnlyCtx.UpdateRange(allLDFProgress);
                    await _writeOnlyCtx.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    return (ExecutionState.Failure, null!, "Failed to update growth percentage");
                }

            }

            return updateResult;
        }
    }
}


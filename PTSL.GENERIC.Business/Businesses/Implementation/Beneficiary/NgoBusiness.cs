using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary
{
    public class NgoBusiness : BaseBusiness<Ngo>, INgoBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public NgoBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = readOnlyCtx;
        }

        public async Task<(ExecutionState executionState, List<Ngo> entity, string message)> ListByForestDivisions(List<long> divisions)
        {
            var ngos = await _readOnlyCtx.Set<Ngo>()
                .Where(x => x.ForestDivisionIdList!.Any(x => divisions.Contains(x)))
                .ToListAsync();

            return (ExecutionState.Retrieved, ngos, "Retrieved successfully");
        }

        public async Task<(ExecutionState executionState, Ngo entity, List<ForestDivision> forestDivisions, string message)> GetCustomAsync(long key)
        {
            var ngo = await _readOnlyCtx.Set<Ngo>().FirstOrDefaultAsync(x => x.Id == key);
            if (ngo == null)
            {
                return (ExecutionState.Retrieved, null!, new List<ForestDivision>(), "Not found");
            }

            var forestDivisions = new List<ForestDivision>();
            if (ngo.ForestDivisionIdList is not null && ngo.ForestDivisionIdList.Count > 0)
            {
                forestDivisions = await _readOnlyCtx.Set<ForestDivision>().Where(x => ngo.ForestDivisionIdList.Any(y => y == x.Id)).ToListAsync();
            }

            return (ExecutionState.Retrieved, ngo, forestDivisions, "Retrieved successfully");
        }

        public override Task<(ExecutionState executionState, IQueryable<Ngo> entity, string message)> List(QueryOptions<Ngo> queryOptions = null)
        {
            queryOptions = new QueryOptions<Ngo>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }

        public override async Task<(ExecutionState executionState, Ngo entity, string message)> CreateAsync(Ngo entity)
        {
            using var transaction = _unitOfWork.Begin();

            try
            {
                var trainingOrganizer = new TrainingOrganizer()
                {
                    Name = entity.Name,
                    NameBn = entity.NameBn,
                };

                await _unitOfWork.CreateAsync(trainingOrganizer);
                var ngoResult = await _unitOfWork.CreateAsync(entity);
                await _unitOfWork.SaveAsync(transaction);

                transaction.Commit();
                return ngoResult;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return (ExecutionState.Failure, null!, "Unexpected error occurred.");
            }
        }
    }
}

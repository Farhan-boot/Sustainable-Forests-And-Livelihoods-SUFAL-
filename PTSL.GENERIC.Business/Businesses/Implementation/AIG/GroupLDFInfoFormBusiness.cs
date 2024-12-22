using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AIG
{
    public class GroupLDFInfoFormBusiness : BaseBusiness<GroupLDFInfoForm>, IGroupLDFInfoFormBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public GroupLDFInfoFormBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
            _writeOnlyCtx = writeOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<GroupLDFInfoForm> entity, string message)> List(QueryOptions<GroupLDFInfoForm> queryOptions = null)
        {
            return base.List(new QueryOptions<GroupLDFInfoForm>
            {
                IncludeExpression = e => e.Include(x => x.Ngo!).Include(x => x.ForestFcvVcf!),
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
        }

        public async Task<(ExecutionState executionState, GroupLDFInfoForm entity, string message)> GetDetails(long id, bool includeAll = false)
        {
            IQueryable<GroupLDFInfoForm> query = _readOnlyCtx.Set<GroupLDFInfoForm>();
            if (includeAll)
            {
                query = query.Include(x => x.Ngo!);
                query = query.Include(x => x.ForestCircle);
                query = query.Include(x => x.ForestDivision);
                query = query.Include(x => x.ForestRange);
                query = query.Include(x => x.ForestBeat);
                query = query.Include(x => x.ForestFcvVcf);
                query = query.Include(x => x.District);
                query = query.Include(x => x.Division);
                query = query.Include(x => x.Upazilla);
                query = query.Include(x => x.Union);
            }
            var result = await query.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null) return (ExecutionState.Failure, null!, "Entity not found");

            var members = await _readOnlyCtx.Set<GroupLDFInfoFormMember>()
                .Where(x => x.GroupLDFInfoFormId == id)
                .Include(x => x.IndividualLDFInfoForm!.Survey)
                .ToListAsync();
            result.GroupLDFInfoFormMembers = members;

            return (ExecutionState.Retrieved, result, "Returned successfully");
        }

        public override Task<(ExecutionState executionState, GroupLDFInfoForm entity, string message)> CreateAsync(GroupLDFInfoForm entity)
        {
            entity.TotalMember = entity.GroupLDFInfoFormMembers?.Count ?? 0;
            entity.SubmittedDate = DateTime.Now;
            entity.SubmittedById = entity.CreatedBy;

            return base.CreateAsync(entity);
        }

        public async Task<(ExecutionState executionState, IList<GroupLDFInfoForm> entity, string message)> ListByFilter(GroupLDFInfoFormFilterVM filter)
        {
            try
            {
                IQueryable<GroupLDFInfoForm> query = _readOnlyCtx.Set<GroupLDFInfoForm>()
                    .OrderByDescending(x => x.Id);

                // Forest Administration
                query = query.WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId);
                query = query.WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId);
                query = query.WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId);
                query = query.WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId);
                query = query.WhereIf(filter.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestFcvVcfId);

                // Civil Administration
                query = query.WhereIf(filter.HasDivisionId, x => x.DivisionId == filter.DivisionId);
                query = query.WhereIf(filter.HasDistrictId, x => x.DistrictId == filter.DistrictId);
                query = query.WhereIf(filter.HasUpazillaId, x => x.UpazillaId == filter.UpazillaId);
                query = query.WhereIf(filter.HasUnionId, x => x.UnionId == filter.UnionId);

                // Others
                query = query.WhereIf(filter.HasNgoId, x => x!.NgoId == filter.NgoId);
                query = query.WhereIf(filter.HasTotalMember, x => x!.TotalMember == filter.TotalMember);
                query = query.WhereIf(filter.HasFromDate, x => x!.SubmittedDate >= filter.FromDate);
                query = query.WhereIf(filter.HasToDate, x => x!.SubmittedDate <= filter.ToDate);

                if (filter.HasTake)
                {
                    query = query.Take(filter.Take ?? Defaults.Take);
                }

                var result = await query
                    .Include(x => x.Ngo!)
                    .Include(x => x.ForestFcvVcf!)
                    .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<GroupLDFInfoForm>()!, "Unexpected error occurred.");
            }
        }

        public async override Task<(ExecutionState executionState, GroupLDFInfoForm entity, string message)> UpdateAsync(GroupLDFInfoForm entity)
        {
            IDbContextTransaction? transaction = null;

            try
            {
                var result = await _readOnlyCtx.Set<GroupLDFInfoForm>()
                    .Where(x => x.Id == entity.Id)
                    .Select(x => new { x.SubmittedById, x.SubmittedDate })
                    .FirstOrDefaultAsync();
                if (result is null) return (ExecutionState.Failure, null!, "Entity not found");

                entity.TotalMember = entity.GroupLDFInfoFormMembers?.Count ?? 0;
                entity.SubmittedById = result.SubmittedById;
                entity.SubmittedDate = result.SubmittedDate;

                transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

                // Remove unselected member
                if (entity.GroupLDFInfoFormMembers is not null)
                {
                    var previous = await _readOnlyCtx.Set<GroupLDFInfoFormMember>()
                        .Where(x => entity.GroupLDFInfoFormMembers.Select(z => z.Id).Contains(x.Id) == false)
                        .ToListAsync();

                    foreach (var item in previous)
                    {
                        item.IsDeleted = true;
                        item.IsActive = false;
                    }

                    _writeOnlyCtx.Set<GroupLDFInfoFormMember>().UpdateRange(previous);
                }

                // New member
                foreach (var item in entity.GroupLDFInfoFormMembers ?? Enumerable.Empty<GroupLDFInfoFormMember>())
                {
                    item.IsActive = true;
                    item.IsDeleted = false;
                }

                _writeOnlyCtx.Set<GroupLDFInfoForm>().Update(entity);
                await _writeOnlyCtx.SaveChangesAsync();
                transaction?.Commit();

                return (ExecutionState.Updated, entity, "Updated");
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                return (ExecutionState.Failure, null!, ex.Message);
            }
        }
    }
}
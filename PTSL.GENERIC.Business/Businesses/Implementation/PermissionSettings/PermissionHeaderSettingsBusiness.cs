using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.PermissionSettings;
using PTSL.GENERIC.Common.Entity.PermissionSettings;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using System.Web;

namespace PTSL.GENERIC.Business.Businesses.Implementation.PermissionSettings
{
    public class PermissionHeaderSettingsBusiness : BaseBusiness<PermissionHeaderSettings>, IPermissionHeaderSettingsBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyContext;
        public PermissionHeaderSettingsBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyContext)
            : base(unitOfWork)
        {
            _readOnlyContext = readOnlyContext;
        }

        public override Task<(ExecutionState executionState, IQueryable<PermissionHeaderSettings> entity, string message)> List(QueryOptions<PermissionHeaderSettings> queryOptions = null)
        {
            return base.List(new QueryOptions<PermissionHeaderSettings>()
            {
                IncludeExpression = e => e.Include(x => x.UserRole!)
                .Include(x=>x.PermissionRowSettings!)
                .Include(x => x.User!)
                .Include(x=>x.Accesslist!),
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            });
        }

        public async Task<(ExecutionState executionState, List<PermissionHeaderSettings> entity, string message)> GetPermissionHeaderSettingsByModuleEnumId(long moduleEnumId)
        {
            try
            {
                var query = _readOnlyContext.Set<PermissionHeaderSettings>()
                   .Where(x => ((long)x.ModuleEnumId!) == moduleEnumId && x.IsDeleted == false && x.IsActive == true)
                   .Include(x => x.PermissionRowSettings!.Where(x => x.IsActive == true && x.IsDeleted == false))
                   .OrderByDescending(x => x.Id)
                   .AsQueryable();

                //if (query != null)
                //{
                //    query = query.Where(x => (long)x.AccesslistId  == moduleEnumId);
                //}

                //query = query.Include(y => y.Ngo).OrderByDescending(x => x.Id);

                var result = await query
                    .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<PermissionHeaderSettings>()!, "Unexpected error occurred.");
            }
        }

        public override Task<(ExecutionState executionState, PermissionHeaderSettings entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<PermissionHeaderSettings>
            {
                IncludeExpression = x => x
                    .Include(x => x.ForestCircle!)
                    .Include(x => x.ForestDivision!)
                    .Include(x => x.ForestRange!)
                    .Include(x => x.ForestBeat!)
                    .Include(x => x.ForestFcvVcf!)
                    .Include(x => x.UserRole!)
                    .Include(x=>x.User!)
                    .Include(x=>x.Accesslist!)
                    .Include(x=>x.PermissionRowSettings!)
                    .ThenInclude(x=>x.User!)
                    .Include(x => x.PermissionRowSettings!)
                    .ThenInclude(x=>x.UserRole!),
                FilterExpression = e => e.Id == id
            };
            return base.GetAsync(filterOptions);
        }


        public async Task<(ExecutionState executionState, List<PermissionHeaderSettings> entity, string message)> GetByFilter(ExecutiveCommitteeFilterVM filterData)
        {
            try
            {
                var query = _readOnlyContext.Set<PermissionHeaderSettings>()
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderByDescending(x => x.Id)
                    .AsQueryable();

                // Forest Administration
                if (filterData?.ForestCircleId != null && filterData?.ForestCircleId > 0)
                {
                    query = query.Where(x => x.ForestCircleId == filterData.ForestCircleId);
                }
                if (filterData?.ForestDivisionId != null && filterData?.ForestDivisionId > 0)
                {
                    query = query.Where(x => x.ForestDivisionId == filterData.ForestDivisionId);
                }
                if (filterData?.ForestRangeId != null && filterData?.ForestRangeId > 0)
                {
                    query = query.Where(x => x.ForestRangeId == filterData.ForestRangeId);
                }
                if (filterData?.ForestBeatId != null && filterData?.ForestBeatId > 0)
                {
                    query = query.Where(x => x.ForestBeatId == filterData.ForestBeatId);
                }

                query = query
                    .Include(x=>x.UserRole!)
                    .Include(y => y.PermissionRowSettings!)
                    .Include(x=>x.User!)
                    .Include(x=>x.Accesslist!)
                    .OrderByDescending(x => x.Id);

                var result = await query
                    .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<PermissionHeaderSettings>()!, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, long data, string message)> GetPermissionHeaderIdByControllerName(string controller)
        {
            try
            {
                controller = HttpUtility.UrlDecode(controller).Trim('/').ToUpper();
                var accessId = await _readOnlyContext.Set<PermissionHeaderSettings>()
                    .Where(x => x.Accesslist!.ControllerName.ToUpper().Equals(controller))
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync();

                return (accessId == default ? ExecutionState.Failure : ExecutionState.Success, accessId, "Success");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, 0, "Failed");
            }
        }
    }
}
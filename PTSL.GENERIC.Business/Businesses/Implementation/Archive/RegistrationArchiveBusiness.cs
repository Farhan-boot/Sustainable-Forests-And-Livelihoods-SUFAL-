using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Archive;
using PTSL.GENERIC.Common.Entity.Archive;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Archive
{
    public class RegistrationArchiveBusiness : BaseBusiness<RegistrationArchive>, IRegistrationArchiveBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public RegistrationArchiveBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx context)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = context;
        }
        public override Task<(ExecutionState executionState, RegistrationArchive entity, string message)> GetAsync(long id)
        {
            var filterOptions = new FilterOptions<RegistrationArchive>
            {
                IncludeExpression = x => x
                    .Include(x => x.RegistrationArchiveFiles)
                    .Include(x => x.ForestCircle)
                    .Include(x => x.ForestDivision)
                    .Include(x => x.ForestRange)
                    .Include(x => x.ForestBeat)
                    .Include(x => x.ForestFcvVcf)
                    .Include(x => x.Division)
                    .Include(x => x.District)
                    .Include(x => x.Upazilla)
                    .Include(x => x.Union),

                FilterExpression = e => e.Id == id
            };

            return base.GetAsync(filterOptions);
        }


        public async Task<(ExecutionState executionState, List<RegistrationArchive> entity, string message)> GetRegistrationArchiveByFilter(MeetingFilterVM filterData)
        {
            try
            {
                var query = _readOnlyCtx.Set<RegistrationArchive>()
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
                if (filterData?.ForestFcvVcfId != null && filterData?.ForestFcvVcfId > 0)
                {
                    query = query.Where(x => x.ForestFcvVcfId == filterData.ForestFcvVcfId);
                }


                // Civil Administration
                if (filterData?.DivisionId != null && filterData?.DivisionId > 0)
                {
                    query = query.Where(x => x.DivisionId == filterData.DivisionId);
                }
                if (filterData?.DistrictId != null && filterData?.DistrictId > 0)
                {
                    query = query.Where(x => x.DistrictId == filterData.DistrictId);
                }
                if (filterData?.UpazillaId != null && filterData?.UpazillaId > 0)
                {
                    query = query.Where(x => x.UpazillaId == filterData.UpazillaId);
                }
                if (filterData?.UnionId != null && filterData?.UnionId > 0)
                {
                    query = query.Where(x => x.UnionId == filterData.UnionId);
                }


                ////Extra Filter

                query = query.OrderByDescending(x => x.Id);



                var result = await query
                    .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<RegistrationArchive>()!, "Unexpected error occurred.");
            }
        }



    }
}
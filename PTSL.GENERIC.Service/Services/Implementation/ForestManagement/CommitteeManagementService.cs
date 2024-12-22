using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.ForestManagement
{
    public class CommitteeManagementService : BaseService<CommitteeManagementVM, CommitteeManagement>, ICommitteeManagementService
    {
        public IMapper _mapper;
        private readonly ICommitteeManagementBusiness _business;

        public CommitteeManagementService(ICommitteeManagementBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
            _business = business;
        }

        public override CommitteeManagement CastModelToEntity(CommitteeManagementVM model)
        {
            return _mapper.Map<CommitteeManagement>(model);
        }

        public override CommitteeManagementVM CastEntityToModel(CommitteeManagement entity)
        {
            return _mapper.Map<CommitteeManagementVM>(entity);
        }

        public override IList<CommitteeManagementVM> CastEntityToModel(IQueryable<CommitteeManagement> entity)
        {
            return _mapper.Map<IList<CommitteeManagementVM>>(entity).ToList();
        }


        public List<CommitteeManagementVM> CastEntityListToModel(List<CommitteeManagement> entity)
        {
            return _mapper.Map<List<CommitteeManagementVM>>(entity);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<CommitteeManagementVM> entity, string message)> GetByFilter(ExecutiveCommitteeFilterVM filter)
        {
            var result = await _business.GetByFilter(filter);

            if (result.entity is not null)
            {
                //return (result.executionState, CastEntityListToModel(result.entity), result.message);
                return (result.executionState, _mapper.Map<PaginationResutl<CommitteeManagementVM>>(result.entity), result.message);

            }

            return (result.executionState, new PaginationResutl<CommitteeManagementVM>(), result.message);
        }
    }
}
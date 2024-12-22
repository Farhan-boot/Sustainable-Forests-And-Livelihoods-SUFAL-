using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.CipManagement;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.CipManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Common.Model.CustomModel;

namespace PTSL.GENERIC.Service.Services.CipManagement
{
    public class CipTeamService : BaseService<CipTeamVM, CipTeam>, ICipTeamService
    {
        public IMapper _mapper;
        private readonly ICipTeamBusiness _business;
        public CipTeamService(ICipTeamBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
            _business = business;
        }

        public override CipTeam CastModelToEntity(CipTeamVM model)
        {
            return _mapper.Map<CipTeam>(model);
        }

        public override CipTeamVM CastEntityToModel(CipTeam entity)
        {
            return _mapper.Map<CipTeamVM>(entity);
        }

        public override IList<CipTeamVM> CastEntityToModel(IQueryable<CipTeam> entity)
        {
            return _mapper.Map<IList<CipTeamVM>>(entity).ToList();
        }


        public PaginationResutl<CipTeamVM> CastEntityListToModel(PaginationResutl<CipTeam> entity)
        {
           
            return _mapper.Map<PaginationResutl<CipTeamVM>>(entity);
        }


        public async Task<(ExecutionState executionState, PaginationResutl<CipTeamVM> entity, string message)> GetByFilter(ExecutiveCommitteeFilterVM filter)
        {
            var result = await _business.GetByFilter(filter);

            if (result.entity is not null)
            {
                return (result.executionState, CastEntityListToModel(result.entity), result.message);

            }

            return (result.executionState, new PaginationResutl<CipTeamVM>(), result.message);
        }

    }
}
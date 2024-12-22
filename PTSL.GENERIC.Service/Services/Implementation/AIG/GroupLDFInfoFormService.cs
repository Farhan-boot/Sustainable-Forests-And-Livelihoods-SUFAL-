using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public class GroupLDFInfoFormService : BaseService<GroupLDFInfoFormVM, GroupLDFInfoForm>, IGroupLDFInfoFormService
    {
        private readonly IGroupLDFInfoFormBusiness _business;
        public IMapper _mapper;

        public GroupLDFInfoFormService(IGroupLDFInfoFormBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override GroupLDFInfoForm CastModelToEntity(GroupLDFInfoFormVM model)
        {
            return _mapper.Map<GroupLDFInfoForm>(model);
        }

        public override GroupLDFInfoFormVM CastEntityToModel(GroupLDFInfoForm entity)
        {
            return _mapper.Map<GroupLDFInfoFormVM>(entity);
        }

        public override IList<GroupLDFInfoFormVM> CastEntityToModel(IQueryable<GroupLDFInfoForm> entity)
        {
            return _mapper.Map<IList<GroupLDFInfoFormVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, GroupLDFInfoFormVM entity, string message)> GetDetails(long id, bool includeAll = false)
        {
            var result = await _business.GetDetails(id, includeAll);
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, entity: CastEntityToModel(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }

        public async Task<(ExecutionState executionState, List<GroupLDFInfoFormVM> entity, string message)> ListByFilter(GroupLDFInfoFormFilterVM filter)
        {
            var result = await _business.ListByFilter(filter);
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, entity: _mapper.Map<List<GroupLDFInfoFormVM>>(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }
    }
}
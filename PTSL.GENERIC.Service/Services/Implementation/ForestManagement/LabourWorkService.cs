using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.Labour;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Service.BaseServices;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Labour
{
    public class LabourWorkService : BaseService<LabourWorkVM, LabourWork>, ILabourWorkService
    {
        private readonly ILabourWorkBusiness _business;
        public IMapper _mapper;

        public LabourWorkService(ILabourWorkBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override LabourWork CastModelToEntity(LabourWorkVM model)
        {
            return _mapper.Map<LabourWork>(model);
        }

        public override LabourWorkVM CastEntityToModel(LabourWork entity)
        {
            return _mapper.Map<LabourWorkVM>(entity);
        }

        public override IList<LabourWorkVM> CastEntityToModel(IQueryable<LabourWork> entity)
        {
            return _mapper.Map<IList<LabourWorkVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, List<LabourWorkVM> entity, string message)> ListByFilter(LabourWorkFilterVM filter)
        {
            var result = await _business.ListByFilter(filter);

            return (result.executionState, _mapper.Map<List<LabourWorkVM>>(result.entity), result.message);
        }
    }
}
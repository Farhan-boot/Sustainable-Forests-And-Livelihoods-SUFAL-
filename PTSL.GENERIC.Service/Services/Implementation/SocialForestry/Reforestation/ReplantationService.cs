using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Reforestation
{
    public class ReplantationService : BaseService<ReplantationVM, Replantation>, IReplantationService
    {
        private readonly IReplantationBusiness _business;
        public IMapper _mapper;

        public ReplantationService(IReplantationBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override Replantation CastModelToEntity(ReplantationVM model)
        {
            return _mapper.Map<Replantation>(model);
        }

        public override ReplantationVM CastEntityToModel(Replantation entity)
        {
            return _mapper.Map<ReplantationVM>(entity);
        }

        public override IList<ReplantationVM> CastEntityToModel(IQueryable<Replantation> entity)
        {
            return _mapper.Map<IList<ReplantationVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, ReplantationVM data, string message)> GetDetails(long id)
        {
            var result = await _business.GetDetails(id);
            return (result.executionState, _mapper.Map<ReplantationVM>(result.data), result.message);
        }
    }
}
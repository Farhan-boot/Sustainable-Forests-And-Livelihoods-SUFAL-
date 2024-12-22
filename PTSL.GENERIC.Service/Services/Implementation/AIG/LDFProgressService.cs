using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public class LDFProgressService : BaseService<LDFProgressVM, LDFProgress>, ILDFProgressService
    {
        public IMapper _mapper;

        public LDFProgressService(ILDFProgressBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override LDFProgress CastModelToEntity(LDFProgressVM model)
        {
            return _mapper.Map<LDFProgress>(model);
        }

        public override LDFProgressVM CastEntityToModel(LDFProgress entity)
        {
            return _mapper.Map<LDFProgressVM>(entity);
        }

        public override IList<LDFProgressVM> CastEntityToModel(IQueryable<LDFProgress> entity)
        {
            return _mapper.Map<IList<LDFProgressVM>>(entity).ToList();
        }
    }
}
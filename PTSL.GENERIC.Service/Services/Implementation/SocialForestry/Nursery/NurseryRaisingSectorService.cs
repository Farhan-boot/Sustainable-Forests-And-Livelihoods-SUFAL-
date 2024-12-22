using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Nursery
{
    public class NurseryRaisingSectorService : BaseService<NurseryRaisingSectorVM, NurseryRaisingSector>, INurseryRaisingSectorService
    {
        public IMapper _mapper;

        public NurseryRaisingSectorService(INurseryRaisingSectorBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override NurseryRaisingSector CastModelToEntity(NurseryRaisingSectorVM model)
        {
            return _mapper.Map<NurseryRaisingSector>(model);
        }

        public override NurseryRaisingSectorVM CastEntityToModel(NurseryRaisingSector entity)
        {
            return _mapper.Map<NurseryRaisingSectorVM>(entity);
        }

        public override IList<NurseryRaisingSectorVM> CastEntityToModel(IQueryable<NurseryRaisingSector> entity)
        {
            return _mapper.Map<IList<NurseryRaisingSectorVM>>(entity).ToList();
        }
    }
}
using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.TransactionMangement;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;
using PTSL.GENERIC.Service.BaseServices;

using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.TransactionMangement
{
    public class FundTypeService : BaseService<FundTypeVM, FundType>, IFundTypeService
    {
        public IMapper _mapper;

        public FundTypeService(IFundTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override FundType CastModelToEntity(FundTypeVM model)
        {
            return _mapper.Map<FundType>(model);
        }

        public override FundTypeVM CastEntityToModel(FundType entity)
        {
            return _mapper.Map<FundTypeVM>(entity);
        }

        public override IList<FundTypeVM> CastEntityToModel(IQueryable<FundType> entity)
        {
            return _mapper.Map<IList<FundTypeVM>>(entity).ToList();
        }
    }
}

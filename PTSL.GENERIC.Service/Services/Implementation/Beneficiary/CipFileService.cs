using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public class CipFileService : BaseService<CipFileVM, CipFile>, ICipFileService
    {
        public IMapper _mapper;

        public CipFileService(ICipFileBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override CipFile CastModelToEntity(CipFileVM model)
        {
            return _mapper.Map<CipFile>(model);
        }

        public override CipFileVM CastEntityToModel(CipFile entity)
        {
            return _mapper.Map<CipFileVM>(entity);
        }

        public override IList<CipFileVM> CastEntityToModel(IQueryable<CipFile> entity)
        {
            return _mapper.Map<IList<CipFileVM>>(entity).ToList();
        }
    }
}
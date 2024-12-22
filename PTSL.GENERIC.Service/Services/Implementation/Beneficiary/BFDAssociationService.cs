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
    public class BFDAssociationService : BaseService<BFDAssociationVM, BFDAssociation>, IBFDAssociationService
    {
        public IMapper _mapper;

        public BFDAssociationService(IBFDAssociationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override BFDAssociation CastModelToEntity(BFDAssociationVM model)
        {
            try
            {
                return _mapper.Map<BFDAssociation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override BFDAssociationVM CastEntityToModel(BFDAssociation entity)
        {
            try
            {
                var model = _mapper.Map<BFDAssociationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<BFDAssociationVM> CastEntityToModel(IQueryable<BFDAssociation> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<BFDAssociationVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

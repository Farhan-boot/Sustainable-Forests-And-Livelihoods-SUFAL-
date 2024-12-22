using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.Labour;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Labour;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Labour
{
    public class OtherLabourMemberService : BaseService<OtherLabourMemberVM, OtherLabourMember>, IOtherLabourMemberService
    {
        private readonly IOtherLabourMemberBusiness _business;
        public IMapper _mapper;

        public OtherLabourMemberService(IOtherLabourMemberBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override OtherLabourMember CastModelToEntity(OtherLabourMemberVM model)
        {
            try
            {
                return _mapper.Map<OtherLabourMember>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override OtherLabourMemberVM CastEntityToModel(OtherLabourMember entity)
        {
            try
            {
                var model = _mapper.Map<OtherLabourMemberVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<OtherLabourMemberVM> CastEntityToModel(IQueryable<OtherLabourMember> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<OtherLabourMemberVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

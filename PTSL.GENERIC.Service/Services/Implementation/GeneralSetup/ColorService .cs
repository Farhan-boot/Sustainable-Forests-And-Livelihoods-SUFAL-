using AutoMapper;
using PTSL.GENERIC.Business;
using PTSL.GENERIC.Business.Businesses;
using PTSL.GENERIC.Business.Businesses.Implementation;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface;
using PTSL.GENERIC.Service.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services
{
    public class ColorService : BaseService<ColorVM, Color>, IColorService
    {
        public readonly IColorBusiness _ColorBusiness;
        public IMapper _mapper;
        public ColorService(IColorBusiness ColorBusiness, IMapper mapper) : base(ColorBusiness)
        {
            _ColorBusiness = ColorBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override Color CastModelToEntity(ColorVM model)
        {
            try
            {
                return _mapper.Map<Color>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override ColorVM CastEntityToModel(Color entity)
        {
            try
            {
                ColorVM model = _mapper.Map<ColorVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<ColorVM> CastEntityToModel(IQueryable<Color> entity)
        {
            try
            {
                //IQueryable<CategoryVM> CategoryList = _mapper.Map<IQueryable<CategoryVM>>(entity).ToList();
                IList<ColorVM> ColorList = _mapper.Map<IList<ColorVM>>(entity).ToList();
                return ColorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

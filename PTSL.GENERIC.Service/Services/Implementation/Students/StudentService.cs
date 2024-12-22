using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Business.Businesses.Interface.Market;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Students;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.Students;
using PTSL.GENERIC.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Students
{
    public class StudentService : BaseService<StudentVM, Student>, IStudentService
    {
        public IMapper _mapper;

        public StudentService(IStudentBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override Student CastModelToEntity(StudentVM model)
        {
            try
            {
                return _mapper.Map<Student>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override StudentVM CastEntityToModel(Student entity)
        {
            try
            {
                var model = _mapper.Map<StudentVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<StudentVM> CastEntityToModel(IQueryable<Student> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<StudentVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

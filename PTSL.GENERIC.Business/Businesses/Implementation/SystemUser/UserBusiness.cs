using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.SystemUser;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.Common.QuerySerialize.Interfaces;
using PTSL.GENERIC.DAL.Repositories.Interface;
using PTSL.GENERIC.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace PTSL.GENERIC.Business.Businesses.Implementation
{
    public class UserBusiness : BaseBusiness<User>, IUserBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public UserBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyCtx = readOnlyCtx;
            _writeOnlyCtx = writeOnlyCtx;
        }

        //Implement System Busniess Logic here
        public async Task<(ExecutionState executionState, User entity, string message)> UserLogin(LoginVM model)
        {
            (ExecutionState executionState, User entity, string message) returnResponse;

            //(ExecutionState executionState, User entity, string message) entityObject = await _unitOfWork.users.UserLogin(model);

            FilterOptions<User> filterOptions = new FilterOptions<User>();
            filterOptions.FilterExpression = x => x.UserEmail.ToLower() == model.UserEmail.ToLower() && x.UserPassword == model.UserPassword;

            (ExecutionState executionState, User entity, string message) entityObject = await _unitOfWork.users.GetAsync(filterOptions, RetrievalPurpose.Consumption);

            if (entityObject.entity != null)
            {
                returnResponse = entityObject;
            }
            else
            {
                returnResponse = entityObject;
            }

            return returnResponse;
        }

        //public async Task<(ExecutionState executionState, User entity, string message)> UserLists()
        //{
        //    (ExecutionState executionState, User entity, string message) returnResponse;

        //    //(ExecutionState executionState, User entity, string message) entityObject = await _unitOfWork.users.UserLogin(model);

        //    FilterOptions<User> filterOptions = new FilterOptions<User>();
        //    filterOptions.FilterExpression = x => x.IsActive == true && x.IsDeleted == false;

        //    (ExecutionState executionState, User entity, string message) entityObject = await _unitOfWork.users.GetAsync(filterOptions, RetrievalPurpose.Consumption);

        //    if (entityObject.entity != null)
        //    {
        //        returnResponse = entityObject;
        //    }
        //    else
        //    {
        //        returnResponse = entityObject;
        //    }

        //    return returnResponse;
        //}
        public override async Task<(ExecutionState executionState, IQueryable<User> entity, string message)> List(QueryOptions<User> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<User> entity, string message) returnResponse;

            queryOptions = new QueryOptions<User>();
            queryOptions.IncludeExpression = x => x.Include(i => i.UserRole!);
            queryOptions.FilterExpression = x => x.SurveyId < 0 || x.SurveyId == null;

            (ExecutionState executionState, IQueryable<User> entity, string message) entityObject = await _unitOfWork.List<User>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, User entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, User entity, string message) returnResponse;

            FilterOptions<User> filterOptions = new FilterOptions<User>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.UserRole!)
            .Include(x=>x.BankAccountsInformations)
            .Include(x=>x.ForestCircle)
            .Include(x=>x.ForestDivision)
            .Include(x=>x.ForestRange)
            .Include(x=>x.ForestBeat)
            .Include(x=>x.ForestFcvVcf)
            .Include(x=>x.Division)
            .Include(x=>x.District)
            .Include(x=>x.Upazilla)
            .Include(x=>x.Union);


            (ExecutionState executionState, User entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

            if (entityObject.entity != null)
            {
                returnResponse = entityObject;
            }
            else
            {
                returnResponse = entityObject;
            }


            return returnResponse;
        }

        public override Task<(ExecutionState executionState, User entity, string message)> CreateAsync(User entity)
        {
            entity.UserType = entity.SurveyId.HasValue && entity.SurveyId > 0
                ? UserType.Beneficiary
                : UserType.Admin;

            return base.CreateAsync(entity);
        }

        public async Task<(ExecutionState executionState, IList<User> entity, string message)> GetBeneficiaryByFilter(BeneficiaryUserFilterVM filter)
        {
            try
            {
                IQueryable<User> query = _readOnlyCtx.Set<User>();

                // Common
                query = query.WhereIf(filter.HasGender, x => x.Survey!.BeneficiaryGender == filter.Gender);
                query = query.WhereIf(filter.HasPhoneNumber, x => x.Survey!.BeneficiaryPhone == filter.PhoneNumber);
                query = query.WhereIf(filter.HasNID, x => x.Survey!.BeneficiaryNid == filter.NID);
                query = query.WhereIf(filter.HasEthnicityId, x => x.Survey!.BeneficiaryEthnicityId == filter.EthnicityId);
                query = query.WhereIf(filter.HasNgoId, x => x.Survey!.NgoId == filter.NgoId);
                query = query.WhereIf(filter.IsBeneficiaryUser, x => x.SurveyId != null);

                // Forest Location
                query = query.FilterUser(filter);

                query = query.OrderByDescending(x => x.Id);

                var result = await query
                    .Include(x => x.Survey)
                    .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<User>()!, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, IList<User> entity, string message)> ListSurveyAccounts(int takeLatest = 50)
        {
            try
            {
                var users = await _readOnlyCtx.Set<User>()
                    .Where(x => x.SurveyId > 0)
                    .OrderByDescending(x => x.Id)
                    .Take(takeLatest)
                    .Include(x => x.Survey)
                    .ToListAsync();

                return (ExecutionState.Retrieved, users, "");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<User>(), "Unexpected error occurred.");
            }
        }

        //GetUserNameByUserRoleId
        public async Task<(ExecutionState executionState, List<User> entity, string message)> GetUserNameByUserRoleId(long userRoleId)
        {
            try
            {
                var query = _readOnlyCtx.Set<User>()
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderByDescending(x => x.Id)
                    .AsQueryable();

                //Extra Filter
                if (query != null)
                {
                    query = query.Where(x => x.UserRoleId == (long)userRoleId);
                }

                query = query?.OrderByDescending(x => x.Id);

                var result = await query
                    .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<User>()!, "Unexpected error occurred.");
            }
        }

        public async Task<(ExecutionState executionState, List<User> entity, string message)> GetFilterByForestId(ExecutiveCommitteeFilterVM filterData)
        {
            try
            {
                var query = _readOnlyCtx.Set<User>()
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderByDescending(x => x.Id)
                    .AsQueryable();

                // Forest Administration
                if (filterData?.ForestCircleId > 0 && filterData.ForestDivisionId == 0 && filterData.ForestRangeId == 0 && filterData.ForestBeatId == 0 && filterData.ForestFcvVcfId == 0 && filterData.UserRoleId == 0)
                {
                    query = query.Where(x => x.ForestCircleId == filterData.ForestCircleId);
                }

                if (filterData?.ForestCircleId > 0 && filterData.ForestDivisionId > 0 && filterData.ForestRangeId == 0 && filterData.ForestBeatId == 0 && filterData.ForestFcvVcfId == 0 && filterData.UserRoleId == 0)
                {
                    query = query.Where(x => x.ForestCircleId == filterData.ForestCircleId && x.ForestDivisionId == filterData.ForestDivisionId);
                }

                if (filterData?.ForestCircleId > 0 && filterData.ForestDivisionId > 0 && filterData.ForestRangeId > 0 && filterData.ForestBeatId == 0 && filterData.ForestFcvVcfId == 0 && filterData.UserRoleId == 0)
                {
                    query = query.Where(x => x.ForestCircleId == filterData.ForestCircleId && x.ForestDivisionId == filterData.ForestDivisionId && x.ForestRangeId == filterData.ForestRangeId);
                }

                if (filterData?.ForestCircleId > 0 && filterData.ForestDivisionId > 0 && filterData.ForestRangeId > 0 && filterData.ForestBeatId > 0 && filterData.ForestFcvVcfId == 0 && filterData.UserRoleId == 0)
                {
                    query = query.Where(x => x.ForestCircleId == filterData.ForestCircleId && x.ForestDivisionId == filterData.ForestDivisionId && x.ForestRangeId == filterData.ForestRangeId && x.ForestBeatId == filterData.ForestBeatId);
                }

                if (filterData?.ForestCircleId > 0 && filterData.ForestDivisionId > 0 && filterData.ForestRangeId > 0 && filterData.ForestBeatId > 0 && filterData.ForestFcvVcfId > 0 && filterData.UserRoleId == 0)
                {
                    query = query.Where(x => x.ForestCircleId == filterData.ForestCircleId && x.ForestDivisionId == filterData.ForestDivisionId && x.ForestRangeId == filterData.ForestRangeId && x.ForestBeatId == filterData.ForestBeatId && x.ForestFcvVcfId == filterData.ForestFcvVcfId);
                }

                //if (filterData?.ForestCircleId > 0 && filterData.ForestDivisionId > 0 && filterData.ForestRangeId > 0 && filterData.ForestBeatId > 0 && filterData.ForestFcvVcfId > 0 && filterData.UserRoleId > 0)
                //{
                //    query = query.Where(x => x.ForestCircleId == filterData.ForestCircleId && x.ForestDivisionId == filterData.ForestDivisionId && x.ForestRangeId == filterData.ForestRangeId && x.ForestBeatId == filterData.ForestBeatId && x.ForestFcvVcfId == filterData.ForestFcvVcfId && x.UserRoleId == filterData.UserRoleId);
                //}


                if (filterData.UserRoleId == 0)
                {
                    query = query.Include(y => y.PermissionRowSettings).OrderByDescending(x => x.Id);
                }
                else
                {
                    query = query.Where(x => x.UserRoleId == filterData.UserRoleId).Include(y => y.PermissionRowSettings).OrderByDescending(x => x.Id);
                }
                



                var result = await query
                    .ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<User>()!, "Unexpected error occurred.");
            }
        }



        public async Task<(ExecutionState executionState, long entity, string message)> GenerateSurveyAccounts(ForestCivilLocationFilter filter)
        {
            IDbContextTransaction? transaction = null;

            try
            {
                var alreadyExists = await _readOnlyCtx.Set<User>()
                    .FilterUser(filter)
                .Select(x => x.SurveyId)
                    .ToListAsync();

                var duplicateNid = await _readOnlyCtx.Set<Survey>()
                    .GroupBy(e => new { e.BeneficiaryNid, e.Id })
                    .Where(g => g.Count() > 1)
                    .Select(g => g!.Key.Id)
                    .ToListAsync();

                var newSurveys = await _readOnlyCtx.Set<Survey>()
                    .FilterSurvey(filter)
                    .Where(x => alreadyExists.Contains(x.Id) == false)
                    .Where(x => duplicateNid.Contains(x.Id) == false)
                    .Where(x => x.BeneficiaryNid != null || x.BeneficiaryNid != string.Empty)
                    .Select(x => new 
                        {
                            x.Id,
                            x.BeneficiaryName,
                            x.BeneficiaryPhone,
                            x.ForestCircleId,
                            x.ForestDivisionId,
                            x.ForestRangeId,
                            x.ForestBeatId,
                            x.ForestFcvVcfId,
                            x.PresentDistrictId,
                            x.PresentDivisionId,
                            x.PresentUpazillaId,
                            x.PresentUnionNewId,
                            x.BeneficiaryNid,
                        })
                    .ToListAsync();

                transaction = _writeOnlyCtx.Database.BeginTransaction();

                //var pmsGroupId = (long)PmsGroupID.BeneficiaryGroup;
                //var roleName = (await _readOnlyCtx.Set<PmsGroup>().FirstOrDefaultAsync(x => x.Id == pmsGroupId))?.GroupName ?? string.Empty;
                var newUsers = new List<User>();

                foreach (var item in newSurveys)
                {
                    newUsers.Add(new User {
                        SurveyId = item.Id,
                        UserName = item.BeneficiaryName,
                        UserEmail = item.BeneficiaryNid,
                        UserPassword = "123456",
                        UserPhone = item.BeneficiaryPhone,
                        //PmsGroupID = pmsGroupId,
                        //RoleName = roleName,
                        ForestCircleId = item.ForestCircleId,
                        ForestDivisionId = item.ForestDivisionId,
                        ForestRangeId = item.ForestRangeId,
                        ForestBeatId = item.ForestBeatId,
                        ForestFcvVcfId = item.ForestFcvVcfId,
                        DistrictId = item.PresentDistrictId,
                        DivisionId = item.PresentDivisionId,
                        UpazillaId = item.PresentUpazillaId,
                        UnionId = item.PresentUnionNewId,
                        UserType = UserType.Beneficiary
                    });
                }

                await _writeOnlyCtx.Set<User>().AddRangeAsync(newUsers);
                await _writeOnlyCtx.SaveChangesAsync();
                transaction?.Commit();

                return (ExecutionState.Created, newUsers.Count, $"{newUsers.Count} Beneficiary users have been created");
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                return (ExecutionState.Failure, 0, "Unexpected error occurred.");
            }
        }

        public override async Task<(ExecutionState executionState, User entity, string message)> UpdateAsync(User entity)
        {
            if (entity.BankAccountsInformations is not null && entity.BankAccountsInformations.Count > 0)
            {
                var bankAccountIds = entity.BankAccountsInformations.Select(x => x.AccountId).ToArray();
                var exitingAccountCount = await _readOnlyCtx.Set<BankAccountsInformation>()
                    .Where(x => x.UserId == entity.Id && bankAccountIds.Contains(x.AccountId))
                    .CountAsync();

                if (exitingAccountCount > 0)
                {
                    return (ExecutionState.Failure, null!, "Account already added");
                }
            }

            return await base.UpdateAsync(entity);
        }

        /*
        private static readonly Random random = new();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        */

        public async Task<(ExecutionState executionState, List<User> entity, string message)> GetUserInfoByUserRoleId(long userRoleId)
        {
            var result = await _readOnlyCtx.Set<User>().Where(x => x.UserRoleId == userRoleId).ToListAsync();

            return (ExecutionState.Success, result, "Ok");
        }
    }
}

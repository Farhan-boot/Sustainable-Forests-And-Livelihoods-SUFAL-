using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation
{
    public class DistrictBusiness : BaseBusiness<District>, IDistrictBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public DistrictBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<(ExecutionState executionState, District entity, string message)> CreateAsync(District entity)
        {
            (ExecutionState executionState, District entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<District> filterOptions = new FilterOptions<District>();
                    filterOptions.FilterExpression = x => x.Name.Trim() == entity.Name.Trim();
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success" || entity?.Name.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(District).Name} name already exists.");
                        return createResponse;
                    }

                    (ExecutionState executionState, District entity, string message) createdResponse = await UoW.CreateAsync<District>(entity);

                    if (createdResponse.executionState == ExecutionState.Failure)
                    {
                        if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid validTransactionGuid))
                        {
                            UoW.Complete(transaction, CompletionState.Failure);
                        }

                        createResponse = createdResponse;
                    }
                    else
                    {
                        (ExecutionState executionState, string message) saveResponse = await UoW.SaveAsync(transaction);

                        bool success = (saveResponse.executionState == ExecutionState.Success);

                        #region Post validation
                        if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                        {
                            UoW.Complete(transaction, success ? CompletionState.Success : CompletionState.Failure);

                            createResponse = success ?
                                        createdResponse :
                                        (executionState: saveResponse.executionState, entity: null, message: saveResponse.message);

                        }
                        else
                        {
                            createResponse = (executionState: ExecutionState.Failure, entity: null, message: "Transaction not found.");
                        }
                        #endregion
                    }
                }
                catch
                {
                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, CompletionState.Failure);
                    }

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(District).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, District entity, string message)> UpdateAsync(District entity)
        {
            (ExecutionState executionState, District entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<District> filterOptions = new FilterOptions<District>();
                    filterOptions.FilterExpression = x => x.Name.Trim() == entity.Name.Trim() && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(District).Name} name already exists.");
                        return updateResponse;
                    }

                    (ExecutionState executionState, District entity, string message) updatedEntity = await UoW.UpdateAsync<District>(entity);

                    (ExecutionState executionState, string message) saveResponse = await UoW.SaveAsync(transaction);

                    bool success = saveResponse.executionState == ExecutionState.Success;

                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, success ? CompletionState.Success : CompletionState.Failure);

                        updateResponse = success ? updatedEntity : (executionState: saveResponse.executionState, entity: null, message: saveResponse.message);

                    }
                    else
                    {
                        updateResponse = (executionState: ExecutionState.Failure, entity: null, message: "Transaction not found.");
                    }
                }
                catch
                {
                    if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                    {
                        UoW.Complete(transaction, CompletionState.Failure);
                    }

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(District).Name} update.");
                }
            }

            return updateResponse;
        }


        public override async Task<(ExecutionState executionState, IQueryable<District> entity, string message)> List(QueryOptions<District> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<District> entity, string message) returnResponse;

            queryOptions = new QueryOptions<District>();
            queryOptions.IncludeExpression = e => e.Include(x => x.Division);
            queryOptions.SortingExpression = x => x.OrderByDescending(y => y.Id);
                       (ExecutionState executionState, IQueryable<District> entity, string message) entityObject = await _unitOfWork.List<District>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, District entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, District entity, string message) returnResponse;

            FilterOptions<District> filterOptions = new FilterOptions<District>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(y => y.Division);
            (ExecutionState executionState, District entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);

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

        public override async Task<(ExecutionState executionState, string message)> DoesExistAsync(long id)
        {

            (ExecutionState executionState, string message) returnResponse;

            FilterOptions<District> filterOptions = new FilterOptions<District>();
            filterOptions.FilterExpression = x => x.Id == id;
            (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
            returnResponse = entityObject;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }
            return returnResponse;
        }

        public async Task<(ExecutionState executionState, IQueryable<District> entity, string message)> ListByDivision(long DivisionId)
        {
            var queryOptions = new QueryOptions<District>();
            queryOptions.FilterExpression = e => e.DivisionId == DivisionId;

            return await base.List(queryOptions);
        }
    }
}

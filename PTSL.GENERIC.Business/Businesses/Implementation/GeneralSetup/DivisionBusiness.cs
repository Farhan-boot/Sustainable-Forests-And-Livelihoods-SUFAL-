using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.Common.QuerySerialize.Interfaces;
using PTSL.GENERIC.DAL.Repositories.Interface;
using PTSL.GENERIC.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation
{
    public class DivisionBusiness : BaseBusiness<Division>, IDivisionBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public DivisionBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<Division> entity, string message)> List(QueryOptions<Division> queryOptions = null)
        {
            queryOptions = new QueryOptions<Division>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }

        public override async Task<(ExecutionState executionState, Division entity, string message)> CreateAsync(Division entity)
        {
            (ExecutionState executionState, Division entity, string message) createResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<Division> filterOptions = new FilterOptions<Division>();
                    filterOptions.FilterExpression = x => x.Name.Trim() == entity.Name.Trim();
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success" || entity?.Name.Trim() == "")
                    {
                        createResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(Division).Name} name already exists.");
                        return createResponse;
                    }

                    (ExecutionState executionState, Division entity, string message) createdResponse = await UoW.CreateAsync<Division>(entity);

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

                    createResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(Division).ToString()} creation.");
                }
            }
            //}

            return createResponse;
        }

        public override async Task<(ExecutionState executionState, Division entity, string message)> UpdateAsync(Division entity)
        {
            (ExecutionState executionState, Division entity, string message) updateResponse;

            await using (IDbContextTransaction transaction = UoW.Begin())
            {
                try
                {
                    FilterOptions<Division> filterOptions = new FilterOptions<Division>();
                    filterOptions.FilterExpression = x => x.Name.Trim() == entity.Name.Trim() && x.Id != entity.Id;
                    (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
                    if (entityObject.executionState.ToString() == "Success")
                    {
                        updateResponse = (executionState: ExecutionState.Success, entity: null, message: $"{typeof(Division).Name} name already exists.");
                        return updateResponse;
                    }

                    (ExecutionState executionState, Division entity, string message) updatedEntity = await UoW.UpdateAsync<Division>(entity);

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

                    updateResponse = (executionState: ExecutionState.Failure, entity: null, message: $"Problem on {typeof(Division).Name} update.");
                }
            }

            return updateResponse;
        }


        public override async Task<(ExecutionState executionState, Division entity, string message)> GetAsync(long id)
        {
            (ExecutionState executionState, Division entity, string message) returnResponse;

            FilterOptions<Division> filterOptions = new FilterOptions<Division>();
            filterOptions.FilterExpression = x => x.Id == id;
            filterOptions.IncludeExpression = x => x.Include(i => i.Districts);
            (ExecutionState executionState, Division entity, string message) entityObject = await _unitOfWork.GetAsync(filterOptions);
            //foreach(var data in entityObject.entity.Districts)
            //{
            //    data.Division = null; 
            //}
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
            filterOptions.FilterExpression = x => x.DivisionId == id;
            (ExecutionState executionState, string message) entityObject = await _unitOfWork.DoesExistAsync(filterOptions);
            returnResponse = entityObject;
            if (returnResponse.executionState.ToString() == "Success")
            {
                return returnResponse;
            }


            return returnResponse;
        }

    }
}

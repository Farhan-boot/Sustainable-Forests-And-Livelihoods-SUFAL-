using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Cutting
{
    public class ShareDistributionBusiness : BaseBusiness<ShareDistribution>, IShareDistributionBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public ShareDistributionBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public async Task<(ExecutionState executionState, List<ShareDistribution> data, string message)> ListByCuttingPlantation(long cuttingPlantationId)
        {
            var sharePercentage = await _readOnlyCtx.Set<ShareDistribution>()
                .Where(x => x.CuttingPlantationId == cuttingPlantationId)
                .ToListAsync();

            return (ExecutionState.Success, sharePercentage, "Success");
        }

        public async Task<(ExecutionState executionState, DefaultDistributionDataVM data, string message)> GetDefaultDistributionData(long cuttingPlantationId)
        {
            var cuttingInfo = await _readOnlyCtx.Set<CuttingPlantation>()
                .Where(x => x.Id == cuttingPlantationId)
                .Include(x => x.NewRaisedPlantation)
                .Include(x => x.Realizations!).ThenInclude(x => x.LotWiseSellingInformation)
                .Select(x => new { x.NewRaisedPlantation, x.Realizations, x.NewRaisedPlantationId })
                .AsSplitQuery()
                .FirstOrDefaultAsync();
            if (cuttingInfo is null || cuttingInfo.NewRaisedPlantation is null)
            {
                return (ExecutionState.Failure, null!, "Felling information not found");
            }

            var percentage = await _readOnlyCtx.Set<DistributionPercentage>()
                .Where(x => x.PlantationTypeId == cuttingInfo.NewRaisedPlantation.PlantationTypeId)
                .Where(x => x.Percentage != 0)
                .Include(x => x.DistributionFundType)
                .ToArrayAsync();
            var shareDistributions = await _readOnlyCtx.Set<ShareDistribution>()
                .Where(x => x.CuttingPlantationId == cuttingPlantationId)
                .ToArrayAsync();

            var totalAmountOfShareToBeDistributed = cuttingInfo.Realizations?.Sum(x => x.TotalSaleValue) ?? 0; // TODO: here instead of realization maybe use lotwise selling
            var totalCurrentDistributedAmount = shareDistributions.Sum(x => x.DepositedRevenueAmount);

            var result = new DefaultDistributionDataVM
            {
                CuttingPlantationId = cuttingPlantationId,
                NewRaisedPlantationId = cuttingInfo.NewRaisedPlantationId,
                PlantationId = cuttingInfo.NewRaisedPlantation.PlantationId,
                TotalAmountOfShareToBeDistributed = totalAmountOfShareToBeDistributed,
                TotalUndistributedAmount = totalAmountOfShareToBeDistributed - totalCurrentDistributedAmount,
                TotalCurrentDistributedAmount = totalCurrentDistributedAmount,
            };
            var resultData = new List<DefaultDistributionFund>(percentage.Length);

            foreach (var item in percentage)
            {
                var xTotalAmountOfShareToBeDistributed = totalAmountOfShareToBeDistributed * (item.Percentage / 100);
                var xTotalCurrentDistributedAmount = shareDistributions
                    .Where(x => x.DistributionFundTypeId == item.DistributionFundTypeId)
                    .Sum(x => x.DepositedRevenueAmount);

                resultData.Add(new DefaultDistributionFund
                {
                    DistributionFundTypeId = item.DistributionFundTypeId,
                    FundTypeName = item.DistributionFundType?.Name ?? string.Empty,
                    DistributionFundTypeEnum = item.DistributionFundType?.DistributionFundTypeEnum ?? DistributionFundTypeEnum.General,
                    Percentage = item.Percentage,

                    TotalAmountOfShareToBeDistributed = xTotalAmountOfShareToBeDistributed,
                    TotalUndistributedAmount = xTotalAmountOfShareToBeDistributed - xTotalCurrentDistributedAmount,
                    TotalCurrentDistributedAmount = xTotalCurrentDistributedAmount,
                });
            }

            result.DefaultDistributionFunds = resultData;

            return (ExecutionState.Success, result, "Success");
        }

        public override Task<(ExecutionState executionState, ShareDistribution entity, string message)> CreateAsync(ShareDistribution entity)
        {
            entity.DistributedToBeneficiary = entity.DistributedToBeneficiary
                ?.Where(x => x.DepositedRevenueAmount > 0)
                .Select(x =>
                {
                    x.SocialForestryBeneficiaryId = x.SocialForestryBeneficiary?.Id ?? 0;
                    x.SocialForestryBeneficiary = null;

                    return x;
                })
                .ToList();

            return base.CreateAsync(entity);
        }
    }
}
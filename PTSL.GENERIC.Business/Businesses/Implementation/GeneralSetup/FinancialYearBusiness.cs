using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.GeneralSetup;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.GeneralSetup
{
    public class FinancialYearBusiness : BaseBusiness<FinancialYear>, IFinancialYearBusiness
    {
        public FinancialYearBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override Task<(ExecutionState executionState, IQueryable<FinancialYear> entity, string message)> List(QueryOptions<FinancialYear> queryOptions = null)
        {
            return base.List(new QueryOptions<FinancialYear>
            {
                SortingExpression = e => e.OrderByDescending(x => x.EndYear)
            });
        }

        public override Task<(ExecutionState executionState, FinancialYear entity, string message)> CreateAsync(FinancialYear entity)
        {
            BuildFinancialYear(ref entity);

            return base.CreateAsync(entity);
        }

        public override Task<(ExecutionState executionState, FinancialYear entity, string message)> UpdateAsync(FinancialYear entity)
        {
            BuildFinancialYear(ref entity);

            return base.UpdateAsync(entity);
        }

        private static void BuildFinancialYear(ref FinancialYear entity)
        {
            entity.Name = $"{entity.StartYear}-{entity.EndYear}";
            entity.NameBn = ConvertEnglishNumberToBangla($"{entity.StartYear}-{entity.EndYear}");
        }

        private static string ConvertEnglishNumberToBangla(string englishNumber)
        {
            var result = new StringBuilder();

            foreach (char digit in englishNumber)
            {
                if (char.IsDigit(digit))
                {
                    int digitValue = (int)char.GetNumericValue(digit);
                    char banglaDigit = (char)('\u09E6' + digitValue); // Adding the Unicode offset

                    result.Append(banglaDigit);
                }
                else
                {
                    result.Append(digit); // Append non-digit characters as is
                }
            }

            return result.ToString();
        }
    }
}

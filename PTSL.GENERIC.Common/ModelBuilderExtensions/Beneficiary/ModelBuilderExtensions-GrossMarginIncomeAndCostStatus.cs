using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureGrossMarginIncomeAndCostStatus(this ModelBuilder builder)
        {
            builder.Entity<GrossMarginIncomeAndCostStatus>(e =>
            {
                e.ToTable($"{nameof(GrossMarginIncomeAndCostStatus)}es", "BEN");

                e.Property(x => x.ProductName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.MeasurementOfProduct)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<GrossMarginIncomeAndCostStatus>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.GrossMarginIncomeAndCostStatuses)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();

			builder.Entity<GrossMarginIncomeAndCostStatus>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

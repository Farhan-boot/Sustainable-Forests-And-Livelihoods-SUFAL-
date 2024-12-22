using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureNaturalResourcesIncomeAndCostStatus(this ModelBuilder builder)
        {
            builder.Entity<NaturalResourcesIncomeAndCostStatus>(e =>
            {
                e.ToTable($"{nameof(NaturalResourcesIncomeAndCostStatus)}es", "BEN");

                e.Property(x => x.Unit)
                    .HasColumnType("varchar(80)")
                    .IsRequired(false);
            });

            builder.Entity<NaturalResourcesIncomeAndCostStatus>()
                .HasOne(x => x.NaturalIncomeSourceType)
                .WithMany(x => x.NaturalResourcesIncomeAndCostStatuses)
                .HasForeignKey(x => x.NaturalIncomeSourceTypeId)
                .IsRequired(false);
            builder.Entity<NaturalResourcesIncomeAndCostStatus>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.NaturalResourcesIncomeAndCostStatuses)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();

			builder.Entity<NaturalResourcesIncomeAndCostStatus>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

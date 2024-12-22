using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureManualPhysicalWork(this ModelBuilder builder)
        {
            builder.Entity<ManualPhysicalWork>(e =>
            {
                e.ToTable($"{nameof(ManualPhysicalWork)}s", "BEN");

                e.Property(x => x.ManualIncomeSourceTypeTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<ManualPhysicalWork>()
                .HasOne(x => x.ManualIncomeSourceType)
                .WithMany(x => x.ManualPhysicalWorks)
                .HasForeignKey(x => x.ManualIncomeSourceTypeId)
                .IsRequired(false);
            builder.Entity<ManualPhysicalWork>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.ManualPhysicalWorks)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();

			builder.Entity<ManualPhysicalWork>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

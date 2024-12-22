using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureOtherIncomeSource(this ModelBuilder builder)
        {
            builder.Entity<OtherIncomeSource>(e =>
            {
                e.ToTable($"{nameof(OtherIncomeSource)}s", "BEN");

                e.Property(x => x.OtherIncomeSourceTypeTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<OtherIncomeSource>()
                .HasOne(x => x.OtherIncomeSourceType)
                .WithMany(x => x.OtherIncomeSources)
                .HasForeignKey(x => x.OtherIncomeSourceTypeId)
                .IsRequired(false);
            builder.Entity<OtherIncomeSource>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.OtherIncomeSources)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();

			builder.Entity<OtherIncomeSource>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureLDFProgress(this ModelBuilder builder)
    {
        builder.Entity<LDFProgress>(e =>
        {
            e.ToTable($"{nameof(LDFProgress)}s", SchemaNames.AIG);

            e.Property(x => x.RepaymentLDFId)
                .IsRequired();
            e.Property(x => x.ProgressAmount)
                .IsRequired();

            e.Property(x => x.RepaymentStartDate)
                .IsRequired();
            e.Property(x => x.RepaymentEndDate)
                .IsRequired();
            e.Property(x => x.RepaymentSerial)
                .IsRequired();

            e.Ignore(x => x.GrowthStatus);
        });

        builder.Entity<LDFProgress>()
            .HasOne(x => x.AIGBasicInformation)
            .WithMany(x => x.LDFProgresses)
            .HasForeignKey(x => x.AIGBasicInformationId)
            .IsRequired();

        builder.Entity<LDFProgress>()
            .HasQueryFilter(q => !q.IsDeleted && q.IsActive)
            .HasQueryFilter(q => !q.AIGBasicInformation!.IsDeleted && q.AIGBasicInformation!.IsActive);
    }
}

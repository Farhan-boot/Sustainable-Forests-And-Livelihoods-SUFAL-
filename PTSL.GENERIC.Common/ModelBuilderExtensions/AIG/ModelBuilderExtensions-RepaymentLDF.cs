using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureRepaymentLDF(this ModelBuilder builder)
    {
        builder.Entity<RepaymentLDF>(e =>
        {
            e.ToTable($"{nameof(RepaymentLDF)}s", SchemaNames.AIG);

            e.Property(x => x.FirstSixtyPercentageLDFId)
                .HasDefaultValue(null)
                .IsRequired(false);
            e.Property(x => x.SecondFourtyPercentageLDFId)
                .HasDefaultValue(null)
                .IsRequired(false);
            e.Property(x => x.AIGBasicInformationId)
                .IsRequired();

            e.Property(x => x.FirstSixtyPercentRepaymentAmount)
                .IsRequired();
            e.Property(x => x.SecondFortyPercentRepaymentAmount)
                .IsRequired();

            e.Property(x => x.RepaymentStartDate)
                .IsRequired();
            e.Property(x => x.RepaymentEndDate)
                .IsRequired();
            e.Property(x => x.IsPaymentCompleted)
                .IsRequired();
            e.Property(x => x.PaymentCompletedDateTime)
                .HasDefaultValue(null)
                .IsRequired(false);
            e.Property(x => x.IsPaymentCompletedLate)
                .IsRequired();
        });

        builder.Entity<RepaymentLDF>()
            .HasOne(x => x.FirstSixtyPercentageLDF)
            .WithMany(x => x.RepaymentLDFs)
            .HasForeignKey(x => x.FirstSixtyPercentageLDFId)
            .IsRequired(false);
        builder.Entity<RepaymentLDF>()
            .HasOne(x => x.SecondFourtyPercentageLDF)
            .WithMany(x => x.RepaymentLDFs)
            .HasForeignKey(x => x.SecondFourtyPercentageLDFId)
            .IsRequired(false);

        builder.Entity<RepaymentLDF>()
            .HasOne(x => x.AIGBasicInformation)
            .WithMany(x => x.RepaymentLDFs)
            .HasForeignKey(x => x.AIGBasicInformationId)
            .IsRequired();

        // 1 to 1
        builder.Entity<RepaymentLDF>()
            .HasOne(x => x.LDFProgress)
            .WithOne(x => x.RepaymentLDF!)
            .HasForeignKey<LDFProgress>(x => x.RepaymentLDFId);

        builder.Entity<RepaymentLDF>()
            .HasQueryFilter(q => !q.IsDeleted && q.IsActive)
            .HasQueryFilter(q => !q.AIGBasicInformation!.IsDeleted && q.AIGBasicInformation!.IsActive);
    }
}

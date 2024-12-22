using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.InternalLoan;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureRepaymentInternalLoan(this ModelBuilder builder)
    {
        builder.Entity<RepaymentInternalLoan>(e =>
        {
            e.ToTable($"{nameof(RepaymentInternalLoan)}s", SchemaNames.InternalLoan);

            e.Property(x => x.InternalLoanInformationId)
                .IsRequired();
            e.Property(x => x.RepaymentAmount)
                .IsRequired(false);
            e.Property(x => x.RepaymentStartDate)
                .IsRequired();
            e.Property(x => x.RepaymentEndDate)
                .IsRequired();

            e.Property(x => x.RepaymentSerial)
                .IsRequired(false);
            e.Property(x => x.IsPaymentCompleted)
                .IsRequired(false);
            e.Property(x => x.PaymentCompletedDateTime)
                .IsRequired(false);
            e.Property(x => x.IsPaymentCompletedLate)
                .IsRequired(false);
            e.Property(x => x.IsLocked)
                .IsRequired(false);
        });

        // Repayment Internal Loan
        builder.Entity<RepaymentInternalLoan>()
           .HasOne(x => x.InternalLoanInformations)
           .WithMany(x => x.RepaymentInternalLoans!)
           .HasForeignKey(x => x.InternalLoanInformationId)
           .IsRequired(false);

        builder.Entity<RepaymentInternalLoan>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureRepaymentLDFHistory(this ModelBuilder builder)
    {
        builder.Entity<RepaymentLDFHistory>(e =>
        {
            e.ToTable($"RepaymentLDFHistories", SchemaNames.AIG);

            e.Property(x => x.RepaymentLDFId)
                .IsRequired();
            e.Property(x => x.EventUserId)
                .IsRequired();
            e.Property(x => x.EventOccurredDate)
                .IsRequired();
            e.Property(x => x.EventMessage)
                .IsRequired(false);
            e.Property(x => x.RepaymentLDFEventType)
                .IsRequired();
        });

        builder.Entity<RepaymentLDFHistory>()
            .HasOne(x => x.RepaymentLDF)
            .WithMany(x => x.RepaymentLDFHistories)
            .HasForeignKey(x => x.RepaymentLDFId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<RepaymentLDFHistory>()
            .HasOne(x => x.EventUser)
            .WithMany(x => x.RepaymentLDFHistories)
            .HasForeignKey(x => x.EventUserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<RepaymentLDFHistory>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}

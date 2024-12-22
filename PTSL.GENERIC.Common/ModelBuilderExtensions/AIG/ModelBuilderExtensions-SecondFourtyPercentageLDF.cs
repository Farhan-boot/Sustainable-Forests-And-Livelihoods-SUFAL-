using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSecondFourtyPercentageLDF(this ModelBuilder builder)
    {
        builder.Entity<SecondFourtyPercentageLDF>(e =>
        {
            e.ToTable($"{nameof(SecondFourtyPercentageLDF)}s", SchemaNames.AIG);

            e.Property(x => x.AIGBasicInformationId)
                .IsRequired();
            e.Property(x => x.ServiceChargeAmount)
                .IsRequired();
            e.Property(x => x.SecurityChargeAmount)
                .IsRequired();
            e.Property(x => x.StartDate)
                .IsRequired();
            e.Property(x => x.StartRepaymentLDFId)
                .IsRequired();
        });

        builder.Entity<SecondFourtyPercentageLDF>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}

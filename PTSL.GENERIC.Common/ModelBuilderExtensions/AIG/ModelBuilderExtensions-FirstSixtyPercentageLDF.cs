using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureFirstSixtyPercentageLDF(this ModelBuilder builder)
    {
        builder.Entity<FirstSixtyPercentageLDF>(e =>
        {
            e.ToTable($"{nameof(FirstSixtyPercentageLDF)}s", SchemaNames.AIG);

            e.Property(x => x.AIGBasicInformationId)
                .IsRequired();
            e.Property(x => x.HasGrace)
                .IsRequired();
            e.Property(x => x.ServiceChargeAmount)
                .IsRequired();
            e.Property(x => x.SecurityChargeAmount)
                .IsRequired();
        });

        builder.Entity<FirstSixtyPercentageLDF>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}

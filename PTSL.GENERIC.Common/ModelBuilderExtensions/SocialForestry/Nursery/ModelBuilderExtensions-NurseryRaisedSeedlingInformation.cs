using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureNurseryRaisedSeedlingInformation(this ModelBuilder builder)
    {
        builder.Entity<NurseryRaisedSeedlingInformation>(e =>
        {
            e.ToTable($"{nameof(NurseryRaisedSeedlingInformation)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<NurseryRaisedSeedlingInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
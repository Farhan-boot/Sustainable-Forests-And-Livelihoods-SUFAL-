using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureReplantationNurseryInfo(this ModelBuilder builder)
    {
        builder.Entity<ReplantationNurseryInfo>(e =>
        {
            e.ToTable($"{nameof(ReplantationNurseryInfo)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<ReplantationNurseryInfo>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
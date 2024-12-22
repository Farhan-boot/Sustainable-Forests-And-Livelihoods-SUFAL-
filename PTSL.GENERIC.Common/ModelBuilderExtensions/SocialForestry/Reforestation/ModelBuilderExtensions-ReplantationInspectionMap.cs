using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureReplantationInspectionMap(this ModelBuilder builder)
    {
        builder.Entity<ReplantationInspectionMap>(e =>
        {
            e.ToTable($"{nameof(ReplantationInspectionMap)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<ReplantationInspectionMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
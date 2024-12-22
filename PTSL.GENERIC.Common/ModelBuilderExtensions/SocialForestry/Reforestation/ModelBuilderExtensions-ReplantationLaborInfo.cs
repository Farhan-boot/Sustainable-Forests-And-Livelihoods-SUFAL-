using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureReplantationLaborInfo(this ModelBuilder builder)
    {
        builder.Entity<ReplantationLaborInfo>(e =>
        {
            e.ToTable($"{nameof(ReplantationLaborInfo)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<ReplantationLaborInfo>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
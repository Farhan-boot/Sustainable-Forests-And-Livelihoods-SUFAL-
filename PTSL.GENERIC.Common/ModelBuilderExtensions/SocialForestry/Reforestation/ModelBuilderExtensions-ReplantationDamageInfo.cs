using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureReplantationDamageInfo(this ModelBuilder builder)
    {
        builder.Entity<ReplantationDamageInfo>(e =>
        {
            e.ToTable(nameof(ReplantationDamageInfo), SchemaNames.SocialForestry);
        });

        builder.Entity<ReplantationDamageInfo>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}

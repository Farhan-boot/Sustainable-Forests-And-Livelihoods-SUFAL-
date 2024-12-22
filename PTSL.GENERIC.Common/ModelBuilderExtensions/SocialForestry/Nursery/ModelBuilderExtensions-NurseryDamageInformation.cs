using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureNurseryDamageInformation(this ModelBuilder builder)
    {
        builder.Entity<NurseryDamageInformation>(e =>
        {
            e.ToTable($"{nameof(NurseryDamageInformation)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<NurseryDamageInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureNurseryType(this ModelBuilder builder)
    {
        builder.Entity<NurseryType>(e =>
        {
            e.ToTable($"{nameof(NurseryType)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<NurseryType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
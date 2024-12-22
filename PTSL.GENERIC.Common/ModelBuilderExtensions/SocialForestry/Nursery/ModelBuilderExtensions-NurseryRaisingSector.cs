using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureNurseryRaisingSector(this ModelBuilder builder)
    {
        builder.Entity<NurseryRaisingSector>(e =>
        {
            e.ToTable($"{nameof(NurseryRaisingSector)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<NurseryRaisingSector>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
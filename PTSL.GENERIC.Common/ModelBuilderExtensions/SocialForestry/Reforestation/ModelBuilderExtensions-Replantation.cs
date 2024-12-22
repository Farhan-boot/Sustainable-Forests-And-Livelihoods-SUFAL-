using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureReplantation(this ModelBuilder builder)
    {
        builder.Entity<Replantation>(e =>
        {
            e.ToTable($"{nameof(Replantation)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<Replantation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.SocialForestry;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureNewRaisedPlantation(this ModelBuilder builder)
    {
        builder.Entity<NewRaisedPlantation>(e =>
        {
            e.ToTable($"{nameof(NewRaisedPlantation)}s", SchemaNames.SocialForestry);
        });

        builder.Entity<NewRaisedPlantation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
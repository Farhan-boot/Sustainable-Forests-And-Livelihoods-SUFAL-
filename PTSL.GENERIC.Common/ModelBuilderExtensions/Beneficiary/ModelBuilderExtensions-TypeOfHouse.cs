using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureTypeOfHouse(this ModelBuilder builder)
    {
        builder.Entity<TypeOfHouse>(e =>
        {
            e.ToTable($"{nameof(TypeOfHouse)}s", "BEN");
        });

        builder.Entity<TypeOfHouse>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
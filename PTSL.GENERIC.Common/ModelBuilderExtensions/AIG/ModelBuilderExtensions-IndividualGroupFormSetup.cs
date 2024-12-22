using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureIndividualGroupFormSetup(this ModelBuilder builder)
    {
        builder.Entity<IndividualGroupFormSetup>(e =>
        {
            e.ToTable($"{nameof(IndividualGroupFormSetup)}s", SchemaNames.AIG);

            e.Property(x => x.GroupDocument)
                .HasColumnType("text")
                .IsRequired(false);
            e.Property(x => x.IndividualDocument)
                .HasColumnType("text")
                .IsRequired(false);
        });

        builder.Entity<IndividualGroupFormSetup>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}

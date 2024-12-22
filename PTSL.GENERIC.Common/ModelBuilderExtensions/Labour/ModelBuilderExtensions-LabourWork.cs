using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Labour;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureLabourWork(this ModelBuilder builder)
    {
        builder.Entity<LabourWork>(e =>
        {
            e.ToTable($"{nameof(LabourWork)}s", SchemaNames.LABOUR);
        });

        builder.Entity<LabourWork>()
            .HasOne(x => x.LabourDatabase)
            .WithMany(x => x.LabourWorks)
            .HasForeignKey(x => x.LabourDatabaseId)
            .IsRequired();

        builder.Entity<LabourWork>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
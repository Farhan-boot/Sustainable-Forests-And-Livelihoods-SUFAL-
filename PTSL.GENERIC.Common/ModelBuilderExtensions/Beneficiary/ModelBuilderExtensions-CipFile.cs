using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureCipFile(this ModelBuilder builder)
    {
        builder.Entity<CipFile>(e =>
        {
            e.ToTable($"{nameof(CipFile)}s", "BEN");
        });

        builder.Entity<CipFile>()
            .HasOne(x => x.Cip)
            .WithMany(x => x.CipFiles)
            .HasForeignKey(x => x.CipId)
            .IsRequired();

        builder.Entity<CipFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
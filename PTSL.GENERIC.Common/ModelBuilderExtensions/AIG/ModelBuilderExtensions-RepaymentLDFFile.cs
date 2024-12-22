using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureRepaymentLDFFile(this ModelBuilder builder)
    {
        builder.Entity<RepaymentLDFFile>(e =>
        {
            e.ToTable($"{nameof(RepaymentLDFFile)}s", SchemaNames.AIG);
        });

        builder.Entity<RepaymentLDFFile>()
            .HasOne(x => x.RepaymentLDF)
            .WithMany(x => x.RepaymentLDFFiles)
            .HasForeignKey(x => x.RepaymentLDFId)
            .IsRequired();

        builder.Entity<RepaymentLDFFile>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
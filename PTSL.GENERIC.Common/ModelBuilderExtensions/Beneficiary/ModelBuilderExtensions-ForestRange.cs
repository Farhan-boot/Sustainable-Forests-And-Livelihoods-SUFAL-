using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureForestRange(this ModelBuilder builder)
        {
            builder.Entity<ForestRange>(e =>
            {
                e.ToTable($"{nameof(ForestRange)}s", "BEN");

                e.Property(x => x.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<ForestRange>()
                .HasOne(x => x.ForestDivision)
                .WithMany(x => x.ForestRanges)
                .HasForeignKey(x => x.ForestDivisionId)
                .IsRequired();

			builder.Entity<ForestRange>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

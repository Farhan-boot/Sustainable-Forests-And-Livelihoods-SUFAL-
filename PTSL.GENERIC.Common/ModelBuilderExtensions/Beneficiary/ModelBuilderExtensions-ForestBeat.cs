using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureForestBeat(this ModelBuilder builder)
        {
            builder.Entity<ForestBeat>(e =>
            {
                e.ToTable($"{nameof(ForestBeat)}s", "BEN");

                e.Property(x => x.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<ForestBeat>()
                .HasOne(x => x.ForestRange)
                .WithMany(x => x.ForestBeats)
                .HasForeignKey(x => x.ForestRangeId)
                .IsRequired();

			builder.Entity<ForestBeat>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

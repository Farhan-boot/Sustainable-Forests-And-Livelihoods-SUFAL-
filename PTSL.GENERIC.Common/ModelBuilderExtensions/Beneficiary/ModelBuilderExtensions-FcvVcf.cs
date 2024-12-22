using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureFcvVcf(this ModelBuilder builder)
        {
            builder.Entity<ForestFcvVcf>(e =>
            {
                e.ToTable($"{nameof(ForestFcvVcf)}s", "BEN");

                e.Property(x => x.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<ForestFcvVcf>()
                .HasOne(x => x.ForestBeat)
                .WithMany(x => x.ForestFcvVcfs)
                .HasForeignKey(x => x.ForestBeatId)
                .IsRequired();

			builder.Entity<ForestFcvVcf>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureForestDivision(this ModelBuilder builder)
        {
            builder.Entity<ForestDivision>(e =>
            {
                e.ToTable($"{nameof(ForestDivision)}s", "BEN");

                e.Property(x => x.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<ForestDivision>()
                .HasOne(x => x.ForestCircle)
                .WithMany(x => x.ForestDivisions)
                .HasForeignKey(x => x.ForestCircleId)
                .IsRequired();

			builder.Entity<ForestDivision>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

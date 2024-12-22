using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureAsset(this ModelBuilder builder)
        {
            builder.Entity<Asset>(e =>
            {
                e.ToTable($"{nameof(Asset)}s", "BEN");

                e.Property(x => x.AssetTypeTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

			builder.Entity<Asset>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

			builder.Entity<Asset>()
                .HasOne(x => x.AssetType)
                .WithMany(x => x.Assets)
                .HasForeignKey(x => x.AssetTypeId)
                .IsRequired();
            builder.Entity<Asset>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.Assets)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();
        }
    }
}

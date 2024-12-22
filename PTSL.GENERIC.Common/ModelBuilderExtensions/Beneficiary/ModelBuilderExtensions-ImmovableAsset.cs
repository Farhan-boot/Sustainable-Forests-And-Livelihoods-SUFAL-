using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureImmovableAsset(this ModelBuilder builder)
        {
            builder.Entity<ImmovableAsset>(e =>
            {
                e.ToTable($"{nameof(ImmovableAsset)}s", "BEN");

                e.Property(x => x.ImmovableAssetsTypeTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<ImmovableAsset>()
                .HasOne(x => x.ImmovableAssetType)
                .WithMany(x => x.ImmovableAssets)
                .HasForeignKey(x => x.ImmovableAssetTypeId)
                .IsRequired();
            builder.Entity<ImmovableAsset>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.ImmovableAssets)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();

			builder.Entity<ImmovableAsset>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

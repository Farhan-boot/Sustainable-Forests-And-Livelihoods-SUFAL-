using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureLiveStock(this ModelBuilder builder)
        {
            builder.Entity<LiveStock>(e =>
            {
                e.ToTable($"{nameof(LiveStock)}s", "BEN");

                e.Property(x => x.LivestockTypeTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<LiveStock>()
                .HasOne(x => x.LiveStockType)
                .WithMany(x => x.LiveStocks)
                .HasForeignKey(x => x.LiveStockTypeId)
                .IsRequired();
            builder.Entity<LiveStock>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.LiveStocks)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();

			builder.Entity<LiveStock>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

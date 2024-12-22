using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureFoodSecurityItem(this ModelBuilder builder)
        {
            builder.Entity<FoodSecurityItem>(e =>
            {
                e.ToTable($"{nameof(FoodSecurityItem)}s", "BEN");

                e.Property(x => x.FoodItemTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.Remarks)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<FoodSecurityItem>()
                .HasOne(x => x.FoodItem)
                .WithMany(x => x.FoodSecurityItems)
                .HasForeignKey(x => x.FoodItemId)
                .IsRequired();
            builder.Entity<FoodSecurityItem>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.FoodSecurityItems)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();

			builder.Entity<FoodSecurityItem>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

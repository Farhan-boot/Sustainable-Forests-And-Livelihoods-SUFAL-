using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureMarketing(this ModelBuilder builder)
        {
            builder.Entity<Marketing>(e =>
            {
                e.ToTable($"{nameof(Marketing)}s", "Marketing");

                e.Property(x => x.MarketingName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                e.Property(x => x.MarketingNameBn)
                   .HasColumnType("varchar(500)")
                   .IsRequired(false);
            });

            builder.Entity<Marketing>()
                .HasOne(x => x.District)
                .WithMany(x => x.Marketings)
                .HasForeignKey(x => x.DistrictId)
                .IsRequired(false);

            builder.Entity<Marketing>()
                .HasOne(x => x.Division)
                .WithMany(x => x.Marketings)
                .HasForeignKey(x => x.DivisionId)
                .IsRequired(false);
        }
    }
}

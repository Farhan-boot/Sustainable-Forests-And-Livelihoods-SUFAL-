using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureUpazilla(this ModelBuilder builder)
        {
            builder.Entity<Upazilla>(ac =>
            {
                ac.ToTable("Upazilla", "GS");

                ac.Property(a => a.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<Upazilla>()
                .HasOne(x => x.District)
                .WithMany(x => x.Upazillas)
                .HasForeignKey(x => x.DistrictId)
                .IsRequired();

            builder.Entity<Upazilla>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureUnion(this ModelBuilder builder)
        {
            builder.Entity<Union>(ac =>
            {
                ac.ToTable("Union", "GS");

                ac.Property(a => a.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<Union>()
                .HasOne(x => x.Upazilla)
                .WithMany(x => x.Unions)
                .HasForeignKey(x => x.UpazillaId)
                .IsRequired();

            builder.Entity<Union>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
        }
    }
}

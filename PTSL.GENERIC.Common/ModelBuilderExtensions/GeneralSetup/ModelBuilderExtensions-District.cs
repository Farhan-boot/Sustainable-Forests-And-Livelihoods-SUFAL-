using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureDistrict(this ModelBuilder builder)
        {
            builder.Entity<District>(ac =>
            {
                ac.ToTable("District", "GS");

                ac.Property(a => a.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired();
                ac.Property(a => a.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                ac.Property(a => a.DivisionId)
                    .HasColumnType("bigint")
                    .IsRequired();
            });

            builder.Entity<District>()
             .HasOne(s => s.Division!)
             .WithMany(g => g.Districts)
             .HasForeignKey(s => s.DivisionId).OnDelete(DeleteBehavior.ClientCascade);

			builder.Entity<District>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

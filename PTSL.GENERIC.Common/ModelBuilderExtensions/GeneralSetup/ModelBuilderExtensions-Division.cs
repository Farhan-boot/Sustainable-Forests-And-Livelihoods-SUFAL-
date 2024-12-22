using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureDivision(this ModelBuilder builder)
        {
            builder.Entity<Division>(ac =>
            {
                ac.ToTable("Division", "GS");

                ac.Property(a => a.Name)
                    .HasColumnName("DivisionName")
                    .HasColumnType("varchar(500)")
                    .IsRequired();
                ac.Property(a => a.NameBn)
                    .HasColumnName("DivisionNameBangla")
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });
            builder.Entity<Division>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            //builder.Entity<Division>().HasQueryFilter(q => q.IsDeleted == 0 && q.IsActive == 1);
        }
    }
}

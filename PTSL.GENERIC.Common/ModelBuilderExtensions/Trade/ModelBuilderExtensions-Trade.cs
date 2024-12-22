using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Trades;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;


namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureTrade(this ModelBuilder builder)
        {
            builder.Entity<Trade>(ac =>
            {
                ac.ToTable("Trade", "BEN");
                ac.Property(a => a.Name)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.NameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });
        }
    }
}

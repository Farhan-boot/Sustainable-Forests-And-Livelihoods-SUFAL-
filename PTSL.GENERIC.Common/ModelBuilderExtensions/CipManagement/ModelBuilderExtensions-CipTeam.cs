using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCipTeam(this ModelBuilder builder)
        {
            builder.Entity<CipTeam>(ac =>
            {
                ac.ToTable("CipTeam", "CipManagement");

                //ac.Property(a => a.Name)
                //    .HasColumnType("varchar(500)")
                //    .IsRequired(false);
                //ac.Property(a => a.NameBn)
                //    .HasColumnType("varchar(500)")
                //    .IsRequired(false);

            });

            //Forest
            builder.Entity<CipTeam>()
                .HasOne(x => x.ForestCircle)
                .WithMany(x => x.CipTeams)
                .HasForeignKey(x => x.ForestCircleId)
                .IsRequired(false);

            builder.Entity<CipTeam>()
               .HasOne(x => x.ForestDivision)
               .WithMany(x => x.CipTeams)
               .HasForeignKey(x => x.ForestDivisionId)
               .IsRequired(false);

            builder.Entity<CipTeam>()
             .HasOne(x => x.ForestRange)
             .WithMany(x => x.CipTeams)
             .HasForeignKey(x => x.ForestRangeId)
             .IsRequired(false);

            builder.Entity<CipTeam>()
              .HasOne(x => x.ForestBeat)
              .WithMany(x => x.CipTeams)
              .HasForeignKey(x => x.ForestBeatId)
              .IsRequired(false);


            //Civil
            builder.Entity<CipTeam>()
                     .HasOne(x => x.Division)
                     .WithMany(x => x.CipTeams)
                     .HasForeignKey(x => x.DivisionId)
                     .IsRequired(false);

            builder.Entity<CipTeam>()
                    .HasOne(x => x.District)
                    .WithMany(x => x.CipTeams)
                    .HasForeignKey(x => x.DistrictId)
                    .IsRequired(false);

            builder.Entity<CipTeam>()
                   .HasOne(x => x.Upazilla)
                   .WithMany(x => x.CipTeams)
                   .HasForeignKey(x => x.UpazillaId)
                   .IsRequired(false);

            builder.Entity<CipTeam>()
                   .HasOne(x => x.Union)
                   .WithMany(x => x.CipTeams)
                   .HasForeignKey(x => x.UnionId)
                   .IsRequired(false);

            builder.Entity<CipTeam>()
             .HasOne(x => x.Ngo)
             .WithMany(x => x.CipTeams)
             .HasForeignKey(x => x.NgoId)
             .IsRequired(false);


          builder.Entity<CipTeam>()
           .HasOne(x => x.ForestFcvVcf)
           .WithMany(x => x.CipTeams)
           .HasForeignKey(x => x.ForestFcvVcfId)
           .IsRequired(false);

			builder.Entity<CipTeam>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

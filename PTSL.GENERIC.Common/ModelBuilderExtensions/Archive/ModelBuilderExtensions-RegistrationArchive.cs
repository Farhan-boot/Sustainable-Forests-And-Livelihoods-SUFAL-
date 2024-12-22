using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Archive;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureRegistrationArchive(this ModelBuilder builder)
        {
            builder.Entity<RegistrationArchive>(ac =>
            {
                ac.ToTable("RegistrationArchive", "Archive");

                ac.Property(a => a.ArchiveName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.DocumentDescription)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            //Forest
            builder.Entity<RegistrationArchive>()
                .HasOne(x => x.ForestCircle)
                .WithMany(x => x.RegistrationArchives)
                .HasForeignKey(x => x.ForestCircleId)
                .IsRequired(false);

            builder.Entity<RegistrationArchive>()
               .HasOne(x => x.ForestDivision)
               .WithMany(x => x.RegistrationArchives)
               .HasForeignKey(x => x.ForestDivisionId)
               .IsRequired(false);

            builder.Entity<RegistrationArchive>()
             .HasOne(x => x.ForestRange)
             .WithMany(x => x.RegistrationArchives)
             .HasForeignKey(x => x.ForestRangeId)
             .IsRequired(false);

            builder.Entity<RegistrationArchive>()
              .HasOne(x => x.ForestBeat)
              .WithMany(x => x.RegistrationArchives)
              .HasForeignKey(x => x.ForestBeatId)
              .IsRequired(false);

           builder.Entity<RegistrationArchive>()
            .HasOne(x => x.ForestFcvVcf)
            .WithMany(x => x.RegistrationArchives)
            .HasForeignKey(x => x.ForestFcvVcfId)
            .IsRequired(false);

            //Civil
            builder.Entity<RegistrationArchive>()
                     .HasOne(x => x.Division)
                     .WithMany(x => x.RegistrationArchives)
                     .HasForeignKey(x => x.DivisionId)
                     .IsRequired(false);

            builder.Entity<RegistrationArchive>()
                    .HasOne(x => x.District)
                    .WithMany(x => x.RegistrationArchives)
                    .HasForeignKey(x => x.DistrictId)
                    .IsRequired(false);

            builder.Entity<RegistrationArchive>()
                   .HasOne(x => x.Upazilla)
                   .WithMany(x => x.RegistrationArchives)
                   .HasForeignKey(x => x.UpazillaId)
                   .IsRequired(false);

            builder.Entity<RegistrationArchive>()
                   .HasOne(x => x.Union)
                   .WithMany(x => x.RegistrationArchives)
                   .HasForeignKey(x => x.UnionId)
                   .IsRequired(false);
        }
    }
}

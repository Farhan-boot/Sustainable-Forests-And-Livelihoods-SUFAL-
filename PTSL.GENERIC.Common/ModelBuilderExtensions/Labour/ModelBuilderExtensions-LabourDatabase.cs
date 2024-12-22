using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Labour;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureLabourDatabase(this ModelBuilder builder)
        {
            builder.Entity<LabourDatabase>(ac =>
            {
                ac.ToTable("LabourDatabases", SchemaNames.LABOUR);

                ac.Property(a => a.SurveyId)
                    .IsRequired(false);
                ac.Property(a => a.OtherLabourMemberId)
                    .IsRequired(false);
                ac.Property(a => a.CodeNo)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
            });

            // Forest Administration
            builder.Entity<LabourDatabase>()
                .HasOne(x => x.ForestCircle)
                .WithMany(x => x.LabourDatabases)
                .HasForeignKey(x => x.ForestCircleId)
                .IsRequired(false);
            builder.Entity<LabourDatabase>()
                .HasOne(x => x.ForestDivision)
                .WithMany(x => x.LabourDatabases)
                .HasForeignKey(x => x.ForestDivisionId)
                .IsRequired(false);
            builder.Entity<LabourDatabase>()
                .HasOne(x => x.ForestRange)
                .WithMany(x => x.LabourDatabases)
                .HasForeignKey(x => x.ForestRangeId)
                .IsRequired(false);
            builder.Entity<LabourDatabase>()
                .HasOne(x => x.ForestBeat)
                .WithMany(x => x.LabourDatabases)
                .HasForeignKey(x => x.ForestBeatId)
                .IsRequired(false);
            builder.Entity<LabourDatabase>()
                .HasOne(x => x.ForestFcvVcf)
                .WithMany(x => x.LabourDatabases)
                .HasForeignKey(x => x.ForestFcvVcfId)
                .IsRequired(false);

            // Civil Administration
            builder.Entity<LabourDatabase>()
                .HasOne(x => x.Division)
                .WithMany(x => x.LabourDatabases)
                .HasForeignKey(x => x.DivisionId)
                .IsRequired(false);
            builder.Entity<LabourDatabase>()
                .HasOne(x => x.District)
                .WithMany(x => x.LabourDatabases)
                .HasForeignKey(x => x.DistrictId)
                .IsRequired(false);
            builder.Entity<LabourDatabase>()
                .HasOne(x => x.Upazilla)
                .WithMany(x => x.LabourDatabases)
                .HasForeignKey(x => x.UpazillaId)
                .IsRequired(false);
            builder.Entity<LabourDatabase>()
                .HasOne(x => x.Union)
                .WithMany(x => x.LabourDatabases)
                .HasForeignKey(x => x.UnionId)
                .IsRequired(false);

            // Survey ar Other labour, Ethnicity
            builder.Entity<LabourDatabase>()
               .HasOne(x => x.Survey)
               .WithMany(x => x.LabourDatabases)
               .HasForeignKey(x => x.SurveyId)
               .IsRequired(false);
            builder.Entity<LabourDatabase>()
               .HasOne(x => x.OtherLabourMember)
               .WithOne(x => x.LabourDatabases)
               .HasForeignKey<LabourDatabase>(x => x.OtherLabourMemberId)
               .IsRequired(false);

            builder.Entity<LabourDatabase>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
        }
    }
}

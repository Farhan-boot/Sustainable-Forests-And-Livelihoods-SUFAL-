using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions;

public static partial class EntityModelBuilderExtensions
{
    public static void ConfigureSocialForestryTraining(this ModelBuilder builder)
    {
        builder.Entity<SocialForestryTraining>(e =>
        {
            e.ToTable($"{nameof(SocialForestryTraining)}s", SchemaNames.SocialForestryTraining);

            e.Property(x => x.TrainingTitle)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

            e.Property(x => x.TrainingTitleBn)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

            e.Property(x => x.StartDate)
                .IsRequired();

            e.Property(x => x.EndDate)
                .IsRequired();

            e.Property(x => x.TrainingDuration)
                .HasColumnType("varchar(200)")
                .IsRequired(false);

            e.Property(x => x.Location)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

            e.Property(x => x.LocationBn)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

            e.Property(x => x.TrainerName)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

            e.Property(x => x.TotalMembers)
                .IsRequired();
            e.Property(x => x.TotalMale)
                .IsRequired();
            e.Property(x => x.TotalFemale)
                .IsRequired();

            e.Property(x => x.FinancialYearForTrainingId)
                .IsRequired(false);

            e.Property(x => x.TrainerDesignationForTrainingId)
               .IsRequired(false);

            e.Property(x => x.TrainerAddress)
               .HasColumnType("varchar(500)")
               .IsRequired(false);
        });

        builder.Entity<SocialForestryTraining>()
                .HasOne(x => x.EventTypeForTraining)
                .WithMany(x => x.SocialForestryTrainings)
                .HasForeignKey(x => x.EventTypeForTrainingId)
                .IsRequired(false);

        builder.Entity<SocialForestryTraining>()
            .HasOne(x => x.TrainingOrganizerForTraining)
            .WithMany(x => x.SocialForestryTrainings)
            .HasForeignKey(x => x.TrainingOrganizerForTrainingId)
            .IsRequired(false);

        builder.Entity<SocialForestryTraining>()
            .HasOne(x => x.FinancialYearForTraining)
            .WithMany(x => x.SocialForestryTrainings)
            .HasForeignKey(x => x.FinancialYearForTrainingId)
            .IsRequired(false);

     //Extar Start

        //Forest
        builder.Entity<SocialForestryTraining>()
            .HasOne(x => x.ForestCircle)
            .WithMany(x => x.SocialForestryTrainings)
            .HasForeignKey(x => x.ForestCircleId)
            .IsRequired(false);

        builder.Entity<SocialForestryTraining>()
           .HasOne(x => x.ForestDivision)
           .WithMany(x => x.SocialForestryTrainings)
           .HasForeignKey(x => x.ForestDivisionId)
           .IsRequired(false);

        builder.Entity<SocialForestryTraining>()
         .HasOne(x => x.ForestRange)
         .WithMany(x => x.SocialForestryTrainings)
         .HasForeignKey(x => x.ForestRangeId)
         .IsRequired(false);

        builder.Entity<SocialForestryTraining>()
          .HasOne(x => x.ForestBeat)
          .WithMany(x => x.SocialForestryTrainings)
          .HasForeignKey(x => x.ForestBeatId)
          .IsRequired(false);

        //Civil
        builder.Entity<SocialForestryTraining>()
                 .HasOne(x => x.Division)
                 .WithMany(x => x.SocialForestryTrainings)
                 .HasForeignKey(x => x.DivisionId)
                 .IsRequired(false);

        builder.Entity<SocialForestryTraining>()
                .HasOne(x => x.District)
                .WithMany(x => x.SocialForestryTrainings)
                .HasForeignKey(x => x.DistrictId)
                .IsRequired(false);

        builder.Entity<SocialForestryTraining>()
               .HasOne(x => x.Upazilla)
               .WithMany(x => x.SocialForestryTrainings)
               .HasForeignKey(x => x.UpazillaId)
               .IsRequired(false);

        builder.Entity<SocialForestryTraining>()
               .HasOne(x => x.Union)
               .WithMany(x => x.SocialForestryTrainings)
               .HasForeignKey(x => x.UnionId)
               .IsRequired(false);
        //Extra End

        builder.Entity<SocialForestryTraining>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
    }
}
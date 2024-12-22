using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureDepartmentalTrainingParticipentsMap(this ModelBuilder builder)
        {
            builder.Entity<DepartmentalTrainingParticipentsMap>(e =>
            {
                e.ToTable($"{nameof(DepartmentalTrainingParticipentsMap)}s", "Capacity");

                e.Property(x => x.DepartmentalTrainingMemberId)
                    .IsRequired();
            });

            builder.Entity<DepartmentalTrainingParticipentsMap>()
                .HasOne(x => x.DepartmentalTrainingMember)
                .WithMany(x => x.DepartmentalTrainingParticipentsMaps)
                .HasForeignKey(x => x.DepartmentalTrainingMemberId)
                .IsRequired();

            builder.Entity<DepartmentalTrainingParticipentsMap>()
                .HasOne(x => x.DepartmentalTraining)
                .WithMany(x => x.DepartmentalTrainingParticipentsMaps)
                .HasForeignKey(x => x.DepartmentalTrainingId)
                .IsRequired();

			builder.Entity<DepartmentalTrainingParticipentsMap>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

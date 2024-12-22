using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureExistingSkill(this ModelBuilder builder)
        {
            builder.Entity<ExistingSkill>(e =>
            {
                e.ToTable($"{nameof(ExistingSkill)}s", "BEN");

                e.Property(x => x.SkillName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                e.Property(x => x.SkillLevelEnum)
                    .HasColumnType("smallint")
                    .IsRequired(false);
                e.Property(x => x.Remarks)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
            });

            builder.Entity<ExistingSkill>()
                .HasOne(x => x.Survey)
                .WithMany(x => x.ExistingSkills)
                .HasForeignKey(x => x.SurveyId)
                .IsRequired();

			builder.Entity<ExistingSkill>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
		}
	}
}

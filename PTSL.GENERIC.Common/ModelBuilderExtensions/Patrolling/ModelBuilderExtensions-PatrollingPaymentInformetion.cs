using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.Patrolling;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigurePatrollingPaymentInformetion(this ModelBuilder builder)
        {
            builder.Entity<PatrollingPaymentInformetion>(ac =>
            {
                ac.ToTable("PatrollingPaymentInformetion", "Patrolling");

                ac.Property(a => a.ParticipentName).IsRequired(false);
                ac.Property(a => a.GenderId).IsRequired(false);
                ac.Property(a => a.PhoneNo).IsRequired(false);
                ac.Property(a => a.AmountOfHonoraryAllowance).IsRequired(false);
                ac.Property(a => a.Remark).IsRequired(false);
            });

            builder.Entity<PatrollingPaymentInformetion>()
                     .HasOne(x => x.PatrollingScheduleInformetions)
                     .WithMany(x => x.PatrollingPaymentInformetions)
                     .HasForeignKey(x => x.PatrollingScheduleInformetionId)
                     .IsRequired(false);

            //Survey
            builder.Entity<PatrollingPaymentInformetion>()
                     .HasOne(x => x.Surveys)
                     .WithMany(x => x.PatrollingPaymentInformetions)
                     .HasForeignKey(x => x.SurveyId)
                     .IsRequired(false);

            //Others
            builder.Entity<PatrollingPaymentInformetion>()
                    .HasOne(x => x.OtherPatrollingMembers)
                    .WithMany(x => x.PatrollingPaymentInformetions)
                    .HasForeignKey(x => x.OtherPatrollingMemberId)
                    .IsRequired(false);


        }
    }
}

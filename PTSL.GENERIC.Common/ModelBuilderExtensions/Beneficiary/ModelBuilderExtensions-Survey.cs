using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum.Beneficiary;

namespace PTSL.GENERIC.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureSurvey(this ModelBuilder builder)
        {
            builder.Entity<Survey>(ac =>
            {
                ac.ToTable($"{nameof(Survey)}s", "BEN");

                // Forest administration
                ac.Property(a => a.StartTime).IsRequired();
                ac.Property(a => a.EndTime).IsRequired();
                ac.Property(a => a.SurveyDate).IsRequired();
                ac.Property(a => a.Deviceid)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.Subscriberid)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.Simserial)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.Phonenumber)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                ac.Property(a => a.DetailsInfo)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                ac.Property(a => a.ForestCircleId).IsRequired();
                ac.Property(a => a.ForestDivisionId).IsRequired();
                ac.Property(a => a.ForestRangeId).IsRequired();
                ac.Property(a => a.ForestBeatId).IsRequired();
                ac.Property(a => a.ForestFcvVcfId).IsRequired();

                ac.Property(a => a.NgoId).IsRequired(false);

                ac.Property(a => a.ForestVillageName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.ForestVillageNameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiaryId)
                    .HasColumnType("varchar(100)")
                    .IsRequired();
                ac.Property(a => a.BeneficiaryHouseholdSerialNo)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);

                ac.Property(a => a.BeneficiaryProfileURL)
                    .HasColumnType("text")
                    .IsRequired(false);

                // General Information
                ac.Property(a => a.BeneficiaryName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiaryNameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiaryNid)
                    .HasColumnType("varchar(100)")
                    .IsRequired();
                ac.HasIndex(a => a.BeneficiaryNid);

                ac.Property(a => a.BeneficiaryPhone)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiaryPhoneBn)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiaryGender)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(a => a.BeneficiaryEthnicityId)
                    .IsRequired(false);
                ac.Property(a => a.BeneficiaryEthnicityTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiaryAge)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiaryAgeBn)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiaryFatherName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiaryFatherNameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiaryMotherName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiaryMotherNameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiarySpouseName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.BeneficiarySpouseNameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.HeadOfHouseholdName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.HeadOfHouseholdNameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.HeadOfHouseholdGender)
                    .HasColumnType("smallint")
                    .IsRequired(false);
                ac.Property(a => a.PresentVillageName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.PresentVillageNameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.PresentPostOfficeName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.PresentPostOfficeNameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.PresentDivisionId).IsRequired();
                ac.Property(a => a.PresentDistrictId).IsRequired();
                ac.Property(a => a.PresentUpazillaId).IsRequired();
                ac.Property(a => a.PresentUnionNewId).IsRequired(false);
                ac.Property(a => a.PresentUnion)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.IsPermanentSameAsPresent).IsRequired();
                ac.Property(x => x.PermanentVillageName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.PermanentVillageNameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.PermanentPostOfficeName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.PermanentPostOfficeNameBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.PermanentDivisionId).IsRequired(false);
                ac.Property(x => x.PermanentDistrictId).IsRequired(false);
                ac.Property(x => x.PermanentUpazillaId).IsRequired(false);
                ac.Property(a => a.PermanentUnionNewId).IsRequired(false);
                ac.Property(x => x.PermanentUnion)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.PermanentUnionBn)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.BeneficiaryLatitude).IsRequired(false);
                ac.Property(x => x.BeneficiaryLongitude).IsRequired(false);
                ac.Property(x => x.BeneficiaryAltitude).IsRequired(false);
                ac.Property(x => x.BeneficiaryPrecision).IsRequired(false);
                ac.Property(x => x.BeneficiaryHouseFrontImage)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.BeneficiaryHouseFrontImageURL)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                // Economic Status
                ac.Property(x => x.GrandTotalLandOccupancy).IsRequired();
                ac.Property(x => x.GrandTotalLivestockCost).IsRequired();
                ac.Property(x => x.GrandTotalAssetsCost).IsRequired();
                ac.Property(x => x.GrandTotalImmovableAnnualReturn).IsRequired();
                ac.Property(x => x.GrandTotalEnergyUsesMonthly).IsRequired();

                // Access to Resources and Services
                ac.Property(x => x.NearestHealthServiceLocation)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.SourceofDrySeasonWaterEnumList)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                ac.Property(x => x.SourceofDrySeasonWaterTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.SourceofWetSeasonWaterEnumList)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                ac.Property(x => x.SourceofWetSeasonWaterTxt)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.NearestGrowthCenter)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.EducationalInstituteAccessibilityEnum)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.SanitationFacilitiesEnum)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.PotentialSkillName1)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.PotentialSkillName2)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.PotentialSkillName3)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.PotentialSpecialSkill)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.PotentialSkillsRemarks)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                // Cross cutting issues
                ac.Property(x => x.ForestMngmtSatisfactionEnum)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.ForestMngmtEffectivenessEnum)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.ForestDependencyEnum)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.DicisionTakerEnum)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.ProductiveAssetsOwnerGender)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.CropTypeDecisionGender)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.DecisionToTransferAssetsGender)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.FamilyNeedsDeciderGender)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.AccessorToCreditGender)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.ControllerOfCreditGender)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.OfficeBearerGender)
                    .HasColumnType("smallint")
                    .IsRequired();
                ac.Property(x => x.MorePaymentGetterGender)
                    .HasColumnType("smallint")
                    .IsRequired();

                // Remittances
                ac.Property(x => x.OtherFinanceName)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);

                // Food Security
                ac.Property(x => x.HouseholdFoodCondition)
                    .HasColumnType("smallint")
                    .IsRequired(false);
                ac.Property(x => x.FoodCrisisMonth)
                    .IsRequired(false);
                ac.Property(x => x.FoodyPersonInFoodCrisis)
                    .HasColumnType("smallint")
                    .IsRequired(false);

                ac.Property(x => x.NotesImage)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.NotesImageUrl)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.NameOfTheEnumerator)
                    .HasColumnType("varchar(500)")
                    .IsRequired(false);
                ac.Property(x => x.CellPhoneNumber)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);
                ac.Property(x => x.DataCollectionDate)
                    .IsRequired(false);

                // Internal Logic related properties
                ac.Property(x => x.BeneficiaryApproveStatus)
                    .HasDefaultValue(BeneficiaryApproveStatus.Pending);
            });

            builder.Entity<Survey>()
                .HasOne(x => x.Ngo)
                .WithMany(x => x.Surveys)
                .HasForeignKey(x => x.NgoId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            // Forest administration
            builder.Entity<Survey>()
                .HasOne(x => x.ForestCircle)
                .WithMany(x => x.Surveys)
                .HasForeignKey(x => x.ForestCircleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Survey>()
                .HasOne(x => x.ForestDivision)
                .WithMany(x => x.Surveys)
                .HasForeignKey(x => x.ForestDivisionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Survey>()
                .HasOne(x => x.ForestRange)
                .WithMany(x => x.Surveys)
                .HasForeignKey(x => x.ForestRangeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Survey>()
                .HasOne(x => x.ForestBeat)
                .WithMany(x => x.Surveys)
                .HasForeignKey(x => x.ForestBeatId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Survey>()
                .HasOne(x => x.ForestFcvVcf)
                .WithMany(x => x.Surveys)
                .HasForeignKey(x => x.ForestFcvVcfId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            // General Information Relations
            builder.Entity<Survey>()
                .HasOne(x => x.BeneficiaryEthnicity)
                .WithMany(x => x.Surveys)
                .HasForeignKey(x => x.BeneficiaryEthnicityId)
                .IsRequired(false);
            builder.Entity<Survey>() // Present
                .HasOne(x => x.PresentDivision)
                .WithMany(x => x.SurveyPresentDivisions)
                .HasForeignKey(x => x.PresentDivisionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Survey>()
                .HasOne(x => x.PresentDistrict)
                .WithMany(x => x.SurveyPresentDistricts)
                .HasForeignKey(x => x.PresentDistrictId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Survey>()
                .HasOne(x => x.PresentUpazilla)
                .WithMany(x => x.SurveyPresentUpazillas)
                .HasForeignKey(x => x.PresentUpazillaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Survey>()
                .HasOne(x => x.PresentUnionNew)
                .WithMany(x => x.SurveyPresentUnions)
                .HasForeignKey(x => x.PresentUnionNewId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Survey>() // Permanent
                .HasOne(x => x.PermanentDivision)
                .WithMany(x => x.SurveyPermanentDivisions)
                .HasForeignKey(x => x.PermanentDivisionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Survey>()
                .HasOne(x => x.PermanentDistrict)
                .WithMany(x => x.SurveyPermanentDistricts)
                .HasForeignKey(x => x.PermanentDistrictId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Survey>()
                .HasOne(x => x.PermanentUpazilla)
                .WithMany(x => x.SurveyPermanentUpazillas)
                .HasForeignKey(x => x.PermanentUpazillaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Survey>()
                .HasOne(x => x.PermanentUnionNew)
                .WithMany(x => x.SurveyPermanentUnions)
                .HasForeignKey(x => x.PermanentUnionNewId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Survey>()
                .HasOne(x => x.User)
                .WithOne(x => x.Survey)
                .HasForeignKey<User>(x => x.SurveyId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Survey>()
                .HasOne(x => x.BeneficiaryApproveStatusBy)
                .WithMany(x => x.Surveys)
                .HasForeignKey(x => x.BeneficiaryApproveStatusById)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Survey>()
                .HasOne(x => x.TypeOfHouse)
                .WithMany(x => x.Surveys)
                .HasForeignKey(x => x.TypeOfHouseId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Survey>()
                .HasIndex(x => x.BeneficiaryId)
                .IsUnique(false);

            builder.Entity<Survey>().HasQueryFilter(q => !q.IsDeleted);
        }
    }
}

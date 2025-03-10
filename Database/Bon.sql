PGDMP                          |            Bon    15.4    15.4 H   �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    33224    Bon    DATABASE     �   CREATE DATABASE "Bon" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United Kingdom.1252';
    DROP DATABASE "Bon";
                postgres    false                        2615    34773    AIG    SCHEMA        CREATE SCHEMA "AIG";
    DROP SCHEMA "AIG";
                postgres    false                        2615    33230    BEN    SCHEMA        CREATE SCHEMA "BEN";
    DROP SCHEMA "BEN";
                postgres    false                        2615    35059    BSA    SCHEMA        CREATE SCHEMA "BSA";
    DROP SCHEMA "BSA";
                postgres    false            
            2615    34041    Capacity    SCHEMA        CREATE SCHEMA "Capacity";
    DROP SCHEMA "Capacity";
                postgres    false                        2615    33232    GS    SCHEMA        CREATE SCHEMA "GS";
    DROP SCHEMA "GS";
                postgres    false                        2615    35748    InternalLoan    SCHEMA        CREATE SCHEMA "InternalLoan";
    DROP SCHEMA "InternalLoan";
                postgres    false                        2615    35909    Labour    SCHEMA        CREATE SCHEMA "Labour";
    DROP SCHEMA "Labour";
                postgres    false            	            2615    34005 	   Marketing    SCHEMA        CREATE SCHEMA "Marketing";
    DROP SCHEMA "Marketing";
                postgres    false                        2615    34656    Meeting    SCHEMA        CREATE SCHEMA "Meeting";
    DROP SCHEMA "Meeting";
                postgres    false                        2615    35366 
   Patrolling    SCHEMA        CREATE SCHEMA "Patrolling";
    DROP SCHEMA "Patrolling";
                postgres    false                        2615    36249    PatrollingScheduling    SCHEMA     &   CREATE SCHEMA "PatrollingScheduling";
 $   DROP SCHEMA "PatrollingScheduling";
                postgres    false                        2615    35476 
   Plantation    SCHEMA        CREATE SCHEMA "Plantation";
    DROP SCHEMA "Plantation";
                postgres    false                        2615    36817    SocialForestry    SCHEMA         CREATE SCHEMA "SocialForestry";
    DROP SCHEMA "SocialForestry";
                postgres    false                        2615    34488    Student    SCHEMA        CREATE SCHEMA "Student";
    DROP SCHEMA "Student";
                postgres    false                        2615    33231    System    SCHEMA        CREATE SCHEMA "System";
    DROP SCHEMA "System";
                postgres    false                        2615    34913    TRANSACTION    SCHEMA        CREATE SCHEMA "TRANSACTION";
    DROP SCHEMA "TRANSACTION";
                postgres    false            �           1259    35151    AIGBasicInformations    TABLE     �  CREATE TABLE "AIG"."AIGBasicInformations" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "ForestFcvVcfId" bigint NOT NULL,
    "DivisionId" bigint NOT NULL,
    "DistrictId" bigint NOT NULL,
    "UpazillaId" bigint NOT NULL,
    "UnionId" bigint,
    "NgoId" bigint NOT NULL,
    "SurveyId" bigint NOT NULL,
    "IsRecievedTrainingInTrade" boolean NOT NULL,
    "TradeId" bigint,
    "TotalAllocatedLoanAmount" double precision NOT NULL,
    "MaximumRepaymentMonth" integer NOT NULL,
    "StartDate" timestamp without time zone NOT NULL,
    "EndDate" timestamp without time zone NOT NULL,
    "ServiceChargePercentage" double precision NOT NULL,
    "SecurityChargePercentage" double precision NOT NULL,
    "LDFCount" integer DEFAULT 0 NOT NULL,
    "BadLoanType" integer DEFAULT 0 NOT NULL
);
 )   DROP TABLE "AIG"."AIGBasicInformations";
       AIG         heap    postgres    false    13            �           1259    35150    AIGBasicInformations_Id_seq    SEQUENCE     �   ALTER TABLE "AIG"."AIGBasicInformations" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "AIG"."AIGBasicInformations_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            AIG          postgres    false    404    13            �           1259    35225    FirstSixtyPercentageLDFs    TABLE       CREATE TABLE "AIG"."FirstSixtyPercentageLDFs" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "AIGBasicInformationId" bigint NOT NULL,
    "HasGrace" boolean NOT NULL,
    "ServiceChargeAmount" double precision NOT NULL,
    "SecurityChargeAmount" double precision NOT NULL,
    "GraceMonth" integer DEFAULT 0 NOT NULL,
    "HasBankAccountInHisOwnName" boolean DEFAULT false NOT NULL,
    "IsAgreeToInvestInOwnIncomeActivities" boolean DEFAULT false NOT NULL,
    "IsAgreedToKeepIncomeAndExpenditureFund" boolean DEFAULT false NOT NULL,
    "IsAttendedEightyPercentageOfMeetings" boolean DEFAULT false NOT NULL,
    "IsFirstInstallmentIsCertifiedBySocialAuditCommittee" boolean DEFAULT false NOT NULL,
    "IsPayingRegularIncomingInstallments" boolean DEFAULT false NOT NULL,
    "ShallAdhereTheCOM" boolean DEFAULT false NOT NULL,
    "LDFAmount" double precision DEFAULT 0.0 NOT NULL,
    "SecurityChargePercentage" double precision DEFAULT 0.0 NOT NULL,
    "ServiceChargePercentage" double precision DEFAULT 0.0 NOT NULL
);
 -   DROP TABLE "AIG"."FirstSixtyPercentageLDFs";
       AIG         heap    postgres    false    13            �           1259    35224    FirstSixtyPercentageLDFs_Id_seq    SEQUENCE     �   ALTER TABLE "AIG"."FirstSixtyPercentageLDFs" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "AIG"."FirstSixtyPercentageLDFs_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            AIG          postgres    false    406    13            �           1259    36183    GroupLDFInfoFormMembers    TABLE     �  CREATE TABLE "AIG"."GroupLDFInfoFormMembers" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "GroupLDFInfoFormId" bigint NOT NULL,
    "IndividualLDFInfoFormId" bigint NOT NULL
);
 ,   DROP TABLE "AIG"."GroupLDFInfoFormMembers";
       AIG         heap    postgres    false    13            �           1259    36182    GroupLDFInfoFormMember_Id_seq    SEQUENCE     �   ALTER TABLE "AIG"."GroupLDFInfoFormMembers" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "AIG"."GroupLDFInfoFormMember_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            AIG          postgres    false    440    13            �           1259    36120    GroupLDFInfoForms    TABLE     �  CREATE TABLE "AIG"."GroupLDFInfoForms" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "ForestFcvVcfId" bigint NOT NULL,
    "DivisionId" bigint NOT NULL,
    "DistrictId" bigint NOT NULL,
    "UpazillaId" bigint NOT NULL,
    "UnionId" bigint,
    "NgoId" bigint,
    "SubmittedById" bigint NOT NULL,
    "SubmittedDate" timestamp without time zone NOT NULL,
    "DocumentName" text,
    "DocumentNameURL" text NOT NULL,
    "TotalMember" integer DEFAULT 0 NOT NULL
);
 &   DROP TABLE "AIG"."GroupLDFInfoForms";
       AIG         heap    postgres    false    13            �           1259    36119    GroupLDFInfoForms_Id_seq    SEQUENCE     �   ALTER TABLE "AIG"."GroupLDFInfoForms" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "AIG"."GroupLDFInfoForms_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            AIG          postgres    false    13    438            �           1259    35717    IndividualGroupFormSetups    TABLE     �  CREATE TABLE "AIG"."IndividualGroupFormSetups" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "IndividualDocument" text,
    "GroupDocument" text
);
 .   DROP TABLE "AIG"."IndividualGroupFormSetups";
       AIG         heap    postgres    false    13            �           1259    35716     IndividualGroupFormSetups_Id_seq    SEQUENCE     �   ALTER TABLE "AIG"."IndividualGroupFormSetups" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "AIG"."IndividualGroupFormSetups_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            AIG          postgres    false    13    422            �           1259    35594    IndividualLDFInfoForms    TABLE     3  CREATE TABLE "AIG"."IndividualLDFInfoForms" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "ForestFcvVcfId" bigint NOT NULL,
    "DivisionId" bigint NOT NULL,
    "DistrictId" bigint NOT NULL,
    "UpazillaId" bigint NOT NULL,
    "UnionId" bigint,
    "SurveyId" bigint NOT NULL,
    "RequestedLoanAmount" double precision NOT NULL,
    "ApprovedLoanAmount" double precision NOT NULL,
    "IndividualLDFInfoStatus" integer NOT NULL,
    "StatusDate" timestamp without time zone,
    "DocumentInfoURL" text NOT NULL,
    "SubmittedDate" timestamp without time zone DEFAULT '-infinity'::timestamp without time zone NOT NULL,
    "NgoId" bigint
);
 +   DROP TABLE "AIG"."IndividualLDFInfoForms";
       AIG         heap    postgres    false    13            �           1259    35593    IndividualLDFInfoForms_Id_seq    SEQUENCE     �   ALTER TABLE "AIG"."IndividualLDFInfoForms" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "AIG"."IndividualLDFInfoForms_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            AIG          postgres    false    420    13            �           1259    35486    LDFProgresss    TABLE     �  CREATE TABLE "AIG"."LDFProgresss" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "AIGBasicInformationId" bigint NOT NULL,
    "RepaymentLDFId" bigint NOT NULL,
    "RepaymentStartDate" timestamp without time zone NOT NULL,
    "RepaymentEndDate" timestamp without time zone NOT NULL,
    "RepaymentSerial" integer NOT NULL,
    "ProgressAmount" double precision NOT NULL,
    "ProgressResource" text
);
 !   DROP TABLE "AIG"."LDFProgresss";
       AIG         heap    postgres    false    13            �           1259    35485    LDFProgresss_Id_seq    SEQUENCE     �   ALTER TABLE "AIG"."LDFProgresss" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "AIG"."LDFProgresss_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            AIG          postgres    false    418    13            �           1259    37118    RepaymentLDFFiles    TABLE     �  CREATE TABLE "AIG"."RepaymentLDFFiles" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "FileName" text,
    "FileNameUrl" text,
    "FileType" integer NOT NULL,
    "RepaymentLDFId" bigint NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 &   DROP TABLE "AIG"."RepaymentLDFFiles";
       AIG         heap    postgres    false    13            �           1259    37117    RepaymentLDFFiles_Id_seq    SEQUENCE     �   ALTER TABLE "AIG"."RepaymentLDFFiles" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "AIG"."RepaymentLDFFiles_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            AIG          postgres    false    482    13            �           1259    35876    RepaymentLDFHistories    TABLE     <  CREATE TABLE "AIG"."RepaymentLDFHistories" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "RepaymentLDFId" bigint NOT NULL,
    "EventUserId" bigint NOT NULL,
    "EventOccurredDate" timestamp without time zone NOT NULL,
    "EventMessage" text,
    "RepaymentLDFEventType" integer NOT NULL
);
 *   DROP TABLE "AIG"."RepaymentLDFHistories";
       AIG         heap    postgres    false    13            �           1259    35875    RepaymentLDFHistories_Id_seq    SEQUENCE     �   ALTER TABLE "AIG"."RepaymentLDFHistories" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "AIG"."RepaymentLDFHistories_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            AIG          postgres    false    428    13            �           1259    35257    RepaymentLDFs    TABLE     �  CREATE TABLE "AIG"."RepaymentLDFs" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "FirstSixtyPercentageLDFId" bigint,
    "SecondFourtyPercentageLDFId" bigint,
    "RepaymentStartDate" timestamp without time zone NOT NULL,
    "RepaymentEndDate" timestamp without time zone NOT NULL,
    "IsPaymentCompleted" boolean NOT NULL,
    "PaymentCompletedDateTime" timestamp without time zone,
    "IsPaymentCompletedLate" boolean NOT NULL,
    "AIGBasicInformationId" bigint DEFAULT 0 NOT NULL,
    "FirstSixtyPercentRepaymentAmount" double precision DEFAULT 0.0 NOT NULL,
    "SecondFortyPercentRepaymentAmount" double precision DEFAULT 0.0 NOT NULL,
    "RepaymentSerial" integer DEFAULT 0 NOT NULL,
    "IsLocked" boolean DEFAULT false NOT NULL
);
 "   DROP TABLE "AIG"."RepaymentLDFs";
       AIG         heap    postgres    false    13            �           1259    35256    RepaymentLDFs_Id_seq    SEQUENCE     �   ALTER TABLE "AIG"."RepaymentLDFs" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "AIG"."RepaymentLDFs_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            AIG          postgres    false    13    410            �           1259    35241    SecondFourtyPercentageLDFs    TABLE     6  CREATE TABLE "AIG"."SecondFourtyPercentageLDFs" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "AIGBasicInformationId" bigint NOT NULL,
    "ServiceChargeAmount" double precision NOT NULL,
    "SecurityChargeAmount" double precision NOT NULL,
    "DidNotBreakTheTenPrinciples" boolean DEFAULT false NOT NULL,
    "HasInvestedSeventyPercentageOfTheLoan" boolean DEFAULT false NOT NULL,
    "IncomeExpenditureFundLoansUpdatedAndCertified" boolean DEFAULT false NOT NULL,
    "IsAttendedRegularMeetings" boolean DEFAULT false NOT NULL,
    "IsLivelihoodDevelopmentFundCertifiedAndApproved" boolean DEFAULT false NOT NULL,
    "IsPaidTheLoanInstallmentThreeConsecutiveMonths" boolean DEFAULT false NOT NULL,
    "LDFAmount" double precision DEFAULT 0.0 NOT NULL,
    "StartDate" timestamp without time zone DEFAULT '-infinity'::timestamp without time zone NOT NULL,
    "StartRepaymentLDFId" bigint DEFAULT 0 NOT NULL,
    "SecurityChargePercentage" double precision DEFAULT 0.0 NOT NULL,
    "ServiceChargePercentage" double precision DEFAULT 0.0 NOT NULL
);
 /   DROP TABLE "AIG"."SecondFourtyPercentageLDFs";
       AIG         heap    postgres    false    13            �           1259    35240 !   SecondFourtyPercentageLDFs_Id_seq    SEQUENCE     �   ALTER TABLE "AIG"."SecondFourtyPercentageLDFs" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "AIG"."SecondFourtyPercentageLDFs_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            AIG          postgres    false    13    408            0           1259    33568    AnnualHouseholdExpenditures    TABLE     G  CREATE TABLE "BEN"."AnnualHouseholdExpenditures" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ExpenditureTypeId" bigint,
    "ExpenditureTypeTxt" character varying(500),
    "ExpenditureCost" double precision NOT NULL,
    "ExpenditureRemarks" character varying(500),
    "SurveyId" bigint NOT NULL
);
 0   DROP TABLE "BEN"."AnnualHouseholdExpenditures";
       BEN         heap    postgres    false    6            /           1259    33567 "   AnnualHouseholdExpenditures_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."AnnualHouseholdExpenditures" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."AnnualHouseholdExpenditures_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    304            �            1259    33234 
   AssetTypes    TABLE     �  CREATE TABLE "BEN"."AssetTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
    DROP TABLE "BEN"."AssetTypes";
       BEN         heap    postgres    false    6            �            1259    33233    AssetTypes_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."AssetTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."AssetTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    232            2           1259    33584    Assets    TABLE     (  CREATE TABLE "BEN"."Assets" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "AssetTypeId" bigint NOT NULL,
    "AssetTypeTxt" character varying(500),
    "AssetQuantity" double precision NOT NULL,
    "AssetsCost" double precision NOT NULL,
    "SurveyId" bigint NOT NULL
);
    DROP TABLE "BEN"."Assets";
       BEN         heap    postgres    false    6            1           1259    33583    Assets_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."Assets" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."Assets_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    306            M           1259    33811 "   BFDAssociationHouseholdMembersMaps    TABLE     #  CREATE TABLE "BEN"."BFDAssociationHouseholdMembersMaps" (
    "BFDAssociationId" bigint NOT NULL,
    "HouseholdMemberId" bigint NOT NULL,
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone DEFAULT '-infinity'::timestamp without time zone NOT NULL,
    "CreatedBy" bigint DEFAULT 0 NOT NULL,
    "DeletedAt" timestamp without time zone,
    "DeletedBy" bigint,
    "IsActive" boolean DEFAULT false NOT NULL,
    "IsDeleted" boolean DEFAULT false NOT NULL,
    "ModifiedBy" bigint,
    "UpdatedAt" timestamp without time zone
);
 7   DROP TABLE "BEN"."BFDAssociationHouseholdMembersMaps";
       BEN         heap    postgres    false    6            P           1259    33990 )   BFDAssociationHouseholdMembersMaps_Id_seq    SEQUENCE       ALTER TABLE "BEN"."BFDAssociationHouseholdMembersMaps" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."BFDAssociationHouseholdMembersMaps_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    333            �            1259    33240    BFDAssociations    TABLE     �  CREATE TABLE "BEN"."BFDAssociations" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 $   DROP TABLE "BEN"."BFDAssociations";
       BEN         heap    postgres    false    6            �            1259    33239    BFDAssociations_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."BFDAssociations" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."BFDAssociations_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    234    6            �            1259    33246    BusinessIncomeSourceTypes    TABLE     �  CREATE TABLE "BEN"."BusinessIncomeSourceTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 .   DROP TABLE "BEN"."BusinessIncomeSourceTypes";
       BEN         heap    postgres    false    6            �            1259    33245     BusinessIncomeSourceTypes_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."BusinessIncomeSourceTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."BusinessIncomeSourceTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    236    6            4           1259    33600 	   Businesss    TABLE     �  CREATE TABLE "BEN"."Businesss" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "BusinessIncomeSourceTypeId" bigint,
    "BusinessIncomeSourceTypeTxt" character varying(500),
    "BusinessGrossValueOfSales" double precision NOT NULL,
    "BusinessTotalCashCosts" double precision NOT NULL,
    "TotalNetIncome" double precision NOT NULL,
    "SurveyId" bigint NOT NULL
);
    DROP TABLE "BEN"."Businesss";
       BEN         heap    postgres    false    6            3           1259    33599    Businesss_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."Businesss" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."Businesss_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    308            �           1259    37071    CipFiles    TABLE     �  CREATE TABLE "BEN"."CipFiles" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CipId" bigint NOT NULL,
    "FileName" text,
    "FileNameUrl" text,
    "FileType" integer NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
    DROP TABLE "BEN"."CipFiles";
       BEN         heap    postgres    false    6            �           1259    37070    CipFiles_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."CipFiles" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."CipFiles_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    478            �           1259    36744    Cips    TABLE     �  CREATE TABLE "BEN"."Cips" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "ForestFcvVcfId" bigint NOT NULL,
    "DivisionId" bigint NOT NULL,
    "DistrictId" bigint NOT NULL,
    "UpazillaId" bigint NOT NULL,
    "UnionId" bigint,
    "ForestVillageName" text,
    "HouseholdSerialNo" text,
    "BeneficiaryName" text,
    "Gender" integer NOT NULL,
    "FatherOrSpouseName" text,
    "EthnicityId" bigint,
    "NID" text,
    "MobileNumber" text,
    "HouseType" integer NOT NULL,
    "CipWealth" integer NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "CipGeneratedId" text
);
    DROP TABLE "BEN"."Cips";
       BEN         heap    postgres    false    6            �           1259    36743    Cips_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."Cips" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."Cips_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    450    6            �           1259    37225    CommitteeManagement    TABLE     �  CREATE TABLE "BEN"."CommitteeManagement" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "DivisionId" bigint NOT NULL,
    "DistrictId" bigint NOT NULL,
    "UpazillaId" bigint NOT NULL,
    "UnionId" bigint NOT NULL,
    "NgoId" bigint NOT NULL,
    "CommitteeTypeId" integer NOT NULL,
    "SubCommitteeTypeId" integer,
    "CommitteeFormDate" timestamp without time zone NOT NULL,
    "CommitteeEndDate" timestamp without time zone NOT NULL,
    "NameOfBankAC" text,
    "AccountNumber" text,
    "AccountType" text,
    "BankName" text,
    "BranchName" text,
    "AccountOpeningDate" timestamp without time zone,
    "Remark" text,
    "IsInActiveCommittee" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 (   DROP TABLE "BEN"."CommitteeManagement";
       BEN         heap    postgres    false    6            �           1259    37278    CommitteeManagementMember    TABLE     q  CREATE TABLE "BEN"."CommitteeManagementMember" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "CommitteeManagementId" bigint NOT NULL,
    "ExecutiveDesignationId" integer,
    "SubCommitteeDesignationId" bigint,
    "SurveyId" bigint,
    "OtherCommitteeMemberId" bigint,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 .   DROP TABLE "BEN"."CommitteeManagementMember";
       BEN         heap    postgres    false    6            �           1259    37277     CommitteeManagementMember_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."CommitteeManagementMember" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."CommitteeManagementMember_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    490            �           1259    37224    CommitteeManagement_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."CommitteeManagement" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."CommitteeManagement_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    488            N           1259    33826 "   DisabilityTypeHouseholdMembersMaps    TABLE     #  CREATE TABLE "BEN"."DisabilityTypeHouseholdMembersMaps" (
    "DisabilityTypeId" bigint NOT NULL,
    "HouseholdMemberId" bigint NOT NULL,
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone DEFAULT '-infinity'::timestamp without time zone NOT NULL,
    "CreatedBy" bigint DEFAULT 0 NOT NULL,
    "DeletedAt" timestamp without time zone,
    "DeletedBy" bigint,
    "IsActive" boolean DEFAULT false NOT NULL,
    "IsDeleted" boolean DEFAULT false NOT NULL,
    "ModifiedBy" bigint,
    "UpdatedAt" timestamp without time zone
);
 7   DROP TABLE "BEN"."DisabilityTypeHouseholdMembersMaps";
       BEN         heap    postgres    false    6            O           1259    33981 )   DisabilityTypeHouseholdMembersMaps_Id_seq    SEQUENCE       ALTER TABLE "BEN"."DisabilityTypeHouseholdMembersMaps" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."DisabilityTypeHouseholdMembersMaps_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    334            �            1259    33252    DisabilityTypes    TABLE     �  CREATE TABLE "BEN"."DisabilityTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 $   DROP TABLE "BEN"."DisabilityTypes";
       BEN         heap    postgres    false    6            �            1259    33251    DisabilityTypes_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."DisabilityTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."DisabilityTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    238    6            �            1259    33258    EnergyTypes    TABLE     �  CREATE TABLE "BEN"."EnergyTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
     DROP TABLE "BEN"."EnergyTypes";
       BEN         heap    postgres    false    6            �            1259    33257    EnergyTypes_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."EnergyTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."EnergyTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    240    6            6           1259    33616 
   EnergyUses    TABLE     	  CREATE TABLE "BEN"."EnergyUses" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "EnergyTypeId" bigint NOT NULL,
    "EnergyUseTypeTxt" character varying(500),
    "EnergyUsesMonthly" double precision NOT NULL,
    "SurveyId" bigint NOT NULL
);
    DROP TABLE "BEN"."EnergyUses";
       BEN         heap    postgres    false    6            5           1259    33615    EnergyUses_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."EnergyUses" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."EnergyUses_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    310    6            �            1259    33264 
   Ethnicitys    TABLE     �  CREATE TABLE "BEN"."Ethnicitys" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
    DROP TABLE "BEN"."Ethnicitys";
       BEN         heap    postgres    false    6            �            1259    33263    Ethnicitys_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."Ethnicitys" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."Ethnicitys_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    242    6            p           1259    34330    ExecutiveCommittee    TABLE     �  CREATE TABLE "BEN"."ExecutiveCommittee" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "NgoId" bigint,
    "AccountNumber" character varying(500),
    "AccountOpeningDate" timestamp without time zone,
    "AccountType" character varying(500),
    "BankName" character varying(500),
    "BranchName" character varying(500),
    "CellNo" character varying(500),
    "ForestCircleId" bigint,
    "CommitteeTypeId" bigint,
    "DesignatinId" bigint,
    "EthnicityId" bigint,
    "FatherOrSpouse" character varying(500),
    "ForestFcvVcfId" bigint,
    "ForestDivisionId" bigint,
    "GenderId" bigint,
    "IsFcv" boolean,
    "NameOfBankAC" character varying(500),
    "NidNo" character varying(500),
    "OfficeBearersId" bigint,
    "ForestRangeId" bigint,
    "Remark" character varying(500),
    "ForestBeatId" bigint,
    "ExDesignatinId" bigint,
    "OtherMemberId" bigint,
    "SubCommitteeDesignationId" bigint,
    "DistrictId" bigint,
    "DivisionId" bigint,
    "UpazillaId" bigint,
    "UnionId" bigint,
    "CommitteeEndDate" timestamp without time zone,
    "CommitteeFormDate" timestamp without time zone,
    "IsActiveCommittee" boolean
);
 '   DROP TABLE "BEN"."ExecutiveCommittee";
       BEN         heap    postgres    false    6            o           1259    34329    ExecutiveCommittee_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."ExecutiveCommittee" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."ExecutiveCommittee_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    368            8           1259    33632    ExistingSkills    TABLE     �  CREATE TABLE "BEN"."ExistingSkills" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "SkillName" character varying(500),
    "SkillLevelEnum" smallint,
    "Remarks" character varying(500),
    "SurveyId" bigint NOT NULL
);
 #   DROP TABLE "BEN"."ExistingSkills";
       BEN         heap    postgres    false    6            7           1259    33631    ExistingSkills_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."ExistingSkills" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."ExistingSkills_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    312            �            1259    33270    ExpenditureTypes    TABLE     �  CREATE TABLE "BEN"."ExpenditureTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 %   DROP TABLE "BEN"."ExpenditureTypes";
       BEN         heap    postgres    false    6            �            1259    33269    ExpenditureTypes_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."ExpenditureTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."ExpenditureTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    244            n           1259    34317    FcvExecutiveCommitteeMember    TABLE       CREATE TABLE "BEN"."FcvExecutiveCommitteeMember" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "ExecutiveMemberTypeId" bigint,
    "NgoId" bigint,
    "BeneficiaryId" bigint
);
 0   DROP TABLE "BEN"."FcvExecutiveCommitteeMember";
       BEN         heap    postgres    false    6            m           1259    34316 "   FcvCxecutiveCommitteeMember_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."FcvExecutiveCommitteeMember" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."FcvCxecutiveCommitteeMember_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    366            �            1259    33276 	   FoodItems    TABLE     �  CREATE TABLE "BEN"."FoodItems" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
    DROP TABLE "BEN"."FoodItems";
       BEN         heap    postgres    false    6            �            1259    33275    FoodItems_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."FoodItems" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."FoodItems_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    246            :           1259    33643    FoodSecurityItems    TABLE     5  CREATE TABLE "BEN"."FoodSecurityItems" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "FoodItemId" bigint NOT NULL,
    "FoodItemTxt" character varying(500),
    "FoodAvilableMonthInYear" double precision NOT NULL,
    "Remarks" character varying(500),
    "SurveyId" bigint NOT NULL
);
 &   DROP TABLE "BEN"."FoodSecurityItems";
       BEN         heap    postgres    false    6            9           1259    33642    FoodSecurityItems_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."FoodSecurityItems" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."FoodSecurityItems_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    314            *           1259    33478    ForestBeats    TABLE     �  CREATE TABLE "BEN"."ForestBeats" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "ForestRangeId" bigint NOT NULL
);
     DROP TABLE "BEN"."ForestBeats";
       BEN         heap    postgres    false    6            )           1259    33477    ForestBeats_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."ForestBeats" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."ForestBeats_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    298            �            1259    33282    ForestCircles    TABLE     �  CREATE TABLE "BEN"."ForestCircles" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 "   DROP TABLE "BEN"."ForestCircles";
       BEN         heap    postgres    false    6            �            1259    33281    ForestCircles_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."ForestCircles" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."ForestCircles_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    248                        1259    33406    ForestDivisions    TABLE     �  CREATE TABLE "BEN"."ForestDivisions" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "ForestCircleId" bigint NOT NULL
);
 $   DROP TABLE "BEN"."ForestDivisions";
       BEN         heap    postgres    false    6                       1259    33405    ForestDivisions_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."ForestDivisions" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."ForestDivisions_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    288            ,           1259    33489    ForestFcvVcfs    TABLE     ,  CREATE TABLE "BEN"."ForestFcvVcfs" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "ForestBeatId" bigint NOT NULL,
    "IsFcv" boolean DEFAULT false NOT NULL,
    "FormedTime" timestamp without time zone
);
 "   DROP TABLE "BEN"."ForestFcvVcfs";
       BEN         heap    postgres    false    6            +           1259    33488    ForestFcvVcfs_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."ForestFcvVcfs" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."ForestFcvVcfs_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    300            &           1259    33456    ForestRanges    TABLE     �  CREATE TABLE "BEN"."ForestRanges" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "ForestDivisionId" bigint NOT NULL
);
 !   DROP TABLE "BEN"."ForestRanges";
       BEN         heap    postgres    false    6            %           1259    33455    ForestRanges_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."ForestRanges" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."ForestRanges_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    294            <           1259    33659     GrossMarginIncomeAndCostStatuses    TABLE     �  CREATE TABLE "BEN"."GrossMarginIncomeAndCostStatuses" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ProductName" character varying(500),
    "LandArea" double precision NOT NULL,
    "MeasurementOfProduct" character varying(500),
    "TotalProductionHousehold" double precision NOT NULL,
    "TotalCostOfProduction" double precision NOT NULL,
    "TotalConsumption" double precision NOT NULL,
    "QuantitySold" double precision NOT NULL,
    "TotalValueSold" double precision NOT NULL,
    "ValueSoldPerQuantity" double precision NOT NULL,
    "ProductionValueSoldPerQuantity" double precision NOT NULL,
    "TotalNetIncome" double precision NOT NULL,
    "SurveyId" bigint NOT NULL
);
 5   DROP TABLE "BEN"."GrossMarginIncomeAndCostStatuses";
       BEN         heap    postgres    false    6            ;           1259    33658 '   GrossMarginIncomeAndCostStatuses_Id_seq    SEQUENCE       ALTER TABLE "BEN"."GrossMarginIncomeAndCostStatuses" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."GrossMarginIncomeAndCostStatuses_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    316            >           1259    33670    HouseholdMembers    TABLE       CREATE TABLE "BEN"."HouseholdMembers" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "FullName" character varying(500),
    "FullNameBn" character varying(500),
    "RelationWithHeadHouseHoldTypeId" bigint NOT NULL,
    "RelationWithHeadHouseHoldTypeTxt" character varying(500),
    "Gender" smallint NOT NULL,
    "Age" character varying(100),
    "AgeBn" character varying(100),
    "MaritalSatus" smallint NOT NULL,
    "MaritalSatusTxt" character varying(100),
    "EducationLevel" smallint NOT NULL,
    "MainOccupationId" bigint NOT NULL,
    "MainOccupationTxt" character varying(500),
    "SecondaryOccupationId" bigint NOT NULL,
    "SecondOccupationTxt" character varying(500),
    "BFDAssociationTxt" character varying(500),
    "HasDisability" boolean NOT NULL,
    "SafetyNetTypeId" bigint NOT NULL,
    "SafetyNetTypeTxt" text,
    "SubmissionTime" timestamp without time zone NOT NULL,
    "SubmittedBy" character varying(500),
    "Notes" character varying(500),
    "SurveyId" bigint NOT NULL
);
 %   DROP TABLE "BEN"."HouseholdMembers";
       BEN         heap    postgres    false    6            =           1259    33669    HouseholdMembers_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."HouseholdMembers" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."HouseholdMembers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    318            �            1259    33288    ImmovableAssetTypes    TABLE     �  CREATE TABLE "BEN"."ImmovableAssetTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 (   DROP TABLE "BEN"."ImmovableAssetTypes";
       BEN         heap    postgres    false    6            �            1259    33287    ImmovableAssetTypes_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."ImmovableAssetTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."ImmovableAssetTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    250    6            @           1259    33703    ImmovableAssets    TABLE        CREATE TABLE "BEN"."ImmovableAssets" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ImmovableAssetTypeId" bigint NOT NULL,
    "ImmovableAssetsTypeTxt" character varying(500),
    "ImmovableAnnualReturn" double precision NOT NULL,
    "SurveyId" bigint NOT NULL
);
 $   DROP TABLE "BEN"."ImmovableAssets";
       BEN         heap    postgres    false    6            ?           1259    33702    ImmovableAssets_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."ImmovableAssets" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."ImmovableAssets_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    320            B           1259    33719    LandOccupancies    TABLE     �  CREATE TABLE "BEN"."LandOccupancies" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "LandClassificationEnum" smallint NOT NULL,
    "LandClassificationTxt" character varying(500),
    "Homesteads" double precision NOT NULL,
    "ProductiveLand" double precision NOT NULL,
    "FallowLand" double precision NOT NULL,
    "ProductiveWetland" double precision NOT NULL,
    "FallowWetland" double precision NOT NULL,
    "OthersLand" double precision NOT NULL,
    "TotalLand" double precision NOT NULL,
    "SubmissionTime" timestamp without time zone NOT NULL,
    "Notes" character varying(500),
    "SurveyId" bigint NOT NULL
);
 $   DROP TABLE "BEN"."LandOccupancies";
       BEN         heap    postgres    false    6            A           1259    33718    LandOccupancies_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."LandOccupancies" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."LandOccupancies_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    322            �            1259    33294    LiveStockTypes    TABLE     �  CREATE TABLE "BEN"."LiveStockTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 #   DROP TABLE "BEN"."LiveStockTypes";
       BEN         heap    postgres    false    6            �            1259    33293    LiveStockTypes_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."LiveStockTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."LiveStockTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    252            D           1259    33730 
   LiveStocks    TABLE     ;  CREATE TABLE "BEN"."LiveStocks" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "LiveStockTypeId" bigint NOT NULL,
    "LivestockTypeTxt" character varying(500),
    "LiveStockQuantity" double precision NOT NULL,
    "LivestockCost" double precision NOT NULL,
    "SurveyId" bigint NOT NULL
);
    DROP TABLE "BEN"."LiveStocks";
       BEN         heap    postgres    false    6            C           1259    33729    LiveStocks_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."LiveStocks" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."LiveStocks_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    324            �            1259    33300    ManualIncomeSourceTypes    TABLE     �  CREATE TABLE "BEN"."ManualIncomeSourceTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 ,   DROP TABLE "BEN"."ManualIncomeSourceTypes";
       BEN         heap    postgres    false    6            �            1259    33299    ManualIncomeSourceTypes_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."ManualIncomeSourceTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."ManualIncomeSourceTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    254            F           1259    33746    ManualPhysicalWorks    TABLE       CREATE TABLE "BEN"."ManualPhysicalWorks" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ManualIncomeSourceTypeId" bigint,
    "ManualIncomeSourceTypeTxt" character varying(500),
    "NoOfMale" integer NOT NULL,
    "NoOfFemale" integer NOT NULL,
    "NoOfActiveMonth" integer NOT NULL,
    "AvgNoPersonActivePerMonth" integer NOT NULL,
    "AvgDailyIncome" double precision NOT NULL,
    "TotalPerson" double precision NOT NULL,
    "TotalAnnualIncome" double precision NOT NULL,
    "SurveyId" bigint NOT NULL
);
 (   DROP TABLE "BEN"."ManualPhysicalWorks";
       BEN         heap    postgres    false    6            E           1259    33745    ManualPhysicalWorks_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."ManualPhysicalWorks" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."ManualPhysicalWorks_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    326                        1259    33306    NaturalIncomeSourceTypes    TABLE     �  CREATE TABLE "BEN"."NaturalIncomeSourceTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 -   DROP TABLE "BEN"."NaturalIncomeSourceTypes";
       BEN         heap    postgres    false    6            �            1259    33305    NaturalIncomeSourceTypes_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."NaturalIncomeSourceTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."NaturalIncomeSourceTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    256            H           1259    33762 %   NaturalResourcesIncomeAndCostStatuses    TABLE     �  CREATE TABLE "BEN"."NaturalResourcesIncomeAndCostStatuses" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "NaturalIncomeSourceTypeId" bigint,
    "NoOfMale" integer NOT NULL,
    "NoOfFemale" integer NOT NULL,
    "NoOfActiveMonth" integer NOT NULL,
    "AvgNoPersonActivePerMonth" double precision NOT NULL,
    "TotalManDaysForCollection" double precision NOT NULL,
    "Unit" character varying(80),
    "TotalProduced" double precision NOT NULL,
    "TotalConsumption" double precision NOT NULL,
    "QuantitySold" double precision NOT NULL,
    "ValueProduceSold" double precision NOT NULL,
    "CostOfActivity" double precision NOT NULL,
    "ValueSoldPerActivity" double precision NOT NULL,
    "ProducedValueSoldActivity" double precision NOT NULL,
    "ActivityPerValueSold" double precision NOT NULL,
    "TotalNetIncome" double precision NOT NULL,
    "SurveyId" bigint NOT NULL
);
 :   DROP TABLE "BEN"."NaturalResourcesIncomeAndCostStatuses";
       BEN         heap    postgres    false    6            G           1259    33761 ,   NaturalResourcesIncomeAndCostStatuses_Id_seq    SEQUENCE       ALTER TABLE "BEN"."NaturalResourcesIncomeAndCostStatuses" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."NaturalResourcesIncomeAndCostStatuses_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    328    6                       1259    33312    Ngos    TABLE     �  CREATE TABLE "BEN"."Ngos" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "ForestDivisionIdList" bigint[],
    "ForestCircleIdList" bigint[]
);
    DROP TABLE "BEN"."Ngos";
       BEN         heap    postgres    false    6                       1259    33311    Ngos_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."Ngos" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."Ngos_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    258                       1259    33318    Occupations    TABLE     �  CREATE TABLE "BEN"."Occupations" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
     DROP TABLE "BEN"."Occupations";
       BEN         heap    postgres    false    6                       1259    33317    Occupations_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."Occupations" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."Occupations_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    260            r           1259    34423    OtherCommitteeMembers    TABLE     �  CREATE TABLE "BEN"."OtherCommitteeMembers" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "FullName" character varying(500) NOT NULL,
    "Gender" integer NOT NULL,
    "PhoneNumber" text NOT NULL,
    "NID" character varying(100),
    "Address" character varying(600),
    "ForestFcvVcfId" bigint NOT NULL,
    "EthnicityId" bigint,
    "DistrictId" bigint DEFAULT 0 NOT NULL,
    "DivisionId" bigint DEFAULT 0 NOT NULL,
    "FatherOrSpouse" text,
    "ForestBeatId" bigint DEFAULT 0 NOT NULL,
    "ForestCircleId" bigint DEFAULT 0 NOT NULL,
    "ForestDivisionId" bigint DEFAULT 0 NOT NULL,
    "ForestRangeId" bigint DEFAULT 0 NOT NULL,
    "UpazillaId" bigint DEFAULT 0 NOT NULL,
    "UnionId" bigint
);
 *   DROP TABLE "BEN"."OtherCommitteeMembers";
       BEN         heap    postgres    false    6            q           1259    34422    OtherCommitteeMembers_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."OtherCommitteeMembers" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."OtherCommitteeMembers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    370    6                       1259    33324    OtherIncomeSourceTypes    TABLE     �  CREATE TABLE "BEN"."OtherIncomeSourceTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 +   DROP TABLE "BEN"."OtherIncomeSourceTypes";
       BEN         heap    postgres    false    6                       1259    33323    OtherIncomeSourceTypes_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."OtherIncomeSourceTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."OtherIncomeSourceTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    262    6            J           1259    33778    OtherIncomeSources    TABLE     {  CREATE TABLE "BEN"."OtherIncomeSources" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "OtherIncomeSourceTypeId" bigint,
    "OtherIncomeSourceTypeTxt" character varying(500),
    "GrossValueOfSales" double precision NOT NULL,
    "TotalCashCosts" double precision NOT NULL,
    "TotalNetIncome" double precision NOT NULL,
    "SurveyId" bigint NOT NULL
);
 '   DROP TABLE "BEN"."OtherIncomeSources";
       BEN         heap    postgres    false    6            I           1259    33777    OtherIncomeSources_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."OtherIncomeSources" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."OtherIncomeSources_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    330                       1259    33330    RelationWithHeadHouseHoldTypes    TABLE     �  CREATE TABLE "BEN"."RelationWithHeadHouseHoldTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 3   DROP TABLE "BEN"."RelationWithHeadHouseHoldTypes";
       BEN         heap    postgres    false    6                       1259    33329 %   RelationWithHeadHouseHoldTypes_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."RelationWithHeadHouseHoldTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."RelationWithHeadHouseHoldTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    264    6            
           1259    33336 
   SafetyNets    TABLE     �  CREATE TABLE "BEN"."SafetyNets" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
    DROP TABLE "BEN"."SafetyNets";
       BEN         heap    postgres    false    6            	           1259    33335    SafetyNets_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."SafetyNets" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."SafetyNets_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    266            �           1259    35728    SurveyDocuments    TABLE     �  CREATE TABLE "BEN"."SurveyDocuments" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "SurveyId" bigint NOT NULL,
    "DocumentName" text NOT NULL,
    "DocumentNameURL" text NOT NULL
);
 $   DROP TABLE "BEN"."SurveyDocuments";
       BEN         heap    postgres    false    6            �           1259    35727    SurveyDocument_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."SurveyDocuments" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."SurveyDocument_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    424            �           1259    37165    SurveyIncidents    TABLE     3  CREATE TABLE "BEN"."SurveyIncidents" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "SurveyId" bigint NOT NULL,
    "Year" character varying(4),
    "MonthNo" integer NOT NULL,
    "Incident" text,
    "Decision" text,
    "Action" text,
    "SurveyIncidentStatus" integer NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 $   DROP TABLE "BEN"."SurveyIncidents";
       BEN         heap    postgres    false    6            �           1259    37164    SurveyIncidents_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."SurveyIncidents" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."SurveyIncidents_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    486            .           1259    33500    Surveys    TABLE     �  CREATE TABLE "BEN"."Surveys" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "StartTime" timestamp without time zone NOT NULL,
    "EndTime" timestamp without time zone NOT NULL,
    "SurveyDate" timestamp without time zone NOT NULL,
    "Deviceid" character varying(500),
    "Subscriberid" character varying(500),
    "Simserial" character varying(500),
    "Phonenumber" character varying(100),
    "DetailsInfo" character varying(100),
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "ForestFcvVcfId" bigint NOT NULL,
    "ForestVillageName" character varying(500),
    "ForestVillageNameBn" character varying(500),
    "BeneficiaryId" character varying(100) NOT NULL,
    "BeneficiaryHouseholdSerialNo" character varying(100),
    "BeneficiaryName" character varying(500),
    "BeneficiaryNameBn" character varying(500),
    "BeneficiaryNid" character varying(100) NOT NULL,
    "BeneficiaryPhone" character varying(100),
    "BeneficiaryPhoneBn" character varying(100),
    "BeneficiaryGender" smallint NOT NULL,
    "BeneficiaryEthnicityId" bigint,
    "BeneficiaryEthnicityTxt" character varying(500),
    "BeneficiaryAge" character varying(100),
    "BeneficiaryAgeBn" character varying(100),
    "BeneficiaryFatherName" character varying(500),
    "BeneficiaryFatherNameBn" character varying(500),
    "BeneficiaryMotherName" character varying(500),
    "BeneficiaryMotherNameBn" character varying(500),
    "BeneficiarySpouseName" character varying(500),
    "BeneficiarySpouseNameBn" character varying(500),
    "HeadOfHouseholdName" character varying(500),
    "HeadOfHouseholdNameBn" character varying(500),
    "HeadOfHouseholdGender" smallint,
    "PresentVillageName" character varying(500),
    "PresentVillageNameBn" character varying(500),
    "PresentPostOfficeName" character varying(500),
    "PresentPostOfficeNameBn" character varying(500),
    "PresentDivisionId" bigint NOT NULL,
    "PresentDistrictId" bigint NOT NULL,
    "PresentUpazillaId" bigint NOT NULL,
    "PresentUnion" character varying(500),
    "IsPermanentSameAsPresent" boolean NOT NULL,
    "PermanentVillageName" character varying(500),
    "PermanentVillageNameBn" character varying(500),
    "PermanentPostOfficeName" character varying(500),
    "PermanentPostOfficeNameBn" character varying(500),
    "PermanentDivisionId" bigint,
    "PermanentDistrictId" bigint,
    "PermanentUpazillaId" bigint,
    "PermanentUnion" character varying(500),
    "PermanentUnionBn" character varying(500),
    "BeneficiaryLatitude" double precision,
    "BeneficiaryLongitude" double precision,
    "BeneficiaryAltitude" double precision,
    "BeneficiaryPrecision" double precision,
    "BeneficiaryHouseFrontImage" character varying(500),
    "BeneficiaryHouseFrontImageURL" character varying(500),
    "GrandTotalLandOccupancy" double precision NOT NULL,
    "BeneficiaryHouseType" integer NOT NULL,
    "GrandTotalLivestockCost" double precision NOT NULL,
    "GrandTotalAssetsCost" double precision NOT NULL,
    "GrandTotalImmovableAnnualReturn" double precision NOT NULL,
    "GrandTotalEnergyUsesMonthly" double precision NOT NULL,
    "IsProblemToAccessHealthService" boolean NOT NULL,
    "NearestHealthServiceLocation" character varying(500),
    "NearestHealthServiceDistance" double precision NOT NULL,
    "IsProblemToAccessDrinkingWater" boolean NOT NULL,
    "NearestDrinkingWaterDistance" double precision NOT NULL,
    "SourceofDrySeasonWaterEnumList" character varying(100),
    "SourceofDrySeasonWaterTxt" character varying(500),
    "SourceofWetSeasonWaterEnumList" character varying(100),
    "SourceofWetSeasonWaterTxt" character varying(500),
    "NearestGrowthCenter" character varying(500),
    "NearestGrowthCenterDistance" double precision NOT NULL,
    "IsProblemToAccessEducation" boolean NOT NULL,
    "HasEducationalInstituteNearby" boolean NOT NULL,
    "EducationalInstituteDistance" double precision NOT NULL,
    "EducationalInstituteAccessibilityEnum" smallint NOT NULL,
    "SanitationFacilitiesEnum" smallint NOT NULL,
    "PotentialSkillName1" character varying(500),
    "PotentialSkillName2" character varying(500),
    "PotentialSkillName3" character varying(500),
    "PotentialSpecialSkill" character varying(500),
    "PotentialSkillsRemarks" character varying(500),
    "ForestMngmtSatisfactionEnum" smallint NOT NULL,
    "ForestMngmtEffectivenessEnum" smallint NOT NULL,
    "ForestDependencyEnum" smallint NOT NULL,
    "IsHearedAboutCfm" boolean NOT NULL,
    "IsParticipatedInCfm" boolean NOT NULL,
    "WillCfmImproveForestMngmnt" boolean NOT NULL,
    "WillCfmImproveWellBeing" boolean NOT NULL,
    "DicisionTakerEnum" smallint NOT NULL,
    "ProductiveAssetsOwnerGender" smallint NOT NULL,
    "CropTypeDecisionGender" smallint NOT NULL,
    "DecisionToTransferAssetsGender" smallint NOT NULL,
    "FamilyNeedsDeciderGender" smallint NOT NULL,
    "AccessorToCreditGender" smallint NOT NULL,
    "ControllerOfCreditGender" smallint NOT NULL,
    "OfficeBearerGender" smallint NOT NULL,
    "MorePaymentGetterGender" smallint NOT NULL,
    "CanAccessLegalSupportForGbv" boolean,
    "CanUnsufructsRights" boolean,
    "FaceLiveAndLivelihoodChallanges" boolean,
    "HasLlfmInterest" boolean,
    "GrandTotalNetIncomeAgriculture" double precision NOT NULL,
    "GrandTotalLandArea" double precision NOT NULL,
    "GrandTotalGrossMarginAgriculture" double precision NOT NULL,
    "GrandTotalAnnualPhysicalIncome" double precision NOT NULL,
    "GrandTotalWildResourceIncome" double precision NOT NULL,
    "GrandTotalOtherIncome" double precision NOT NULL,
    "GrandTotalBusinessIncome" double precision NOT NULL,
    "NoOfMaleInsideCountry" integer NOT NULL,
    "SentIncomeOfMaleInYearInsideCountry" double precision NOT NULL,
    "NoOfFemaleInsideCountry" integer NOT NULL,
    "SentIncomeOfFemaleInYearInsideCountry" double precision NOT NULL,
    "NoOfMaleOutsideCountry" integer NOT NULL,
    "SentIncomeOfMaleInYearOutsideCountry" double precision NOT NULL,
    "NoOfFemaleOutsideCountry" integer NOT NULL,
    "SentIncomeOfFemaleInYearOutsideCountry" double precision NOT NULL,
    "PersonalSavingsOfAllMembers" double precision NOT NULL,
    "HouseShareInSavings" double precision NOT NULL,
    "BorrowedFromBank" double precision NOT NULL,
    "BorrowedFromNGO" double precision NOT NULL,
    "GrantsFromNGO" double precision NOT NULL,
    "GrantsFromGob" double precision NOT NULL,
    "BorrowedFromCoOperatives" double precision NOT NULL,
    "BorrowedFromNonRelatives" double precision NOT NULL,
    "BorrowedFromRelatives" double precision NOT NULL,
    "SaleOfProducts" double precision NOT NULL,
    "OtherFinanceName" character varying(500),
    "OtherFinanceAmount" double precision NOT NULL,
    "GrandTotalHouseholdExpenditure" double precision NOT NULL,
    "HouseholdFoodCondition" smallint,
    "FoodCrisisMonth" timestamp without time zone,
    "FoodyPersonInFoodCrisis" smallint,
    "NotesImage" character varying(500),
    "NotesImageUrl" character varying(500),
    "NameOfTheEnumerator" character varying(500),
    "CellPhoneNumber" character varying(100),
    "DataCollectionDate" timestamp without time zone,
    "BeneficiaryApproveStatus" integer DEFAULT 1 NOT NULL,
    "BeneficiaryProfileURL" text,
    "NgoId" bigint,
    "PermanentUnionNewId" bigint,
    "PresentUnionNewId" bigint,
    "BeneficiaryApproveStatusById" bigint,
    "FcvVcfAddedDate" timestamp without time zone,
    "CipId" bigint
);
    DROP TABLE "BEN"."Surveys";
       BEN         heap    postgres    false    6            -           1259    33499    Surveys_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."Surveys" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."Surveys_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    302            v           1259    34568    Trade    TABLE     �  CREATE TABLE "BEN"."Trade" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
    DROP TABLE "BEN"."Trade";
       BEN         heap    postgres    false    6            u           1259    34567    Trade_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."Trade" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."Trade_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    374                       1259    33342    VulnerabilitySituationTypes    TABLE     �  CREATE TABLE "BEN"."VulnerabilitySituationTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 0   DROP TABLE "BEN"."VulnerabilitySituationTypes";
       BEN         heap    postgres    false    6                       1259    33341 "   VulnerabilitySituationTypes_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."VulnerabilitySituationTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."VulnerabilitySituationTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    268    6            L           1259    33794    VulnerabilitySituations    TABLE     �  CREATE TABLE "BEN"."VulnerabilitySituations" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "VulnerabilitySituationTypeId" bigint,
    "VulnerabilitySituationTypeTxt" character varying(500),
    "EventName" character varying(500),
    "MonetaryLoss" double precision,
    "HowDidRecover" character varying(500),
    "Remarks" character varying(500),
    "SurveyId" bigint NOT NULL
);
 ,   DROP TABLE "BEN"."VulnerabilitySituations";
       BEN         heap    postgres    false    6            K           1259    33793    VulnerabilitySituations_Id_seq    SEQUENCE     �   ALTER TABLE "BEN"."VulnerabilitySituations" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BEN"."VulnerabilitySituations_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BEN          postgres    false    6    332            �           1259    35061    SavingsAccount    TABLE     �  CREATE TABLE "BSA"."SavingsAccount" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ForestCircleId" bigint,
    "ForestDivisionId" bigint,
    "ForestRangeId" bigint,
    "ForestBeatId" bigint,
    "FcvId" bigint,
    "DivisionId" bigint,
    "DistrictId" bigint,
    "UpazillaId" bigint,
    "NgoId" bigint,
    "SurveyId" bigint,
    "StatusId" bigint,
    "AccountTypeId" bigint,
    "AmountLimit" numeric,
    "UnionId" bigint
);
 #   DROP TABLE "BSA"."SavingsAccount";
       BSA         heap    postgres    false    15            �           1259    35060    SavingsAccount_Id_seq    SEQUENCE     �   ALTER TABLE "BSA"."SavingsAccount" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BSA"."SavingsAccount_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BSA          postgres    false    15    398            �           1259    35123    SavingsAmountInformation    TABLE       CREATE TABLE "BSA"."SavingsAmountInformation" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "SavingsAccountId" bigint,
    "SavingsDate" timestamp without time zone,
    "SavingsAmount" double precision,
    "Remark" text,
    "DocumentFileUrl" text
);
 -   DROP TABLE "BSA"."SavingsAmountInformation";
       BSA         heap    postgres    false    15            �           1259    35122    SavingsAmountInformation_Id_seq    SEQUENCE     �   ALTER TABLE "BSA"."SavingsAmountInformation" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BSA"."SavingsAmountInformation_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BSA          postgres    false    15    400            �           1259    35136    WithdrawAmountInformation    TABLE     +  CREATE TABLE "BSA"."WithdrawAmountInformation" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "SavingsAccountId" bigint,
    "WithdrawDate" timestamp without time zone,
    "WithdrawAmount" double precision,
    "Remark" text,
    "DfoRemark" text,
    "DfoStatusId" bigint
);
 .   DROP TABLE "BSA"."WithdrawAmountInformation";
       BSA         heap    postgres    false    15            �           1259    35135     WithdrawAmountInformation_Id_seq    SEQUENCE     �   ALTER TABLE "BSA"."WithdrawAmountInformation" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "BSA"."WithdrawAmountInformation_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            BSA          postgres    false    15    402            b           1259    34168    CommunityTrainingFiles    TABLE     �  CREATE TABLE "Capacity"."CommunityTrainingFiles" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "FileName" text,
    "FileNameUrl" text,
    "FileType" integer NOT NULL,
    "CommunityTrainingId" bigint NOT NULL
);
 0   DROP TABLE "Capacity"."CommunityTrainingFiles";
       Capacity         heap    postgres    false    10            a           1259    34167    CommunityTrainingFiles_Id_seq    SEQUENCE     �   ALTER TABLE "Capacity"."CommunityTrainingFiles" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."CommunityTrainingFiles_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    10    354            V           1259    34043    CommunityTrainingMembers    TABLE     T  CREATE TABLE "Capacity"."CommunityTrainingMembers" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "MemberName" character varying(500) NOT NULL,
    "MemberAge" integer NOT NULL,
    "MemberPhoneNumber" character varying(30),
    "MemberAddress" character varying(800),
    "MemberGender" integer DEFAULT 0 NOT NULL
);
 2   DROP TABLE "Capacity"."CommunityTrainingMembers";
       Capacity         heap    postgres    false    10            U           1259    34042    CommunityTrainingMembers_Id_seq    SEQUENCE     �   ALTER TABLE "Capacity"."CommunityTrainingMembers" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."CommunityTrainingMembers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    342    10            ^           1259    34075 !   CommunityTrainingParticipentsMaps    TABLE       CREATE TABLE "Capacity"."CommunityTrainingParticipentsMaps" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "SurveyId" bigint,
    "CommunityTrainingMemberId" bigint,
    "ParticipentType" integer NOT NULL,
    "CommunityTrainingId" bigint DEFAULT 0 NOT NULL
);
 ;   DROP TABLE "Capacity"."CommunityTrainingParticipentsMaps";
       Capacity         heap    postgres    false    10            ]           1259    34074 (   CommunityTrainingParticipentsMaps_Id_seq    SEQUENCE       ALTER TABLE "Capacity"."CommunityTrainingParticipentsMaps" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."CommunityTrainingParticipentsMaps_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    350    10            X           1259    34051    CommunityTrainingTypes    TABLE     �  CREATE TABLE "Capacity"."CommunityTrainingTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 0   DROP TABLE "Capacity"."CommunityTrainingTypes";
       Capacity         heap    postgres    false    10            W           1259    34050    CommunityTrainingTypes_Id_seq    SEQUENCE     �   ALTER TABLE "Capacity"."CommunityTrainingTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."CommunityTrainingTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    10    344            `           1259    34091    CommunityTrainings    TABLE     �  CREATE TABLE "Capacity"."CommunityTrainings" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "TrainingTitle" character varying(500),
    "TrainingTitleBn" character varying(500),
    "StartDate" timestamp without time zone NOT NULL,
    "EndDate" timestamp without time zone NOT NULL,
    "TrainingDuration" character varying(200) NOT NULL,
    "Location" character varying(500),
    "LocationBn" character varying(500),
    "TrainerName" character varying(500),
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "ForestFcvVcfId" bigint NOT NULL,
    "DivisionId" bigint NOT NULL,
    "DistrictId" bigint NOT NULL,
    "UpazillaId" bigint NOT NULL,
    "EventTypeId" bigint NOT NULL,
    "CommunityTrainingTypeId" bigint,
    "TrainingOrganizerId" bigint NOT NULL,
    "UnionId" bigint
);
 ,   DROP TABLE "Capacity"."CommunityTrainings";
       Capacity         heap    postgres    false    10            _           1259    34090    CommunityTrainings_Id_seq    SEQUENCE     �   ALTER TABLE "Capacity"."CommunityTrainings" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."CommunityTrainings_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    10    352            j           1259    34260    DepartmentalTrainingFiles    TABLE     �  CREATE TABLE "Capacity"."DepartmentalTrainingFiles" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "FileName" text,
    "FileNameUrl" text,
    "FileType" integer NOT NULL,
    "DepartmentalTrainingId" bigint NOT NULL
);
 3   DROP TABLE "Capacity"."DepartmentalTrainingFiles";
       Capacity         heap    postgres    false    10            i           1259    34259     DepartmentalTrainingFiles_Id_seq    SEQUENCE     �   ALTER TABLE "Capacity"."DepartmentalTrainingFiles" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."DepartmentalTrainingFiles_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    10    362            d           1259    34181    DepartmentalTrainingMembers    TABLE     �  CREATE TABLE "Capacity"."DepartmentalTrainingMembers" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "MemberName" character varying(500) NOT NULL,
    "MemberPhoneNumber" character varying(30),
    "MemberGender" integer NOT NULL,
    "MemberEmail" character varying(200),
    "MemberNID" character varying(100),
    "MemberDesignation" character varying(500),
    "MemberOrganization" character varying(800),
    "EthnicityId" bigint,
    "MemberAddress" text
);
 5   DROP TABLE "Capacity"."DepartmentalTrainingMembers";
       Capacity         heap    postgres    false    10            c           1259    34180 "   DepartmentalTrainingMembers_Id_seq    SEQUENCE       ALTER TABLE "Capacity"."DepartmentalTrainingMembers" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."DepartmentalTrainingMembers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    356    10            l           1259    34273 $   DepartmentalTrainingParticipentsMaps    TABLE     �  CREATE TABLE "Capacity"."DepartmentalTrainingParticipentsMaps" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "DepartmentalTrainingMemberId" bigint NOT NULL,
    "DepartmentalTrainingId" bigint NOT NULL
);
 >   DROP TABLE "Capacity"."DepartmentalTrainingParticipentsMaps";
       Capacity         heap    postgres    false    10            k           1259    34272 +   DepartmentalTrainingParticipentsMaps_Id_seq    SEQUENCE       ALTER TABLE "Capacity"."DepartmentalTrainingParticipentsMaps" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."DepartmentalTrainingParticipentsMaps_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    10    364            f           1259    34189    DepartmentalTrainingTypes    TABLE     �  CREATE TABLE "Capacity"."DepartmentalTrainingTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 3   DROP TABLE "Capacity"."DepartmentalTrainingTypes";
       Capacity         heap    postgres    false    10            e           1259    34188     DepartmentalTrainingTypes_Id_seq    SEQUENCE     �   ALTER TABLE "Capacity"."DepartmentalTrainingTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."DepartmentalTrainingTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    10    358            h           1259    34197    DepartmentalTrainings    TABLE     �  CREATE TABLE "Capacity"."DepartmentalTrainings" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "TrainingTitle" character varying(500),
    "TrainingTitleBn" character varying(500),
    "StartDate" timestamp without time zone NOT NULL,
    "EndDate" timestamp without time zone NOT NULL,
    "TrainingDuration" character varying(200) NOT NULL,
    "Location" character varying(500),
    "LocationBn" character varying(500),
    "TrainerName" character varying(500),
    "ForestCircleId" bigint,
    "ForestDivisionId" bigint,
    "ForestRangeId" bigint,
    "ForestBeatId" bigint,
    "ForestFcvVcfId" bigint,
    "DivisionId" bigint,
    "DistrictId" bigint,
    "UpazillaId" bigint,
    "EventTypeId" bigint NOT NULL,
    "DepartmentalTrainingTypeId" bigint,
    "TrainingOrganizerId" bigint NOT NULL,
    "FinancialYearId" bigint,
    "TotalFemale" integer DEFAULT 0 NOT NULL,
    "TotalMale" integer DEFAULT 0 NOT NULL,
    "TotalMembers" integer DEFAULT 0 NOT NULL
);
 /   DROP TABLE "Capacity"."DepartmentalTrainings";
       Capacity         heap    postgres    false    10            g           1259    34196    DepartmentalTrainings_Id_seq    SEQUENCE     �   ALTER TABLE "Capacity"."DepartmentalTrainings" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."DepartmentalTrainings_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    360    10            Z           1259    34059 
   EventTypes    TABLE     �  CREATE TABLE "Capacity"."EventTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "HasTrainingType" boolean NOT NULL
);
 $   DROP TABLE "Capacity"."EventTypes";
       Capacity         heap    postgres    false    10            Y           1259    34058    EventTypes_Id_seq    SEQUENCE     �   ALTER TABLE "Capacity"."EventTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."EventTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    346    10            �           1259    34727    MeetingParticipantsMaps    TABLE     �  CREATE TABLE "Capacity"."MeetingParticipantsMaps" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "SurveyId" bigint,
    "MeetingMemberId" bigint,
    "ParticipentType" integer NOT NULL,
    "MeetingId" bigint NOT NULL
);
 1   DROP TABLE "Capacity"."MeetingParticipantsMaps";
       Capacity         heap    postgres    false    10                       1259    34726    MeetingParticipantsMaps_Id_seq    SEQUENCE     �   ALTER TABLE "Capacity"."MeetingParticipantsMaps" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."MeetingParticipantsMaps_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    384    10            \           1259    34067    TrainingOrganizers    TABLE     �  CREATE TABLE "Capacity"."TrainingOrganizers" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500)
);
 ,   DROP TABLE "Capacity"."TrainingOrganizers";
       Capacity         heap    postgres    false    10            [           1259    34066    TrainingOrganizers_Id_seq    SEQUENCE     �   ALTER TABLE "Capacity"."TrainingOrganizers" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Capacity"."TrainingOrganizers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Capacity          postgres    false    348    10                       1259    33348    Category    TABLE     �  CREATE TABLE "GS"."Category" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "CategoryName" character varying(500) NOT NULL
);
    DROP TABLE "GS"."Category";
       GS         heap    postgres    false    8                       1259    33347    Category_Id_seq    SEQUENCE     �   ALTER TABLE "GS"."Category" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "GS"."Category_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            GS          postgres    false    270    8                       1259    33354    Color    TABLE     �  CREATE TABLE "GS"."Color" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ColorName" character varying(500) NOT NULL
);
    DROP TABLE "GS"."Color";
       GS         heap    postgres    false    8                       1259    33353    Color_Id_seq    SEQUENCE     �   ALTER TABLE "GS"."Color" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "GS"."Color_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            GS          postgres    false    8    272            "           1259    33422    District    TABLE     �  CREATE TABLE "GS"."District" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500) NOT NULL,
    "NameBn" character varying(500),
    "DivisionId" bigint NOT NULL
);
    DROP TABLE "GS"."District";
       GS         heap    postgres    false    8            !           1259    33421    District_Id_seq    SEQUENCE     �   ALTER TABLE "GS"."District" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "GS"."District_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            GS          postgres    false    290    8                       1259    33360    Division    TABLE     �  CREATE TABLE "GS"."Division" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "DivisionName" character varying(500) NOT NULL,
    "DivisionNameBangla" character varying(500)
);
    DROP TABLE "GS"."Division";
       GS         heap    postgres    false    8                       1259    33359    Division_Id_seq    SEQUENCE     �   ALTER TABLE "GS"."Division" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "GS"."Division_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            GS          postgres    false    8    274            �           1259    34915    FinancialYears    TABLE       CREATE TABLE "GS"."FinancialYears" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "EndYear" integer DEFAULT 0 NOT NULL,
    "StartYear" integer DEFAULT 0 NOT NULL
);
 "   DROP TABLE "GS"."FinancialYears";
       GS         heap    postgres    false    8            �           1259    34914    FinancialYears_Id_seq    SEQUENCE     �   ALTER TABLE "GS"."FinancialYears" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "GS"."FinancialYears_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            GS          postgres    false    8    388            x           1259    34576    SubCommitteeDesignations    TABLE     �  CREATE TABLE "GS"."SubCommitteeDesignations" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ExecutiveMemberType" integer NOT NULL,
    "Name" text,
    "NameBn" text
);
 ,   DROP TABLE "GS"."SubCommitteeDesignations";
       GS         heap    postgres    false    8            w           1259    34575    SubCommitteeDesignations_Id_seq    SEQUENCE     �   ALTER TABLE "GS"."SubCommitteeDesignations" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "GS"."SubCommitteeDesignations_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            GS          postgres    false    376    8            T           1259    34028    Union    TABLE     �  CREATE TABLE "GS"."Union" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "UpazillaId" bigint NOT NULL
);
    DROP TABLE "GS"."Union";
       GS         heap    postgres    false    8            S           1259    34027    Union_Id_seq    SEQUENCE     �   ALTER TABLE "GS"."Union" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "GS"."Union_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            GS          postgres    false    8    340            (           1259    33467    Upazilla    TABLE     �  CREATE TABLE "GS"."Upazilla" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "DistrictId" bigint NOT NULL
);
    DROP TABLE "GS"."Upazilla";
       GS         heap    postgres    false    8            '           1259    33466    Upazilla_Id_seq    SEQUENCE     �   ALTER TABLE "GS"."Upazilla" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "GS"."Upazilla_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            GS          postgres    false    296    8            �           1259    37088    InternalLoanInformationFiles    TABLE       CREATE TABLE "InternalLoan"."InternalLoanInformationFiles" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "InternalLoanInformationId" bigint DEFAULT 0 NOT NULL,
    "FileName" text,
    "FileNameUrl" text,
    "FileType" integer NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 :   DROP TABLE "InternalLoan"."InternalLoanInformationFiles";
       InternalLoan         heap    postgres    false    18            �           1259    37087 "   InternalLoanInformationFile_Id_seq    SEQUENCE       ALTER TABLE "InternalLoan"."InternalLoanInformationFiles" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "InternalLoan"."InternalLoanInformationFile_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            InternalLoan          postgres    false    18    480            �           1259    35750    InternalLoanInformations    TABLE     V  CREATE TABLE "InternalLoan"."InternalLoanInformations" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "ForestFcvVcfId" bigint NOT NULL,
    "DivisionId" bigint NOT NULL,
    "DistrictId" bigint NOT NULL,
    "UpazillaId" bigint NOT NULL,
    "UnionId" bigint,
    "NgoId" bigint NOT NULL,
    "SurveyId" bigint NOT NULL,
    "LDFCount" integer NOT NULL,
    "TotalAllocatedLoanAmount" double precision NOT NULL,
    "MaximumRepaymentMonth" integer NOT NULL,
    "StartDate" timestamp without time zone NOT NULL,
    "EndDate" timestamp without time zone NOT NULL,
    "ServiceChargePercentage" double precision NOT NULL,
    "SecurityChargePercentage" double precision NOT NULL
);
 6   DROP TABLE "InternalLoan"."InternalLoanInformations";
       InternalLoan         heap    postgres    false    18            �           1259    35749    InternalLoanInformations_Id_seq    SEQUENCE       ALTER TABLE "InternalLoan"."InternalLoanInformations" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "InternalLoan"."InternalLoanInformations_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            InternalLoan          postgres    false    426    18            �           1259    35896    RepaymentInternalLoans    TABLE     a  CREATE TABLE "InternalLoan"."RepaymentInternalLoans" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "InternalLoanInformationId" bigint NOT NULL,
    "RepaymentAmount" numeric,
    "RepaymentStartDate" timestamp without time zone DEFAULT '-infinity'::timestamp without time zone NOT NULL,
    "RepaymentEndDate" timestamp without time zone DEFAULT '-infinity'::timestamp without time zone NOT NULL,
    "RepaymentSerial" integer,
    "IsPaymentCompleted" boolean,
    "PaymentCompletedDateTime" timestamp without time zone,
    "IsPaymentCompletedLate" boolean,
    "IsLocked" boolean
);
 4   DROP TABLE "InternalLoan"."RepaymentInternalLoans";
       InternalLoan         heap    postgres    false    18            �           1259    35895    RepaymentInternalLoans_Id_seq    SEQUENCE       ALTER TABLE "InternalLoan"."RepaymentInternalLoans" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "InternalLoan"."RepaymentInternalLoans_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            InternalLoan          postgres    false    18    430            �           1259    36063    LabourDatabaseFiles    TABLE       CREATE TABLE "Labour"."LabourDatabaseFiles" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "LabourDatabaseId" bigint NOT NULL,
    "FileType" integer NOT NULL,
    "FileName" character varying(500) NOT NULL,
    "FileUrl" character varying(500) NOT NULL
);
 +   DROP TABLE "Labour"."LabourDatabaseFiles";
       Labour         heap    postgres    false    19            �           1259    36062    LabourDatabaseFiles_Id_seq    SEQUENCE     �   ALTER TABLE "Labour"."LabourDatabaseFiles" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Labour"."LabourDatabaseFiles_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Labour          postgres    false    19    436            �           1259    35985    LabourDatabases    TABLE       CREATE TABLE "Labour"."LabourDatabases" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "ForestFcvVcfId" bigint NOT NULL,
    "DivisionId" bigint NOT NULL,
    "DistrictId" bigint NOT NULL,
    "UpazillaId" bigint NOT NULL,
    "UnionId" bigint,
    "SurveyId" bigint,
    "OtherLabourMemberId" bigint,
    "EthnicityId" bigint,
    "CodeNo" character varying(100)
);
 '   DROP TABLE "Labour"."LabourDatabases";
       Labour         heap    postgres    false    19            �           1259    35984    LabourDatabases_Id_seq    SEQUENCE     �   ALTER TABLE "Labour"."LabourDatabases" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Labour"."LabourDatabases_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Labour          postgres    false    19    434            �           1259    37319    LabourWorks    TABLE     F  CREATE TABLE "Labour"."LabourWorks" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "LabourDatabaseId" bigint NOT NULL,
    "WorkType" text,
    "ManDays" double precision NOT NULL,
    "PaymentAmountPerDay" text,
    "TotalAmount" double precision NOT NULL,
    "PaymentType" text,
    "Remarks" text,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 #   DROP TABLE "Labour"."LabourWorks";
       Labour         heap    postgres    false    19            �           1259    37318    LabourWorks_Id_seq    SEQUENCE     �   ALTER TABLE "Labour"."LabourWorks" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Labour"."LabourWorks_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Labour          postgres    false    19    492            �           1259    35927    OtherLabourMembers    TABLE       CREATE TABLE "Labour"."OtherLabourMembers" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "FullName" character varying(500) NOT NULL,
    "Gender" integer NOT NULL,
    "PhoneNumber" text NOT NULL,
    "NID" character varying(100),
    "ForestCircleId" bigint,
    "ForestDivisionId" bigint,
    "ForestRangeId" bigint,
    "ForestBeatId" bigint,
    "ForestFcvVcfId" bigint,
    "DivisionId" bigint,
    "DistrictId" bigint,
    "UpazillaId" bigint,
    "UnionId" bigint,
    "EthnicityId" bigint
);
 *   DROP TABLE "Labour"."OtherLabourMembers";
       Labour         heap    postgres    false    19            �           1259    35926    OtherLabourMembers_Id_seq    SEQUENCE     �   ALTER TABLE "Labour"."OtherLabourMembers" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Labour"."OtherLabourMembers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Labour          postgres    false    19    432            R           1259    34007 
   Marketings    TABLE     �  CREATE TABLE "Marketing"."Marketings" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "MarketingName" character varying(500),
    "MarketingNameBn" character varying(500),
    "DistrictId" bigint,
    "DivisionId" bigint
);
 %   DROP TABLE "Marketing"."Marketings";
    	   Marketing         heap    postgres    false    9            Q           1259    34006    Marketings_Id_seq    SEQUENCE     �   ALTER TABLE "Marketing"."Marketings" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Marketing"."Marketings_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
         	   Marketing          postgres    false    9    338            �           1259    34748    MeetingFiles    TABLE     �  CREATE TABLE "Meeting"."MeetingFiles" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "FileName" text,
    "FileNameUrl" text,
    "FileType" integer NOT NULL,
    "MeetingId" bigint NOT NULL
);
 %   DROP TABLE "Meeting"."MeetingFiles";
       Meeting         heap    postgres    false    12            �           1259    34747    MeetingFiles_Id_seq    SEQUENCE     �   ALTER TABLE "Meeting"."MeetingFiles" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Meeting"."MeetingFiles_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Meeting          postgres    false    12    386            z           1259    34658    MeetingMembers    TABLE     '  CREATE TABLE "Meeting"."MeetingMembers" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "MemberName" text NOT NULL,
    "MemberGender" integer NOT NULL,
    "MemberAge" integer NOT NULL,
    "MemberPhone" text NOT NULL,
    "MemberAddress" text DEFAULT ''::text NOT NULL
);
 '   DROP TABLE "Meeting"."MeetingMembers";
       Meeting         heap    postgres    false    12            y           1259    34657    MeetingMembers_Id_seq    SEQUENCE     �   ALTER TABLE "Meeting"."MeetingMembers" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Meeting"."MeetingMembers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Meeting          postgres    false    378    12            |           1259    34666    MeetingTypes    TABLE     �  CREATE TABLE "Meeting"."MeetingTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" text,
    "NameBn" text
);
 %   DROP TABLE "Meeting"."MeetingTypes";
       Meeting         heap    postgres    false    12            {           1259    34665    MeetingTypes_Id_seq    SEQUENCE     �   ALTER TABLE "Meeting"."MeetingTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Meeting"."MeetingTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Meeting          postgres    false    12    380            ~           1259    34674    Meetings    TABLE       CREATE TABLE "Meeting"."Meetings" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "MeetingTitle" text NOT NULL,
    "MeetingDate" timestamp without time zone NOT NULL,
    "MeetingTypeId" bigint NOT NULL,
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "ForestFcvVcfId" bigint NOT NULL,
    "DivisionId" bigint NOT NULL,
    "DistrictId" bigint NOT NULL,
    "UpazillaId" bigint NOT NULL,
    "EndTime" timestamp without time zone DEFAULT '-infinity'::timestamp without time zone NOT NULL,
    "StartTime" timestamp without time zone DEFAULT '-infinity'::timestamp without time zone NOT NULL,
    "UnionId" bigint,
    "NgoId" bigint,
    "Venue" text
);
 !   DROP TABLE "Meeting"."Meetings";
       Meeting         heap    postgres    false    12            }           1259    34673    Meetings_Id_seq    SEQUENCE     �   ALTER TABLE "Meeting"."Meetings" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Meeting"."Meetings_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Meeting          postgres    false    382    12            �           1259    35368    OtherPatrollingMember    TABLE     �  CREATE TABLE "Patrolling"."OtherPatrollingMember" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "FullName" character varying(500) NOT NULL,
    "FatherOrSpouse" text,
    "Gender" integer NOT NULL,
    "PhoneNumber" text NOT NULL,
    "NID" character varying(100),
    "Address" character varying(600),
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "ForestFcvVcfId" bigint NOT NULL,
    "DivisionId" bigint NOT NULL,
    "DistrictId" bigint NOT NULL,
    "UpazillaId" bigint NOT NULL,
    "EthnicityId" bigint
);
 1   DROP TABLE "Patrolling"."OtherPatrollingMember";
    
   Patrolling         heap    postgres    false    16            �           1259    35367    OtherPatrollingMember_Id_seq    SEQUENCE     �   ALTER TABLE "Patrolling"."OtherPatrollingMember" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Patrolling"."OtherPatrollingMember_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
         
   Patrolling          postgres    false    416    16            �           1259    35339    PatrollingPaymentInformetion    TABLE     s  CREATE TABLE "Patrolling"."PatrollingPaymentInformetion" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "PatrollingScheduleInformetionId" bigint,
    "SurveyId" bigint,
    "AmountOfHonoraryAllowance" double precision,
    "Remark" text,
    "GenderId" bigint,
    "ParticipentName" text,
    "PhoneNo" text,
    "OtherPatrollingMemberId" bigint
);
 8   DROP TABLE "Patrolling"."PatrollingPaymentInformetion";
    
   Patrolling         heap    postgres    false    16            �           1259    35338 #   PatrollingPaymentInformetion_Id_seq    SEQUENCE     	  ALTER TABLE "Patrolling"."PatrollingPaymentInformetion" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Patrolling"."PatrollingPaymentInformetion_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
         
   Patrolling          postgres    false    414    16            �           1259    35291    PatrollingScheduleInformetion    TABLE     �  CREATE TABLE "Patrolling"."PatrollingScheduleInformetion" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ForestCircleId" bigint,
    "ForestDivisionId" bigint,
    "ForestRangeId" bigint,
    "ForestBeatId" bigint,
    "FcvId" bigint,
    "DivisionId" bigint,
    "DistrictId" bigint,
    "UpazillaId" bigint,
    "NgoId" bigint,
    "Date" timestamp without time zone,
    "PatrollingDescription" timestamp without time zone,
    "StartTime" timestamp without time zone,
    "EndTime" timestamp without time zone,
    "PatrollingArea" text,
    "AllocatedAmountMonth" text,
    "FilePath" text,
    "Remark" text,
    "OtherPatrollingMemberId" bigint,
    "PatrollingPlanningFile" text,
    "UnionId" bigint
);
 9   DROP TABLE "Patrolling"."PatrollingScheduleInformetion";
    
   Patrolling         heap    postgres    false    16            �           1259    35290 $   PatrollingScheduleInformetion_Id_seq    SEQUENCE       ALTER TABLE "Patrolling"."PatrollingScheduleInformetion" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Patrolling"."PatrollingScheduleInformetion_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
         
   Patrolling          postgres    false    16    412            �           1259    36317    PatrollingSchedulingFiles    TABLE     �  CREATE TABLE "PatrollingScheduling"."PatrollingSchedulingFiles" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "FileName" text,
    "FileNameUrl" text,
    "FileType" integer NOT NULL,
    "PatrollingSchedulingId" bigint NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 ?   DROP TABLE "PatrollingScheduling"."PatrollingSchedulingFiles";
       PatrollingScheduling         heap    postgres    false    20            �           1259    36316     PatrollingSchedulingFiles_Id_seq    SEQUENCE       ALTER TABLE "PatrollingScheduling"."PatrollingSchedulingFiles" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "PatrollingScheduling"."PatrollingSchedulingFiles_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            PatrollingScheduling          postgres    false    446    20            �           1259    36251    PatrollingSchedulingMembers    TABLE     Y  CREATE TABLE "PatrollingScheduling"."PatrollingSchedulingMembers" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "MemberName" character varying(500) NOT NULL,
    "MemberAge" integer NOT NULL,
    "MemberGender" integer NOT NULL,
    "MemberPhoneNumber" character varying(30),
    "MemberAddress" character varying(800),
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 A   DROP TABLE "PatrollingScheduling"."PatrollingSchedulingMembers";
       PatrollingScheduling         heap    postgres    false    20            �           1259    36250 "   PatrollingSchedulingMembers_Id_seq    SEQUENCE       ALTER TABLE "PatrollingScheduling"."PatrollingSchedulingMembers" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "PatrollingScheduling"."PatrollingSchedulingMembers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            PatrollingScheduling          postgres    false    442    20            �           1259    36330 $   PatrollingSchedulingParticipentsMaps    TABLE     �  CREATE TABLE "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "SurveyId" bigint,
    "PatrollingSchedulingMemberId" bigint,
    "ParticipentType" integer NOT NULL,
    "PatrollingSchedulingId" bigint NOT NULL,
    "ParticipentName" text,
    "GenderEnumId" integer,
    "PhoneNo" text,
    "AmountOfHonoraryAllowance" double precision,
    "Remark" text,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 J   DROP TABLE "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps";
       PatrollingScheduling         heap    postgres    false    20            �           1259    36329 +   PatrollingSchedulingParticipentsMaps_Id_seq    SEQUENCE     -  ALTER TABLE "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            PatrollingScheduling          postgres    false    448    20            �           1259    36259    PatrollingSchedulings    TABLE       CREATE TABLE "PatrollingScheduling"."PatrollingSchedulings" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "ForestFcvVcfId" bigint NOT NULL,
    "DivisionId" bigint NOT NULL,
    "DistrictId" bigint NOT NULL,
    "UpazillaId" bigint NOT NULL,
    "UnionId" bigint,
    "NgoId" bigint,
    "FcvId" bigint NOT NULL,
    "Date" timestamp without time zone NOT NULL,
    "PatrollingDescription" text NOT NULL,
    "StartTime" timestamp without time zone NOT NULL,
    "EndTime" timestamp without time zone NOT NULL,
    "PatrollingArea" text NOT NULL,
    "AllocatedAmountMonth" text NOT NULL,
    "Remark" text,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 ;   DROP TABLE "PatrollingScheduling"."PatrollingSchedulings";
       PatrollingScheduling         heap    postgres    false    20            �           1259    36258    PatrollingSchedulings_Id_seq    SEQUENCE       ALTER TABLE "PatrollingScheduling"."PatrollingSchedulings" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "PatrollingScheduling"."PatrollingSchedulings_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            PatrollingScheduling          postgres    false    444    20            �           1259    37000    BankDeposits    TABLE       CREATE TABLE "SocialForestry"."BankDeposits" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "RevenueDistributionId" bigint NOT NULL,
    "DepositAmount" double precision NOT NULL,
    "DepositDate" timestamp without time zone NOT NULL,
    "Remarks" text,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 ,   DROP TABLE "SocialForestry"."BankDeposits";
       SocialForestry         heap    postgres    false    21            �           1259    36999    BankDeposits_Id_seq    SEQUENCE     �   ALTER TABLE "SocialForestry"."BankDeposits" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."BankDeposits_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    21    474            �           1259    36922    CuttingPlantations    TABLE     "  CREATE TABLE "SocialForestry"."CuttingPlantations" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "NewRaisedPlantationId" bigint NOT NULL,
    "YearOfCutting" integer NOT NULL,
    "ResourceQtyTimber" double precision NOT NULL,
    "ResourceQtyPole" double precision NOT NULL,
    "ResourceQtyFuelWood" double precision NOT NULL,
    "SaleValueTimber" double precision NOT NULL,
    "SaleValuePole" double precision NOT NULL,
    "SaleValueFuelWood" double precision NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ResourceQtyTotal" double precision DEFAULT 0.0 NOT NULL,
    "SaleValueTotal" double precision DEFAULT 0.0 NOT NULL,
    "RotationInYears" integer DEFAULT 0 NOT NULL,
    "YearOfReforestation" integer DEFAULT 0 NOT NULL,
    "RotationNo" integer DEFAULT 0 NOT NULL,
    "ReforestationId" bigint
);
 2   DROP TABLE "SocialForestry"."CuttingPlantations";
       SocialForestry         heap    postgres    false    21            �           1259    36921    CuttingPlantations_Id_seq    SEQUENCE     �   ALTER TABLE "SocialForestry"."CuttingPlantations" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."CuttingPlantations_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    462    21            �           1259    37013 "   DistributedOrRevenueDepositAmounts    TABLE     (  CREATE TABLE "SocialForestry"."DistributedOrRevenueDepositAmounts" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "RevenueDistributionId" bigint NOT NULL,
    "Amount" double precision NOT NULL,
    "DateOccurred" timestamp without time zone NOT NULL,
    "Remarks" text,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 B   DROP TABLE "SocialForestry"."DistributedOrRevenueDepositAmounts";
       SocialForestry         heap    postgres    false    21            �           1259    37012 )   DistributedOrRevenueDepositAmounts_Id_seq    SEQUENCE       ALTER TABLE "SocialForestry"."DistributedOrRevenueDepositAmounts" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."DistributedOrRevenueDepositAmounts_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    476    21            �           1259    36933    NewRaisedPlantationUnionMaps    TABLE     �  CREATE TABLE "SocialForestry"."NewRaisedPlantationUnionMaps" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "NewRaisedPlantationId" bigint NOT NULL,
    "UnionId" bigint NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 <   DROP TABLE "SocialForestry"."NewRaisedPlantationUnionMaps";
       SocialForestry         heap    postgres    false    21            �           1259    36932 #   NewRaisedPlantationUnionMaps_Id_seq    SEQUENCE       ALTER TABLE "SocialForestry"."NewRaisedPlantationUnionMaps" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."NewRaisedPlantationUnionMaps_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    464    21            �           1259    36949    NewRaisedPlantationUpazillaMaps    TABLE     �  CREATE TABLE "SocialForestry"."NewRaisedPlantationUpazillaMaps" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "NewRaisedPlantationId" bigint NOT NULL,
    "UpazillaId" bigint NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 ?   DROP TABLE "SocialForestry"."NewRaisedPlantationUpazillaMaps";
       SocialForestry         heap    postgres    false    21            �           1259    36948 &   NewRaisedPlantationUpazillaMaps_Id_seq    SEQUENCE       ALTER TABLE "SocialForestry"."NewRaisedPlantationUpazillaMaps" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."NewRaisedPlantationUpazillaMaps_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    466    21            �           1259    36859    NewRaisedPlantations    TABLE     �  CREATE TABLE "SocialForestry"."NewRaisedPlantations" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "ForestRangeId" bigint NOT NULL,
    "ForestBeatId" bigint NOT NULL,
    "ForestFcvVcfId" bigint NOT NULL,
    "DivisionId" bigint NOT NULL,
    "DistrictId" bigint NOT NULL,
    "NgoId" bigint NOT NULL,
    "PlantationProjectId" bigint NOT NULL,
    "PlantationTypeId" bigint NOT NULL,
    "StripTypeId" bigint,
    "YearOfPlantation" integer NOT NULL,
    "ExpectedYearOfCutting" integer NOT NULL,
    "PlantationLocation" text,
    "PlantationArea" double precision NOT NULL,
    "PlantationEstablishmentCostNurseryTk" double precision NOT NULL,
    "PlantationEstablishmentCostPlantationTk" double precision NOT NULL,
    "LaborInvolvedNurseryMale" integer NOT NULL,
    "LaborInvolvedNurseryFemale" integer NOT NULL,
    "LaborInvolvedPlantationMale" integer NOT NULL,
    "LaborInvolvedPlantationFemale" integer NOT NULL,
    "MaleBeneficiaries" integer NOT NULL,
    "FemaleBeneficiaries" integer NOT NULL,
    "IsSocialForestryCommitteeFormed" boolean NOT NULL,
    "IsFundManagementSubCommitteeFormed" boolean NOT NULL,
    "Remarks" text,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "LaborEngagedTotal" integer DEFAULT 0 NOT NULL,
    "LaborEngagedTotalFemale" integer DEFAULT 0 NOT NULL,
    "LaborEngagedTotalMale" integer DEFAULT 0 NOT NULL,
    "LaborInvolvedNurseryTotal" integer DEFAULT 0 NOT NULL,
    "LaborInvolvedPlantationTotal" integer DEFAULT 0 NOT NULL,
    "PlantationEstablishmentCostPlantationTotal" double precision DEFAULT 0.0 NOT NULL,
    "TotalBeneficiaries" integer DEFAULT 0 NOT NULL,
    "RotationInYears" integer DEFAULT 0 NOT NULL
);
 4   DROP TABLE "SocialForestry"."NewRaisedPlantations";
       SocialForestry         heap    postgres    false    21            �           1259    36858    NewRaisedPlantations_Id_seq    SEQUENCE       ALTER TABLE "SocialForestry"."NewRaisedPlantations" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."NewRaisedPlantations_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    21    460            �           1259    36819    PlantationProjects    TABLE     �  CREATE TABLE "SocialForestry"."PlantationProjects" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "Name" text,
    "NameBn" text,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 2   DROP TABLE "SocialForestry"."PlantationProjects";
       SocialForestry         heap    postgres    false    21            �           1259    36818    PlantationProjects_Id_seq    SEQUENCE     �   ALTER TABLE "SocialForestry"."PlantationProjects" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."PlantationProjects_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    21    452            �           1259    36835     PlantationTypeRevenuePercentages    TABLE       CREATE TABLE "SocialForestry"."PlantationTypeRevenuePercentages" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "PlantationTypeId" bigint NOT NULL,
    "RevenueDistributionTypeEnum" integer NOT NULL,
    "RevenuePercentage" double precision NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 @   DROP TABLE "SocialForestry"."PlantationTypeRevenuePercentages";
       SocialForestry         heap    postgres    false    21            �           1259    36834 '   PlantationTypeRevenuePercentages_Id_seq    SEQUENCE       ALTER TABLE "SocialForestry"."PlantationTypeRevenuePercentages" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."PlantationTypeRevenuePercentages_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    456    21            �           1259    36827    PlantationTypes    TABLE     �  CREATE TABLE "SocialForestry"."PlantationTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "TypeName" text,
    "PlantationAreaTypeEnum" integer NOT NULL,
    "HasStripType" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 /   DROP TABLE "SocialForestry"."PlantationTypes";
       SocialForestry         heap    postgres    false    21            �           1259    36826    PlantationTypes_Id_seq    SEQUENCE     �   ALTER TABLE "SocialForestry"."PlantationTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."PlantationTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    21    454            �           1259    36965    Reforestations    TABLE     y  CREATE TABLE "SocialForestry"."Reforestations" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "NewRaisedPlantationId" bigint NOT NULL,
    "YearOfReforestation" integer NOT NULL,
    "ExpectedYearOfCutting" integer NOT NULL,
    "ReforestLocation" text,
    "ReforestationArea" double precision NOT NULL,
    "PlantationEstablishmentCostNurseryTk" double precision NOT NULL,
    "PlantationEstablishmentCostPlantationTk" double precision NOT NULL,
    "LaborInvolvedNurseryMale" integer NOT NULL,
    "LaborInvolvedNurseryFemale" integer NOT NULL,
    "LaborInvolvedPlantationMale" integer NOT NULL,
    "LaborInvolvedPlantationFemale" integer NOT NULL,
    "MaleBeneficiaries" integer NOT NULL,
    "FemaleBeneficiaries" integer NOT NULL,
    "IsAccountMaintainedBySubCommittee" boolean NOT NULL,
    "Remarks" text,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "LaborEngagedTotal" integer DEFAULT 0 NOT NULL,
    "LaborEngagedTotalFemale" integer DEFAULT 0 NOT NULL,
    "LaborEngagedTotalMale" integer DEFAULT 0 NOT NULL,
    "LaborInvolvedNurseryTotal" integer DEFAULT 0 NOT NULL,
    "LaborInvolvedPlantationTotal" integer DEFAULT 0 NOT NULL,
    "PlantationEstablishmentCostPlantationTotal" double precision DEFAULT 0.0 NOT NULL,
    "RotationInYears" integer DEFAULT 0 NOT NULL,
    "TotalBeneficiaries" integer DEFAULT 0 NOT NULL,
    "RotationNo" integer DEFAULT 0 NOT NULL,
    "CuttingPlantationId" bigint
);
 .   DROP TABLE "SocialForestry"."Reforestations";
       SocialForestry         heap    postgres    false    21            �           1259    36964    Reforestations_Id_seq    SEQUENCE     �   ALTER TABLE "SocialForestry"."Reforestations" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."Reforestations_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    468    21            �           1259    36989    RevenueDistributions    TABLE     �  CREATE TABLE "SocialForestry"."RevenueDistributions" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "RevenueId" bigint NOT NULL,
    "RevenueDistributionTypeEnum" integer NOT NULL,
    "ShareInPercentage" double precision NOT NULL,
    "GovernmentRevenue" double precision NOT NULL,
    "RevenueCollected" double precision NOT NULL,
    "OutStandingAmount" double precision NOT NULL,
    "NumberOrMale" integer,
    "NumberOrFemale" integer,
    "AmountInHand" double precision,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 4   DROP TABLE "SocialForestry"."RevenueDistributions";
       SocialForestry         heap    postgres    false    21            �           1259    36988    RevenueDistributions_Id_seq    SEQUENCE       ALTER TABLE "SocialForestry"."RevenueDistributions" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."RevenueDistributions_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    472    21            �           1259    36978    Revenues    TABLE     D  CREATE TABLE "SocialForestry"."Revenues" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CuttingPlantationId" bigint NOT NULL,
    "RevenueReceivedAmount" double precision NOT NULL,
    "RevenueReceivedDate" timestamp without time zone NOT NULL,
    "OutstandingSaleValue" double precision NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 (   DROP TABLE "SocialForestry"."Revenues";
       SocialForestry         heap    postgres    false    21            �           1259    36977    Revenues_Id_seq    SEQUENCE     �   ALTER TABLE "SocialForestry"."Revenues" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."Revenues_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    470    21            �           1259    36846 
   StripTypes    TABLE     �  CREATE TABLE "SocialForestry"."StripTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "Name" text,
    "NameBn" text,
    "PlantationTypeId" bigint NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 *   DROP TABLE "SocialForestry"."StripTypes";
       SocialForestry         heap    postgres    false    21            �           1259    36845    StripTypes_Id_seq    SEQUENCE     �   ALTER TABLE "SocialForestry"."StripTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "SocialForestry"."StripTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            SocialForestry          postgres    false    21    458            t           1259    34490    Students    TABLE     ,  CREATE TABLE "Student"."Students" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "Email" character varying(500),
    "RollNumber" character varying(500),
    "AccountNumber" character varying(500),
    "Batch" bigint,
    "Semester" bigint
);
 !   DROP TABLE "Student"."Students";
       Student         heap    postgres    false    11            s           1259    34489    Students_Id_seq    SEQUENCE     �   ALTER TABLE "Student"."Students" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "Student"."Students_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            Student          postgres    false    372    11                       1259    33372    AccessMapper    TABLE     �  CREATE TABLE "System"."AccessMapper" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "AccessList" character varying(500) NOT NULL,
    "RoleStatus" smallint NOT NULL,
    "IsVisible" smallint NOT NULL
);
 $   DROP TABLE "System"."AccessMapper";
       System         heap    postgres    false    7                       1259    33371    AccessMapper_Id_seq    SEQUENCE     �   ALTER TABLE "System"."AccessMapper" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "System"."AccessMapper_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            System          postgres    false    7    278                       1259    33366 
   Accesslist    TABLE     �  CREATE TABLE "System"."Accesslist" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ControllerName" character varying(500) NOT NULL,
    "ActionName" character varying(500) NOT NULL,
    "Mask" character varying(500) NOT NULL,
    "AccessStatus" smallint NOT NULL,
    "IsVisible" smallint NOT NULL,
    "IconClass" character varying(500) NOT NULL,
    "BaseModule" integer NOT NULL,
    "BaseModuleIndex" integer
);
 "   DROP TABLE "System"."Accesslist";
       System         heap    postgres    false    7                       1259    33365    Accesslist_Id_seq    SEQUENCE     �   ALTER TABLE "System"."Accesslist" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "System"."Accesslist_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            System          postgres    false    7    276                       1259    33380    Module    TABLE       CREATE TABLE "System"."Module" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ModuleName" character varying(500) NOT NULL,
    "ModuleIcon" character varying(500) NOT NULL,
    "IsVisible" smallint NOT NULL,
    "MenueOrder" integer NOT NULL
);
    DROP TABLE "System"."Module";
       System         heap    postgres    false    7                       1259    33379    Module_Id_seq    SEQUENCE     �   ALTER TABLE "System"."Module" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "System"."Module_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            System          postgres    false    280    7                       1259    33386    PmsGroup    TABLE       CREATE TABLE "System"."PmsGroup" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "GroupName" character varying(40) NOT NULL,
    "GroupDescription" character varying(250) NOT NULL,
    "GroupStatus" smallint NOT NULL,
    "IsVisible" smallint NOT NULL
);
     DROP TABLE "System"."PmsGroup";
       System         heap    postgres    false    7                       1259    33385    PmsGroup_Id_seq    SEQUENCE     �   ALTER TABLE "System"."PmsGroup" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "System"."PmsGroup_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            System          postgres    false    282    7            $           1259    33433    User    TABLE     )  CREATE TABLE "System"."User" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "FirstName" text,
    "LastName" text,
    "RoleName" character varying(100),
    "UserName" character varying(500) NOT NULL,
    "UserEmail" character varying(100) NOT NULL,
    "UserPassword" character varying(500) NOT NULL,
    "ImageUrl" text,
    "UserPhone" character varying(100),
    "UserGroup" character varying(100),
    "UserStatus" integer NOT NULL,
    "PmsGroupID" bigint NOT NULL,
    "GroupID" bigint,
    "UserRolesId" bigint,
    "DistrictId" bigint,
    "DivisionId" bigint,
    "ForestBeatId" bigint,
    "ForestCircleId" bigint,
    "ForestDivisionId" bigint,
    "ForestFcvVcfId" bigint,
    "ForestRangeId" bigint,
    "UnionId" bigint,
    "UpazillaId" bigint,
    "SurveyId" bigint
);
    DROP TABLE "System"."User";
       System         heap    postgres    false    7                       1259    33392 	   UserGroup    TABLE     4  CREATE TABLE "System"."UserGroup" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "GroupName" character varying(40) NOT NULL,
    "ModuleActionNames" character varying(500) NOT NULL,
    "IsUsed" smallint NOT NULL,
    "IsDefault" smallint NOT NULL,
    "IsVisible" smallint NOT NULL
);
 !   DROP TABLE "System"."UserGroup";
       System         heap    postgres    false    7                       1259    33391    UserGroup_Id_seq    SEQUENCE     �   ALTER TABLE "System"."UserGroup" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "System"."UserGroup_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            System          postgres    false    284    7                       1259    33400 	   UserRoles    TABLE     �  CREATE TABLE "System"."UserRoles" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "RoleName" character varying(500) NOT NULL
);
 !   DROP TABLE "System"."UserRoles";
       System         heap    postgres    false    7                       1259    33399    UserRoles_Id_seq    SEQUENCE     �   ALTER TABLE "System"."UserRoles" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "System"."UserRoles_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            System          postgres    false    286    7            #           1259    33432    User_Id_seq    SEQUENCE     �   ALTER TABLE "System"."User" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "System"."User_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            System          postgres    false    292    7            �           1259    37133    ExpenseDetailsForCDFs    TABLE       CREATE TABLE "TRANSACTION"."ExpenseDetailsForCDFs" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "TransactionExpenseId" bigint NOT NULL,
    "ExpenseScheme" text,
    "ExpenseAmount" double precision NOT NULL,
    "DocumentFileURL" text,
    "Remakrs" text,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint
);
 2   DROP TABLE "TRANSACTION"."ExpenseDetailsForCDFs";
       TRANSACTION         heap    postgres    false    14            �           1259    37132    ExpenseDetailsForCDFs_Id_seq    SEQUENCE     �   ALTER TABLE "TRANSACTION"."ExpenseDetailsForCDFs" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "TRANSACTION"."ExpenseDetailsForCDFs_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            TRANSACTION          postgres    false    484    14            �           1259    34923 	   FundTypes    TABLE     �  CREATE TABLE "TRANSACTION"."FundTypes" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "Name" character varying(500),
    "NameBn" character varying(500),
    "IsCdf" boolean DEFAULT false NOT NULL
);
 &   DROP TABLE "TRANSACTION"."FundTypes";
       TRANSACTION         heap    postgres    false    14            �           1259    34922    FundTypes_Id_seq    SEQUENCE     �   ALTER TABLE "TRANSACTION"."FundTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "TRANSACTION"."FundTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            TRANSACTION          postgres    false    14    390            �           1259    34952    TransactionDetails    TABLE     �  CREATE TABLE "TRANSACTION"."TransactionDetails" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "TransactionId" bigint NOT NULL,
    "FundTypeId" bigint NOT NULL,
    "TargetAmount" double precision NOT NULL
);
 /   DROP TABLE "TRANSACTION"."TransactionDetails";
       TRANSACTION         heap    postgres    false    14            �           1259    34951    TransactionDetails_Id_seq    SEQUENCE     �   ALTER TABLE "TRANSACTION"."TransactionDetails" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "TRANSACTION"."TransactionDetails_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            TRANSACTION          postgres    false    394    14            �           1259    34968    TransactionExpenses    TABLE       CREATE TABLE "TRANSACTION"."TransactionExpenses" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "TransactionDetailsId" bigint NOT NULL,
    "ExpenseAmount" double precision NOT NULL,
    "ExpenseDate" timestamp without time zone NOT NULL,
    "ExpenseDocumentFileName" text,
    "ExpenseDocumentFileURL" text,
    "FundTypeId" bigint,
    "ExpenseMonth" integer DEFAULT 0 NOT NULL,
    "ExpenseYear" text,
    "ForestBeatId" bigint,
    "ForestFcvVcfId" bigint,
    "ForestRangeId" bigint
);
 0   DROP TABLE "TRANSACTION"."TransactionExpenses";
       TRANSACTION         heap    postgres    false    14            �           1259    34967    TransactionExpenses_Id_seq    SEQUENCE     �   ALTER TABLE "TRANSACTION"."TransactionExpenses" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "TRANSACTION"."TransactionExpenses_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            TRANSACTION          postgres    false    396    14            �           1259    34931    Transactions    TABLE     J  CREATE TABLE "TRANSACTION"."Transactions" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone,
    "DeletedAt" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedBy" bigint NOT NULL,
    "ModifiedBy" bigint,
    "DeletedBy" bigint,
    "ForestCircleId" bigint NOT NULL,
    "ForestDivisionId" bigint NOT NULL,
    "FromDate" timestamp without time zone NOT NULL,
    "ToDate" timestamp without time zone NOT NULL,
    "FinancialYearId" bigint NOT NULL
);
 )   DROP TABLE "TRANSACTION"."Transactions";
       TRANSACTION         heap    postgres    false    14            �           1259    34930    Transactions_Id_seq    SEQUENCE     �   ALTER TABLE "TRANSACTION"."Transactions" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "TRANSACTION"."Transactions_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            TRANSACTION          postgres    false    14    392            �            1259    33225    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap    postgres    false            >          0    35151    AIGBasicInformations 
   TABLE DATA             COPY "AIG"."AIGBasicInformations" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "UpazillaId", "UnionId", "NgoId", "SurveyId", "IsRecievedTrainingInTrade", "TradeId", "TotalAllocatedLoanAmount", "MaximumRepaymentMonth", "StartDate", "EndDate", "ServiceChargePercentage", "SecurityChargePercentage", "LDFCount", "BadLoanType") FROM stdin;
    AIG          postgres    false    404   �D	      @          0    35225    FirstSixtyPercentageLDFs 
   TABLE DATA           R  COPY "AIG"."FirstSixtyPercentageLDFs" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "AIGBasicInformationId", "HasGrace", "ServiceChargeAmount", "SecurityChargeAmount", "GraceMonth", "HasBankAccountInHisOwnName", "IsAgreeToInvestInOwnIncomeActivities", "IsAgreedToKeepIncomeAndExpenditureFund", "IsAttendedEightyPercentageOfMeetings", "IsFirstInstallmentIsCertifiedBySocialAuditCommittee", "IsPayingRegularIncomingInstallments", "ShallAdhereTheCOM", "LDFAmount", "SecurityChargePercentage", "ServiceChargePercentage") FROM stdin;
    AIG          postgres    false    406   �D	      b          0    36183    GroupLDFInfoFormMembers 
   TABLE DATA           �   COPY "AIG"."GroupLDFInfoFormMembers" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "GroupLDFInfoFormId", "IndividualLDFInfoFormId") FROM stdin;
    AIG          postgres    false    440   �D	      `          0    36120    GroupLDFInfoForms 
   TABLE DATA           �  COPY "AIG"."GroupLDFInfoForms" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "UpazillaId", "UnionId", "NgoId", "SubmittedById", "SubmittedDate", "DocumentName", "DocumentNameURL", "TotalMember") FROM stdin;
    AIG          postgres    false    438   �D	      P          0    35717    IndividualGroupFormSetups 
   TABLE DATA           �   COPY "AIG"."IndividualGroupFormSetups" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "IndividualDocument", "GroupDocument") FROM stdin;
    AIG          postgres    false    422   E	      N          0    35594    IndividualLDFInfoForms 
   TABLE DATA           �  COPY "AIG"."IndividualLDFInfoForms" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "UpazillaId", "UnionId", "SurveyId", "RequestedLoanAmount", "ApprovedLoanAmount", "IndividualLDFInfoStatus", "StatusDate", "DocumentInfoURL", "SubmittedDate", "NgoId") FROM stdin;
    AIG          postgres    false    420   2E	      L          0    35486    LDFProgresss 
   TABLE DATA           #  COPY "AIG"."LDFProgresss" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "AIGBasicInformationId", "RepaymentLDFId", "RepaymentStartDate", "RepaymentEndDate", "RepaymentSerial", "ProgressAmount", "ProgressResource") FROM stdin;
    AIG          postgres    false    418   OE	      �          0    37118    RepaymentLDFFiles 
   TABLE DATA           �   COPY "AIG"."RepaymentLDFFiles" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "FileName", "FileNameUrl", "FileType", "RepaymentLDFId", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    AIG          postgres    false    482   lE	      V          0    35876    RepaymentLDFHistories 
   TABLE DATA           �   COPY "AIG"."RepaymentLDFHistories" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "RepaymentLDFId", "EventUserId", "EventOccurredDate", "EventMessage", "RepaymentLDFEventType") FROM stdin;
    AIG          postgres    false    428   �E	      D          0    35257    RepaymentLDFs 
   TABLE DATA           �  COPY "AIG"."RepaymentLDFs" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "FirstSixtyPercentageLDFId", "SecondFourtyPercentageLDFId", "RepaymentStartDate", "RepaymentEndDate", "IsPaymentCompleted", "PaymentCompletedDateTime", "IsPaymentCompletedLate", "AIGBasicInformationId", "FirstSixtyPercentRepaymentAmount", "SecondFortyPercentRepaymentAmount", "RepaymentSerial", "IsLocked") FROM stdin;
    AIG          postgres    false    410   �E	      B          0    35241    SecondFourtyPercentageLDFs 
   TABLE DATA           N  COPY "AIG"."SecondFourtyPercentageLDFs" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "AIGBasicInformationId", "ServiceChargeAmount", "SecurityChargeAmount", "DidNotBreakTheTenPrinciples", "HasInvestedSeventyPercentageOfTheLoan", "IncomeExpenditureFundLoansUpdatedAndCertified", "IsAttendedRegularMeetings", "IsLivelihoodDevelopmentFundCertifiedAndApproved", "IsPaidTheLoanInstallmentThreeConsecutiveMonths", "LDFAmount", "StartDate", "StartRepaymentLDFId", "SecurityChargePercentage", "ServiceChargePercentage") FROM stdin;
    AIG          postgres    false    408   �E	      �          0    33568    AnnualHouseholdExpenditures 
   TABLE DATA             COPY "BEN"."AnnualHouseholdExpenditures" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ExpenditureTypeId", "ExpenditureTypeTxt", "ExpenditureCost", "ExpenditureRemarks", "SurveyId") FROM stdin;
    BEN          postgres    false    304   �E	      �          0    33234 
   AssetTypes 
   TABLE DATA           �   COPY "BEN"."AssetTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    232   �E	      �          0    33584    Assets 
   TABLE DATA           �   COPY "BEN"."Assets" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "AssetTypeId", "AssetTypeTxt", "AssetQuantity", "AssetsCost", "SurveyId") FROM stdin;
    BEN          postgres    false    306   F	      �          0    33811 "   BFDAssociationHouseholdMembersMaps 
   TABLE DATA           �   COPY "BEN"."BFDAssociationHouseholdMembersMaps" ("BFDAssociationId", "HouseholdMemberId", "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActive", "IsDeleted", "ModifiedBy", "UpdatedAt") FROM stdin;
    BEN          postgres    false    333   7F	      �          0    33240    BFDAssociations 
   TABLE DATA           �   COPY "BEN"."BFDAssociations" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    234   TF	      �          0    33246    BusinessIncomeSourceTypes 
   TABLE DATA           �   COPY "BEN"."BusinessIncomeSourceTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    236   qF	      �          0    33600 	   Businesss 
   TABLE DATA           $  COPY "BEN"."Businesss" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "BusinessIncomeSourceTypeId", "BusinessIncomeSourceTypeTxt", "BusinessGrossValueOfSales", "BusinessTotalCashCosts", "TotalNetIncome", "SurveyId") FROM stdin;
    BEN          postgres    false    308   �F	      �          0    37071    CipFiles 
   TABLE DATA           �   COPY "BEN"."CipFiles" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CipId", "FileName", "FileNameUrl", "FileType", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    BEN          postgres    false    478   �F	      l          0    36744    Cips 
   TABLE DATA           �  COPY "BEN"."Cips" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "UpazillaId", "UnionId", "ForestVillageName", "HouseholdSerialNo", "BeneficiaryName", "Gender", "FatherOrSpouseName", "EthnicityId", "NID", "MobileNumber", "HouseType", "CipWealth", "CreatedBy", "ModifiedBy", "DeletedBy", "CipGeneratedId") FROM stdin;
    BEN          postgres    false    450   �F	      �          0    37225    CommitteeManagement 
   TABLE DATA             COPY "BEN"."CommitteeManagement" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "Name", "NameBn", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "DivisionId", "DistrictId", "UpazillaId", "UnionId", "NgoId", "CommitteeTypeId", "SubCommitteeTypeId", "CommitteeFormDate", "CommitteeEndDate", "NameOfBankAC", "AccountNumber", "AccountType", "BankName", "BranchName", "AccountOpeningDate", "Remark", "IsInActiveCommittee", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    BEN          postgres    false    488   �F	      �          0    37278    CommitteeManagementMember 
   TABLE DATA           *  COPY "BEN"."CommitteeManagementMember" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "Name", "NameBn", "CommitteeManagementId", "ExecutiveDesignationId", "SubCommitteeDesignationId", "SurveyId", "OtherCommitteeMemberId", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    BEN          postgres    false    490   G	      �          0    33826 "   DisabilityTypeHouseholdMembersMaps 
   TABLE DATA           �   COPY "BEN"."DisabilityTypeHouseholdMembersMaps" ("DisabilityTypeId", "HouseholdMemberId", "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActive", "IsDeleted", "ModifiedBy", "UpdatedAt") FROM stdin;
    BEN          postgres    false    334   G	      �          0    33252    DisabilityTypes 
   TABLE DATA           �   COPY "BEN"."DisabilityTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    238   <G	      �          0    33258    EnergyTypes 
   TABLE DATA           �   COPY "BEN"."EnergyTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    240   YG	      �          0    33616 
   EnergyUses 
   TABLE DATA           �   COPY "BEN"."EnergyUses" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "EnergyTypeId", "EnergyUseTypeTxt", "EnergyUsesMonthly", "SurveyId") FROM stdin;
    BEN          postgres    false    310   vG	      �          0    33264 
   Ethnicitys 
   TABLE DATA           �   COPY "BEN"."Ethnicitys" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    242   �G	                0    34330    ExecutiveCommittee 
   TABLE DATA           �  COPY "BEN"."ExecutiveCommittee" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "NgoId", "AccountNumber", "AccountOpeningDate", "AccountType", "BankName", "BranchName", "CellNo", "ForestCircleId", "CommitteeTypeId", "DesignatinId", "EthnicityId", "FatherOrSpouse", "ForestFcvVcfId", "ForestDivisionId", "GenderId", "IsFcv", "NameOfBankAC", "NidNo", "OfficeBearersId", "ForestRangeId", "Remark", "ForestBeatId", "ExDesignatinId", "OtherMemberId", "SubCommitteeDesignationId", "DistrictId", "DivisionId", "UpazillaId", "UnionId", "CommitteeEndDate", "CommitteeFormDate", "IsActiveCommittee") FROM stdin;
    BEN          postgres    false    368   �G	      �          0    33632    ExistingSkills 
   TABLE DATA           �   COPY "BEN"."ExistingSkills" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "SkillName", "SkillLevelEnum", "Remarks", "SurveyId") FROM stdin;
    BEN          postgres    false    312   �G	      �          0    33270    ExpenditureTypes 
   TABLE DATA           �   COPY "BEN"."ExpenditureTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    244   �G	                0    34317    FcvExecutiveCommitteeMember 
   TABLE DATA           �   COPY "BEN"."FcvExecutiveCommitteeMember" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "ExecutiveMemberTypeId", "NgoId", "BeneficiaryId") FROM stdin;
    BEN          postgres    false    366   H	      �          0    33276 	   FoodItems 
   TABLE DATA           �   COPY "BEN"."FoodItems" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    246   $H	      �          0    33643    FoodSecurityItems 
   TABLE DATA           �   COPY "BEN"."FoodSecurityItems" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "FoodItemId", "FoodItemTxt", "FoodAvilableMonthInYear", "Remarks", "SurveyId") FROM stdin;
    BEN          postgres    false    314   AH	      �          0    33478    ForestBeats 
   TABLE DATA           �   COPY "BEN"."ForestBeats" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "ForestRangeId") FROM stdin;
    BEN          postgres    false    298   ^H	      �          0    33282    ForestCircles 
   TABLE DATA           �   COPY "BEN"."ForestCircles" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    248   {H	      �          0    33406    ForestDivisions 
   TABLE DATA           �   COPY "BEN"."ForestDivisions" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "ForestCircleId") FROM stdin;
    BEN          postgres    false    288   �H	      �          0    33489    ForestFcvVcfs 
   TABLE DATA           �   COPY "BEN"."ForestFcvVcfs" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "ForestBeatId", "IsFcv", "FormedTime") FROM stdin;
    BEN          postgres    false    300   �H	      �          0    33456    ForestRanges 
   TABLE DATA           �   COPY "BEN"."ForestRanges" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "ForestDivisionId") FROM stdin;
    BEN          postgres    false    294   �H	      �          0    33659     GrossMarginIncomeAndCostStatuses 
   TABLE DATA           �  COPY "BEN"."GrossMarginIncomeAndCostStatuses" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ProductName", "LandArea", "MeasurementOfProduct", "TotalProductionHousehold", "TotalCostOfProduction", "TotalConsumption", "QuantitySold", "TotalValueSold", "ValueSoldPerQuantity", "ProductionValueSoldPerQuantity", "TotalNetIncome", "SurveyId") FROM stdin;
    BEN          postgres    false    316   �H	      �          0    33670    HouseholdMembers 
   TABLE DATA           %  COPY "BEN"."HouseholdMembers" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "FullName", "FullNameBn", "RelationWithHeadHouseHoldTypeId", "RelationWithHeadHouseHoldTypeTxt", "Gender", "Age", "AgeBn", "MaritalSatus", "MaritalSatusTxt", "EducationLevel", "MainOccupationId", "MainOccupationTxt", "SecondaryOccupationId", "SecondOccupationTxt", "BFDAssociationTxt", "HasDisability", "SafetyNetTypeId", "SafetyNetTypeTxt", "SubmissionTime", "SubmittedBy", "Notes", "SurveyId") FROM stdin;
    BEN          postgres    false    318   I	      �          0    33288    ImmovableAssetTypes 
   TABLE DATA           �   COPY "BEN"."ImmovableAssetTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    250   )I	      �          0    33703    ImmovableAssets 
   TABLE DATA           �   COPY "BEN"."ImmovableAssets" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ImmovableAssetTypeId", "ImmovableAssetsTypeTxt", "ImmovableAnnualReturn", "SurveyId") FROM stdin;
    BEN          postgres    false    320   FI	      �          0    33719    LandOccupancies 
   TABLE DATA           a  COPY "BEN"."LandOccupancies" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "LandClassificationEnum", "LandClassificationTxt", "Homesteads", "ProductiveLand", "FallowLand", "ProductiveWetland", "FallowWetland", "OthersLand", "TotalLand", "SubmissionTime", "Notes", "SurveyId") FROM stdin;
    BEN          postgres    false    322   cI	      �          0    33294    LiveStockTypes 
   TABLE DATA           �   COPY "BEN"."LiveStockTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    252   �I	      �          0    33730 
   LiveStocks 
   TABLE DATA           �   COPY "BEN"."LiveStocks" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "LiveStockTypeId", "LivestockTypeTxt", "LiveStockQuantity", "LivestockCost", "SurveyId") FROM stdin;
    BEN          postgres    false    324   �I	      �          0    33300    ManualIncomeSourceTypes 
   TABLE DATA           �   COPY "BEN"."ManualIncomeSourceTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    254   �I	      �          0    33746    ManualPhysicalWorks 
   TABLE DATA           a  COPY "BEN"."ManualPhysicalWorks" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ManualIncomeSourceTypeId", "ManualIncomeSourceTypeTxt", "NoOfMale", "NoOfFemale", "NoOfActiveMonth", "AvgNoPersonActivePerMonth", "AvgDailyIncome", "TotalPerson", "TotalAnnualIncome", "SurveyId") FROM stdin;
    BEN          postgres    false    326   �I	      �          0    33306    NaturalIncomeSourceTypes 
   TABLE DATA           �   COPY "BEN"."NaturalIncomeSourceTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    256   �I	      �          0    33762 %   NaturalResourcesIncomeAndCostStatuses 
   TABLE DATA              COPY "BEN"."NaturalResourcesIncomeAndCostStatuses" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "NaturalIncomeSourceTypeId", "NoOfMale", "NoOfFemale", "NoOfActiveMonth", "AvgNoPersonActivePerMonth", "TotalManDaysForCollection", "Unit", "TotalProduced", "TotalConsumption", "QuantitySold", "ValueProduceSold", "CostOfActivity", "ValueSoldPerActivity", "ProducedValueSoldActivity", "ActivityPerValueSold", "TotalNetIncome", "SurveyId") FROM stdin;
    BEN          postgres    false    328   J	      �          0    33312    Ngos 
   TABLE DATA           �   COPY "BEN"."Ngos" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "ForestDivisionIdList", "ForestCircleIdList") FROM stdin;
    BEN          postgres    false    258   .J	      �          0    33318    Occupations 
   TABLE DATA           �   COPY "BEN"."Occupations" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    260   KJ	                0    34423    OtherCommitteeMembers 
   TABLE DATA           �  COPY "BEN"."OtherCommitteeMembers" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "FullName", "Gender", "PhoneNumber", "NID", "Address", "ForestFcvVcfId", "EthnicityId", "DistrictId", "DivisionId", "FatherOrSpouse", "ForestBeatId", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "UpazillaId", "UnionId") FROM stdin;
    BEN          postgres    false    370   hJ	      �          0    33324    OtherIncomeSourceTypes 
   TABLE DATA           �   COPY "BEN"."OtherIncomeSourceTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    262   �J	      �          0    33778    OtherIncomeSources 
   TABLE DATA             COPY "BEN"."OtherIncomeSources" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "OtherIncomeSourceTypeId", "OtherIncomeSourceTypeTxt", "GrossValueOfSales", "TotalCashCosts", "TotalNetIncome", "SurveyId") FROM stdin;
    BEN          postgres    false    330   �J	      �          0    33330    RelationWithHeadHouseHoldTypes 
   TABLE DATA           �   COPY "BEN"."RelationWithHeadHouseHoldTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    264   �J	      �          0    33336 
   SafetyNets 
   TABLE DATA           �   COPY "BEN"."SafetyNets" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    266   �J	      R          0    35728    SurveyDocuments 
   TABLE DATA           �   COPY "BEN"."SurveyDocuments" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "SurveyId", "DocumentName", "DocumentNameURL") FROM stdin;
    BEN          postgres    false    424   �J	      �          0    37165    SurveyIncidents 
   TABLE DATA           �   COPY "BEN"."SurveyIncidents" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "SurveyId", "Year", "MonthNo", "Incident", "Decision", "Action", "SurveyIncidentStatus", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    BEN          postgres    false    486   K	      �          0    33500    Surveys 
   TABLE DATA           ;  COPY "BEN"."Surveys" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "StartTime", "EndTime", "SurveyDate", "Deviceid", "Subscriberid", "Simserial", "Phonenumber", "DetailsInfo", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "ForestVillageName", "ForestVillageNameBn", "BeneficiaryId", "BeneficiaryHouseholdSerialNo", "BeneficiaryName", "BeneficiaryNameBn", "BeneficiaryNid", "BeneficiaryPhone", "BeneficiaryPhoneBn", "BeneficiaryGender", "BeneficiaryEthnicityId", "BeneficiaryEthnicityTxt", "BeneficiaryAge", "BeneficiaryAgeBn", "BeneficiaryFatherName", "BeneficiaryFatherNameBn", "BeneficiaryMotherName", "BeneficiaryMotherNameBn", "BeneficiarySpouseName", "BeneficiarySpouseNameBn", "HeadOfHouseholdName", "HeadOfHouseholdNameBn", "HeadOfHouseholdGender", "PresentVillageName", "PresentVillageNameBn", "PresentPostOfficeName", "PresentPostOfficeNameBn", "PresentDivisionId", "PresentDistrictId", "PresentUpazillaId", "PresentUnion", "IsPermanentSameAsPresent", "PermanentVillageName", "PermanentVillageNameBn", "PermanentPostOfficeName", "PermanentPostOfficeNameBn", "PermanentDivisionId", "PermanentDistrictId", "PermanentUpazillaId", "PermanentUnion", "PermanentUnionBn", "BeneficiaryLatitude", "BeneficiaryLongitude", "BeneficiaryAltitude", "BeneficiaryPrecision", "BeneficiaryHouseFrontImage", "BeneficiaryHouseFrontImageURL", "GrandTotalLandOccupancy", "BeneficiaryHouseType", "GrandTotalLivestockCost", "GrandTotalAssetsCost", "GrandTotalImmovableAnnualReturn", "GrandTotalEnergyUsesMonthly", "IsProblemToAccessHealthService", "NearestHealthServiceLocation", "NearestHealthServiceDistance", "IsProblemToAccessDrinkingWater", "NearestDrinkingWaterDistance", "SourceofDrySeasonWaterEnumList", "SourceofDrySeasonWaterTxt", "SourceofWetSeasonWaterEnumList", "SourceofWetSeasonWaterTxt", "NearestGrowthCenter", "NearestGrowthCenterDistance", "IsProblemToAccessEducation", "HasEducationalInstituteNearby", "EducationalInstituteDistance", "EducationalInstituteAccessibilityEnum", "SanitationFacilitiesEnum", "PotentialSkillName1", "PotentialSkillName2", "PotentialSkillName3", "PotentialSpecialSkill", "PotentialSkillsRemarks", "ForestMngmtSatisfactionEnum", "ForestMngmtEffectivenessEnum", "ForestDependencyEnum", "IsHearedAboutCfm", "IsParticipatedInCfm", "WillCfmImproveForestMngmnt", "WillCfmImproveWellBeing", "DicisionTakerEnum", "ProductiveAssetsOwnerGender", "CropTypeDecisionGender", "DecisionToTransferAssetsGender", "FamilyNeedsDeciderGender", "AccessorToCreditGender", "ControllerOfCreditGender", "OfficeBearerGender", "MorePaymentGetterGender", "CanAccessLegalSupportForGbv", "CanUnsufructsRights", "FaceLiveAndLivelihoodChallanges", "HasLlfmInterest", "GrandTotalNetIncomeAgriculture", "GrandTotalLandArea", "GrandTotalGrossMarginAgriculture", "GrandTotalAnnualPhysicalIncome", "GrandTotalWildResourceIncome", "GrandTotalOtherIncome", "GrandTotalBusinessIncome", "NoOfMaleInsideCountry", "SentIncomeOfMaleInYearInsideCountry", "NoOfFemaleInsideCountry", "SentIncomeOfFemaleInYearInsideCountry", "NoOfMaleOutsideCountry", "SentIncomeOfMaleInYearOutsideCountry", "NoOfFemaleOutsideCountry", "SentIncomeOfFemaleInYearOutsideCountry", "PersonalSavingsOfAllMembers", "HouseShareInSavings", "BorrowedFromBank", "BorrowedFromNGO", "GrantsFromNGO", "GrantsFromGob", "BorrowedFromCoOperatives", "BorrowedFromNonRelatives", "BorrowedFromRelatives", "SaleOfProducts", "OtherFinanceName", "OtherFinanceAmount", "GrandTotalHouseholdExpenditure", "HouseholdFoodCondition", "FoodCrisisMonth", "FoodyPersonInFoodCrisis", "NotesImage", "NotesImageUrl", "NameOfTheEnumerator", "CellPhoneNumber", "DataCollectionDate", "BeneficiaryApproveStatus", "BeneficiaryProfileURL", "NgoId", "PermanentUnionNewId", "PresentUnionNewId", "BeneficiaryApproveStatusById", "FcvVcfAddedDate", "CipId") FROM stdin;
    BEN          postgres    false    302   3K	                 0    34568    Trade 
   TABLE DATA           �   COPY "BEN"."Trade" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    374   PK	      �          0    33342    VulnerabilitySituationTypes 
   TABLE DATA           �   COPY "BEN"."VulnerabilitySituationTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    BEN          postgres    false    268   mK	      �          0    33794    VulnerabilitySituations 
   TABLE DATA           &  COPY "BEN"."VulnerabilitySituations" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "VulnerabilitySituationTypeId", "VulnerabilitySituationTypeTxt", "EventName", "MonetaryLoss", "HowDidRecover", "Remarks", "SurveyId") FROM stdin;
    BEN          postgres    false    332   �K	      8          0    35061    SavingsAccount 
   TABLE DATA           ]  COPY "BSA"."SavingsAccount" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "FcvId", "DivisionId", "DistrictId", "UpazillaId", "NgoId", "SurveyId", "StatusId", "AccountTypeId", "AmountLimit", "UnionId") FROM stdin;
    BSA          postgres    false    398   �K	      :          0    35123    SavingsAmountInformation 
   TABLE DATA           �   COPY "BSA"."SavingsAmountInformation" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "SavingsAccountId", "SavingsDate", "SavingsAmount", "Remark", "DocumentFileUrl") FROM stdin;
    BSA          postgres    false    400   �K	      <          0    35136    WithdrawAmountInformation 
   TABLE DATA           �   COPY "BSA"."WithdrawAmountInformation" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "SavingsAccountId", "WithdrawDate", "WithdrawAmount", "Remark", "DfoRemark", "DfoStatusId") FROM stdin;
    BSA          postgres    false    402   �K	                0    34168    CommunityTrainingFiles 
   TABLE DATA           �   COPY "Capacity"."CommunityTrainingFiles" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "FileName", "FileNameUrl", "FileType", "CommunityTrainingId") FROM stdin;
    Capacity          postgres    false    354   �K	                 0    34043    CommunityTrainingMembers 
   TABLE DATA           �   COPY "Capacity"."CommunityTrainingMembers" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "MemberName", "MemberAge", "MemberPhoneNumber", "MemberAddress", "MemberGender") FROM stdin;
    Capacity          postgres    false    342   L	                0    34075 !   CommunityTrainingParticipentsMaps 
   TABLE DATA             COPY "Capacity"."CommunityTrainingParticipentsMaps" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "SurveyId", "CommunityTrainingMemberId", "ParticipentType", "CommunityTrainingId") FROM stdin;
    Capacity          postgres    false    350   8L	                0    34051    CommunityTrainingTypes 
   TABLE DATA           �   COPY "Capacity"."CommunityTrainingTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    Capacity          postgres    false    344   UL	      
          0    34091    CommunityTrainings 
   TABLE DATA           �  COPY "Capacity"."CommunityTrainings" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "TrainingTitle", "TrainingTitleBn", "StartDate", "EndDate", "TrainingDuration", "Location", "LocationBn", "TrainerName", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "UpazillaId", "EventTypeId", "CommunityTrainingTypeId", "TrainingOrganizerId", "UnionId") FROM stdin;
    Capacity          postgres    false    352   rL	                0    34260    DepartmentalTrainingFiles 
   TABLE DATA           �   COPY "Capacity"."DepartmentalTrainingFiles" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "FileName", "FileNameUrl", "FileType", "DepartmentalTrainingId") FROM stdin;
    Capacity          postgres    false    362   �L	                0    34181    DepartmentalTrainingMembers 
   TABLE DATA           C  COPY "Capacity"."DepartmentalTrainingMembers" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "MemberName", "MemberPhoneNumber", "MemberGender", "MemberEmail", "MemberNID", "MemberDesignation", "MemberOrganization", "EthnicityId", "MemberAddress") FROM stdin;
    Capacity          postgres    false    356   �L	                0    34273 $   DepartmentalTrainingParticipentsMaps 
   TABLE DATA           �   COPY "Capacity"."DepartmentalTrainingParticipentsMaps" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "DepartmentalTrainingMemberId", "DepartmentalTrainingId") FROM stdin;
    Capacity          postgres    false    364   �L	                0    34189    DepartmentalTrainingTypes 
   TABLE DATA           �   COPY "Capacity"."DepartmentalTrainingTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    Capacity          postgres    false    358   �L	                0    34197    DepartmentalTrainings 
   TABLE DATA           "  COPY "Capacity"."DepartmentalTrainings" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "TrainingTitle", "TrainingTitleBn", "StartDate", "EndDate", "TrainingDuration", "Location", "LocationBn", "TrainerName", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "UpazillaId", "EventTypeId", "DepartmentalTrainingTypeId", "TrainingOrganizerId", "FinancialYearId", "TotalFemale", "TotalMale", "TotalMembers") FROM stdin;
    Capacity          postgres    false    360   M	                0    34059 
   EventTypes 
   TABLE DATA           �   COPY "Capacity"."EventTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "HasTrainingType") FROM stdin;
    Capacity          postgres    false    346    M	      *          0    34727    MeetingParticipantsMaps 
   TABLE DATA           �   COPY "Capacity"."MeetingParticipantsMaps" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "SurveyId", "MeetingMemberId", "ParticipentType", "MeetingId") FROM stdin;
    Capacity          postgres    false    384   =M	                0    34067    TrainingOrganizers 
   TABLE DATA           �   COPY "Capacity"."TrainingOrganizers" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    Capacity          postgres    false    348   ZM	      �          0    33348    Category 
   TABLE DATA           �   COPY "GS"."Category" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "CategoryName") FROM stdin;
    GS          postgres    false    270   wM	      �          0    33354    Color 
   TABLE DATA           �   COPY "GS"."Color" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ColorName") FROM stdin;
    GS          postgres    false    272   �M	      �          0    33422    District 
   TABLE DATA           �   COPY "GS"."District" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "DivisionId") FROM stdin;
    GS          postgres    false    290   �M	      �          0    33360    Division 
   TABLE DATA           �   COPY "GS"."Division" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "DivisionName", "DivisionNameBangla") FROM stdin;
    GS          postgres    false    274   �M	      .          0    34915    FinancialYears 
   TABLE DATA           �   COPY "GS"."FinancialYears" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "EndYear", "StartYear") FROM stdin;
    GS          postgres    false    388   �M	      "          0    34576    SubCommitteeDesignations 
   TABLE DATA           �   COPY "GS"."SubCommitteeDesignations" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ExecutiveMemberType", "Name", "NameBn") FROM stdin;
    GS          postgres    false    376   N	      �          0    34028    Union 
   TABLE DATA           �   COPY "GS"."Union" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "UpazillaId") FROM stdin;
    GS          postgres    false    340   %N	      �          0    33467    Upazilla 
   TABLE DATA           �   COPY "GS"."Upazilla" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "DistrictId") FROM stdin;
    GS          postgres    false    296   BN	      �          0    37088    InternalLoanInformationFiles 
   TABLE DATA           �   COPY "InternalLoan"."InternalLoanInformationFiles" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "InternalLoanInformationId", "FileName", "FileNameUrl", "FileType", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    InternalLoan          postgres    false    480   _N	      T          0    35750    InternalLoanInformations 
   TABLE DATA           �  COPY "InternalLoan"."InternalLoanInformations" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "UpazillaId", "UnionId", "NgoId", "SurveyId", "LDFCount", "TotalAllocatedLoanAmount", "MaximumRepaymentMonth", "StartDate", "EndDate", "ServiceChargePercentage", "SecurityChargePercentage") FROM stdin;
    InternalLoan          postgres    false    426   |N	      X          0    35896    RepaymentInternalLoans 
   TABLE DATA           m  COPY "InternalLoan"."RepaymentInternalLoans" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "InternalLoanInformationId", "RepaymentAmount", "RepaymentStartDate", "RepaymentEndDate", "RepaymentSerial", "IsPaymentCompleted", "PaymentCompletedDateTime", "IsPaymentCompletedLate", "IsLocked") FROM stdin;
    InternalLoan          postgres    false    430   �N	      ^          0    36063    LabourDatabaseFiles 
   TABLE DATA           �   COPY "Labour"."LabourDatabaseFiles" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "LabourDatabaseId", "FileType", "FileName", "FileUrl") FROM stdin;
    Labour          postgres    false    436   �N	      \          0    35985    LabourDatabases 
   TABLE DATA           e  COPY "Labour"."LabourDatabases" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "UpazillaId", "UnionId", "SurveyId", "OtherLabourMemberId", "EthnicityId", "CodeNo") FROM stdin;
    Labour          postgres    false    434   �N	      �          0    37319    LabourWorks 
   TABLE DATA             COPY "Labour"."LabourWorks" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "LabourDatabaseId", "WorkType", "ManDays", "PaymentAmountPerDay", "TotalAmount", "PaymentType", "Remarks", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    Labour          postgres    false    492   �N	      Z          0    35927    OtherLabourMembers 
   TABLE DATA           g  COPY "Labour"."OtherLabourMembers" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "FullName", "Gender", "PhoneNumber", "NID", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "UpazillaId", "UnionId", "EthnicityId") FROM stdin;
    Labour          postgres    false    432   O	      �          0    34007 
   Marketings 
   TABLE DATA           �   COPY "Marketing"."Marketings" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "MarketingName", "MarketingNameBn", "DistrictId", "DivisionId") FROM stdin;
 	   Marketing          postgres    false    338   *O	      ,          0    34748    MeetingFiles 
   TABLE DATA           �   COPY "Meeting"."MeetingFiles" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "FileName", "FileNameUrl", "FileType", "MeetingId") FROM stdin;
    Meeting          postgres    false    386   GO	      $          0    34658    MeetingMembers 
   TABLE DATA           �   COPY "Meeting"."MeetingMembers" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "MemberName", "MemberGender", "MemberAge", "MemberPhone", "MemberAddress") FROM stdin;
    Meeting          postgres    false    378   dO	      &          0    34666    MeetingTypes 
   TABLE DATA           �   COPY "Meeting"."MeetingTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn") FROM stdin;
    Meeting          postgres    false    380   �O	      (          0    34674    Meetings 
   TABLE DATA           }  COPY "Meeting"."Meetings" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "MeetingTitle", "MeetingDate", "MeetingTypeId", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "UpazillaId", "EndTime", "StartTime", "UnionId", "NgoId", "Venue") FROM stdin;
    Meeting          postgres    false    382   �O	      J          0    35368    OtherPatrollingMember 
   TABLE DATA           �  COPY "Patrolling"."OtherPatrollingMember" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "FullName", "FatherOrSpouse", "Gender", "PhoneNumber", "NID", "Address", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "UpazillaId", "EthnicityId") FROM stdin;
 
   Patrolling          postgres    false    416   �O	      H          0    35339    PatrollingPaymentInformetion 
   TABLE DATA           G  COPY "Patrolling"."PatrollingPaymentInformetion" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "PatrollingScheduleInformetionId", "SurveyId", "AmountOfHonoraryAllowance", "Remark", "GenderId", "ParticipentName", "PhoneNo", "OtherPatrollingMemberId") FROM stdin;
 
   Patrolling          postgres    false    414   �O	      F          0    35291    PatrollingScheduleInformetion 
   TABLE DATA           �  COPY "Patrolling"."PatrollingScheduleInformetion" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "FcvId", "DivisionId", "DistrictId", "UpazillaId", "NgoId", "Date", "PatrollingDescription", "StartTime", "EndTime", "PatrollingArea", "AllocatedAmountMonth", "FilePath", "Remark", "OtherPatrollingMemberId", "PatrollingPlanningFile", "UnionId") FROM stdin;
 
   Patrolling          postgres    false    412   �O	      h          0    36317    PatrollingSchedulingFiles 
   TABLE DATA           �   COPY "PatrollingScheduling"."PatrollingSchedulingFiles" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "FileName", "FileNameUrl", "FileType", "PatrollingSchedulingId", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    PatrollingScheduling          postgres    false    446   P	      d          0    36251    PatrollingSchedulingMembers 
   TABLE DATA             COPY "PatrollingScheduling"."PatrollingSchedulingMembers" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "MemberName", "MemberAge", "MemberGender", "MemberPhoneNumber", "MemberAddress", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    PatrollingScheduling          postgres    false    442   /P	      j          0    36330 $   PatrollingSchedulingParticipentsMaps 
   TABLE DATA           l  COPY "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "SurveyId", "PatrollingSchedulingMemberId", "ParticipentType", "PatrollingSchedulingId", "ParticipentName", "GenderEnumId", "PhoneNo", "AmountOfHonoraryAllowance", "Remark", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    PatrollingScheduling          postgres    false    448   LP	      f          0    36259    PatrollingSchedulings 
   TABLE DATA           �  COPY "PatrollingScheduling"."PatrollingSchedulings" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "UpazillaId", "UnionId", "NgoId", "FcvId", "Date", "PatrollingDescription", "StartTime", "EndTime", "PatrollingArea", "AllocatedAmountMonth", "Remark", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    PatrollingScheduling          postgres    false    444   iP	      �          0    37000    BankDeposits 
   TABLE DATA           �   COPY "SocialForestry"."BankDeposits" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "RevenueDistributionId", "DepositAmount", "DepositDate", "Remarks", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    SocialForestry          postgres    false    474   �P	      x          0    36922    CuttingPlantations 
   TABLE DATA           �  COPY "SocialForestry"."CuttingPlantations" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "NewRaisedPlantationId", "YearOfCutting", "ResourceQtyTimber", "ResourceQtyPole", "ResourceQtyFuelWood", "SaleValueTimber", "SaleValuePole", "SaleValueFuelWood", "CreatedBy", "ModifiedBy", "DeletedBy", "ResourceQtyTotal", "SaleValueTotal", "RotationInYears", "YearOfReforestation", "RotationNo", "ReforestationId") FROM stdin;
    SocialForestry          postgres    false    462   �P	      �          0    37013 "   DistributedOrRevenueDepositAmounts 
   TABLE DATA           �   COPY "SocialForestry"."DistributedOrRevenueDepositAmounts" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "RevenueDistributionId", "Amount", "DateOccurred", "Remarks", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    SocialForestry          postgres    false    476   �P	      z          0    36933    NewRaisedPlantationUnionMaps 
   TABLE DATA           �   COPY "SocialForestry"."NewRaisedPlantationUnionMaps" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "NewRaisedPlantationId", "UnionId", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    SocialForestry          postgres    false    464   �P	      |          0    36949    NewRaisedPlantationUpazillaMaps 
   TABLE DATA           �   COPY "SocialForestry"."NewRaisedPlantationUpazillaMaps" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "NewRaisedPlantationId", "UpazillaId", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    SocialForestry          postgres    false    466   �P	      v          0    36859    NewRaisedPlantations 
   TABLE DATA           �  COPY "SocialForestry"."NewRaisedPlantations" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "ForestCircleId", "ForestDivisionId", "ForestRangeId", "ForestBeatId", "ForestFcvVcfId", "DivisionId", "DistrictId", "NgoId", "PlantationProjectId", "PlantationTypeId", "StripTypeId", "YearOfPlantation", "ExpectedYearOfCutting", "PlantationLocation", "PlantationArea", "PlantationEstablishmentCostNurseryTk", "PlantationEstablishmentCostPlantationTk", "LaborInvolvedNurseryMale", "LaborInvolvedNurseryFemale", "LaborInvolvedPlantationMale", "LaborInvolvedPlantationFemale", "MaleBeneficiaries", "FemaleBeneficiaries", "IsSocialForestryCommitteeFormed", "IsFundManagementSubCommitteeFormed", "Remarks", "CreatedBy", "ModifiedBy", "DeletedBy", "LaborEngagedTotal", "LaborEngagedTotalFemale", "LaborEngagedTotalMale", "LaborInvolvedNurseryTotal", "LaborInvolvedPlantationTotal", "PlantationEstablishmentCostPlantationTotal", "TotalBeneficiaries", "RotationInYears") FROM stdin;
    SocialForestry          postgres    false    460   Q	      n          0    36819    PlantationProjects 
   TABLE DATA           �   COPY "SocialForestry"."PlantationProjects" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "Name", "NameBn", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    SocialForestry          postgres    false    452   4Q	      r          0    36835     PlantationTypeRevenuePercentages 
   TABLE DATA           �   COPY "SocialForestry"."PlantationTypeRevenuePercentages" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "PlantationTypeId", "RevenueDistributionTypeEnum", "RevenuePercentage", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    SocialForestry          postgres    false    456   QQ	      p          0    36827    PlantationTypes 
   TABLE DATA           �   COPY "SocialForestry"."PlantationTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "TypeName", "PlantationAreaTypeEnum", "HasStripType", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    SocialForestry          postgres    false    454   nQ	      ~          0    36965    Reforestations 
   TABLE DATA           ?  COPY "SocialForestry"."Reforestations" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "NewRaisedPlantationId", "YearOfReforestation", "ExpectedYearOfCutting", "ReforestLocation", "ReforestationArea", "PlantationEstablishmentCostNurseryTk", "PlantationEstablishmentCostPlantationTk", "LaborInvolvedNurseryMale", "LaborInvolvedNurseryFemale", "LaborInvolvedPlantationMale", "LaborInvolvedPlantationFemale", "MaleBeneficiaries", "FemaleBeneficiaries", "IsAccountMaintainedBySubCommittee", "Remarks", "CreatedBy", "ModifiedBy", "DeletedBy", "LaborEngagedTotal", "LaborEngagedTotalFemale", "LaborEngagedTotalMale", "LaborInvolvedNurseryTotal", "LaborInvolvedPlantationTotal", "PlantationEstablishmentCostPlantationTotal", "RotationInYears", "TotalBeneficiaries", "RotationNo", "CuttingPlantationId") FROM stdin;
    SocialForestry          postgres    false    468   �Q	      �          0    36989    RevenueDistributions 
   TABLE DATA           Y  COPY "SocialForestry"."RevenueDistributions" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "RevenueId", "RevenueDistributionTypeEnum", "ShareInPercentage", "GovernmentRevenue", "RevenueCollected", "OutStandingAmount", "NumberOrMale", "NumberOrFemale", "AmountInHand", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    SocialForestry          postgres    false    472   �Q	      �          0    36978    Revenues 
   TABLE DATA           �   COPY "SocialForestry"."Revenues" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CuttingPlantationId", "RevenueReceivedAmount", "RevenueReceivedDate", "OutstandingSaleValue", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    SocialForestry          postgres    false    470   �Q	      t          0    36846 
   StripTypes 
   TABLE DATA           �   COPY "SocialForestry"."StripTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "Name", "NameBn", "PlantationTypeId", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    SocialForestry          postgres    false    458   �Q	                0    34490    Students 
   TABLE DATA           �   COPY "Student"."Students" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "Email", "RollNumber", "AccountNumber", "Batch", "Semester") FROM stdin;
    Student          postgres    false    372   �Q	      �          0    33372    AccessMapper 
   TABLE DATA           �   COPY "System"."AccessMapper" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "AccessList", "RoleStatus", "IsVisible") FROM stdin;
    System          postgres    false    278   R	      �          0    33366 
   Accesslist 
   TABLE DATA           	  COPY "System"."Accesslist" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ControllerName", "ActionName", "Mask", "AccessStatus", "IsVisible", "IconClass", "BaseModule", "BaseModuleIndex") FROM stdin;
    System          postgres    false    276   9R	      �          0    33380    Module 
   TABLE DATA           �   COPY "System"."Module" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ModuleName", "ModuleIcon", "IsVisible", "MenueOrder") FROM stdin;
    System          postgres    false    280   VR	      �          0    33386    PmsGroup 
   TABLE DATA           �   COPY "System"."PmsGroup" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "GroupName", "GroupDescription", "GroupStatus", "IsVisible") FROM stdin;
    System          postgres    false    282   sR	      �          0    33433    User 
   TABLE DATA           �  COPY "System"."User" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "FirstName", "LastName", "RoleName", "UserName", "UserEmail", "UserPassword", "ImageUrl", "UserPhone", "UserGroup", "UserStatus", "PmsGroupID", "GroupID", "UserRolesId", "DistrictId", "DivisionId", "ForestBeatId", "ForestCircleId", "ForestDivisionId", "ForestFcvVcfId", "ForestRangeId", "UnionId", "UpazillaId", "SurveyId") FROM stdin;
    System          postgres    false    292   �R	      �          0    33392 	   UserGroup 
   TABLE DATA           �   COPY "System"."UserGroup" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "GroupName", "ModuleActionNames", "IsUsed", "IsDefault", "IsVisible") FROM stdin;
    System          postgres    false    284   �R	      �          0    33400 	   UserRoles 
   TABLE DATA           �   COPY "System"."UserRoles" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "RoleName") FROM stdin;
    System          postgres    false    286   �R	      �          0    37133    ExpenseDetailsForCDFs 
   TABLE DATA           �   COPY "TRANSACTION"."ExpenseDetailsForCDFs" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "TransactionExpenseId", "ExpenseScheme", "ExpenseAmount", "DocumentFileURL", "Remakrs", "CreatedBy", "ModifiedBy", "DeletedBy") FROM stdin;
    TRANSACTION          postgres    false    484   �R	      0          0    34923 	   FundTypes 
   TABLE DATA           �   COPY "TRANSACTION"."FundTypes" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "Name", "NameBn", "IsCdf") FROM stdin;
    TRANSACTION          postgres    false    390   S	      4          0    34952    TransactionDetails 
   TABLE DATA           �   COPY "TRANSACTION"."TransactionDetails" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "TransactionId", "FundTypeId", "TargetAmount") FROM stdin;
    TRANSACTION          postgres    false    394   !S	      6          0    34968    TransactionExpenses 
   TABLE DATA           q  COPY "TRANSACTION"."TransactionExpenses" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "TransactionDetailsId", "ExpenseAmount", "ExpenseDate", "ExpenseDocumentFileName", "ExpenseDocumentFileURL", "FundTypeId", "ExpenseMonth", "ExpenseYear", "ForestBeatId", "ForestFcvVcfId", "ForestRangeId") FROM stdin;
    TRANSACTION          postgres    false    396   >S	      2          0    34931    Transactions 
   TABLE DATA           �   COPY "TRANSACTION"."Transactions" ("Id", "CreatedAt", "UpdatedAt", "DeletedAt", "IsDeleted", "IsActive", "CreatedBy", "ModifiedBy", "DeletedBy", "ForestCircleId", "ForestDivisionId", "FromDate", "ToDate", "FinancialYearId") FROM stdin;
    TRANSACTION          postgres    false    392   [S	      �          0    33225    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public          postgres    false    230   xS	      �           0    0    AIGBasicInformations_Id_seq    SEQUENCE SET     K   SELECT pg_catalog.setval('"AIG"."AIGBasicInformations_Id_seq"', 1, false);
          AIG          postgres    false    403            �           0    0    FirstSixtyPercentageLDFs_Id_seq    SEQUENCE SET     O   SELECT pg_catalog.setval('"AIG"."FirstSixtyPercentageLDFs_Id_seq"', 1, false);
          AIG          postgres    false    405            �           0    0    GroupLDFInfoFormMember_Id_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('"AIG"."GroupLDFInfoFormMember_Id_seq"', 1, false);
          AIG          postgres    false    439            �           0    0    GroupLDFInfoForms_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('"AIG"."GroupLDFInfoForms_Id_seq"', 1, false);
          AIG          postgres    false    437            �           0    0     IndividualGroupFormSetups_Id_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('"AIG"."IndividualGroupFormSetups_Id_seq"', 1, false);
          AIG          postgres    false    421            �           0    0    IndividualLDFInfoForms_Id_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('"AIG"."IndividualLDFInfoForms_Id_seq"', 1, false);
          AIG          postgres    false    419            �           0    0    LDFProgresss_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('"AIG"."LDFProgresss_Id_seq"', 1, false);
          AIG          postgres    false    417            �           0    0    RepaymentLDFFiles_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('"AIG"."RepaymentLDFFiles_Id_seq"', 1, false);
          AIG          postgres    false    481            �           0    0    RepaymentLDFHistories_Id_seq    SEQUENCE SET     L   SELECT pg_catalog.setval('"AIG"."RepaymentLDFHistories_Id_seq"', 1, false);
          AIG          postgres    false    427            �           0    0    RepaymentLDFs_Id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('"AIG"."RepaymentLDFs_Id_seq"', 1, false);
          AIG          postgres    false    409            �           0    0 !   SecondFourtyPercentageLDFs_Id_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('"AIG"."SecondFourtyPercentageLDFs_Id_seq"', 1, false);
          AIG          postgres    false    407            �           0    0 "   AnnualHouseholdExpenditures_Id_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('"BEN"."AnnualHouseholdExpenditures_Id_seq"', 1, false);
          BEN          postgres    false    303            �           0    0    AssetTypes_Id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('"BEN"."AssetTypes_Id_seq"', 1, false);
          BEN          postgres    false    231            �           0    0    Assets_Id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('"BEN"."Assets_Id_seq"', 1, false);
          BEN          postgres    false    305            �           0    0 )   BFDAssociationHouseholdMembersMaps_Id_seq    SEQUENCE SET     Y   SELECT pg_catalog.setval('"BEN"."BFDAssociationHouseholdMembersMaps_Id_seq"', 1, false);
          BEN          postgres    false    336            �           0    0    BFDAssociations_Id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('"BEN"."BFDAssociations_Id_seq"', 1, false);
          BEN          postgres    false    233            �           0    0     BusinessIncomeSourceTypes_Id_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('"BEN"."BusinessIncomeSourceTypes_Id_seq"', 1, false);
          BEN          postgres    false    235            �           0    0    Businesss_Id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('"BEN"."Businesss_Id_seq"', 1, false);
          BEN          postgres    false    307            �           0    0    CipFiles_Id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('"BEN"."CipFiles_Id_seq"', 1, false);
          BEN          postgres    false    477            �           0    0    Cips_Id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('"BEN"."Cips_Id_seq"', 1, false);
          BEN          postgres    false    449            �           0    0     CommitteeManagementMember_Id_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('"BEN"."CommitteeManagementMember_Id_seq"', 1, false);
          BEN          postgres    false    489            �           0    0    CommitteeManagement_Id_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('"BEN"."CommitteeManagement_Id_seq"', 1, false);
          BEN          postgres    false    487            �           0    0 )   DisabilityTypeHouseholdMembersMaps_Id_seq    SEQUENCE SET     Y   SELECT pg_catalog.setval('"BEN"."DisabilityTypeHouseholdMembersMaps_Id_seq"', 1, false);
          BEN          postgres    false    335            �           0    0    DisabilityTypes_Id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('"BEN"."DisabilityTypes_Id_seq"', 1, false);
          BEN          postgres    false    237            �           0    0    EnergyTypes_Id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('"BEN"."EnergyTypes_Id_seq"', 1, false);
          BEN          postgres    false    239            �           0    0    EnergyUses_Id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('"BEN"."EnergyUses_Id_seq"', 1, false);
          BEN          postgres    false    309            �           0    0    Ethnicitys_Id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('"BEN"."Ethnicitys_Id_seq"', 1, false);
          BEN          postgres    false    241            �           0    0    ExecutiveCommittee_Id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('"BEN"."ExecutiveCommittee_Id_seq"', 1, false);
          BEN          postgres    false    367            �           0    0    ExistingSkills_Id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('"BEN"."ExistingSkills_Id_seq"', 1, false);
          BEN          postgres    false    311            �           0    0    ExpenditureTypes_Id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('"BEN"."ExpenditureTypes_Id_seq"', 1, false);
          BEN          postgres    false    243            �           0    0 "   FcvCxecutiveCommitteeMember_Id_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('"BEN"."FcvCxecutiveCommitteeMember_Id_seq"', 1, false);
          BEN          postgres    false    365            �           0    0    FoodItems_Id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('"BEN"."FoodItems_Id_seq"', 1, false);
          BEN          postgres    false    245            �           0    0    FoodSecurityItems_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('"BEN"."FoodSecurityItems_Id_seq"', 1, false);
          BEN          postgres    false    313            �           0    0    ForestBeats_Id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('"BEN"."ForestBeats_Id_seq"', 1, false);
          BEN          postgres    false    297            �           0    0    ForestCircles_Id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('"BEN"."ForestCircles_Id_seq"', 1, false);
          BEN          postgres    false    247            �           0    0    ForestDivisions_Id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('"BEN"."ForestDivisions_Id_seq"', 1, false);
          BEN          postgres    false    287            �           0    0    ForestFcvVcfs_Id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('"BEN"."ForestFcvVcfs_Id_seq"', 1, false);
          BEN          postgres    false    299            �           0    0    ForestRanges_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('"BEN"."ForestRanges_Id_seq"', 1, false);
          BEN          postgres    false    293            �           0    0 '   GrossMarginIncomeAndCostStatuses_Id_seq    SEQUENCE SET     W   SELECT pg_catalog.setval('"BEN"."GrossMarginIncomeAndCostStatuses_Id_seq"', 1, false);
          BEN          postgres    false    315            �           0    0    HouseholdMembers_Id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('"BEN"."HouseholdMembers_Id_seq"', 1, false);
          BEN          postgres    false    317            �           0    0    ImmovableAssetTypes_Id_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('"BEN"."ImmovableAssetTypes_Id_seq"', 1, false);
          BEN          postgres    false    249            �           0    0    ImmovableAssets_Id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('"BEN"."ImmovableAssets_Id_seq"', 1, false);
          BEN          postgres    false    319            �           0    0    LandOccupancies_Id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('"BEN"."LandOccupancies_Id_seq"', 1, false);
          BEN          postgres    false    321            �           0    0    LiveStockTypes_Id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('"BEN"."LiveStockTypes_Id_seq"', 1, false);
          BEN          postgres    false    251            �           0    0    LiveStocks_Id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('"BEN"."LiveStocks_Id_seq"', 1, false);
          BEN          postgres    false    323            �           0    0    ManualIncomeSourceTypes_Id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('"BEN"."ManualIncomeSourceTypes_Id_seq"', 1, false);
          BEN          postgres    false    253            �           0    0    ManualPhysicalWorks_Id_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('"BEN"."ManualPhysicalWorks_Id_seq"', 1, false);
          BEN          postgres    false    325            �           0    0    NaturalIncomeSourceTypes_Id_seq    SEQUENCE SET     O   SELECT pg_catalog.setval('"BEN"."NaturalIncomeSourceTypes_Id_seq"', 1, false);
          BEN          postgres    false    255            �           0    0 ,   NaturalResourcesIncomeAndCostStatuses_Id_seq    SEQUENCE SET     \   SELECT pg_catalog.setval('"BEN"."NaturalResourcesIncomeAndCostStatuses_Id_seq"', 1, false);
          BEN          postgres    false    327            �           0    0    Ngos_Id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('"BEN"."Ngos_Id_seq"', 1, false);
          BEN          postgres    false    257            �           0    0    Occupations_Id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('"BEN"."Occupations_Id_seq"', 1, false);
          BEN          postgres    false    259            �           0    0    OtherCommitteeMembers_Id_seq    SEQUENCE SET     L   SELECT pg_catalog.setval('"BEN"."OtherCommitteeMembers_Id_seq"', 1, false);
          BEN          postgres    false    369            �           0    0    OtherIncomeSourceTypes_Id_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('"BEN"."OtherIncomeSourceTypes_Id_seq"', 1, false);
          BEN          postgres    false    261            �           0    0    OtherIncomeSources_Id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('"BEN"."OtherIncomeSources_Id_seq"', 1, false);
          BEN          postgres    false    329            �           0    0 %   RelationWithHeadHouseHoldTypes_Id_seq    SEQUENCE SET     U   SELECT pg_catalog.setval('"BEN"."RelationWithHeadHouseHoldTypes_Id_seq"', 1, false);
          BEN          postgres    false    263            �           0    0    SafetyNets_Id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('"BEN"."SafetyNets_Id_seq"', 1, false);
          BEN          postgres    false    265            �           0    0    SurveyDocument_Id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('"BEN"."SurveyDocument_Id_seq"', 1, false);
          BEN          postgres    false    423            �           0    0    SurveyIncidents_Id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('"BEN"."SurveyIncidents_Id_seq"', 1, false);
          BEN          postgres    false    485            �           0    0    Surveys_Id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('"BEN"."Surveys_Id_seq"', 1, false);
          BEN          postgres    false    301            �           0    0    Trade_Id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('"BEN"."Trade_Id_seq"', 1, false);
          BEN          postgres    false    373            �           0    0 "   VulnerabilitySituationTypes_Id_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('"BEN"."VulnerabilitySituationTypes_Id_seq"', 1, false);
          BEN          postgres    false    267            �           0    0    VulnerabilitySituations_Id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('"BEN"."VulnerabilitySituations_Id_seq"', 1, false);
          BEN          postgres    false    331            �           0    0    SavingsAccount_Id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('"BSA"."SavingsAccount_Id_seq"', 1, false);
          BSA          postgres    false    397            �           0    0    SavingsAmountInformation_Id_seq    SEQUENCE SET     O   SELECT pg_catalog.setval('"BSA"."SavingsAmountInformation_Id_seq"', 1, false);
          BSA          postgres    false    399            �           0    0     WithdrawAmountInformation_Id_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('"BSA"."WithdrawAmountInformation_Id_seq"', 1, false);
          BSA          postgres    false    401            �           0    0    CommunityTrainingFiles_Id_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('"Capacity"."CommunityTrainingFiles_Id_seq"', 1, false);
          Capacity          postgres    false    353            �           0    0    CommunityTrainingMembers_Id_seq    SEQUENCE SET     T   SELECT pg_catalog.setval('"Capacity"."CommunityTrainingMembers_Id_seq"', 1, false);
          Capacity          postgres    false    341            �           0    0 (   CommunityTrainingParticipentsMaps_Id_seq    SEQUENCE SET     ]   SELECT pg_catalog.setval('"Capacity"."CommunityTrainingParticipentsMaps_Id_seq"', 1, false);
          Capacity          postgres    false    349            �           0    0    CommunityTrainingTypes_Id_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('"Capacity"."CommunityTrainingTypes_Id_seq"', 1, false);
          Capacity          postgres    false    343            �           0    0    CommunityTrainings_Id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('"Capacity"."CommunityTrainings_Id_seq"', 1, false);
          Capacity          postgres    false    351            �           0    0     DepartmentalTrainingFiles_Id_seq    SEQUENCE SET     U   SELECT pg_catalog.setval('"Capacity"."DepartmentalTrainingFiles_Id_seq"', 1, false);
          Capacity          postgres    false    361            �           0    0 "   DepartmentalTrainingMembers_Id_seq    SEQUENCE SET     W   SELECT pg_catalog.setval('"Capacity"."DepartmentalTrainingMembers_Id_seq"', 1, false);
          Capacity          postgres    false    355            �           0    0 +   DepartmentalTrainingParticipentsMaps_Id_seq    SEQUENCE SET     `   SELECT pg_catalog.setval('"Capacity"."DepartmentalTrainingParticipentsMaps_Id_seq"', 1, false);
          Capacity          postgres    false    363            �           0    0     DepartmentalTrainingTypes_Id_seq    SEQUENCE SET     U   SELECT pg_catalog.setval('"Capacity"."DepartmentalTrainingTypes_Id_seq"', 1, false);
          Capacity          postgres    false    357            �           0    0    DepartmentalTrainings_Id_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('"Capacity"."DepartmentalTrainings_Id_seq"', 1, false);
          Capacity          postgres    false    359            �           0    0    EventTypes_Id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('"Capacity"."EventTypes_Id_seq"', 1, false);
          Capacity          postgres    false    345            �           0    0    MeetingParticipantsMaps_Id_seq    SEQUENCE SET     S   SELECT pg_catalog.setval('"Capacity"."MeetingParticipantsMaps_Id_seq"', 1, false);
          Capacity          postgres    false    383            �           0    0    TrainingOrganizers_Id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('"Capacity"."TrainingOrganizers_Id_seq"', 1, false);
          Capacity          postgres    false    347            �           0    0    Category_Id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('"GS"."Category_Id_seq"', 1, false);
          GS          postgres    false    269            �           0    0    Color_Id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('"GS"."Color_Id_seq"', 1, false);
          GS          postgres    false    271            �           0    0    District_Id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('"GS"."District_Id_seq"', 1, false);
          GS          postgres    false    289            �           0    0    Division_Id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('"GS"."Division_Id_seq"', 1, false);
          GS          postgres    false    273            �           0    0    FinancialYears_Id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('"GS"."FinancialYears_Id_seq"', 1, false);
          GS          postgres    false    387            �           0    0    SubCommitteeDesignations_Id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('"GS"."SubCommitteeDesignations_Id_seq"', 1, false);
          GS          postgres    false    375            �           0    0    Union_Id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('"GS"."Union_Id_seq"', 1, false);
          GS          postgres    false    339            �           0    0    Upazilla_Id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('"GS"."Upazilla_Id_seq"', 1, false);
          GS          postgres    false    295            �           0    0 "   InternalLoanInformationFile_Id_seq    SEQUENCE SET     [   SELECT pg_catalog.setval('"InternalLoan"."InternalLoanInformationFile_Id_seq"', 1, false);
          InternalLoan          postgres    false    479            �           0    0    InternalLoanInformations_Id_seq    SEQUENCE SET     X   SELECT pg_catalog.setval('"InternalLoan"."InternalLoanInformations_Id_seq"', 1, false);
          InternalLoan          postgres    false    425            �           0    0    RepaymentInternalLoans_Id_seq    SEQUENCE SET     V   SELECT pg_catalog.setval('"InternalLoan"."RepaymentInternalLoans_Id_seq"', 1, false);
          InternalLoan          postgres    false    429            �           0    0    LabourDatabaseFiles_Id_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('"Labour"."LabourDatabaseFiles_Id_seq"', 1, false);
          Labour          postgres    false    435            �           0    0    LabourDatabases_Id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('"Labour"."LabourDatabases_Id_seq"', 1, false);
          Labour          postgres    false    433            �           0    0    LabourWorks_Id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('"Labour"."LabourWorks_Id_seq"', 1, false);
          Labour          postgres    false    491            �           0    0    OtherLabourMembers_Id_seq    SEQUENCE SET     L   SELECT pg_catalog.setval('"Labour"."OtherLabourMembers_Id_seq"', 1, false);
          Labour          postgres    false    431            �           0    0    Marketings_Id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('"Marketing"."Marketings_Id_seq"', 1, false);
       	   Marketing          postgres    false    337            �           0    0    MeetingFiles_Id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('"Meeting"."MeetingFiles_Id_seq"', 1, false);
          Meeting          postgres    false    385            �           0    0    MeetingMembers_Id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('"Meeting"."MeetingMembers_Id_seq"', 1, false);
          Meeting          postgres    false    377            �           0    0    MeetingTypes_Id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('"Meeting"."MeetingTypes_Id_seq"', 1, false);
          Meeting          postgres    false    379            �           0    0    Meetings_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('"Meeting"."Meetings_Id_seq"', 1, false);
          Meeting          postgres    false    381            �           0    0    OtherPatrollingMember_Id_seq    SEQUENCE SET     S   SELECT pg_catalog.setval('"Patrolling"."OtherPatrollingMember_Id_seq"', 1, false);
       
   Patrolling          postgres    false    415                        0    0 #   PatrollingPaymentInformetion_Id_seq    SEQUENCE SET     Z   SELECT pg_catalog.setval('"Patrolling"."PatrollingPaymentInformetion_Id_seq"', 1, false);
       
   Patrolling          postgres    false    413                       0    0 $   PatrollingScheduleInformetion_Id_seq    SEQUENCE SET     [   SELECT pg_catalog.setval('"Patrolling"."PatrollingScheduleInformetion_Id_seq"', 1, false);
       
   Patrolling          postgres    false    411                       0    0     PatrollingSchedulingFiles_Id_seq    SEQUENCE SET     a   SELECT pg_catalog.setval('"PatrollingScheduling"."PatrollingSchedulingFiles_Id_seq"', 1, false);
          PatrollingScheduling          postgres    false    445                       0    0 "   PatrollingSchedulingMembers_Id_seq    SEQUENCE SET     c   SELECT pg_catalog.setval('"PatrollingScheduling"."PatrollingSchedulingMembers_Id_seq"', 1, false);
          PatrollingScheduling          postgres    false    441                       0    0 +   PatrollingSchedulingParticipentsMaps_Id_seq    SEQUENCE SET     l   SELECT pg_catalog.setval('"PatrollingScheduling"."PatrollingSchedulingParticipentsMaps_Id_seq"', 1, false);
          PatrollingScheduling          postgres    false    447                       0    0    PatrollingSchedulings_Id_seq    SEQUENCE SET     ]   SELECT pg_catalog.setval('"PatrollingScheduling"."PatrollingSchedulings_Id_seq"', 1, false);
          PatrollingScheduling          postgres    false    443                       0    0    BankDeposits_Id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('"SocialForestry"."BankDeposits_Id_seq"', 1, false);
          SocialForestry          postgres    false    473                       0    0    CuttingPlantations_Id_seq    SEQUENCE SET     T   SELECT pg_catalog.setval('"SocialForestry"."CuttingPlantations_Id_seq"', 1, false);
          SocialForestry          postgres    false    461                       0    0 )   DistributedOrRevenueDepositAmounts_Id_seq    SEQUENCE SET     d   SELECT pg_catalog.setval('"SocialForestry"."DistributedOrRevenueDepositAmounts_Id_seq"', 1, false);
          SocialForestry          postgres    false    475            	           0    0 #   NewRaisedPlantationUnionMaps_Id_seq    SEQUENCE SET     ^   SELECT pg_catalog.setval('"SocialForestry"."NewRaisedPlantationUnionMaps_Id_seq"', 1, false);
          SocialForestry          postgres    false    463            
           0    0 &   NewRaisedPlantationUpazillaMaps_Id_seq    SEQUENCE SET     a   SELECT pg_catalog.setval('"SocialForestry"."NewRaisedPlantationUpazillaMaps_Id_seq"', 1, false);
          SocialForestry          postgres    false    465                       0    0    NewRaisedPlantations_Id_seq    SEQUENCE SET     V   SELECT pg_catalog.setval('"SocialForestry"."NewRaisedPlantations_Id_seq"', 1, false);
          SocialForestry          postgres    false    459                       0    0    PlantationProjects_Id_seq    SEQUENCE SET     T   SELECT pg_catalog.setval('"SocialForestry"."PlantationProjects_Id_seq"', 1, false);
          SocialForestry          postgres    false    451                       0    0 '   PlantationTypeRevenuePercentages_Id_seq    SEQUENCE SET     b   SELECT pg_catalog.setval('"SocialForestry"."PlantationTypeRevenuePercentages_Id_seq"', 1, false);
          SocialForestry          postgres    false    455                       0    0    PlantationTypes_Id_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('"SocialForestry"."PlantationTypes_Id_seq"', 1, false);
          SocialForestry          postgres    false    453                       0    0    Reforestations_Id_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('"SocialForestry"."Reforestations_Id_seq"', 1, false);
          SocialForestry          postgres    false    467                       0    0    RevenueDistributions_Id_seq    SEQUENCE SET     V   SELECT pg_catalog.setval('"SocialForestry"."RevenueDistributions_Id_seq"', 1, false);
          SocialForestry          postgres    false    471                       0    0    Revenues_Id_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('"SocialForestry"."Revenues_Id_seq"', 1, false);
          SocialForestry          postgres    false    469                       0    0    StripTypes_Id_seq    SEQUENCE SET     L   SELECT pg_catalog.setval('"SocialForestry"."StripTypes_Id_seq"', 1, false);
          SocialForestry          postgres    false    457                       0    0    Students_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('"Student"."Students_Id_seq"', 1, false);
          Student          postgres    false    371                       0    0    AccessMapper_Id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('"System"."AccessMapper_Id_seq"', 1, false);
          System          postgres    false    277                       0    0    Accesslist_Id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('"System"."Accesslist_Id_seq"', 1, false);
          System          postgres    false    275                       0    0    Module_Id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('"System"."Module_Id_seq"', 1, false);
          System          postgres    false    279                       0    0    PmsGroup_Id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('"System"."PmsGroup_Id_seq"', 1, false);
          System          postgres    false    281                       0    0    UserGroup_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('"System"."UserGroup_Id_seq"', 1, false);
          System          postgres    false    283                       0    0    UserRoles_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('"System"."UserRoles_Id_seq"', 1, false);
          System          postgres    false    285                       0    0    User_Id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('"System"."User_Id_seq"', 1, false);
          System          postgres    false    291                       0    0    ExpenseDetailsForCDFs_Id_seq    SEQUENCE SET     T   SELECT pg_catalog.setval('"TRANSACTION"."ExpenseDetailsForCDFs_Id_seq"', 1, false);
          TRANSACTION          postgres    false    483                       0    0    FundTypes_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('"TRANSACTION"."FundTypes_Id_seq"', 1, false);
          TRANSACTION          postgres    false    389                       0    0    TransactionDetails_Id_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('"TRANSACTION"."TransactionDetails_Id_seq"', 1, false);
          TRANSACTION          postgres    false    393                       0    0    TransactionExpenses_Id_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('"TRANSACTION"."TransactionExpenses_Id_seq"', 1, false);
          TRANSACTION          postgres    false    395                       0    0    Transactions_Id_seq    SEQUENCE SET     K   SELECT pg_catalog.setval('"TRANSACTION"."Transactions_Id_seq"', 1, false);
          TRANSACTION          postgres    false    391            �           2606    35155 ,   AIGBasicInformations PK_AIGBasicInformations 
   CONSTRAINT     o   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "PK_AIGBasicInformations" PRIMARY KEY ("Id");
 Y   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "PK_AIGBasicInformations";
       AIG            postgres    false    404            �           2606    35229 4   FirstSixtyPercentageLDFs PK_FirstSixtyPercentageLDFs 
   CONSTRAINT     w   ALTER TABLE ONLY "AIG"."FirstSixtyPercentageLDFs"
    ADD CONSTRAINT "PK_FirstSixtyPercentageLDFs" PRIMARY KEY ("Id");
 a   ALTER TABLE ONLY "AIG"."FirstSixtyPercentageLDFs" DROP CONSTRAINT "PK_FirstSixtyPercentageLDFs";
       AIG            postgres    false    406            :           2606    36213 2   GroupLDFInfoFormMembers PK_GroupLDFInfoFormMembers 
   CONSTRAINT     u   ALTER TABLE ONLY "AIG"."GroupLDFInfoFormMembers"
    ADD CONSTRAINT "PK_GroupLDFInfoFormMembers" PRIMARY KEY ("Id");
 _   ALTER TABLE ONLY "AIG"."GroupLDFInfoFormMembers" DROP CONSTRAINT "PK_GroupLDFInfoFormMembers";
       AIG            postgres    false    440            6           2606    36126 &   GroupLDFInfoForms PK_GroupLDFInfoForms 
   CONSTRAINT     i   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms"
    ADD CONSTRAINT "PK_GroupLDFInfoForms" PRIMARY KEY ("Id");
 S   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms" DROP CONSTRAINT "PK_GroupLDFInfoForms";
       AIG            postgres    false    438            �           2606    35723 6   IndividualGroupFormSetups PK_IndividualGroupFormSetups 
   CONSTRAINT     y   ALTER TABLE ONLY "AIG"."IndividualGroupFormSetups"
    ADD CONSTRAINT "PK_IndividualGroupFormSetups" PRIMARY KEY ("Id");
 c   ALTER TABLE ONLY "AIG"."IndividualGroupFormSetups" DROP CONSTRAINT "PK_IndividualGroupFormSetups";
       AIG            postgres    false    422            �           2606    35600 0   IndividualLDFInfoForms PK_IndividualLDFInfoForms 
   CONSTRAINT     s   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms"
    ADD CONSTRAINT "PK_IndividualLDFInfoForms" PRIMARY KEY ("Id");
 ]   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms" DROP CONSTRAINT "PK_IndividualLDFInfoForms";
       AIG            postgres    false    420            �           2606    35490    LDFProgresss PK_LDFProgresss 
   CONSTRAINT     _   ALTER TABLE ONLY "AIG"."LDFProgresss"
    ADD CONSTRAINT "PK_LDFProgresss" PRIMARY KEY ("Id");
 I   ALTER TABLE ONLY "AIG"."LDFProgresss" DROP CONSTRAINT "PK_LDFProgresss";
       AIG            postgres    false    418            �           2606    37124 &   RepaymentLDFFiles PK_RepaymentLDFFiles 
   CONSTRAINT     i   ALTER TABLE ONLY "AIG"."RepaymentLDFFiles"
    ADD CONSTRAINT "PK_RepaymentLDFFiles" PRIMARY KEY ("Id");
 S   ALTER TABLE ONLY "AIG"."RepaymentLDFFiles" DROP CONSTRAINT "PK_RepaymentLDFFiles";
       AIG            postgres    false    482            	           2606    35882 .   RepaymentLDFHistories PK_RepaymentLDFHistories 
   CONSTRAINT     q   ALTER TABLE ONLY "AIG"."RepaymentLDFHistories"
    ADD CONSTRAINT "PK_RepaymentLDFHistories" PRIMARY KEY ("Id");
 [   ALTER TABLE ONLY "AIG"."RepaymentLDFHistories" DROP CONSTRAINT "PK_RepaymentLDFHistories";
       AIG            postgres    false    428            �           2606    35261    RepaymentLDFs PK_RepaymentLDFs 
   CONSTRAINT     a   ALTER TABLE ONLY "AIG"."RepaymentLDFs"
    ADD CONSTRAINT "PK_RepaymentLDFs" PRIMARY KEY ("Id");
 K   ALTER TABLE ONLY "AIG"."RepaymentLDFs" DROP CONSTRAINT "PK_RepaymentLDFs";
       AIG            postgres    false    410            �           2606    35245 8   SecondFourtyPercentageLDFs PK_SecondFourtyPercentageLDFs 
   CONSTRAINT     {   ALTER TABLE ONLY "AIG"."SecondFourtyPercentageLDFs"
    ADD CONSTRAINT "PK_SecondFourtyPercentageLDFs" PRIMARY KEY ("Id");
 e   ALTER TABLE ONLY "AIG"."SecondFourtyPercentageLDFs" DROP CONSTRAINT "PK_SecondFourtyPercentageLDFs";
       AIG            postgres    false    408            �           2606    33572 :   AnnualHouseholdExpenditures PK_AnnualHouseholdExpenditures 
   CONSTRAINT     }   ALTER TABLE ONLY "BEN"."AnnualHouseholdExpenditures"
    ADD CONSTRAINT "PK_AnnualHouseholdExpenditures" PRIMARY KEY ("Id");
 g   ALTER TABLE ONLY "BEN"."AnnualHouseholdExpenditures" DROP CONSTRAINT "PK_AnnualHouseholdExpenditures";
       BEN            postgres    false    304            [           2606    33238    AssetTypes PK_AssetTypes 
   CONSTRAINT     [   ALTER TABLE ONLY "BEN"."AssetTypes"
    ADD CONSTRAINT "PK_AssetTypes" PRIMARY KEY ("Id");
 E   ALTER TABLE ONLY "BEN"."AssetTypes" DROP CONSTRAINT "PK_AssetTypes";
       BEN            postgres    false    232            �           2606    33588    Assets PK_Assets 
   CONSTRAINT     S   ALTER TABLE ONLY "BEN"."Assets"
    ADD CONSTRAINT "PK_Assets" PRIMARY KEY ("Id");
 =   ALTER TABLE ONLY "BEN"."Assets" DROP CONSTRAINT "PK_Assets";
       BEN            postgres    false    306                       2606    34002 H   BFDAssociationHouseholdMembersMaps PK_BFDAssociationHouseholdMembersMaps 
   CONSTRAINT     �   ALTER TABLE ONLY "BEN"."BFDAssociationHouseholdMembersMaps"
    ADD CONSTRAINT "PK_BFDAssociationHouseholdMembersMaps" PRIMARY KEY ("Id");
 u   ALTER TABLE ONLY "BEN"."BFDAssociationHouseholdMembersMaps" DROP CONSTRAINT "PK_BFDAssociationHouseholdMembersMaps";
       BEN            postgres    false    333            ]           2606    33244 "   BFDAssociations PK_BFDAssociations 
   CONSTRAINT     e   ALTER TABLE ONLY "BEN"."BFDAssociations"
    ADD CONSTRAINT "PK_BFDAssociations" PRIMARY KEY ("Id");
 O   ALTER TABLE ONLY "BEN"."BFDAssociations" DROP CONSTRAINT "PK_BFDAssociations";
       BEN            postgres    false    234            _           2606    33250 6   BusinessIncomeSourceTypes PK_BusinessIncomeSourceTypes 
   CONSTRAINT     y   ALTER TABLE ONLY "BEN"."BusinessIncomeSourceTypes"
    ADD CONSTRAINT "PK_BusinessIncomeSourceTypes" PRIMARY KEY ("Id");
 c   ALTER TABLE ONLY "BEN"."BusinessIncomeSourceTypes" DROP CONSTRAINT "PK_BusinessIncomeSourceTypes";
       BEN            postgres    false    236            �           2606    33604    Businesss PK_Businesss 
   CONSTRAINT     Y   ALTER TABLE ONLY "BEN"."Businesss"
    ADD CONSTRAINT "PK_Businesss" PRIMARY KEY ("Id");
 C   ALTER TABLE ONLY "BEN"."Businesss" DROP CONSTRAINT "PK_Businesss";
       BEN            postgres    false    308            �           2606    37077    CipFiles PK_CipFiles 
   CONSTRAINT     W   ALTER TABLE ONLY "BEN"."CipFiles"
    ADD CONSTRAINT "PK_CipFiles" PRIMARY KEY ("Id");
 A   ALTER TABLE ONLY "BEN"."CipFiles" DROP CONSTRAINT "PK_CipFiles";
       BEN            postgres    false    478            ]           2606    36750    Cips PK_Cips 
   CONSTRAINT     O   ALTER TABLE ONLY "BEN"."Cips"
    ADD CONSTRAINT "PK_Cips" PRIMARY KEY ("Id");
 9   ALTER TABLE ONLY "BEN"."Cips" DROP CONSTRAINT "PK_Cips";
       BEN            postgres    false    450            �           2606    37231 *   CommitteeManagement PK_CommitteeManagement 
   CONSTRAINT     m   ALTER TABLE ONLY "BEN"."CommitteeManagement"
    ADD CONSTRAINT "PK_CommitteeManagement" PRIMARY KEY ("Id");
 W   ALTER TABLE ONLY "BEN"."CommitteeManagement" DROP CONSTRAINT "PK_CommitteeManagement";
       BEN            postgres    false    488            �           2606    37284 6   CommitteeManagementMember PK_CommitteeManagementMember 
   CONSTRAINT     y   ALTER TABLE ONLY "BEN"."CommitteeManagementMember"
    ADD CONSTRAINT "PK_CommitteeManagementMember" PRIMARY KEY ("Id");
 c   ALTER TABLE ONLY "BEN"."CommitteeManagementMember" DROP CONSTRAINT "PK_CommitteeManagementMember";
       BEN            postgres    false    490            
           2606    34000 H   DisabilityTypeHouseholdMembersMaps PK_DisabilityTypeHouseholdMembersMaps 
   CONSTRAINT     �   ALTER TABLE ONLY "BEN"."DisabilityTypeHouseholdMembersMaps"
    ADD CONSTRAINT "PK_DisabilityTypeHouseholdMembersMaps" PRIMARY KEY ("Id");
 u   ALTER TABLE ONLY "BEN"."DisabilityTypeHouseholdMembersMaps" DROP CONSTRAINT "PK_DisabilityTypeHouseholdMembersMaps";
       BEN            postgres    false    334            a           2606    33256 "   DisabilityTypes PK_DisabilityTypes 
   CONSTRAINT     e   ALTER TABLE ONLY "BEN"."DisabilityTypes"
    ADD CONSTRAINT "PK_DisabilityTypes" PRIMARY KEY ("Id");
 O   ALTER TABLE ONLY "BEN"."DisabilityTypes" DROP CONSTRAINT "PK_DisabilityTypes";
       BEN            postgres    false    238            c           2606    33262    EnergyTypes PK_EnergyTypes 
   CONSTRAINT     ]   ALTER TABLE ONLY "BEN"."EnergyTypes"
    ADD CONSTRAINT "PK_EnergyTypes" PRIMARY KEY ("Id");
 G   ALTER TABLE ONLY "BEN"."EnergyTypes" DROP CONSTRAINT "PK_EnergyTypes";
       BEN            postgres    false    240            �           2606    33620    EnergyUses PK_EnergyUses 
   CONSTRAINT     [   ALTER TABLE ONLY "BEN"."EnergyUses"
    ADD CONSTRAINT "PK_EnergyUses" PRIMARY KEY ("Id");
 E   ALTER TABLE ONLY "BEN"."EnergyUses" DROP CONSTRAINT "PK_EnergyUses";
       BEN            postgres    false    310            e           2606    33268    Ethnicitys PK_Ethnicitys 
   CONSTRAINT     [   ALTER TABLE ONLY "BEN"."Ethnicitys"
    ADD CONSTRAINT "PK_Ethnicitys" PRIMARY KEY ("Id");
 E   ALTER TABLE ONLY "BEN"."Ethnicitys" DROP CONSTRAINT "PK_Ethnicitys";
       BEN            postgres    false    242            \           2606    34336 (   ExecutiveCommittee PK_ExecutiveCommittee 
   CONSTRAINT     k   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "PK_ExecutiveCommittee" PRIMARY KEY ("Id");
 U   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "PK_ExecutiveCommittee";
       BEN            postgres    false    368            �           2606    33636     ExistingSkills PK_ExistingSkills 
   CONSTRAINT     c   ALTER TABLE ONLY "BEN"."ExistingSkills"
    ADD CONSTRAINT "PK_ExistingSkills" PRIMARY KEY ("Id");
 M   ALTER TABLE ONLY "BEN"."ExistingSkills" DROP CONSTRAINT "PK_ExistingSkills";
       BEN            postgres    false    312            g           2606    33274 $   ExpenditureTypes PK_ExpenditureTypes 
   CONSTRAINT     g   ALTER TABLE ONLY "BEN"."ExpenditureTypes"
    ADD CONSTRAINT "PK_ExpenditureTypes" PRIMARY KEY ("Id");
 Q   ALTER TABLE ONLY "BEN"."ExpenditureTypes" DROP CONSTRAINT "PK_ExpenditureTypes";
       BEN            postgres    false    244            L           2606    34351 :   FcvExecutiveCommitteeMember PK_FcvExecutiveCommitteeMember 
   CONSTRAINT     }   ALTER TABLE ONLY "BEN"."FcvExecutiveCommitteeMember"
    ADD CONSTRAINT "PK_FcvExecutiveCommitteeMember" PRIMARY KEY ("Id");
 g   ALTER TABLE ONLY "BEN"."FcvExecutiveCommitteeMember" DROP CONSTRAINT "PK_FcvExecutiveCommitteeMember";
       BEN            postgres    false    366            i           2606    33280    FoodItems PK_FoodItems 
   CONSTRAINT     Y   ALTER TABLE ONLY "BEN"."FoodItems"
    ADD CONSTRAINT "PK_FoodItems" PRIMARY KEY ("Id");
 C   ALTER TABLE ONLY "BEN"."FoodItems" DROP CONSTRAINT "PK_FoodItems";
       BEN            postgres    false    246            �           2606    33647 &   FoodSecurityItems PK_FoodSecurityItems 
   CONSTRAINT     i   ALTER TABLE ONLY "BEN"."FoodSecurityItems"
    ADD CONSTRAINT "PK_FoodSecurityItems" PRIMARY KEY ("Id");
 S   ALTER TABLE ONLY "BEN"."FoodSecurityItems" DROP CONSTRAINT "PK_FoodSecurityItems";
       BEN            postgres    false    314            �           2606    33482    ForestBeats PK_ForestBeats 
   CONSTRAINT     ]   ALTER TABLE ONLY "BEN"."ForestBeats"
    ADD CONSTRAINT "PK_ForestBeats" PRIMARY KEY ("Id");
 G   ALTER TABLE ONLY "BEN"."ForestBeats" DROP CONSTRAINT "PK_ForestBeats";
       BEN            postgres    false    298            k           2606    33286    ForestCircles PK_ForestCircles 
   CONSTRAINT     a   ALTER TABLE ONLY "BEN"."ForestCircles"
    ADD CONSTRAINT "PK_ForestCircles" PRIMARY KEY ("Id");
 K   ALTER TABLE ONLY "BEN"."ForestCircles" DROP CONSTRAINT "PK_ForestCircles";
       BEN            postgres    false    248            �           2606    33410 "   ForestDivisions PK_ForestDivisions 
   CONSTRAINT     e   ALTER TABLE ONLY "BEN"."ForestDivisions"
    ADD CONSTRAINT "PK_ForestDivisions" PRIMARY KEY ("Id");
 O   ALTER TABLE ONLY "BEN"."ForestDivisions" DROP CONSTRAINT "PK_ForestDivisions";
       BEN            postgres    false    288            �           2606    33493    ForestFcvVcfs PK_ForestFcvVcfs 
   CONSTRAINT     a   ALTER TABLE ONLY "BEN"."ForestFcvVcfs"
    ADD CONSTRAINT "PK_ForestFcvVcfs" PRIMARY KEY ("Id");
 K   ALTER TABLE ONLY "BEN"."ForestFcvVcfs" DROP CONSTRAINT "PK_ForestFcvVcfs";
       BEN            postgres    false    300            �           2606    33460    ForestRanges PK_ForestRanges 
   CONSTRAINT     _   ALTER TABLE ONLY "BEN"."ForestRanges"
    ADD CONSTRAINT "PK_ForestRanges" PRIMARY KEY ("Id");
 I   ALTER TABLE ONLY "BEN"."ForestRanges" DROP CONSTRAINT "PK_ForestRanges";
       BEN            postgres    false    294            �           2606    33663 D   GrossMarginIncomeAndCostStatuses PK_GrossMarginIncomeAndCostStatuses 
   CONSTRAINT     �   ALTER TABLE ONLY "BEN"."GrossMarginIncomeAndCostStatuses"
    ADD CONSTRAINT "PK_GrossMarginIncomeAndCostStatuses" PRIMARY KEY ("Id");
 q   ALTER TABLE ONLY "BEN"."GrossMarginIncomeAndCostStatuses" DROP CONSTRAINT "PK_GrossMarginIncomeAndCostStatuses";
       BEN            postgres    false    316            �           2606    33676 $   HouseholdMembers PK_HouseholdMembers 
   CONSTRAINT     g   ALTER TABLE ONLY "BEN"."HouseholdMembers"
    ADD CONSTRAINT "PK_HouseholdMembers" PRIMARY KEY ("Id");
 Q   ALTER TABLE ONLY "BEN"."HouseholdMembers" DROP CONSTRAINT "PK_HouseholdMembers";
       BEN            postgres    false    318            m           2606    33292 *   ImmovableAssetTypes PK_ImmovableAssetTypes 
   CONSTRAINT     m   ALTER TABLE ONLY "BEN"."ImmovableAssetTypes"
    ADD CONSTRAINT "PK_ImmovableAssetTypes" PRIMARY KEY ("Id");
 W   ALTER TABLE ONLY "BEN"."ImmovableAssetTypes" DROP CONSTRAINT "PK_ImmovableAssetTypes";
       BEN            postgres    false    250            �           2606    33707 "   ImmovableAssets PK_ImmovableAssets 
   CONSTRAINT     e   ALTER TABLE ONLY "BEN"."ImmovableAssets"
    ADD CONSTRAINT "PK_ImmovableAssets" PRIMARY KEY ("Id");
 O   ALTER TABLE ONLY "BEN"."ImmovableAssets" DROP CONSTRAINT "PK_ImmovableAssets";
       BEN            postgres    false    320            �           2606    33723 "   LandOccupancies PK_LandOccupancies 
   CONSTRAINT     e   ALTER TABLE ONLY "BEN"."LandOccupancies"
    ADD CONSTRAINT "PK_LandOccupancies" PRIMARY KEY ("Id");
 O   ALTER TABLE ONLY "BEN"."LandOccupancies" DROP CONSTRAINT "PK_LandOccupancies";
       BEN            postgres    false    322            o           2606    33298     LiveStockTypes PK_LiveStockTypes 
   CONSTRAINT     c   ALTER TABLE ONLY "BEN"."LiveStockTypes"
    ADD CONSTRAINT "PK_LiveStockTypes" PRIMARY KEY ("Id");
 M   ALTER TABLE ONLY "BEN"."LiveStockTypes" DROP CONSTRAINT "PK_LiveStockTypes";
       BEN            postgres    false    252            �           2606    33734    LiveStocks PK_LiveStocks 
   CONSTRAINT     [   ALTER TABLE ONLY "BEN"."LiveStocks"
    ADD CONSTRAINT "PK_LiveStocks" PRIMARY KEY ("Id");
 E   ALTER TABLE ONLY "BEN"."LiveStocks" DROP CONSTRAINT "PK_LiveStocks";
       BEN            postgres    false    324            q           2606    33304 2   ManualIncomeSourceTypes PK_ManualIncomeSourceTypes 
   CONSTRAINT     u   ALTER TABLE ONLY "BEN"."ManualIncomeSourceTypes"
    ADD CONSTRAINT "PK_ManualIncomeSourceTypes" PRIMARY KEY ("Id");
 _   ALTER TABLE ONLY "BEN"."ManualIncomeSourceTypes" DROP CONSTRAINT "PK_ManualIncomeSourceTypes";
       BEN            postgres    false    254            �           2606    33750 *   ManualPhysicalWorks PK_ManualPhysicalWorks 
   CONSTRAINT     m   ALTER TABLE ONLY "BEN"."ManualPhysicalWorks"
    ADD CONSTRAINT "PK_ManualPhysicalWorks" PRIMARY KEY ("Id");
 W   ALTER TABLE ONLY "BEN"."ManualPhysicalWorks" DROP CONSTRAINT "PK_ManualPhysicalWorks";
       BEN            postgres    false    326            s           2606    33310 4   NaturalIncomeSourceTypes PK_NaturalIncomeSourceTypes 
   CONSTRAINT     w   ALTER TABLE ONLY "BEN"."NaturalIncomeSourceTypes"
    ADD CONSTRAINT "PK_NaturalIncomeSourceTypes" PRIMARY KEY ("Id");
 a   ALTER TABLE ONLY "BEN"."NaturalIncomeSourceTypes" DROP CONSTRAINT "PK_NaturalIncomeSourceTypes";
       BEN            postgres    false    256            �           2606    33766 N   NaturalResourcesIncomeAndCostStatuses PK_NaturalResourcesIncomeAndCostStatuses 
   CONSTRAINT     �   ALTER TABLE ONLY "BEN"."NaturalResourcesIncomeAndCostStatuses"
    ADD CONSTRAINT "PK_NaturalResourcesIncomeAndCostStatuses" PRIMARY KEY ("Id");
 {   ALTER TABLE ONLY "BEN"."NaturalResourcesIncomeAndCostStatuses" DROP CONSTRAINT "PK_NaturalResourcesIncomeAndCostStatuses";
       BEN            postgres    false    328            u           2606    33316    Ngos PK_Ngos 
   CONSTRAINT     O   ALTER TABLE ONLY "BEN"."Ngos"
    ADD CONSTRAINT "PK_Ngos" PRIMARY KEY ("Id");
 9   ALTER TABLE ONLY "BEN"."Ngos" DROP CONSTRAINT "PK_Ngos";
       BEN            postgres    false    258            w           2606    33322    Occupations PK_Occupations 
   CONSTRAINT     ]   ALTER TABLE ONLY "BEN"."Occupations"
    ADD CONSTRAINT "PK_Occupations" PRIMARY KEY ("Id");
 G   ALTER TABLE ONLY "BEN"."Occupations" DROP CONSTRAINT "PK_Occupations";
       BEN            postgres    false    260            h           2606    34429 .   OtherCommitteeMembers PK_OtherCommitteeMembers 
   CONSTRAINT     q   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers"
    ADD CONSTRAINT "PK_OtherCommitteeMembers" PRIMARY KEY ("Id");
 [   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers" DROP CONSTRAINT "PK_OtherCommitteeMembers";
       BEN            postgres    false    370            y           2606    33328 0   OtherIncomeSourceTypes PK_OtherIncomeSourceTypes 
   CONSTRAINT     s   ALTER TABLE ONLY "BEN"."OtherIncomeSourceTypes"
    ADD CONSTRAINT "PK_OtherIncomeSourceTypes" PRIMARY KEY ("Id");
 ]   ALTER TABLE ONLY "BEN"."OtherIncomeSourceTypes" DROP CONSTRAINT "PK_OtherIncomeSourceTypes";
       BEN            postgres    false    262            �           2606    33782 (   OtherIncomeSources PK_OtherIncomeSources 
   CONSTRAINT     k   ALTER TABLE ONLY "BEN"."OtherIncomeSources"
    ADD CONSTRAINT "PK_OtherIncomeSources" PRIMARY KEY ("Id");
 U   ALTER TABLE ONLY "BEN"."OtherIncomeSources" DROP CONSTRAINT "PK_OtherIncomeSources";
       BEN            postgres    false    330            {           2606    33334 @   RelationWithHeadHouseHoldTypes PK_RelationWithHeadHouseHoldTypes 
   CONSTRAINT     �   ALTER TABLE ONLY "BEN"."RelationWithHeadHouseHoldTypes"
    ADD CONSTRAINT "PK_RelationWithHeadHouseHoldTypes" PRIMARY KEY ("Id");
 m   ALTER TABLE ONLY "BEN"."RelationWithHeadHouseHoldTypes" DROP CONSTRAINT "PK_RelationWithHeadHouseHoldTypes";
       BEN            postgres    false    264            }           2606    33340    SafetyNets PK_SafetyNets 
   CONSTRAINT     [   ALTER TABLE ONLY "BEN"."SafetyNets"
    ADD CONSTRAINT "PK_SafetyNets" PRIMARY KEY ("Id");
 E   ALTER TABLE ONLY "BEN"."SafetyNets" DROP CONSTRAINT "PK_SafetyNets";
       BEN            postgres    false    266            �           2606    35742 "   SurveyDocuments PK_SurveyDocuments 
   CONSTRAINT     e   ALTER TABLE ONLY "BEN"."SurveyDocuments"
    ADD CONSTRAINT "PK_SurveyDocuments" PRIMARY KEY ("Id");
 O   ALTER TABLE ONLY "BEN"."SurveyDocuments" DROP CONSTRAINT "PK_SurveyDocuments";
       BEN            postgres    false    424            �           2606    37171 "   SurveyIncidents PK_SurveyIncidents 
   CONSTRAINT     e   ALTER TABLE ONLY "BEN"."SurveyIncidents"
    ADD CONSTRAINT "PK_SurveyIncidents" PRIMARY KEY ("Id");
 O   ALTER TABLE ONLY "BEN"."SurveyIncidents" DROP CONSTRAINT "PK_SurveyIncidents";
       BEN            postgres    false    486            �           2606    33506    Surveys PK_Surveys 
   CONSTRAINT     U   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "PK_Surveys" PRIMARY KEY ("Id");
 ?   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "PK_Surveys";
       BEN            postgres    false    302            l           2606    34574    Trade PK_Trade 
   CONSTRAINT     Q   ALTER TABLE ONLY "BEN"."Trade"
    ADD CONSTRAINT "PK_Trade" PRIMARY KEY ("Id");
 ;   ALTER TABLE ONLY "BEN"."Trade" DROP CONSTRAINT "PK_Trade";
       BEN            postgres    false    374                       2606    33346 :   VulnerabilitySituationTypes PK_VulnerabilitySituationTypes 
   CONSTRAINT     }   ALTER TABLE ONLY "BEN"."VulnerabilitySituationTypes"
    ADD CONSTRAINT "PK_VulnerabilitySituationTypes" PRIMARY KEY ("Id");
 g   ALTER TABLE ONLY "BEN"."VulnerabilitySituationTypes" DROP CONSTRAINT "PK_VulnerabilitySituationTypes";
       BEN            postgres    false    268                       2606    33800 2   VulnerabilitySituations PK_VulnerabilitySituations 
   CONSTRAINT     u   ALTER TABLE ONLY "BEN"."VulnerabilitySituations"
    ADD CONSTRAINT "PK_VulnerabilitySituations" PRIMARY KEY ("Id");
 _   ALTER TABLE ONLY "BEN"."VulnerabilitySituations" DROP CONSTRAINT "PK_VulnerabilitySituations";
       BEN            postgres    false    332            �           2606    35065     SavingsAccount PK_SavingsAccount 
   CONSTRAINT     c   ALTER TABLE ONLY "BSA"."SavingsAccount"
    ADD CONSTRAINT "PK_SavingsAccount" PRIMARY KEY ("Id");
 M   ALTER TABLE ONLY "BSA"."SavingsAccount" DROP CONSTRAINT "PK_SavingsAccount";
       BSA            postgres    false    398            �           2606    35129 4   SavingsAmountInformation PK_SavingsAmountInformation 
   CONSTRAINT     w   ALTER TABLE ONLY "BSA"."SavingsAmountInformation"
    ADD CONSTRAINT "PK_SavingsAmountInformation" PRIMARY KEY ("Id");
 a   ALTER TABLE ONLY "BSA"."SavingsAmountInformation" DROP CONSTRAINT "PK_SavingsAmountInformation";
       BSA            postgres    false    400            �           2606    35142 6   WithdrawAmountInformation PK_WithdrawAmountInformation 
   CONSTRAINT     y   ALTER TABLE ONLY "BSA"."WithdrawAmountInformation"
    ADD CONSTRAINT "PK_WithdrawAmountInformation" PRIMARY KEY ("Id");
 c   ALTER TABLE ONLY "BSA"."WithdrawAmountInformation" DROP CONSTRAINT "PK_WithdrawAmountInformation";
       BSA            postgres    false    402            /           2606    34174 0   CommunityTrainingFiles PK_CommunityTrainingFiles 
   CONSTRAINT     x   ALTER TABLE ONLY "Capacity"."CommunityTrainingFiles"
    ADD CONSTRAINT "PK_CommunityTrainingFiles" PRIMARY KEY ("Id");
 b   ALTER TABLE ONLY "Capacity"."CommunityTrainingFiles" DROP CONSTRAINT "PK_CommunityTrainingFiles";
       Capacity            postgres    false    354                       2606    34049 4   CommunityTrainingMembers PK_CommunityTrainingMembers 
   CONSTRAINT     |   ALTER TABLE ONLY "Capacity"."CommunityTrainingMembers"
    ADD CONSTRAINT "PK_CommunityTrainingMembers" PRIMARY KEY ("Id");
 f   ALTER TABLE ONLY "Capacity"."CommunityTrainingMembers" DROP CONSTRAINT "PK_CommunityTrainingMembers";
       Capacity            postgres    false    342                       2606    34079 F   CommunityTrainingParticipentsMaps PK_CommunityTrainingParticipentsMaps 
   CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainingParticipentsMaps"
    ADD CONSTRAINT "PK_CommunityTrainingParticipentsMaps" PRIMARY KEY ("Id");
 x   ALTER TABLE ONLY "Capacity"."CommunityTrainingParticipentsMaps" DROP CONSTRAINT "PK_CommunityTrainingParticipentsMaps";
       Capacity            postgres    false    350                       2606    34057 0   CommunityTrainingTypes PK_CommunityTrainingTypes 
   CONSTRAINT     x   ALTER TABLE ONLY "Capacity"."CommunityTrainingTypes"
    ADD CONSTRAINT "PK_CommunityTrainingTypes" PRIMARY KEY ("Id");
 b   ALTER TABLE ONLY "Capacity"."CommunityTrainingTypes" DROP CONSTRAINT "PK_CommunityTrainingTypes";
       Capacity            postgres    false    344            ,           2606    34097 (   CommunityTrainings PK_CommunityTrainings 
   CONSTRAINT     p   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "PK_CommunityTrainings" PRIMARY KEY ("Id");
 Z   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "PK_CommunityTrainings";
       Capacity            postgres    false    352            E           2606    34266 6   DepartmentalTrainingFiles PK_DepartmentalTrainingFiles 
   CONSTRAINT     ~   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingFiles"
    ADD CONSTRAINT "PK_DepartmentalTrainingFiles" PRIMARY KEY ("Id");
 h   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingFiles" DROP CONSTRAINT "PK_DepartmentalTrainingFiles";
       Capacity            postgres    false    362            2           2606    34187 :   DepartmentalTrainingMembers PK_DepartmentalTrainingMembers 
   CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingMembers"
    ADD CONSTRAINT "PK_DepartmentalTrainingMembers" PRIMARY KEY ("Id");
 l   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingMembers" DROP CONSTRAINT "PK_DepartmentalTrainingMembers";
       Capacity            postgres    false    356            I           2606    34277 L   DepartmentalTrainingParticipentsMaps PK_DepartmentalTrainingParticipentsMaps 
   CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingParticipentsMaps"
    ADD CONSTRAINT "PK_DepartmentalTrainingParticipentsMaps" PRIMARY KEY ("Id");
 ~   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingParticipentsMaps" DROP CONSTRAINT "PK_DepartmentalTrainingParticipentsMaps";
       Capacity            postgres    false    364            4           2606    34195 6   DepartmentalTrainingTypes PK_DepartmentalTrainingTypes 
   CONSTRAINT     ~   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingTypes"
    ADD CONSTRAINT "PK_DepartmentalTrainingTypes" PRIMARY KEY ("Id");
 h   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingTypes" DROP CONSTRAINT "PK_DepartmentalTrainingTypes";
       Capacity            postgres    false    358            B           2606    34203 .   DepartmentalTrainings PK_DepartmentalTrainings 
   CONSTRAINT     v   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "PK_DepartmentalTrainings" PRIMARY KEY ("Id");
 `   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "PK_DepartmentalTrainings";
       Capacity            postgres    false    360                       2606    34065    EventTypes PK_EventTypes 
   CONSTRAINT     `   ALTER TABLE ONLY "Capacity"."EventTypes"
    ADD CONSTRAINT "PK_EventTypes" PRIMARY KEY ("Id");
 J   ALTER TABLE ONLY "Capacity"."EventTypes" DROP CONSTRAINT "PK_EventTypes";
       Capacity            postgres    false    346            �           2606    34731 2   MeetingParticipantsMaps PK_MeetingParticipantsMaps 
   CONSTRAINT     z   ALTER TABLE ONLY "Capacity"."MeetingParticipantsMaps"
    ADD CONSTRAINT "PK_MeetingParticipantsMaps" PRIMARY KEY ("Id");
 d   ALTER TABLE ONLY "Capacity"."MeetingParticipantsMaps" DROP CONSTRAINT "PK_MeetingParticipantsMaps";
       Capacity            postgres    false    384                       2606    34073 (   TrainingOrganizers PK_TrainingOrganizers 
   CONSTRAINT     p   ALTER TABLE ONLY "Capacity"."TrainingOrganizers"
    ADD CONSTRAINT "PK_TrainingOrganizers" PRIMARY KEY ("Id");
 Z   ALTER TABLE ONLY "Capacity"."TrainingOrganizers" DROP CONSTRAINT "PK_TrainingOrganizers";
       Capacity            postgres    false    348            �           2606    33352    Category PK_Category 
   CONSTRAINT     V   ALTER TABLE ONLY "GS"."Category"
    ADD CONSTRAINT "PK_Category" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY "GS"."Category" DROP CONSTRAINT "PK_Category";
       GS            postgres    false    270            �           2606    33358    Color PK_Color 
   CONSTRAINT     P   ALTER TABLE ONLY "GS"."Color"
    ADD CONSTRAINT "PK_Color" PRIMARY KEY ("Id");
 :   ALTER TABLE ONLY "GS"."Color" DROP CONSTRAINT "PK_Color";
       GS            postgres    false    272            �           2606    33426    District PK_District 
   CONSTRAINT     V   ALTER TABLE ONLY "GS"."District"
    ADD CONSTRAINT "PK_District" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY "GS"."District" DROP CONSTRAINT "PK_District";
       GS            postgres    false    290            �           2606    33364    Division PK_Division 
   CONSTRAINT     V   ALTER TABLE ONLY "GS"."Division"
    ADD CONSTRAINT "PK_Division" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY "GS"."Division" DROP CONSTRAINT "PK_Division";
       GS            postgres    false    274            �           2606    34921     FinancialYears PK_FinancialYears 
   CONSTRAINT     b   ALTER TABLE ONLY "GS"."FinancialYears"
    ADD CONSTRAINT "PK_FinancialYears" PRIMARY KEY ("Id");
 L   ALTER TABLE ONLY "GS"."FinancialYears" DROP CONSTRAINT "PK_FinancialYears";
       GS            postgres    false    388            n           2606    34582 4   SubCommitteeDesignations PK_SubCommitteeDesignations 
   CONSTRAINT     v   ALTER TABLE ONLY "GS"."SubCommitteeDesignations"
    ADD CONSTRAINT "PK_SubCommitteeDesignations" PRIMARY KEY ("Id");
 `   ALTER TABLE ONLY "GS"."SubCommitteeDesignations" DROP CONSTRAINT "PK_SubCommitteeDesignations";
       GS            postgres    false    376                       2606    34034    Union PK_Union 
   CONSTRAINT     P   ALTER TABLE ONLY "GS"."Union"
    ADD CONSTRAINT "PK_Union" PRIMARY KEY ("Id");
 :   ALTER TABLE ONLY "GS"."Union" DROP CONSTRAINT "PK_Union";
       GS            postgres    false    340            �           2606    33471    Upazilla PK_Upazilla 
   CONSTRAINT     V   ALTER TABLE ONLY "GS"."Upazilla"
    ADD CONSTRAINT "PK_Upazilla" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY "GS"."Upazilla" DROP CONSTRAINT "PK_Upazilla";
       GS            postgres    false    296            �           2606    37103 <   InternalLoanInformationFiles PK_InternalLoanInformationFiles 
   CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformationFiles"
    ADD CONSTRAINT "PK_InternalLoanInformationFiles" PRIMARY KEY ("Id");
 r   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformationFiles" DROP CONSTRAINT "PK_InternalLoanInformationFiles";
       InternalLoan            postgres    false    480                       2606    35754 4   InternalLoanInformations PK_InternalLoanInformations 
   CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations"
    ADD CONSTRAINT "PK_InternalLoanInformations" PRIMARY KEY ("Id");
 j   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations" DROP CONSTRAINT "PK_InternalLoanInformations";
       InternalLoan            postgres    false    426                       2606    35902 0   RepaymentInternalLoans PK_RepaymentInternalLoans 
   CONSTRAINT     |   ALTER TABLE ONLY "InternalLoan"."RepaymentInternalLoans"
    ADD CONSTRAINT "PK_RepaymentInternalLoans" PRIMARY KEY ("Id");
 f   ALTER TABLE ONLY "InternalLoan"."RepaymentInternalLoans" DROP CONSTRAINT "PK_RepaymentInternalLoans";
       InternalLoan            postgres    false    430            )           2606    36069 *   LabourDatabaseFiles PK_LabourDatabaseFiles 
   CONSTRAINT     p   ALTER TABLE ONLY "Labour"."LabourDatabaseFiles"
    ADD CONSTRAINT "PK_LabourDatabaseFiles" PRIMARY KEY ("Id");
 Z   ALTER TABLE ONLY "Labour"."LabourDatabaseFiles" DROP CONSTRAINT "PK_LabourDatabaseFiles";
       Labour            postgres    false    436            &           2606    35991 "   LabourDatabases PK_LabourDatabases 
   CONSTRAINT     h   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "PK_LabourDatabases" PRIMARY KEY ("Id");
 R   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "PK_LabourDatabases";
       Labour            postgres    false    434            �           2606    37325    LabourWorks PK_LabourWorks 
   CONSTRAINT     `   ALTER TABLE ONLY "Labour"."LabourWorks"
    ADD CONSTRAINT "PK_LabourWorks" PRIMARY KEY ("Id");
 J   ALTER TABLE ONLY "Labour"."LabourWorks" DROP CONSTRAINT "PK_LabourWorks";
       Labour            postgres    false    492                       2606    35933 (   OtherLabourMembers PK_OtherLabourMembers 
   CONSTRAINT     n   ALTER TABLE ONLY "Labour"."OtherLabourMembers"
    ADD CONSTRAINT "PK_OtherLabourMembers" PRIMARY KEY ("Id");
 X   ALTER TABLE ONLY "Labour"."OtherLabourMembers" DROP CONSTRAINT "PK_OtherLabourMembers";
       Labour            postgres    false    432                       2606    34013    Marketings PK_Marketings 
   CONSTRAINT     a   ALTER TABLE ONLY "Marketing"."Marketings"
    ADD CONSTRAINT "PK_Marketings" PRIMARY KEY ("Id");
 K   ALTER TABLE ONLY "Marketing"."Marketings" DROP CONSTRAINT "PK_Marketings";
    	   Marketing            postgres    false    338            �           2606    34754    MeetingFiles PK_MeetingFiles 
   CONSTRAINT     c   ALTER TABLE ONLY "Meeting"."MeetingFiles"
    ADD CONSTRAINT "PK_MeetingFiles" PRIMARY KEY ("Id");
 M   ALTER TABLE ONLY "Meeting"."MeetingFiles" DROP CONSTRAINT "PK_MeetingFiles";
       Meeting            postgres    false    386            p           2606    34664     MeetingMembers PK_MeetingMembers 
   CONSTRAINT     g   ALTER TABLE ONLY "Meeting"."MeetingMembers"
    ADD CONSTRAINT "PK_MeetingMembers" PRIMARY KEY ("Id");
 Q   ALTER TABLE ONLY "Meeting"."MeetingMembers" DROP CONSTRAINT "PK_MeetingMembers";
       Meeting            postgres    false    378            r           2606    34672    MeetingTypes PK_MeetingTypes 
   CONSTRAINT     c   ALTER TABLE ONLY "Meeting"."MeetingTypes"
    ADD CONSTRAINT "PK_MeetingTypes" PRIMARY KEY ("Id");
 M   ALTER TABLE ONLY "Meeting"."MeetingTypes" DROP CONSTRAINT "PK_MeetingTypes";
       Meeting            postgres    false    380                       2606    34680    Meetings PK_Meetings 
   CONSTRAINT     [   ALTER TABLE ONLY "Meeting"."Meetings"
    ADD CONSTRAINT "PK_Meetings" PRIMARY KEY ("Id");
 E   ALTER TABLE ONLY "Meeting"."Meetings" DROP CONSTRAINT "PK_Meetings";
       Meeting            postgres    false    382            �           2606    35374 .   OtherPatrollingMember PK_OtherPatrollingMember 
   CONSTRAINT     x   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember"
    ADD CONSTRAINT "PK_OtherPatrollingMember" PRIMARY KEY ("Id");
 b   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember" DROP CONSTRAINT "PK_OtherPatrollingMember";
    
   Patrolling            postgres    false    416            �           2606    35345 <   PatrollingPaymentInformetion PK_PatrollingPaymentInformetion 
   CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."PatrollingPaymentInformetion"
    ADD CONSTRAINT "PK_PatrollingPaymentInformetion" PRIMARY KEY ("Id");
 p   ALTER TABLE ONLY "Patrolling"."PatrollingPaymentInformetion" DROP CONSTRAINT "PK_PatrollingPaymentInformetion";
    
   Patrolling            postgres    false    414            �           2606    35297 >   PatrollingScheduleInformetion PK_PatrollingScheduleInformetion 
   CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion"
    ADD CONSTRAINT "PK_PatrollingScheduleInformetion" PRIMARY KEY ("Id");
 r   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion" DROP CONSTRAINT "PK_PatrollingScheduleInformetion";
    
   Patrolling            postgres    false    412            K           2606    36323 6   PatrollingSchedulingFiles PK_PatrollingSchedulingFiles 
   CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingFiles"
    ADD CONSTRAINT "PK_PatrollingSchedulingFiles" PRIMARY KEY ("Id");
 t   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingFiles" DROP CONSTRAINT "PK_PatrollingSchedulingFiles";
       PatrollingScheduling            postgres    false    446            <           2606    36257 :   PatrollingSchedulingMembers PK_PatrollingSchedulingMembers 
   CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingMembers"
    ADD CONSTRAINT "PK_PatrollingSchedulingMembers" PRIMARY KEY ("Id");
 x   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingMembers" DROP CONSTRAINT "PK_PatrollingSchedulingMembers";
       PatrollingScheduling            postgres    false    442            P           2606    36336 L   PatrollingSchedulingParticipentsMaps PK_PatrollingSchedulingParticipentsMaps 
   CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps"
    ADD CONSTRAINT "PK_PatrollingSchedulingParticipentsMaps" PRIMARY KEY ("Id");
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps" DROP CONSTRAINT "PK_PatrollingSchedulingParticipentsMaps";
       PatrollingScheduling            postgres    false    448            H           2606    36265 .   PatrollingSchedulings PK_PatrollingSchedulings 
   CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings"
    ADD CONSTRAINT "PK_PatrollingSchedulings" PRIMARY KEY ("Id");
 l   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings" DROP CONSTRAINT "PK_PatrollingSchedulings";
       PatrollingScheduling            postgres    false    444            �           2606    37006    BankDeposits PK_BankDeposits 
   CONSTRAINT     j   ALTER TABLE ONLY "SocialForestry"."BankDeposits"
    ADD CONSTRAINT "PK_BankDeposits" PRIMARY KEY ("Id");
 T   ALTER TABLE ONLY "SocialForestry"."BankDeposits" DROP CONSTRAINT "PK_BankDeposits";
       SocialForestry            postgres    false    474            w           2606    36926 (   CuttingPlantations PK_CuttingPlantations 
   CONSTRAINT     v   ALTER TABLE ONLY "SocialForestry"."CuttingPlantations"
    ADD CONSTRAINT "PK_CuttingPlantations" PRIMARY KEY ("Id");
 `   ALTER TABLE ONLY "SocialForestry"."CuttingPlantations" DROP CONSTRAINT "PK_CuttingPlantations";
       SocialForestry            postgres    false    462            �           2606    37019 H   DistributedOrRevenueDepositAmounts PK_DistributedOrRevenueDepositAmounts 
   CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."DistributedOrRevenueDepositAmounts"
    ADD CONSTRAINT "PK_DistributedOrRevenueDepositAmounts" PRIMARY KEY ("Id");
 �   ALTER TABLE ONLY "SocialForestry"."DistributedOrRevenueDepositAmounts" DROP CONSTRAINT "PK_DistributedOrRevenueDepositAmounts";
       SocialForestry            postgres    false    476            {           2606    36937 <   NewRaisedPlantationUnionMaps PK_NewRaisedPlantationUnionMaps 
   CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantationUnionMaps"
    ADD CONSTRAINT "PK_NewRaisedPlantationUnionMaps" PRIMARY KEY ("Id");
 t   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantationUnionMaps" DROP CONSTRAINT "PK_NewRaisedPlantationUnionMaps";
       SocialForestry            postgres    false    464                       2606    36953 B   NewRaisedPlantationUpazillaMaps PK_NewRaisedPlantationUpazillaMaps 
   CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantationUpazillaMaps"
    ADD CONSTRAINT "PK_NewRaisedPlantationUpazillaMaps" PRIMARY KEY ("Id");
 z   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantationUpazillaMaps" DROP CONSTRAINT "PK_NewRaisedPlantationUpazillaMaps";
       SocialForestry            postgres    false    466            t           2606    36865 ,   NewRaisedPlantations PK_NewRaisedPlantations 
   CONSTRAINT     z   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations"
    ADD CONSTRAINT "PK_NewRaisedPlantations" PRIMARY KEY ("Id");
 d   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations" DROP CONSTRAINT "PK_NewRaisedPlantations";
       SocialForestry            postgres    false    460            _           2606    36825 (   PlantationProjects PK_PlantationProjects 
   CONSTRAINT     v   ALTER TABLE ONLY "SocialForestry"."PlantationProjects"
    ADD CONSTRAINT "PK_PlantationProjects" PRIMARY KEY ("Id");
 `   ALTER TABLE ONLY "SocialForestry"."PlantationProjects" DROP CONSTRAINT "PK_PlantationProjects";
       SocialForestry            postgres    false    452            d           2606    36839 D   PlantationTypeRevenuePercentages PK_PlantationTypeRevenuePercentages 
   CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."PlantationTypeRevenuePercentages"
    ADD CONSTRAINT "PK_PlantationTypeRevenuePercentages" PRIMARY KEY ("Id");
 |   ALTER TABLE ONLY "SocialForestry"."PlantationTypeRevenuePercentages" DROP CONSTRAINT "PK_PlantationTypeRevenuePercentages";
       SocialForestry            postgres    false    456            a           2606    36833 "   PlantationTypes PK_PlantationTypes 
   CONSTRAINT     p   ALTER TABLE ONLY "SocialForestry"."PlantationTypes"
    ADD CONSTRAINT "PK_PlantationTypes" PRIMARY KEY ("Id");
 Z   ALTER TABLE ONLY "SocialForestry"."PlantationTypes" DROP CONSTRAINT "PK_PlantationTypes";
       SocialForestry            postgres    false    454            �           2606    36971     Reforestations PK_Reforestations 
   CONSTRAINT     n   ALTER TABLE ONLY "SocialForestry"."Reforestations"
    ADD CONSTRAINT "PK_Reforestations" PRIMARY KEY ("Id");
 X   ALTER TABLE ONLY "SocialForestry"."Reforestations" DROP CONSTRAINT "PK_Reforestations";
       SocialForestry            postgres    false    468            �           2606    36993 ,   RevenueDistributions PK_RevenueDistributions 
   CONSTRAINT     z   ALTER TABLE ONLY "SocialForestry"."RevenueDistributions"
    ADD CONSTRAINT "PK_RevenueDistributions" PRIMARY KEY ("Id");
 d   ALTER TABLE ONLY "SocialForestry"."RevenueDistributions" DROP CONSTRAINT "PK_RevenueDistributions";
       SocialForestry            postgres    false    472            �           2606    36982    Revenues PK_Revenues 
   CONSTRAINT     b   ALTER TABLE ONLY "SocialForestry"."Revenues"
    ADD CONSTRAINT "PK_Revenues" PRIMARY KEY ("Id");
 L   ALTER TABLE ONLY "SocialForestry"."Revenues" DROP CONSTRAINT "PK_Revenues";
       SocialForestry            postgres    false    470            g           2606    36852    StripTypes PK_StripTypes 
   CONSTRAINT     f   ALTER TABLE ONLY "SocialForestry"."StripTypes"
    ADD CONSTRAINT "PK_StripTypes" PRIMARY KEY ("Id");
 P   ALTER TABLE ONLY "SocialForestry"."StripTypes" DROP CONSTRAINT "PK_StripTypes";
       SocialForestry            postgres    false    458            j           2606    34496    Students PK_Students 
   CONSTRAINT     [   ALTER TABLE ONLY "Student"."Students"
    ADD CONSTRAINT "PK_Students" PRIMARY KEY ("Id");
 E   ALTER TABLE ONLY "Student"."Students" DROP CONSTRAINT "PK_Students";
       Student            postgres    false    372            �           2606    33378    AccessMapper PK_AccessMapper 
   CONSTRAINT     b   ALTER TABLE ONLY "System"."AccessMapper"
    ADD CONSTRAINT "PK_AccessMapper" PRIMARY KEY ("Id");
 L   ALTER TABLE ONLY "System"."AccessMapper" DROP CONSTRAINT "PK_AccessMapper";
       System            postgres    false    278            �           2606    33370    Accesslist PK_Accesslist 
   CONSTRAINT     ^   ALTER TABLE ONLY "System"."Accesslist"
    ADD CONSTRAINT "PK_Accesslist" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY "System"."Accesslist" DROP CONSTRAINT "PK_Accesslist";
       System            postgres    false    276            �           2606    33384    Module PK_Module 
   CONSTRAINT     V   ALTER TABLE ONLY "System"."Module"
    ADD CONSTRAINT "PK_Module" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY "System"."Module" DROP CONSTRAINT "PK_Module";
       System            postgres    false    280            �           2606    33390    PmsGroup PK_PmsGroup 
   CONSTRAINT     Z   ALTER TABLE ONLY "System"."PmsGroup"
    ADD CONSTRAINT "PK_PmsGroup" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY "System"."PmsGroup" DROP CONSTRAINT "PK_PmsGroup";
       System            postgres    false    282            �           2606    33439    User PK_User 
   CONSTRAINT     R   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "PK_User" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "PK_User";
       System            postgres    false    292            �           2606    33398    UserGroup PK_UserGroup 
   CONSTRAINT     \   ALTER TABLE ONLY "System"."UserGroup"
    ADD CONSTRAINT "PK_UserGroup" PRIMARY KEY ("Id");
 F   ALTER TABLE ONLY "System"."UserGroup" DROP CONSTRAINT "PK_UserGroup";
       System            postgres    false    284            �           2606    33404    UserRoles PK_UserRoles 
   CONSTRAINT     \   ALTER TABLE ONLY "System"."UserRoles"
    ADD CONSTRAINT "PK_UserRoles" PRIMARY KEY ("Id");
 F   ALTER TABLE ONLY "System"."UserRoles" DROP CONSTRAINT "PK_UserRoles";
       System            postgres    false    286            �           2606    37139 .   ExpenseDetailsForCDFs PK_ExpenseDetailsForCDFs 
   CONSTRAINT     y   ALTER TABLE ONLY "TRANSACTION"."ExpenseDetailsForCDFs"
    ADD CONSTRAINT "PK_ExpenseDetailsForCDFs" PRIMARY KEY ("Id");
 c   ALTER TABLE ONLY "TRANSACTION"."ExpenseDetailsForCDFs" DROP CONSTRAINT "PK_ExpenseDetailsForCDFs";
       TRANSACTION            postgres    false    484            �           2606    34929    FundTypes PK_FundTypes 
   CONSTRAINT     a   ALTER TABLE ONLY "TRANSACTION"."FundTypes"
    ADD CONSTRAINT "PK_FundTypes" PRIMARY KEY ("Id");
 K   ALTER TABLE ONLY "TRANSACTION"."FundTypes" DROP CONSTRAINT "PK_FundTypes";
       TRANSACTION            postgres    false    390            �           2606    34956 (   TransactionDetails PK_TransactionDetails 
   CONSTRAINT     s   ALTER TABLE ONLY "TRANSACTION"."TransactionDetails"
    ADD CONSTRAINT "PK_TransactionDetails" PRIMARY KEY ("Id");
 ]   ALTER TABLE ONLY "TRANSACTION"."TransactionDetails" DROP CONSTRAINT "PK_TransactionDetails";
       TRANSACTION            postgres    false    394            �           2606    34974 *   TransactionExpenses PK_TransactionExpenses 
   CONSTRAINT     u   ALTER TABLE ONLY "TRANSACTION"."TransactionExpenses"
    ADD CONSTRAINT "PK_TransactionExpenses" PRIMARY KEY ("Id");
 _   ALTER TABLE ONLY "TRANSACTION"."TransactionExpenses" DROP CONSTRAINT "PK_TransactionExpenses";
       TRANSACTION            postgres    false    396            �           2606    34935    Transactions PK_Transactions 
   CONSTRAINT     g   ALTER TABLE ONLY "TRANSACTION"."Transactions"
    ADD CONSTRAINT "PK_Transactions" PRIMARY KEY ("Id");
 Q   ALTER TABLE ONLY "TRANSACTION"."Transactions" DROP CONSTRAINT "PK_Transactions";
       TRANSACTION            postgres    false    392            Y           2606    33229 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public            postgres    false    230            �           1259    35272 "   IX_AIGBasicInformations_DistrictId    INDEX     n   CREATE INDEX "IX_AIGBasicInformations_DistrictId" ON "AIG"."AIGBasicInformations" USING btree ("DistrictId");
 7   DROP INDEX "AIG"."IX_AIGBasicInformations_DistrictId";
       AIG            postgres    false    404            �           1259    35273 "   IX_AIGBasicInformations_DivisionId    INDEX     n   CREATE INDEX "IX_AIGBasicInformations_DivisionId" ON "AIG"."AIGBasicInformations" USING btree ("DivisionId");
 7   DROP INDEX "AIG"."IX_AIGBasicInformations_DivisionId";
       AIG            postgres    false    404            �           1259    35274 $   IX_AIGBasicInformations_ForestBeatId    INDEX     r   CREATE INDEX "IX_AIGBasicInformations_ForestBeatId" ON "AIG"."AIGBasicInformations" USING btree ("ForestBeatId");
 9   DROP INDEX "AIG"."IX_AIGBasicInformations_ForestBeatId";
       AIG            postgres    false    404            �           1259    35275 &   IX_AIGBasicInformations_ForestCircleId    INDEX     v   CREATE INDEX "IX_AIGBasicInformations_ForestCircleId" ON "AIG"."AIGBasicInformations" USING btree ("ForestCircleId");
 ;   DROP INDEX "AIG"."IX_AIGBasicInformations_ForestCircleId";
       AIG            postgres    false    404            �           1259    35276 (   IX_AIGBasicInformations_ForestDivisionId    INDEX     z   CREATE INDEX "IX_AIGBasicInformations_ForestDivisionId" ON "AIG"."AIGBasicInformations" USING btree ("ForestDivisionId");
 =   DROP INDEX "AIG"."IX_AIGBasicInformations_ForestDivisionId";
       AIG            postgres    false    404            �           1259    35277 &   IX_AIGBasicInformations_ForestFcvVcfId    INDEX     v   CREATE INDEX "IX_AIGBasicInformations_ForestFcvVcfId" ON "AIG"."AIGBasicInformations" USING btree ("ForestFcvVcfId");
 ;   DROP INDEX "AIG"."IX_AIGBasicInformations_ForestFcvVcfId";
       AIG            postgres    false    404            �           1259    35278 %   IX_AIGBasicInformations_ForestRangeId    INDEX     t   CREATE INDEX "IX_AIGBasicInformations_ForestRangeId" ON "AIG"."AIGBasicInformations" USING btree ("ForestRangeId");
 :   DROP INDEX "AIG"."IX_AIGBasicInformations_ForestRangeId";
       AIG            postgres    false    404            �           1259    35279    IX_AIGBasicInformations_NgoId    INDEX     d   CREATE INDEX "IX_AIGBasicInformations_NgoId" ON "AIG"."AIGBasicInformations" USING btree ("NgoId");
 2   DROP INDEX "AIG"."IX_AIGBasicInformations_NgoId";
       AIG            postgres    false    404            �           1259    35280     IX_AIGBasicInformations_SurveyId    INDEX     j   CREATE INDEX "IX_AIGBasicInformations_SurveyId" ON "AIG"."AIGBasicInformations" USING btree ("SurveyId");
 5   DROP INDEX "AIG"."IX_AIGBasicInformations_SurveyId";
       AIG            postgres    false    404            �           1259    35281    IX_AIGBasicInformations_TradeId    INDEX     h   CREATE INDEX "IX_AIGBasicInformations_TradeId" ON "AIG"."AIGBasicInformations" USING btree ("TradeId");
 4   DROP INDEX "AIG"."IX_AIGBasicInformations_TradeId";
       AIG            postgres    false    404            �           1259    35282    IX_AIGBasicInformations_UnionId    INDEX     h   CREATE INDEX "IX_AIGBasicInformations_UnionId" ON "AIG"."AIGBasicInformations" USING btree ("UnionId");
 4   DROP INDEX "AIG"."IX_AIGBasicInformations_UnionId";
       AIG            postgres    false    404            �           1259    35283 "   IX_AIGBasicInformations_UpazillaId    INDEX     n   CREATE INDEX "IX_AIGBasicInformations_UpazillaId" ON "AIG"."AIGBasicInformations" USING btree ("UpazillaId");
 7   DROP INDEX "AIG"."IX_AIGBasicInformations_UpazillaId";
       AIG            postgres    false    404            �           1259    35284 1   IX_FirstSixtyPercentageLDFs_AIGBasicInformationId    INDEX     �   CREATE UNIQUE INDEX "IX_FirstSixtyPercentageLDFs_AIGBasicInformationId" ON "AIG"."FirstSixtyPercentageLDFs" USING btree ("AIGBasicInformationId");
 F   DROP INDEX "AIG"."IX_FirstSixtyPercentageLDFs_AIGBasicInformationId";
       AIG            postgres    false    406            7           1259    36198 -   IX_GroupLDFInfoFormMembers_GroupLDFInfoFormId    INDEX     �   CREATE INDEX "IX_GroupLDFInfoFormMembers_GroupLDFInfoFormId" ON "AIG"."GroupLDFInfoFormMembers" USING btree ("GroupLDFInfoFormId");
 B   DROP INDEX "AIG"."IX_GroupLDFInfoFormMembers_GroupLDFInfoFormId";
       AIG            postgres    false    440            8           1259    36199 2   IX_GroupLDFInfoFormMembers_IndividualLDFInfoFormId    INDEX     �   CREATE INDEX "IX_GroupLDFInfoFormMembers_IndividualLDFInfoFormId" ON "AIG"."GroupLDFInfoFormMembers" USING btree ("IndividualLDFInfoFormId");
 G   DROP INDEX "AIG"."IX_GroupLDFInfoFormMembers_IndividualLDFInfoFormId";
       AIG            postgres    false    440            *           1259    36200    IX_GroupLDFInfoForms_DistrictId    INDEX     h   CREATE INDEX "IX_GroupLDFInfoForms_DistrictId" ON "AIG"."GroupLDFInfoForms" USING btree ("DistrictId");
 4   DROP INDEX "AIG"."IX_GroupLDFInfoForms_DistrictId";
       AIG            postgres    false    438            +           1259    36201    IX_GroupLDFInfoForms_DivisionId    INDEX     h   CREATE INDEX "IX_GroupLDFInfoForms_DivisionId" ON "AIG"."GroupLDFInfoForms" USING btree ("DivisionId");
 4   DROP INDEX "AIG"."IX_GroupLDFInfoForms_DivisionId";
       AIG            postgres    false    438            ,           1259    36202 !   IX_GroupLDFInfoForms_ForestBeatId    INDEX     l   CREATE INDEX "IX_GroupLDFInfoForms_ForestBeatId" ON "AIG"."GroupLDFInfoForms" USING btree ("ForestBeatId");
 6   DROP INDEX "AIG"."IX_GroupLDFInfoForms_ForestBeatId";
       AIG            postgres    false    438            -           1259    36203 #   IX_GroupLDFInfoForms_ForestCircleId    INDEX     p   CREATE INDEX "IX_GroupLDFInfoForms_ForestCircleId" ON "AIG"."GroupLDFInfoForms" USING btree ("ForestCircleId");
 8   DROP INDEX "AIG"."IX_GroupLDFInfoForms_ForestCircleId";
       AIG            postgres    false    438            .           1259    36204 %   IX_GroupLDFInfoForms_ForestDivisionId    INDEX     t   CREATE INDEX "IX_GroupLDFInfoForms_ForestDivisionId" ON "AIG"."GroupLDFInfoForms" USING btree ("ForestDivisionId");
 :   DROP INDEX "AIG"."IX_GroupLDFInfoForms_ForestDivisionId";
       AIG            postgres    false    438            /           1259    36205 #   IX_GroupLDFInfoForms_ForestFcvVcfId    INDEX     p   CREATE INDEX "IX_GroupLDFInfoForms_ForestFcvVcfId" ON "AIG"."GroupLDFInfoForms" USING btree ("ForestFcvVcfId");
 8   DROP INDEX "AIG"."IX_GroupLDFInfoForms_ForestFcvVcfId";
       AIG            postgres    false    438            0           1259    36206 "   IX_GroupLDFInfoForms_ForestRangeId    INDEX     n   CREATE INDEX "IX_GroupLDFInfoForms_ForestRangeId" ON "AIG"."GroupLDFInfoForms" USING btree ("ForestRangeId");
 7   DROP INDEX "AIG"."IX_GroupLDFInfoForms_ForestRangeId";
       AIG            postgres    false    438            1           1259    36207    IX_GroupLDFInfoForms_NgoId    INDEX     ^   CREATE INDEX "IX_GroupLDFInfoForms_NgoId" ON "AIG"."GroupLDFInfoForms" USING btree ("NgoId");
 /   DROP INDEX "AIG"."IX_GroupLDFInfoForms_NgoId";
       AIG            postgres    false    438            2           1259    36208 "   IX_GroupLDFInfoForms_SubmittedById    INDEX     n   CREATE INDEX "IX_GroupLDFInfoForms_SubmittedById" ON "AIG"."GroupLDFInfoForms" USING btree ("SubmittedById");
 7   DROP INDEX "AIG"."IX_GroupLDFInfoForms_SubmittedById";
       AIG            postgres    false    438            3           1259    36209    IX_GroupLDFInfoForms_UnionId    INDEX     b   CREATE INDEX "IX_GroupLDFInfoForms_UnionId" ON "AIG"."GroupLDFInfoForms" USING btree ("UnionId");
 1   DROP INDEX "AIG"."IX_GroupLDFInfoForms_UnionId";
       AIG            postgres    false    438            4           1259    36210    IX_GroupLDFInfoForms_UpazillaId    INDEX     h   CREATE INDEX "IX_GroupLDFInfoForms_UpazillaId" ON "AIG"."GroupLDFInfoForms" USING btree ("UpazillaId");
 4   DROP INDEX "AIG"."IX_GroupLDFInfoForms_UpazillaId";
       AIG            postgres    false    438            �           1259    35651 $   IX_IndividualLDFInfoForms_DistrictId    INDEX     r   CREATE INDEX "IX_IndividualLDFInfoForms_DistrictId" ON "AIG"."IndividualLDFInfoForms" USING btree ("DistrictId");
 9   DROP INDEX "AIG"."IX_IndividualLDFInfoForms_DistrictId";
       AIG            postgres    false    420            �           1259    35652 $   IX_IndividualLDFInfoForms_DivisionId    INDEX     r   CREATE INDEX "IX_IndividualLDFInfoForms_DivisionId" ON "AIG"."IndividualLDFInfoForms" USING btree ("DivisionId");
 9   DROP INDEX "AIG"."IX_IndividualLDFInfoForms_DivisionId";
       AIG            postgres    false    420            �           1259    35653 &   IX_IndividualLDFInfoForms_ForestBeatId    INDEX     v   CREATE INDEX "IX_IndividualLDFInfoForms_ForestBeatId" ON "AIG"."IndividualLDFInfoForms" USING btree ("ForestBeatId");
 ;   DROP INDEX "AIG"."IX_IndividualLDFInfoForms_ForestBeatId";
       AIG            postgres    false    420            �           1259    35654 (   IX_IndividualLDFInfoForms_ForestCircleId    INDEX     z   CREATE INDEX "IX_IndividualLDFInfoForms_ForestCircleId" ON "AIG"."IndividualLDFInfoForms" USING btree ("ForestCircleId");
 =   DROP INDEX "AIG"."IX_IndividualLDFInfoForms_ForestCircleId";
       AIG            postgres    false    420            �           1259    35655 *   IX_IndividualLDFInfoForms_ForestDivisionId    INDEX     ~   CREATE INDEX "IX_IndividualLDFInfoForms_ForestDivisionId" ON "AIG"."IndividualLDFInfoForms" USING btree ("ForestDivisionId");
 ?   DROP INDEX "AIG"."IX_IndividualLDFInfoForms_ForestDivisionId";
       AIG            postgres    false    420            �           1259    35656 (   IX_IndividualLDFInfoForms_ForestFcvVcfId    INDEX     z   CREATE INDEX "IX_IndividualLDFInfoForms_ForestFcvVcfId" ON "AIG"."IndividualLDFInfoForms" USING btree ("ForestFcvVcfId");
 =   DROP INDEX "AIG"."IX_IndividualLDFInfoForms_ForestFcvVcfId";
       AIG            postgres    false    420            �           1259    35657 '   IX_IndividualLDFInfoForms_ForestRangeId    INDEX     x   CREATE INDEX "IX_IndividualLDFInfoForms_ForestRangeId" ON "AIG"."IndividualLDFInfoForms" USING btree ("ForestRangeId");
 <   DROP INDEX "AIG"."IX_IndividualLDFInfoForms_ForestRangeId";
       AIG            postgres    false    420            �           1259    35672    IX_IndividualLDFInfoForms_NgoId    INDEX     h   CREATE INDEX "IX_IndividualLDFInfoForms_NgoId" ON "AIG"."IndividualLDFInfoForms" USING btree ("NgoId");
 4   DROP INDEX "AIG"."IX_IndividualLDFInfoForms_NgoId";
       AIG            postgres    false    420            �           1259    35658 "   IX_IndividualLDFInfoForms_SurveyId    INDEX     n   CREATE INDEX "IX_IndividualLDFInfoForms_SurveyId" ON "AIG"."IndividualLDFInfoForms" USING btree ("SurveyId");
 7   DROP INDEX "AIG"."IX_IndividualLDFInfoForms_SurveyId";
       AIG            postgres    false    420            �           1259    35659 !   IX_IndividualLDFInfoForms_UnionId    INDEX     l   CREATE INDEX "IX_IndividualLDFInfoForms_UnionId" ON "AIG"."IndividualLDFInfoForms" USING btree ("UnionId");
 6   DROP INDEX "AIG"."IX_IndividualLDFInfoForms_UnionId";
       AIG            postgres    false    420            �           1259    35660 $   IX_IndividualLDFInfoForms_UpazillaId    INDEX     r   CREATE INDEX "IX_IndividualLDFInfoForms_UpazillaId" ON "AIG"."IndividualLDFInfoForms" USING btree ("UpazillaId");
 9   DROP INDEX "AIG"."IX_IndividualLDFInfoForms_UpazillaId";
       AIG            postgres    false    420            �           1259    35501 %   IX_LDFProgresss_AIGBasicInformationId    INDEX     t   CREATE INDEX "IX_LDFProgresss_AIGBasicInformationId" ON "AIG"."LDFProgresss" USING btree ("AIGBasicInformationId");
 :   DROP INDEX "AIG"."IX_LDFProgresss_AIGBasicInformationId";
       AIG            postgres    false    418            �           1259    35502    IX_LDFProgresss_RepaymentLDFId    INDEX     m   CREATE UNIQUE INDEX "IX_LDFProgresss_RepaymentLDFId" ON "AIG"."LDFProgresss" USING btree ("RepaymentLDFId");
 3   DROP INDEX "AIG"."IX_LDFProgresss_RepaymentLDFId";
       AIG            postgres    false    418            �           1259    37130 #   IX_RepaymentLDFFiles_RepaymentLDFId    INDEX     p   CREATE INDEX "IX_RepaymentLDFFiles_RepaymentLDFId" ON "AIG"."RepaymentLDFFiles" USING btree ("RepaymentLDFId");
 8   DROP INDEX "AIG"."IX_RepaymentLDFFiles_RepaymentLDFId";
       AIG            postgres    false    482                       1259    35893 $   IX_RepaymentLDFHistories_EventUserId    INDEX     r   CREATE INDEX "IX_RepaymentLDFHistories_EventUserId" ON "AIG"."RepaymentLDFHistories" USING btree ("EventUserId");
 9   DROP INDEX "AIG"."IX_RepaymentLDFHistories_EventUserId";
       AIG            postgres    false    428                       1259    35894 '   IX_RepaymentLDFHistories_RepaymentLDFId    INDEX     x   CREATE INDEX "IX_RepaymentLDFHistories_RepaymentLDFId" ON "AIG"."RepaymentLDFHistories" USING btree ("RepaymentLDFId");
 <   DROP INDEX "AIG"."IX_RepaymentLDFHistories_RepaymentLDFId";
       AIG            postgres    false    428            �           1259    35460 &   IX_RepaymentLDFs_AIGBasicInformationId    INDEX     v   CREATE INDEX "IX_RepaymentLDFs_AIGBasicInformationId" ON "AIG"."RepaymentLDFs" USING btree ("AIGBasicInformationId");
 ;   DROP INDEX "AIG"."IX_RepaymentLDFs_AIGBasicInformationId";
       AIG            postgres    false    410            �           1259    35286 *   IX_RepaymentLDFs_FirstSixtyPercentageLDFId    INDEX     ~   CREATE INDEX "IX_RepaymentLDFs_FirstSixtyPercentageLDFId" ON "AIG"."RepaymentLDFs" USING btree ("FirstSixtyPercentageLDFId");
 ?   DROP INDEX "AIG"."IX_RepaymentLDFs_FirstSixtyPercentageLDFId";
       AIG            postgres    false    410            �           1259    35287 ,   IX_RepaymentLDFs_SecondFourtyPercentageLDFId    INDEX     �   CREATE INDEX "IX_RepaymentLDFs_SecondFourtyPercentageLDFId" ON "AIG"."RepaymentLDFs" USING btree ("SecondFourtyPercentageLDFId");
 A   DROP INDEX "AIG"."IX_RepaymentLDFs_SecondFourtyPercentageLDFId";
       AIG            postgres    false    410            �           1259    35288 3   IX_SecondFourtyPercentageLDFs_AIGBasicInformationId    INDEX     �   CREATE UNIQUE INDEX "IX_SecondFourtyPercentageLDFs_AIGBasicInformationId" ON "AIG"."SecondFourtyPercentageLDFs" USING btree ("AIGBasicInformationId");
 H   DROP INDEX "AIG"."IX_SecondFourtyPercentageLDFs_AIGBasicInformationId";
       AIG            postgres    false    408            �           1259    33841 0   IX_AnnualHouseholdExpenditures_ExpenditureTypeId    INDEX     �   CREATE INDEX "IX_AnnualHouseholdExpenditures_ExpenditureTypeId" ON "BEN"."AnnualHouseholdExpenditures" USING btree ("ExpenditureTypeId");
 E   DROP INDEX "BEN"."IX_AnnualHouseholdExpenditures_ExpenditureTypeId";
       BEN            postgres    false    304            �           1259    33842 '   IX_AnnualHouseholdExpenditures_SurveyId    INDEX     x   CREATE INDEX "IX_AnnualHouseholdExpenditures_SurveyId" ON "BEN"."AnnualHouseholdExpenditures" USING btree ("SurveyId");
 <   DROP INDEX "BEN"."IX_AnnualHouseholdExpenditures_SurveyId";
       BEN            postgres    false    304            �           1259    33843    IX_Assets_AssetTypeId    INDEX     T   CREATE INDEX "IX_Assets_AssetTypeId" ON "BEN"."Assets" USING btree ("AssetTypeId");
 *   DROP INDEX "BEN"."IX_Assets_AssetTypeId";
       BEN            postgres    false    306            �           1259    33844    IX_Assets_SurveyId    INDEX     N   CREATE INDEX "IX_Assets_SurveyId" ON "BEN"."Assets" USING btree ("SurveyId");
 '   DROP INDEX "BEN"."IX_Assets_SurveyId";
       BEN            postgres    false    306                       1259    34004 6   IX_BFDAssociationHouseholdMembersMaps_BFDAssociationId    INDEX     �   CREATE INDEX "IX_BFDAssociationHouseholdMembersMaps_BFDAssociationId" ON "BEN"."BFDAssociationHouseholdMembersMaps" USING btree ("BFDAssociationId");
 K   DROP INDEX "BEN"."IX_BFDAssociationHouseholdMembersMaps_BFDAssociationId";
       BEN            postgres    false    333                       1259    33845 7   IX_BFDAssociationHouseholdMembersMaps_HouseholdMemberId    INDEX     �   CREATE INDEX "IX_BFDAssociationHouseholdMembersMaps_HouseholdMemberId" ON "BEN"."BFDAssociationHouseholdMembersMaps" USING btree ("HouseholdMemberId");
 L   DROP INDEX "BEN"."IX_BFDAssociationHouseholdMembersMaps_HouseholdMemberId";
       BEN            postgres    false    333            �           1259    33846 '   IX_Businesss_BusinessIncomeSourceTypeId    INDEX     x   CREATE INDEX "IX_Businesss_BusinessIncomeSourceTypeId" ON "BEN"."Businesss" USING btree ("BusinessIncomeSourceTypeId");
 <   DROP INDEX "BEN"."IX_Businesss_BusinessIncomeSourceTypeId";
       BEN            postgres    false    308            �           1259    33847    IX_Businesss_SurveyId    INDEX     T   CREATE INDEX "IX_Businesss_SurveyId" ON "BEN"."Businesss" USING btree ("SurveyId");
 *   DROP INDEX "BEN"."IX_Businesss_SurveyId";
       BEN            postgres    false    308            �           1259    37083    IX_CipFiles_CipId    INDEX     L   CREATE INDEX "IX_CipFiles_CipId" ON "BEN"."CipFiles" USING btree ("CipId");
 &   DROP INDEX "BEN"."IX_CipFiles_CipId";
       BEN            postgres    false    478            Q           1259    37086    IX_Cips_CipGeneratedId    INDEX     ]   CREATE UNIQUE INDEX "IX_Cips_CipGeneratedId" ON "BEN"."Cips" USING btree ("CipGeneratedId");
 +   DROP INDEX "BEN"."IX_Cips_CipGeneratedId";
       BEN            postgres    false    450            R           1259    36801    IX_Cips_DistrictId    INDEX     N   CREATE INDEX "IX_Cips_DistrictId" ON "BEN"."Cips" USING btree ("DistrictId");
 '   DROP INDEX "BEN"."IX_Cips_DistrictId";
       BEN            postgres    false    450            S           1259    36802    IX_Cips_DivisionId    INDEX     N   CREATE INDEX "IX_Cips_DivisionId" ON "BEN"."Cips" USING btree ("DivisionId");
 '   DROP INDEX "BEN"."IX_Cips_DivisionId";
       BEN            postgres    false    450            T           1259    36803    IX_Cips_EthnicityId    INDEX     P   CREATE INDEX "IX_Cips_EthnicityId" ON "BEN"."Cips" USING btree ("EthnicityId");
 (   DROP INDEX "BEN"."IX_Cips_EthnicityId";
       BEN            postgres    false    450            U           1259    36804    IX_Cips_ForestBeatId    INDEX     R   CREATE INDEX "IX_Cips_ForestBeatId" ON "BEN"."Cips" USING btree ("ForestBeatId");
 )   DROP INDEX "BEN"."IX_Cips_ForestBeatId";
       BEN            postgres    false    450            V           1259    36805    IX_Cips_ForestCircleId    INDEX     V   CREATE INDEX "IX_Cips_ForestCircleId" ON "BEN"."Cips" USING btree ("ForestCircleId");
 +   DROP INDEX "BEN"."IX_Cips_ForestCircleId";
       BEN            postgres    false    450            W           1259    36806    IX_Cips_ForestDivisionId    INDEX     Z   CREATE INDEX "IX_Cips_ForestDivisionId" ON "BEN"."Cips" USING btree ("ForestDivisionId");
 -   DROP INDEX "BEN"."IX_Cips_ForestDivisionId";
       BEN            postgres    false    450            X           1259    36807    IX_Cips_ForestFcvVcfId    INDEX     V   CREATE INDEX "IX_Cips_ForestFcvVcfId" ON "BEN"."Cips" USING btree ("ForestFcvVcfId");
 +   DROP INDEX "BEN"."IX_Cips_ForestFcvVcfId";
       BEN            postgres    false    450            Y           1259    36808    IX_Cips_ForestRangeId    INDEX     T   CREATE INDEX "IX_Cips_ForestRangeId" ON "BEN"."Cips" USING btree ("ForestRangeId");
 *   DROP INDEX "BEN"."IX_Cips_ForestRangeId";
       BEN            postgres    false    450            Z           1259    36809    IX_Cips_UnionId    INDEX     H   CREATE INDEX "IX_Cips_UnionId" ON "BEN"."Cips" USING btree ("UnionId");
 $   DROP INDEX "BEN"."IX_Cips_UnionId";
       BEN            postgres    false    450            [           1259    36810    IX_Cips_UpazillaId    INDEX     N   CREATE INDEX "IX_Cips_UpazillaId" ON "BEN"."Cips" USING btree ("UpazillaId");
 '   DROP INDEX "BEN"."IX_Cips_UpazillaId";
       BEN            postgres    false    450            �           1259    37314 2   IX_CommitteeManagementMember_CommitteeManagementId    INDEX     �   CREATE INDEX "IX_CommitteeManagementMember_CommitteeManagementId" ON "BEN"."CommitteeManagementMember" USING btree ("CommitteeManagementId");
 G   DROP INDEX "BEN"."IX_CommitteeManagementMember_CommitteeManagementId";
       BEN            postgres    false    490            �           1259    37315 3   IX_CommitteeManagementMember_OtherCommitteeMemberId    INDEX     �   CREATE INDEX "IX_CommitteeManagementMember_OtherCommitteeMemberId" ON "BEN"."CommitteeManagementMember" USING btree ("OtherCommitteeMemberId");
 H   DROP INDEX "BEN"."IX_CommitteeManagementMember_OtherCommitteeMemberId";
       BEN            postgres    false    490            �           1259    37316 6   IX_CommitteeManagementMember_SubCommitteeDesignationId    INDEX     �   CREATE INDEX "IX_CommitteeManagementMember_SubCommitteeDesignationId" ON "BEN"."CommitteeManagementMember" USING btree ("SubCommitteeDesignationId");
 K   DROP INDEX "BEN"."IX_CommitteeManagementMember_SubCommitteeDesignationId";
       BEN            postgres    false    490            �           1259    37317 %   IX_CommitteeManagementMember_SurveyId    INDEX     t   CREATE INDEX "IX_CommitteeManagementMember_SurveyId" ON "BEN"."CommitteeManagementMember" USING btree ("SurveyId");
 :   DROP INDEX "BEN"."IX_CommitteeManagementMember_SurveyId";
       BEN            postgres    false    490            �           1259    37305 !   IX_CommitteeManagement_DistrictId    INDEX     l   CREATE INDEX "IX_CommitteeManagement_DistrictId" ON "BEN"."CommitteeManagement" USING btree ("DistrictId");
 6   DROP INDEX "BEN"."IX_CommitteeManagement_DistrictId";
       BEN            postgres    false    488            �           1259    37306 !   IX_CommitteeManagement_DivisionId    INDEX     l   CREATE INDEX "IX_CommitteeManagement_DivisionId" ON "BEN"."CommitteeManagement" USING btree ("DivisionId");
 6   DROP INDEX "BEN"."IX_CommitteeManagement_DivisionId";
       BEN            postgres    false    488            �           1259    37307 #   IX_CommitteeManagement_ForestBeatId    INDEX     p   CREATE INDEX "IX_CommitteeManagement_ForestBeatId" ON "BEN"."CommitteeManagement" USING btree ("ForestBeatId");
 8   DROP INDEX "BEN"."IX_CommitteeManagement_ForestBeatId";
       BEN            postgres    false    488            �           1259    37308 %   IX_CommitteeManagement_ForestCircleId    INDEX     t   CREATE INDEX "IX_CommitteeManagement_ForestCircleId" ON "BEN"."CommitteeManagement" USING btree ("ForestCircleId");
 :   DROP INDEX "BEN"."IX_CommitteeManagement_ForestCircleId";
       BEN            postgres    false    488            �           1259    37309 '   IX_CommitteeManagement_ForestDivisionId    INDEX     x   CREATE INDEX "IX_CommitteeManagement_ForestDivisionId" ON "BEN"."CommitteeManagement" USING btree ("ForestDivisionId");
 <   DROP INDEX "BEN"."IX_CommitteeManagement_ForestDivisionId";
       BEN            postgres    false    488            �           1259    37310 $   IX_CommitteeManagement_ForestRangeId    INDEX     r   CREATE INDEX "IX_CommitteeManagement_ForestRangeId" ON "BEN"."CommitteeManagement" USING btree ("ForestRangeId");
 9   DROP INDEX "BEN"."IX_CommitteeManagement_ForestRangeId";
       BEN            postgres    false    488            �           1259    37311    IX_CommitteeManagement_NgoId    INDEX     b   CREATE INDEX "IX_CommitteeManagement_NgoId" ON "BEN"."CommitteeManagement" USING btree ("NgoId");
 1   DROP INDEX "BEN"."IX_CommitteeManagement_NgoId";
       BEN            postgres    false    488            �           1259    37312    IX_CommitteeManagement_UnionId    INDEX     f   CREATE INDEX "IX_CommitteeManagement_UnionId" ON "BEN"."CommitteeManagement" USING btree ("UnionId");
 3   DROP INDEX "BEN"."IX_CommitteeManagement_UnionId";
       BEN            postgres    false    488            �           1259    37313 !   IX_CommitteeManagement_UpazillaId    INDEX     l   CREATE INDEX "IX_CommitteeManagement_UpazillaId" ON "BEN"."CommitteeManagement" USING btree ("UpazillaId");
 6   DROP INDEX "BEN"."IX_CommitteeManagement_UpazillaId";
       BEN            postgres    false    488                       1259    34003 6   IX_DisabilityTypeHouseholdMembersMaps_DisabilityTypeId    INDEX     �   CREATE INDEX "IX_DisabilityTypeHouseholdMembersMaps_DisabilityTypeId" ON "BEN"."DisabilityTypeHouseholdMembersMaps" USING btree ("DisabilityTypeId");
 K   DROP INDEX "BEN"."IX_DisabilityTypeHouseholdMembersMaps_DisabilityTypeId";
       BEN            postgres    false    334                       1259    33848 7   IX_DisabilityTypeHouseholdMembersMaps_HouseholdMemberId    INDEX     �   CREATE INDEX "IX_DisabilityTypeHouseholdMembersMaps_HouseholdMemberId" ON "BEN"."DisabilityTypeHouseholdMembersMaps" USING btree ("HouseholdMemberId");
 L   DROP INDEX "BEN"."IX_DisabilityTypeHouseholdMembersMaps_HouseholdMemberId";
       BEN            postgres    false    334            �           1259    33849    IX_EnergyUses_EnergyTypeId    INDEX     ^   CREATE INDEX "IX_EnergyUses_EnergyTypeId" ON "BEN"."EnergyUses" USING btree ("EnergyTypeId");
 /   DROP INDEX "BEN"."IX_EnergyUses_EnergyTypeId";
       BEN            postgres    false    310            �           1259    33850    IX_EnergyUses_SurveyId    INDEX     V   CREATE INDEX "IX_EnergyUses_SurveyId" ON "BEN"."EnergyUses" USING btree ("SurveyId");
 +   DROP INDEX "BEN"."IX_EnergyUses_SurveyId";
       BEN            postgres    false    310            M           1259    34603     IX_ExecutiveCommittee_DistrictId    INDEX     j   CREATE INDEX "IX_ExecutiveCommittee_DistrictId" ON "BEN"."ExecutiveCommittee" USING btree ("DistrictId");
 5   DROP INDEX "BEN"."IX_ExecutiveCommittee_DistrictId";
       BEN            postgres    false    368            N           1259    34604     IX_ExecutiveCommittee_DivisionId    INDEX     j   CREATE INDEX "IX_ExecutiveCommittee_DivisionId" ON "BEN"."ExecutiveCommittee" USING btree ("DivisionId");
 5   DROP INDEX "BEN"."IX_ExecutiveCommittee_DivisionId";
       BEN            postgres    false    368            O           1259    34376 !   IX_ExecutiveCommittee_EthnicityId    INDEX     l   CREATE INDEX "IX_ExecutiveCommittee_EthnicityId" ON "BEN"."ExecutiveCommittee" USING btree ("EthnicityId");
 6   DROP INDEX "BEN"."IX_ExecutiveCommittee_EthnicityId";
       BEN            postgres    false    368            P           1259    34442 "   IX_ExecutiveCommittee_ForestBeatId    INDEX     n   CREATE INDEX "IX_ExecutiveCommittee_ForestBeatId" ON "BEN"."ExecutiveCommittee" USING btree ("ForestBeatId");
 7   DROP INDEX "BEN"."IX_ExecutiveCommittee_ForestBeatId";
       BEN            postgres    false    368            Q           1259    34375 $   IX_ExecutiveCommittee_ForestCircleId    INDEX     r   CREATE INDEX "IX_ExecutiveCommittee_ForestCircleId" ON "BEN"."ExecutiveCommittee" USING btree ("ForestCircleId");
 9   DROP INDEX "BEN"."IX_ExecutiveCommittee_ForestCircleId";
       BEN            postgres    false    368            R           1259    34378 &   IX_ExecutiveCommittee_ForestDivisionId    INDEX     v   CREATE INDEX "IX_ExecutiveCommittee_ForestDivisionId" ON "BEN"."ExecutiveCommittee" USING btree ("ForestDivisionId");
 ;   DROP INDEX "BEN"."IX_ExecutiveCommittee_ForestDivisionId";
       BEN            postgres    false    368            S           1259    34377 $   IX_ExecutiveCommittee_ForestFcvVcfId    INDEX     r   CREATE INDEX "IX_ExecutiveCommittee_ForestFcvVcfId" ON "BEN"."ExecutiveCommittee" USING btree ("ForestFcvVcfId");
 9   DROP INDEX "BEN"."IX_ExecutiveCommittee_ForestFcvVcfId";
       BEN            postgres    false    368            T           1259    34381 #   IX_ExecutiveCommittee_ForestRangeId    INDEX     p   CREATE INDEX "IX_ExecutiveCommittee_ForestRangeId" ON "BEN"."ExecutiveCommittee" USING btree ("ForestRangeId");
 8   DROP INDEX "BEN"."IX_ExecutiveCommittee_ForestRangeId";
       BEN            postgres    false    368            U           1259    34379    IX_ExecutiveCommittee_NgoId    INDEX     `   CREATE INDEX "IX_ExecutiveCommittee_NgoId" ON "BEN"."ExecutiveCommittee" USING btree ("NgoId");
 0   DROP INDEX "BEN"."IX_ExecutiveCommittee_NgoId";
       BEN            postgres    false    368            V           1259    34380 %   IX_ExecutiveCommittee_OfficeBearersId    INDEX     t   CREATE INDEX "IX_ExecutiveCommittee_OfficeBearersId" ON "BEN"."ExecutiveCommittee" USING btree ("OfficeBearersId");
 :   DROP INDEX "BEN"."IX_ExecutiveCommittee_OfficeBearersId";
       BEN            postgres    false    368            W           1259    34561 #   IX_ExecutiveCommittee_OtherMemberId    INDEX     p   CREATE INDEX "IX_ExecutiveCommittee_OtherMemberId" ON "BEN"."ExecutiveCommittee" USING btree ("OtherMemberId");
 8   DROP INDEX "BEN"."IX_ExecutiveCommittee_OtherMemberId";
       BEN            postgres    false    368            X           1259    34583 /   IX_ExecutiveCommittee_SubCommitteeDesignationId    INDEX     �   CREATE INDEX "IX_ExecutiveCommittee_SubCommitteeDesignationId" ON "BEN"."ExecutiveCommittee" USING btree ("SubCommitteeDesignationId");
 D   DROP INDEX "BEN"."IX_ExecutiveCommittee_SubCommitteeDesignationId";
       BEN            postgres    false    368            Y           1259    36101    IX_ExecutiveCommittee_UnionId    INDEX     d   CREATE INDEX "IX_ExecutiveCommittee_UnionId" ON "BEN"."ExecutiveCommittee" USING btree ("UnionId");
 2   DROP INDEX "BEN"."IX_ExecutiveCommittee_UnionId";
       BEN            postgres    false    368            Z           1259    34605     IX_ExecutiveCommittee_UpazillaId    INDEX     j   CREATE INDEX "IX_ExecutiveCommittee_UpazillaId" ON "BEN"."ExecutiveCommittee" USING btree ("UpazillaId");
 5   DROP INDEX "BEN"."IX_ExecutiveCommittee_UpazillaId";
       BEN            postgres    false    368            �           1259    33851    IX_ExistingSkills_SurveyId    INDEX     ^   CREATE INDEX "IX_ExistingSkills_SurveyId" ON "BEN"."ExistingSkills" USING btree ("SurveyId");
 /   DROP INDEX "BEN"."IX_ExistingSkills_SurveyId";
       BEN            postgres    false    312            J           1259    34349 $   IX_FcvExecutiveCommitteeMember_NgoId    INDEX     r   CREATE INDEX "IX_FcvExecutiveCommitteeMember_NgoId" ON "BEN"."FcvExecutiveCommitteeMember" USING btree ("NgoId");
 9   DROP INDEX "BEN"."IX_FcvExecutiveCommitteeMember_NgoId";
       BEN            postgres    false    366            �           1259    33852    IX_FoodSecurityItems_FoodItemId    INDEX     h   CREATE INDEX "IX_FoodSecurityItems_FoodItemId" ON "BEN"."FoodSecurityItems" USING btree ("FoodItemId");
 4   DROP INDEX "BEN"."IX_FoodSecurityItems_FoodItemId";
       BEN            postgres    false    314            �           1259    33853    IX_FoodSecurityItems_SurveyId    INDEX     d   CREATE INDEX "IX_FoodSecurityItems_SurveyId" ON "BEN"."FoodSecurityItems" USING btree ("SurveyId");
 2   DROP INDEX "BEN"."IX_FoodSecurityItems_SurveyId";
       BEN            postgres    false    314            �           1259    33854    IX_ForestBeats_ForestRangeId    INDEX     b   CREATE INDEX "IX_ForestBeats_ForestRangeId" ON "BEN"."ForestBeats" USING btree ("ForestRangeId");
 1   DROP INDEX "BEN"."IX_ForestBeats_ForestRangeId";
       BEN            postgres    false    298            �           1259    33855 !   IX_ForestDivisions_ForestCircleId    INDEX     l   CREATE INDEX "IX_ForestDivisions_ForestCircleId" ON "BEN"."ForestDivisions" USING btree ("ForestCircleId");
 6   DROP INDEX "BEN"."IX_ForestDivisions_ForestCircleId";
       BEN            postgres    false    288            �           1259    33857    IX_ForestFcvVcfs_ForestBeatId    INDEX     d   CREATE INDEX "IX_ForestFcvVcfs_ForestBeatId" ON "BEN"."ForestFcvVcfs" USING btree ("ForestBeatId");
 2   DROP INDEX "BEN"."IX_ForestFcvVcfs_ForestBeatId";
       BEN            postgres    false    300            �           1259    33858     IX_ForestRanges_ForestDivisionId    INDEX     j   CREATE INDEX "IX_ForestRanges_ForestDivisionId" ON "BEN"."ForestRanges" USING btree ("ForestDivisionId");
 5   DROP INDEX "BEN"."IX_ForestRanges_ForestDivisionId";
       BEN            postgres    false    294            �           1259    33859 ,   IX_GrossMarginIncomeAndCostStatuses_SurveyId    INDEX     �   CREATE INDEX "IX_GrossMarginIncomeAndCostStatuses_SurveyId" ON "BEN"."GrossMarginIncomeAndCostStatuses" USING btree ("SurveyId");
 A   DROP INDEX "BEN"."IX_GrossMarginIncomeAndCostStatuses_SurveyId";
       BEN            postgres    false    316            �           1259    33860 $   IX_HouseholdMembers_MainOccupationId    INDEX     r   CREATE INDEX "IX_HouseholdMembers_MainOccupationId" ON "BEN"."HouseholdMembers" USING btree ("MainOccupationId");
 9   DROP INDEX "BEN"."IX_HouseholdMembers_MainOccupationId";
       BEN            postgres    false    318            �           1259    33861 3   IX_HouseholdMembers_RelationWithHeadHouseHoldTypeId    INDEX     �   CREATE INDEX "IX_HouseholdMembers_RelationWithHeadHouseHoldTypeId" ON "BEN"."HouseholdMembers" USING btree ("RelationWithHeadHouseHoldTypeId");
 H   DROP INDEX "BEN"."IX_HouseholdMembers_RelationWithHeadHouseHoldTypeId";
       BEN            postgres    false    318            �           1259    33862 #   IX_HouseholdMembers_SafetyNetTypeId    INDEX     p   CREATE INDEX "IX_HouseholdMembers_SafetyNetTypeId" ON "BEN"."HouseholdMembers" USING btree ("SafetyNetTypeId");
 8   DROP INDEX "BEN"."IX_HouseholdMembers_SafetyNetTypeId";
       BEN            postgres    false    318            �           1259    33863 )   IX_HouseholdMembers_SecondaryOccupationId    INDEX     |   CREATE INDEX "IX_HouseholdMembers_SecondaryOccupationId" ON "BEN"."HouseholdMembers" USING btree ("SecondaryOccupationId");
 >   DROP INDEX "BEN"."IX_HouseholdMembers_SecondaryOccupationId";
       BEN            postgres    false    318            �           1259    33864    IX_HouseholdMembers_SurveyId    INDEX     b   CREATE INDEX "IX_HouseholdMembers_SurveyId" ON "BEN"."HouseholdMembers" USING btree ("SurveyId");
 1   DROP INDEX "BEN"."IX_HouseholdMembers_SurveyId";
       BEN            postgres    false    318            �           1259    33865 '   IX_ImmovableAssets_ImmovableAssetTypeId    INDEX     x   CREATE INDEX "IX_ImmovableAssets_ImmovableAssetTypeId" ON "BEN"."ImmovableAssets" USING btree ("ImmovableAssetTypeId");
 <   DROP INDEX "BEN"."IX_ImmovableAssets_ImmovableAssetTypeId";
       BEN            postgres    false    320            �           1259    33866    IX_ImmovableAssets_SurveyId    INDEX     `   CREATE INDEX "IX_ImmovableAssets_SurveyId" ON "BEN"."ImmovableAssets" USING btree ("SurveyId");
 0   DROP INDEX "BEN"."IX_ImmovableAssets_SurveyId";
       BEN            postgres    false    320            �           1259    33867    IX_LandOccupancies_SurveyId    INDEX     `   CREATE INDEX "IX_LandOccupancies_SurveyId" ON "BEN"."LandOccupancies" USING btree ("SurveyId");
 0   DROP INDEX "BEN"."IX_LandOccupancies_SurveyId";
       BEN            postgres    false    322            �           1259    33868    IX_LiveStocks_LiveStockTypeId    INDEX     d   CREATE INDEX "IX_LiveStocks_LiveStockTypeId" ON "BEN"."LiveStocks" USING btree ("LiveStockTypeId");
 2   DROP INDEX "BEN"."IX_LiveStocks_LiveStockTypeId";
       BEN            postgres    false    324            �           1259    33869    IX_LiveStocks_SurveyId    INDEX     V   CREATE INDEX "IX_LiveStocks_SurveyId" ON "BEN"."LiveStocks" USING btree ("SurveyId");
 +   DROP INDEX "BEN"."IX_LiveStocks_SurveyId";
       BEN            postgres    false    324            �           1259    33870 /   IX_ManualPhysicalWorks_ManualIncomeSourceTypeId    INDEX     �   CREATE INDEX "IX_ManualPhysicalWorks_ManualIncomeSourceTypeId" ON "BEN"."ManualPhysicalWorks" USING btree ("ManualIncomeSourceTypeId");
 D   DROP INDEX "BEN"."IX_ManualPhysicalWorks_ManualIncomeSourceTypeId";
       BEN            postgres    false    326            �           1259    33871    IX_ManualPhysicalWorks_SurveyId    INDEX     h   CREATE INDEX "IX_ManualPhysicalWorks_SurveyId" ON "BEN"."ManualPhysicalWorks" USING btree ("SurveyId");
 4   DROP INDEX "BEN"."IX_ManualPhysicalWorks_SurveyId";
       BEN            postgres    false    326            �           1259    33872 ?   IX_NaturalResourcesIncomeAndCostStatuses_NaturalIncomeSourceTy~    INDEX     �   CREATE INDEX "IX_NaturalResourcesIncomeAndCostStatuses_NaturalIncomeSourceTy~" ON "BEN"."NaturalResourcesIncomeAndCostStatuses" USING btree ("NaturalIncomeSourceTypeId");
 T   DROP INDEX "BEN"."IX_NaturalResourcesIncomeAndCostStatuses_NaturalIncomeSourceTy~";
       BEN            postgres    false    328            �           1259    33873 1   IX_NaturalResourcesIncomeAndCostStatuses_SurveyId    INDEX     �   CREATE INDEX "IX_NaturalResourcesIncomeAndCostStatuses_SurveyId" ON "BEN"."NaturalResourcesIncomeAndCostStatuses" USING btree ("SurveyId");
 F   DROP INDEX "BEN"."IX_NaturalResourcesIncomeAndCostStatuses_SurveyId";
       BEN            postgres    false    328            ]           1259    34596 #   IX_OtherCommitteeMembers_DistrictId    INDEX     p   CREATE INDEX "IX_OtherCommitteeMembers_DistrictId" ON "BEN"."OtherCommitteeMembers" USING btree ("DistrictId");
 8   DROP INDEX "BEN"."IX_OtherCommitteeMembers_DistrictId";
       BEN            postgres    false    370            ^           1259    34597 #   IX_OtherCommitteeMembers_DivisionId    INDEX     p   CREATE INDEX "IX_OtherCommitteeMembers_DivisionId" ON "BEN"."OtherCommitteeMembers" USING btree ("DivisionId");
 8   DROP INDEX "BEN"."IX_OtherCommitteeMembers_DivisionId";
       BEN            postgres    false    370            _           1259    34440 $   IX_OtherCommitteeMembers_EthnicityId    INDEX     r   CREATE INDEX "IX_OtherCommitteeMembers_EthnicityId" ON "BEN"."OtherCommitteeMembers" USING btree ("EthnicityId");
 9   DROP INDEX "BEN"."IX_OtherCommitteeMembers_EthnicityId";
       BEN            postgres    false    370            `           1259    34598 %   IX_OtherCommitteeMembers_ForestBeatId    INDEX     t   CREATE INDEX "IX_OtherCommitteeMembers_ForestBeatId" ON "BEN"."OtherCommitteeMembers" USING btree ("ForestBeatId");
 :   DROP INDEX "BEN"."IX_OtherCommitteeMembers_ForestBeatId";
       BEN            postgres    false    370            a           1259    34599 '   IX_OtherCommitteeMembers_ForestCircleId    INDEX     x   CREATE INDEX "IX_OtherCommitteeMembers_ForestCircleId" ON "BEN"."OtherCommitteeMembers" USING btree ("ForestCircleId");
 <   DROP INDEX "BEN"."IX_OtherCommitteeMembers_ForestCircleId";
       BEN            postgres    false    370            b           1259    34600 )   IX_OtherCommitteeMembers_ForestDivisionId    INDEX     |   CREATE INDEX "IX_OtherCommitteeMembers_ForestDivisionId" ON "BEN"."OtherCommitteeMembers" USING btree ("ForestDivisionId");
 >   DROP INDEX "BEN"."IX_OtherCommitteeMembers_ForestDivisionId";
       BEN            postgres    false    370            c           1259    34441 '   IX_OtherCommitteeMembers_ForestFcvVcfId    INDEX     x   CREATE INDEX "IX_OtherCommitteeMembers_ForestFcvVcfId" ON "BEN"."OtherCommitteeMembers" USING btree ("ForestFcvVcfId");
 <   DROP INDEX "BEN"."IX_OtherCommitteeMembers_ForestFcvVcfId";
       BEN            postgres    false    370            d           1259    34601 &   IX_OtherCommitteeMembers_ForestRangeId    INDEX     v   CREATE INDEX "IX_OtherCommitteeMembers_ForestRangeId" ON "BEN"."OtherCommitteeMembers" USING btree ("ForestRangeId");
 ;   DROP INDEX "BEN"."IX_OtherCommitteeMembers_ForestRangeId";
       BEN            postgres    false    370            e           1259    36811     IX_OtherCommitteeMembers_UnionId    INDEX     j   CREATE INDEX "IX_OtherCommitteeMembers_UnionId" ON "BEN"."OtherCommitteeMembers" USING btree ("UnionId");
 5   DROP INDEX "BEN"."IX_OtherCommitteeMembers_UnionId";
       BEN            postgres    false    370            f           1259    34602 #   IX_OtherCommitteeMembers_UpazillaId    INDEX     p   CREATE INDEX "IX_OtherCommitteeMembers_UpazillaId" ON "BEN"."OtherCommitteeMembers" USING btree ("UpazillaId");
 8   DROP INDEX "BEN"."IX_OtherCommitteeMembers_UpazillaId";
       BEN            postgres    false    370            �           1259    33874 -   IX_OtherIncomeSources_OtherIncomeSourceTypeId    INDEX     �   CREATE INDEX "IX_OtherIncomeSources_OtherIncomeSourceTypeId" ON "BEN"."OtherIncomeSources" USING btree ("OtherIncomeSourceTypeId");
 B   DROP INDEX "BEN"."IX_OtherIncomeSources_OtherIncomeSourceTypeId";
       BEN            postgres    false    330            �           1259    33875    IX_OtherIncomeSources_SurveyId    INDEX     f   CREATE INDEX "IX_OtherIncomeSources_SurveyId" ON "BEN"."OtherIncomeSources" USING btree ("SurveyId");
 3   DROP INDEX "BEN"."IX_OtherIncomeSources_SurveyId";
       BEN            postgres    false    330            �           1259    35740    IX_SurveyDocuments_SurveyId    INDEX     `   CREATE INDEX "IX_SurveyDocuments_SurveyId" ON "BEN"."SurveyDocuments" USING btree ("SurveyId");
 0   DROP INDEX "BEN"."IX_SurveyDocuments_SurveyId";
       BEN            postgres    false    424            �           1259    37177    IX_SurveyIncidents_SurveyId    INDEX     `   CREATE INDEX "IX_SurveyIncidents_SurveyId" ON "BEN"."SurveyIncidents" USING btree ("SurveyId");
 0   DROP INDEX "BEN"."IX_SurveyIncidents_SurveyId";
       BEN            postgres    false    486            �           1259    36732 '   IX_Surveys_BeneficiaryApproveStatusById    INDEX     x   CREATE INDEX "IX_Surveys_BeneficiaryApproveStatusById" ON "BEN"."Surveys" USING btree ("BeneficiaryApproveStatusById");
 <   DROP INDEX "BEN"."IX_Surveys_BeneficiaryApproveStatusById";
       BEN            postgres    false    302            �           1259    33876 !   IX_Surveys_BeneficiaryEthnicityId    INDEX     l   CREATE INDEX "IX_Surveys_BeneficiaryEthnicityId" ON "BEN"."Surveys" USING btree ("BeneficiaryEthnicityId");
 6   DROP INDEX "BEN"."IX_Surveys_BeneficiaryEthnicityId";
       BEN            postgres    false    302            �           1259    37084    IX_Surveys_BeneficiaryId    INDEX     Z   CREATE INDEX "IX_Surveys_BeneficiaryId" ON "BEN"."Surveys" USING btree ("BeneficiaryId");
 -   DROP INDEX "BEN"."IX_Surveys_BeneficiaryId";
       BEN            postgres    false    302            �           1259    37109    IX_Surveys_CipId    INDEX     Q   CREATE UNIQUE INDEX "IX_Surveys_CipId" ON "BEN"."Surveys" USING btree ("CipId");
 %   DROP INDEX "BEN"."IX_Surveys_CipId";
       BEN            postgres    false    302            �           1259    33877    IX_Surveys_ForestBeatId    INDEX     X   CREATE INDEX "IX_Surveys_ForestBeatId" ON "BEN"."Surveys" USING btree ("ForestBeatId");
 ,   DROP INDEX "BEN"."IX_Surveys_ForestBeatId";
       BEN            postgres    false    302            �           1259    33878    IX_Surveys_ForestCircleId    INDEX     \   CREATE INDEX "IX_Surveys_ForestCircleId" ON "BEN"."Surveys" USING btree ("ForestCircleId");
 .   DROP INDEX "BEN"."IX_Surveys_ForestCircleId";
       BEN            postgres    false    302            �           1259    33879    IX_Surveys_ForestDivisionId    INDEX     `   CREATE INDEX "IX_Surveys_ForestDivisionId" ON "BEN"."Surveys" USING btree ("ForestDivisionId");
 0   DROP INDEX "BEN"."IX_Surveys_ForestDivisionId";
       BEN            postgres    false    302            �           1259    33880    IX_Surveys_ForestFcvVcfId    INDEX     \   CREATE INDEX "IX_Surveys_ForestFcvVcfId" ON "BEN"."Surveys" USING btree ("ForestFcvVcfId");
 .   DROP INDEX "BEN"."IX_Surveys_ForestFcvVcfId";
       BEN            postgres    false    302            �           1259    33881    IX_Surveys_ForestRangeId    INDEX     Z   CREATE INDEX "IX_Surveys_ForestRangeId" ON "BEN"."Surveys" USING btree ("ForestRangeId");
 -   DROP INDEX "BEN"."IX_Surveys_ForestRangeId";
       BEN            postgres    false    302            �           1259    35680    IX_Surveys_NgoId    INDEX     J   CREATE INDEX "IX_Surveys_NgoId" ON "BEN"."Surveys" USING btree ("NgoId");
 %   DROP INDEX "BEN"."IX_Surveys_NgoId";
       BEN            postgres    false    302            �           1259    33882    IX_Surveys_PermanentDistrictId    INDEX     f   CREATE INDEX "IX_Surveys_PermanentDistrictId" ON "BEN"."Surveys" USING btree ("PermanentDistrictId");
 3   DROP INDEX "BEN"."IX_Surveys_PermanentDistrictId";
       BEN            postgres    false    302            �           1259    33883    IX_Surveys_PermanentDivisionId    INDEX     f   CREATE INDEX "IX_Surveys_PermanentDivisionId" ON "BEN"."Surveys" USING btree ("PermanentDivisionId");
 3   DROP INDEX "BEN"."IX_Surveys_PermanentDivisionId";
       BEN            postgres    false    302            �           1259    35681    IX_Surveys_PermanentUnionNewId    INDEX     f   CREATE INDEX "IX_Surveys_PermanentUnionNewId" ON "BEN"."Surveys" USING btree ("PermanentUnionNewId");
 3   DROP INDEX "BEN"."IX_Surveys_PermanentUnionNewId";
       BEN            postgres    false    302            �           1259    33884    IX_Surveys_PermanentUpazillaId    INDEX     f   CREATE INDEX "IX_Surveys_PermanentUpazillaId" ON "BEN"."Surveys" USING btree ("PermanentUpazillaId");
 3   DROP INDEX "BEN"."IX_Surveys_PermanentUpazillaId";
       BEN            postgres    false    302            �           1259    33885    IX_Surveys_PresentDistrictId    INDEX     b   CREATE INDEX "IX_Surveys_PresentDistrictId" ON "BEN"."Surveys" USING btree ("PresentDistrictId");
 1   DROP INDEX "BEN"."IX_Surveys_PresentDistrictId";
       BEN            postgres    false    302            �           1259    33886    IX_Surveys_PresentDivisionId    INDEX     b   CREATE INDEX "IX_Surveys_PresentDivisionId" ON "BEN"."Surveys" USING btree ("PresentDivisionId");
 1   DROP INDEX "BEN"."IX_Surveys_PresentDivisionId";
       BEN            postgres    false    302            �           1259    35682    IX_Surveys_PresentUnionNewId    INDEX     b   CREATE INDEX "IX_Surveys_PresentUnionNewId" ON "BEN"."Surveys" USING btree ("PresentUnionNewId");
 1   DROP INDEX "BEN"."IX_Surveys_PresentUnionNewId";
       BEN            postgres    false    302            �           1259    33887    IX_Surveys_PresentUpazillaId    INDEX     b   CREATE INDEX "IX_Surveys_PresentUpazillaId" ON "BEN"."Surveys" USING btree ("PresentUpazillaId");
 1   DROP INDEX "BEN"."IX_Surveys_PresentUpazillaId";
       BEN            postgres    false    302            �           1259    33888 #   IX_VulnerabilitySituations_SurveyId    INDEX     p   CREATE INDEX "IX_VulnerabilitySituations_SurveyId" ON "BEN"."VulnerabilitySituations" USING btree ("SurveyId");
 8   DROP INDEX "BEN"."IX_VulnerabilitySituations_SurveyId";
       BEN            postgres    false    332                        1259    33889 7   IX_VulnerabilitySituations_VulnerabilitySituationTypeId    INDEX     �   CREATE INDEX "IX_VulnerabilitySituations_VulnerabilitySituationTypeId" ON "BEN"."VulnerabilitySituations" USING btree ("VulnerabilitySituationTypeId");
 L   DROP INDEX "BEN"."IX_VulnerabilitySituations_VulnerabilitySituationTypeId";
       BEN            postgres    false    332            �           1259    35111    IX_SavingsAccount_DistrictId    INDEX     b   CREATE INDEX "IX_SavingsAccount_DistrictId" ON "BSA"."SavingsAccount" USING btree ("DistrictId");
 1   DROP INDEX "BSA"."IX_SavingsAccount_DistrictId";
       BSA            postgres    false    398            �           1259    35112    IX_SavingsAccount_DivisionId    INDEX     b   CREATE INDEX "IX_SavingsAccount_DivisionId" ON "BSA"."SavingsAccount" USING btree ("DivisionId");
 1   DROP INDEX "BSA"."IX_SavingsAccount_DivisionId";
       BSA            postgres    false    398            �           1259    35113    IX_SavingsAccount_ForestBeatId    INDEX     f   CREATE INDEX "IX_SavingsAccount_ForestBeatId" ON "BSA"."SavingsAccount" USING btree ("ForestBeatId");
 3   DROP INDEX "BSA"."IX_SavingsAccount_ForestBeatId";
       BSA            postgres    false    398            �           1259    35114     IX_SavingsAccount_ForestCircleId    INDEX     j   CREATE INDEX "IX_SavingsAccount_ForestCircleId" ON "BSA"."SavingsAccount" USING btree ("ForestCircleId");
 5   DROP INDEX "BSA"."IX_SavingsAccount_ForestCircleId";
       BSA            postgres    false    398            �           1259    35115 "   IX_SavingsAccount_ForestDivisionId    INDEX     n   CREATE INDEX "IX_SavingsAccount_ForestDivisionId" ON "BSA"."SavingsAccount" USING btree ("ForestDivisionId");
 7   DROP INDEX "BSA"."IX_SavingsAccount_ForestDivisionId";
       BSA            postgres    false    398            �           1259    35116    IX_SavingsAccount_ForestRangeId    INDEX     h   CREATE INDEX "IX_SavingsAccount_ForestRangeId" ON "BSA"."SavingsAccount" USING btree ("ForestRangeId");
 4   DROP INDEX "BSA"."IX_SavingsAccount_ForestRangeId";
       BSA            postgres    false    398            �           1259    35117    IX_SavingsAccount_NgoId    INDEX     X   CREATE INDEX "IX_SavingsAccount_NgoId" ON "BSA"."SavingsAccount" USING btree ("NgoId");
 ,   DROP INDEX "BSA"."IX_SavingsAccount_NgoId";
       BSA            postgres    false    398            �           1259    35118    IX_SavingsAccount_SurveyId    INDEX     ^   CREATE INDEX "IX_SavingsAccount_SurveyId" ON "BSA"."SavingsAccount" USING btree ("SurveyId");
 /   DROP INDEX "BSA"."IX_SavingsAccount_SurveyId";
       BSA            postgres    false    398            �           1259    35698    IX_SavingsAccount_UnionId    INDEX     \   CREATE INDEX "IX_SavingsAccount_UnionId" ON "BSA"."SavingsAccount" USING btree ("UnionId");
 .   DROP INDEX "BSA"."IX_SavingsAccount_UnionId";
       BSA            postgres    false    398            �           1259    35119    IX_SavingsAccount_UpazillaId    INDEX     b   CREATE INDEX "IX_SavingsAccount_UpazillaId" ON "BSA"."SavingsAccount" USING btree ("UpazillaId");
 1   DROP INDEX "BSA"."IX_SavingsAccount_UpazillaId";
       BSA            postgres    false    398            �           1259    35148 ,   IX_SavingsAmountInformation_SavingsAccountId    INDEX     �   CREATE INDEX "IX_SavingsAmountInformation_SavingsAccountId" ON "BSA"."SavingsAmountInformation" USING btree ("SavingsAccountId");
 A   DROP INDEX "BSA"."IX_SavingsAmountInformation_SavingsAccountId";
       BSA            postgres    false    400            �           1259    35149 -   IX_WithdrawAmountInformation_SavingsAccountId    INDEX     �   CREATE INDEX "IX_WithdrawAmountInformation_SavingsAccountId" ON "BSA"."WithdrawAmountInformation" USING btree ("SavingsAccountId");
 B   DROP INDEX "BSA"."IX_WithdrawAmountInformation_SavingsAccountId";
       BSA            postgres    false    402            -           1259    34289 -   IX_CommunityTrainingFiles_CommunityTrainingId    INDEX     �   CREATE INDEX "IX_CommunityTrainingFiles_CommunityTrainingId" ON "Capacity"."CommunityTrainingFiles" USING btree ("CommunityTrainingId");
 G   DROP INDEX "Capacity"."IX_CommunityTrainingFiles_CommunityTrainingId";
       Capacity            postgres    false    354                       1259    34288 8   IX_CommunityTrainingParticipentsMaps_CommunityTrainingId    INDEX     �   CREATE INDEX "IX_CommunityTrainingParticipentsMaps_CommunityTrainingId" ON "Capacity"."CommunityTrainingParticipentsMaps" USING btree ("CommunityTrainingId");
 R   DROP INDEX "Capacity"."IX_CommunityTrainingParticipentsMaps_CommunityTrainingId";
       Capacity            postgres    false    350                       1259    34153 >   IX_CommunityTrainingParticipentsMaps_CommunityTrainingMemberId    INDEX     �   CREATE INDEX "IX_CommunityTrainingParticipentsMaps_CommunityTrainingMemberId" ON "Capacity"."CommunityTrainingParticipentsMaps" USING btree ("CommunityTrainingMemberId");
 X   DROP INDEX "Capacity"."IX_CommunityTrainingParticipentsMaps_CommunityTrainingMemberId";
       Capacity            postgres    false    350                       1259    34154 -   IX_CommunityTrainingParticipentsMaps_SurveyId    INDEX     �   CREATE INDEX "IX_CommunityTrainingParticipentsMaps_SurveyId" ON "Capacity"."CommunityTrainingParticipentsMaps" USING btree ("SurveyId");
 G   DROP INDEX "Capacity"."IX_CommunityTrainingParticipentsMaps_SurveyId";
       Capacity            postgres    false    350                       1259    34155 -   IX_CommunityTrainings_CommunityTrainingTypeId    INDEX     �   CREATE INDEX "IX_CommunityTrainings_CommunityTrainingTypeId" ON "Capacity"."CommunityTrainings" USING btree ("CommunityTrainingTypeId");
 G   DROP INDEX "Capacity"."IX_CommunityTrainings_CommunityTrainingTypeId";
       Capacity            postgres    false    352                        1259    34156     IX_CommunityTrainings_DistrictId    INDEX     o   CREATE INDEX "IX_CommunityTrainings_DistrictId" ON "Capacity"."CommunityTrainings" USING btree ("DistrictId");
 :   DROP INDEX "Capacity"."IX_CommunityTrainings_DistrictId";
       Capacity            postgres    false    352            !           1259    34157     IX_CommunityTrainings_DivisionId    INDEX     o   CREATE INDEX "IX_CommunityTrainings_DivisionId" ON "Capacity"."CommunityTrainings" USING btree ("DivisionId");
 :   DROP INDEX "Capacity"."IX_CommunityTrainings_DivisionId";
       Capacity            postgres    false    352            "           1259    34158 !   IX_CommunityTrainings_EventTypeId    INDEX     q   CREATE INDEX "IX_CommunityTrainings_EventTypeId" ON "Capacity"."CommunityTrainings" USING btree ("EventTypeId");
 ;   DROP INDEX "Capacity"."IX_CommunityTrainings_EventTypeId";
       Capacity            postgres    false    352            #           1259    34159 "   IX_CommunityTrainings_ForestBeatId    INDEX     s   CREATE INDEX "IX_CommunityTrainings_ForestBeatId" ON "Capacity"."CommunityTrainings" USING btree ("ForestBeatId");
 <   DROP INDEX "Capacity"."IX_CommunityTrainings_ForestBeatId";
       Capacity            postgres    false    352            $           1259    34160 $   IX_CommunityTrainings_ForestCircleId    INDEX     w   CREATE INDEX "IX_CommunityTrainings_ForestCircleId" ON "Capacity"."CommunityTrainings" USING btree ("ForestCircleId");
 >   DROP INDEX "Capacity"."IX_CommunityTrainings_ForestCircleId";
       Capacity            postgres    false    352            %           1259    34161 &   IX_CommunityTrainings_ForestDivisionId    INDEX     {   CREATE INDEX "IX_CommunityTrainings_ForestDivisionId" ON "Capacity"."CommunityTrainings" USING btree ("ForestDivisionId");
 @   DROP INDEX "Capacity"."IX_CommunityTrainings_ForestDivisionId";
       Capacity            postgres    false    352            &           1259    34162 $   IX_CommunityTrainings_ForestFcvVcfId    INDEX     w   CREATE INDEX "IX_CommunityTrainings_ForestFcvVcfId" ON "Capacity"."CommunityTrainings" USING btree ("ForestFcvVcfId");
 >   DROP INDEX "Capacity"."IX_CommunityTrainings_ForestFcvVcfId";
       Capacity            postgres    false    352            '           1259    34163 #   IX_CommunityTrainings_ForestRangeId    INDEX     u   CREATE INDEX "IX_CommunityTrainings_ForestRangeId" ON "Capacity"."CommunityTrainings" USING btree ("ForestRangeId");
 =   DROP INDEX "Capacity"."IX_CommunityTrainings_ForestRangeId";
       Capacity            postgres    false    352            (           1259    34164 )   IX_CommunityTrainings_TrainingOrganizerId    INDEX     �   CREATE INDEX "IX_CommunityTrainings_TrainingOrganizerId" ON "Capacity"."CommunityTrainings" USING btree ("TrainingOrganizerId");
 C   DROP INDEX "Capacity"."IX_CommunityTrainings_TrainingOrganizerId";
       Capacity            postgres    false    352            )           1259    35704    IX_CommunityTrainings_UnionId    INDEX     i   CREATE INDEX "IX_CommunityTrainings_UnionId" ON "Capacity"."CommunityTrainings" USING btree ("UnionId");
 7   DROP INDEX "Capacity"."IX_CommunityTrainings_UnionId";
       Capacity            postgres    false    352            *           1259    34165     IX_CommunityTrainings_UpazillaId    INDEX     o   CREATE INDEX "IX_CommunityTrainings_UpazillaId" ON "Capacity"."CommunityTrainings" USING btree ("UpazillaId");
 :   DROP INDEX "Capacity"."IX_CommunityTrainings_UpazillaId";
       Capacity            postgres    false    352            C           1259    34290 3   IX_DepartmentalTrainingFiles_DepartmentalTrainingId    INDEX     �   CREATE INDEX "IX_DepartmentalTrainingFiles_DepartmentalTrainingId" ON "Capacity"."DepartmentalTrainingFiles" USING btree ("DepartmentalTrainingId");
 M   DROP INDEX "Capacity"."IX_DepartmentalTrainingFiles_DepartmentalTrainingId";
       Capacity            postgres    false    362            0           1259    34907 *   IX_DepartmentalTrainingMembers_EthnicityId    INDEX     �   CREATE INDEX "IX_DepartmentalTrainingMembers_EthnicityId" ON "Capacity"."DepartmentalTrainingMembers" USING btree ("EthnicityId");
 D   DROP INDEX "Capacity"."IX_DepartmentalTrainingMembers_EthnicityId";
       Capacity            postgres    false    356            F           1259    34291 >   IX_DepartmentalTrainingParticipentsMaps_DepartmentalTrainingId    INDEX     �   CREATE INDEX "IX_DepartmentalTrainingParticipentsMaps_DepartmentalTrainingId" ON "Capacity"."DepartmentalTrainingParticipentsMaps" USING btree ("DepartmentalTrainingId");
 X   DROP INDEX "Capacity"."IX_DepartmentalTrainingParticipentsMaps_DepartmentalTrainingId";
       Capacity            postgres    false    364            G           1259    34292 ?   IX_DepartmentalTrainingParticipentsMaps_DepartmentalTrainingMe~    INDEX     �   CREATE INDEX "IX_DepartmentalTrainingParticipentsMaps_DepartmentalTrainingMe~" ON "Capacity"."DepartmentalTrainingParticipentsMaps" USING btree ("DepartmentalTrainingMemberId");
 Y   DROP INDEX "Capacity"."IX_DepartmentalTrainingParticipentsMaps_DepartmentalTrainingMe~";
       Capacity            postgres    false    364            5           1259    34293 3   IX_DepartmentalTrainings_DepartmentalTrainingTypeId    INDEX     �   CREATE INDEX "IX_DepartmentalTrainings_DepartmentalTrainingTypeId" ON "Capacity"."DepartmentalTrainings" USING btree ("DepartmentalTrainingTypeId");
 M   DROP INDEX "Capacity"."IX_DepartmentalTrainings_DepartmentalTrainingTypeId";
       Capacity            postgres    false    360            6           1259    34294 #   IX_DepartmentalTrainings_DistrictId    INDEX     u   CREATE INDEX "IX_DepartmentalTrainings_DistrictId" ON "Capacity"."DepartmentalTrainings" USING btree ("DistrictId");
 =   DROP INDEX "Capacity"."IX_DepartmentalTrainings_DistrictId";
       Capacity            postgres    false    360            7           1259    34295 #   IX_DepartmentalTrainings_DivisionId    INDEX     u   CREATE INDEX "IX_DepartmentalTrainings_DivisionId" ON "Capacity"."DepartmentalTrainings" USING btree ("DivisionId");
 =   DROP INDEX "Capacity"."IX_DepartmentalTrainings_DivisionId";
       Capacity            postgres    false    360            8           1259    34296 $   IX_DepartmentalTrainings_EventTypeId    INDEX     w   CREATE INDEX "IX_DepartmentalTrainings_EventTypeId" ON "Capacity"."DepartmentalTrainings" USING btree ("EventTypeId");
 >   DROP INDEX "Capacity"."IX_DepartmentalTrainings_EventTypeId";
       Capacity            postgres    false    360            9           1259    34992 (   IX_DepartmentalTrainings_FinancialYearId    INDEX        CREATE INDEX "IX_DepartmentalTrainings_FinancialYearId" ON "Capacity"."DepartmentalTrainings" USING btree ("FinancialYearId");
 B   DROP INDEX "Capacity"."IX_DepartmentalTrainings_FinancialYearId";
       Capacity            postgres    false    360            :           1259    34297 %   IX_DepartmentalTrainings_ForestBeatId    INDEX     y   CREATE INDEX "IX_DepartmentalTrainings_ForestBeatId" ON "Capacity"."DepartmentalTrainings" USING btree ("ForestBeatId");
 ?   DROP INDEX "Capacity"."IX_DepartmentalTrainings_ForestBeatId";
       Capacity            postgres    false    360            ;           1259    34298 '   IX_DepartmentalTrainings_ForestCircleId    INDEX     }   CREATE INDEX "IX_DepartmentalTrainings_ForestCircleId" ON "Capacity"."DepartmentalTrainings" USING btree ("ForestCircleId");
 A   DROP INDEX "Capacity"."IX_DepartmentalTrainings_ForestCircleId";
       Capacity            postgres    false    360            <           1259    34299 )   IX_DepartmentalTrainings_ForestDivisionId    INDEX     �   CREATE INDEX "IX_DepartmentalTrainings_ForestDivisionId" ON "Capacity"."DepartmentalTrainings" USING btree ("ForestDivisionId");
 C   DROP INDEX "Capacity"."IX_DepartmentalTrainings_ForestDivisionId";
       Capacity            postgres    false    360            =           1259    34300 '   IX_DepartmentalTrainings_ForestFcvVcfId    INDEX     }   CREATE INDEX "IX_DepartmentalTrainings_ForestFcvVcfId" ON "Capacity"."DepartmentalTrainings" USING btree ("ForestFcvVcfId");
 A   DROP INDEX "Capacity"."IX_DepartmentalTrainings_ForestFcvVcfId";
       Capacity            postgres    false    360            >           1259    34301 &   IX_DepartmentalTrainings_ForestRangeId    INDEX     {   CREATE INDEX "IX_DepartmentalTrainings_ForestRangeId" ON "Capacity"."DepartmentalTrainings" USING btree ("ForestRangeId");
 @   DROP INDEX "Capacity"."IX_DepartmentalTrainings_ForestRangeId";
       Capacity            postgres    false    360            ?           1259    34302 ,   IX_DepartmentalTrainings_TrainingOrganizerId    INDEX     �   CREATE INDEX "IX_DepartmentalTrainings_TrainingOrganizerId" ON "Capacity"."DepartmentalTrainings" USING btree ("TrainingOrganizerId");
 F   DROP INDEX "Capacity"."IX_DepartmentalTrainings_TrainingOrganizerId";
       Capacity            postgres    false    360            @           1259    34303 #   IX_DepartmentalTrainings_UpazillaId    INDEX     u   CREATE INDEX "IX_DepartmentalTrainings_UpazillaId" ON "Capacity"."DepartmentalTrainings" USING btree ("UpazillaId");
 =   DROP INDEX "Capacity"."IX_DepartmentalTrainings_UpazillaId";
       Capacity            postgres    false    360            �           1259    34760 $   IX_MeetingParticipantsMaps_MeetingId    INDEX     w   CREATE INDEX "IX_MeetingParticipantsMaps_MeetingId" ON "Capacity"."MeetingParticipantsMaps" USING btree ("MeetingId");
 >   DROP INDEX "Capacity"."IX_MeetingParticipantsMaps_MeetingId";
       Capacity            postgres    false    384            �           1259    34761 *   IX_MeetingParticipantsMaps_MeetingMemberId    INDEX     �   CREATE INDEX "IX_MeetingParticipantsMaps_MeetingMemberId" ON "Capacity"."MeetingParticipantsMaps" USING btree ("MeetingMemberId");
 D   DROP INDEX "Capacity"."IX_MeetingParticipantsMaps_MeetingMemberId";
       Capacity            postgres    false    384            �           1259    34762 #   IX_MeetingParticipantsMaps_SurveyId    INDEX     u   CREATE INDEX "IX_MeetingParticipantsMaps_SurveyId" ON "Capacity"."MeetingParticipantsMaps" USING btree ("SurveyId");
 =   DROP INDEX "Capacity"."IX_MeetingParticipantsMaps_SurveyId";
       Capacity            postgres    false    384            �           1259    33890    IX_District_DivisionId    INDEX     U   CREATE INDEX "IX_District_DivisionId" ON "GS"."District" USING btree ("DivisionId");
 *   DROP INDEX "GS"."IX_District_DivisionId";
       GS            postgres    false    290                       1259    34040    IX_Union_UpazillaId    INDEX     O   CREATE INDEX "IX_Union_UpazillaId" ON "GS"."Union" USING btree ("UpazillaId");
 '   DROP INDEX "GS"."IX_Union_UpazillaId";
       GS            postgres    false    340            �           1259    33891    IX_Upazilla_DistrictId    INDEX     U   CREATE INDEX "IX_Upazilla_DistrictId" ON "GS"."Upazilla" USING btree ("DistrictId");
 *   DROP INDEX "GS"."IX_Upazilla_DistrictId";
       GS            postgres    false    296            �           1259    37100 9   IX_InternalLoanInformationFiles_InternalLoanInformationId    INDEX     �   CREATE INDEX "IX_InternalLoanInformationFiles_InternalLoanInformationId" ON "InternalLoan"."InternalLoanInformationFiles" USING btree ("InternalLoanInformationId");
 W   DROP INDEX "InternalLoan"."IX_InternalLoanInformationFiles_InternalLoanInformationId";
       InternalLoan            postgres    false    480            �           1259    35810 &   IX_InternalLoanInformations_DistrictId    INDEX        CREATE INDEX "IX_InternalLoanInformations_DistrictId" ON "InternalLoan"."InternalLoanInformations" USING btree ("DistrictId");
 D   DROP INDEX "InternalLoan"."IX_InternalLoanInformations_DistrictId";
       InternalLoan            postgres    false    426            �           1259    35811 &   IX_InternalLoanInformations_DivisionId    INDEX        CREATE INDEX "IX_InternalLoanInformations_DivisionId" ON "InternalLoan"."InternalLoanInformations" USING btree ("DivisionId");
 D   DROP INDEX "InternalLoan"."IX_InternalLoanInformations_DivisionId";
       InternalLoan            postgres    false    426            �           1259    35812 (   IX_InternalLoanInformations_ForestBeatId    INDEX     �   CREATE INDEX "IX_InternalLoanInformations_ForestBeatId" ON "InternalLoan"."InternalLoanInformations" USING btree ("ForestBeatId");
 F   DROP INDEX "InternalLoan"."IX_InternalLoanInformations_ForestBeatId";
       InternalLoan            postgres    false    426            �           1259    35813 *   IX_InternalLoanInformations_ForestCircleId    INDEX     �   CREATE INDEX "IX_InternalLoanInformations_ForestCircleId" ON "InternalLoan"."InternalLoanInformations" USING btree ("ForestCircleId");
 H   DROP INDEX "InternalLoan"."IX_InternalLoanInformations_ForestCircleId";
       InternalLoan            postgres    false    426            �           1259    35814 ,   IX_InternalLoanInformations_ForestDivisionId    INDEX     �   CREATE INDEX "IX_InternalLoanInformations_ForestDivisionId" ON "InternalLoan"."InternalLoanInformations" USING btree ("ForestDivisionId");
 J   DROP INDEX "InternalLoan"."IX_InternalLoanInformations_ForestDivisionId";
       InternalLoan            postgres    false    426            �           1259    35815 *   IX_InternalLoanInformations_ForestFcvVcfId    INDEX     �   CREATE INDEX "IX_InternalLoanInformations_ForestFcvVcfId" ON "InternalLoan"."InternalLoanInformations" USING btree ("ForestFcvVcfId");
 H   DROP INDEX "InternalLoan"."IX_InternalLoanInformations_ForestFcvVcfId";
       InternalLoan            postgres    false    426            �           1259    35816 )   IX_InternalLoanInformations_ForestRangeId    INDEX     �   CREATE INDEX "IX_InternalLoanInformations_ForestRangeId" ON "InternalLoan"."InternalLoanInformations" USING btree ("ForestRangeId");
 G   DROP INDEX "InternalLoan"."IX_InternalLoanInformations_ForestRangeId";
       InternalLoan            postgres    false    426                        1259    35817 !   IX_InternalLoanInformations_NgoId    INDEX     u   CREATE INDEX "IX_InternalLoanInformations_NgoId" ON "InternalLoan"."InternalLoanInformations" USING btree ("NgoId");
 ?   DROP INDEX "InternalLoan"."IX_InternalLoanInformations_NgoId";
       InternalLoan            postgres    false    426                       1259    35818 $   IX_InternalLoanInformations_SurveyId    INDEX     {   CREATE INDEX "IX_InternalLoanInformations_SurveyId" ON "InternalLoan"."InternalLoanInformations" USING btree ("SurveyId");
 B   DROP INDEX "InternalLoan"."IX_InternalLoanInformations_SurveyId";
       InternalLoan            postgres    false    426                       1259    35819 #   IX_InternalLoanInformations_UnionId    INDEX     y   CREATE INDEX "IX_InternalLoanInformations_UnionId" ON "InternalLoan"."InternalLoanInformations" USING btree ("UnionId");
 A   DROP INDEX "InternalLoan"."IX_InternalLoanInformations_UnionId";
       InternalLoan            postgres    false    426                       1259    35820 &   IX_InternalLoanInformations_UpazillaId    INDEX        CREATE INDEX "IX_InternalLoanInformations_UpazillaId" ON "InternalLoan"."InternalLoanInformations" USING btree ("UpazillaId");
 D   DROP INDEX "InternalLoan"."IX_InternalLoanInformations_UpazillaId";
       InternalLoan            postgres    false    426            
           1259    35908 3   IX_RepaymentInternalLoans_InternalLoanInformationId    INDEX     �   CREATE INDEX "IX_RepaymentInternalLoans_InternalLoanInformationId" ON "InternalLoan"."RepaymentInternalLoans" USING btree ("InternalLoanInformationId");
 Q   DROP INDEX "InternalLoan"."IX_RepaymentInternalLoans_InternalLoanInformationId";
       InternalLoan            postgres    false    430            '           1259    36075 '   IX_LabourDatabaseFiles_LabourDatabaseId    INDEX     {   CREATE INDEX "IX_LabourDatabaseFiles_LabourDatabaseId" ON "Labour"."LabourDatabaseFiles" USING btree ("LabourDatabaseId");
 ?   DROP INDEX "Labour"."IX_LabourDatabaseFiles_LabourDatabaseId";
       Labour            postgres    false    436                       1259    36077    IX_LabourDatabases_DistrictId    INDEX     g   CREATE INDEX "IX_LabourDatabases_DistrictId" ON "Labour"."LabourDatabases" USING btree ("DistrictId");
 5   DROP INDEX "Labour"."IX_LabourDatabases_DistrictId";
       Labour            postgres    false    434                       1259    36078    IX_LabourDatabases_DivisionId    INDEX     g   CREATE INDEX "IX_LabourDatabases_DivisionId" ON "Labour"."LabourDatabases" USING btree ("DivisionId");
 5   DROP INDEX "Labour"."IX_LabourDatabases_DivisionId";
       Labour            postgres    false    434                       1259    36079    IX_LabourDatabases_EthnicityId    INDEX     i   CREATE INDEX "IX_LabourDatabases_EthnicityId" ON "Labour"."LabourDatabases" USING btree ("EthnicityId");
 6   DROP INDEX "Labour"."IX_LabourDatabases_EthnicityId";
       Labour            postgres    false    434                       1259    36080    IX_LabourDatabases_ForestBeatId    INDEX     k   CREATE INDEX "IX_LabourDatabases_ForestBeatId" ON "Labour"."LabourDatabases" USING btree ("ForestBeatId");
 7   DROP INDEX "Labour"."IX_LabourDatabases_ForestBeatId";
       Labour            postgres    false    434                       1259    36081 !   IX_LabourDatabases_ForestCircleId    INDEX     o   CREATE INDEX "IX_LabourDatabases_ForestCircleId" ON "Labour"."LabourDatabases" USING btree ("ForestCircleId");
 9   DROP INDEX "Labour"."IX_LabourDatabases_ForestCircleId";
       Labour            postgres    false    434                       1259    36082 #   IX_LabourDatabases_ForestDivisionId    INDEX     s   CREATE INDEX "IX_LabourDatabases_ForestDivisionId" ON "Labour"."LabourDatabases" USING btree ("ForestDivisionId");
 ;   DROP INDEX "Labour"."IX_LabourDatabases_ForestDivisionId";
       Labour            postgres    false    434                       1259    36083 !   IX_LabourDatabases_ForestFcvVcfId    INDEX     o   CREATE INDEX "IX_LabourDatabases_ForestFcvVcfId" ON "Labour"."LabourDatabases" USING btree ("ForestFcvVcfId");
 9   DROP INDEX "Labour"."IX_LabourDatabases_ForestFcvVcfId";
       Labour            postgres    false    434                        1259    36084     IX_LabourDatabases_ForestRangeId    INDEX     m   CREATE INDEX "IX_LabourDatabases_ForestRangeId" ON "Labour"."LabourDatabases" USING btree ("ForestRangeId");
 8   DROP INDEX "Labour"."IX_LabourDatabases_ForestRangeId";
       Labour            postgres    false    434            !           1259    37178 &   IX_LabourDatabases_OtherLabourMemberId    INDEX     �   CREATE UNIQUE INDEX "IX_LabourDatabases_OtherLabourMemberId" ON "Labour"."LabourDatabases" USING btree ("OtherLabourMemberId");
 >   DROP INDEX "Labour"."IX_LabourDatabases_OtherLabourMemberId";
       Labour            postgres    false    434            "           1259    36087    IX_LabourDatabases_SurveyId    INDEX     c   CREATE INDEX "IX_LabourDatabases_SurveyId" ON "Labour"."LabourDatabases" USING btree ("SurveyId");
 3   DROP INDEX "Labour"."IX_LabourDatabases_SurveyId";
       Labour            postgres    false    434            #           1259    36088    IX_LabourDatabases_UnionId    INDEX     a   CREATE INDEX "IX_LabourDatabases_UnionId" ON "Labour"."LabourDatabases" USING btree ("UnionId");
 2   DROP INDEX "Labour"."IX_LabourDatabases_UnionId";
       Labour            postgres    false    434            $           1259    36089    IX_LabourDatabases_UpazillaId    INDEX     g   CREATE INDEX "IX_LabourDatabases_UpazillaId" ON "Labour"."LabourDatabases" USING btree ("UpazillaId");
 5   DROP INDEX "Labour"."IX_LabourDatabases_UpazillaId";
       Labour            postgres    false    434            �           1259    37331    IX_LabourWorks_LabourDatabaseId    INDEX     k   CREATE INDEX "IX_LabourWorks_LabourDatabaseId" ON "Labour"."LabourWorks" USING btree ("LabourDatabaseId");
 7   DROP INDEX "Labour"."IX_LabourWorks_LabourDatabaseId";
       Labour            postgres    false    492                       1259    36090     IX_OtherLabourMembers_DistrictId    INDEX     m   CREATE INDEX "IX_OtherLabourMembers_DistrictId" ON "Labour"."OtherLabourMembers" USING btree ("DistrictId");
 8   DROP INDEX "Labour"."IX_OtherLabourMembers_DistrictId";
       Labour            postgres    false    432                       1259    36091     IX_OtherLabourMembers_DivisionId    INDEX     m   CREATE INDEX "IX_OtherLabourMembers_DivisionId" ON "Labour"."OtherLabourMembers" USING btree ("DivisionId");
 8   DROP INDEX "Labour"."IX_OtherLabourMembers_DivisionId";
       Labour            postgres    false    432                       1259    36092 !   IX_OtherLabourMembers_EthnicityId    INDEX     o   CREATE INDEX "IX_OtherLabourMembers_EthnicityId" ON "Labour"."OtherLabourMembers" USING btree ("EthnicityId");
 9   DROP INDEX "Labour"."IX_OtherLabourMembers_EthnicityId";
       Labour            postgres    false    432                       1259    36093 "   IX_OtherLabourMembers_ForestBeatId    INDEX     q   CREATE INDEX "IX_OtherLabourMembers_ForestBeatId" ON "Labour"."OtherLabourMembers" USING btree ("ForestBeatId");
 :   DROP INDEX "Labour"."IX_OtherLabourMembers_ForestBeatId";
       Labour            postgres    false    432                       1259    36094 $   IX_OtherLabourMembers_ForestCircleId    INDEX     u   CREATE INDEX "IX_OtherLabourMembers_ForestCircleId" ON "Labour"."OtherLabourMembers" USING btree ("ForestCircleId");
 <   DROP INDEX "Labour"."IX_OtherLabourMembers_ForestCircleId";
       Labour            postgres    false    432                       1259    36095 &   IX_OtherLabourMembers_ForestDivisionId    INDEX     y   CREATE INDEX "IX_OtherLabourMembers_ForestDivisionId" ON "Labour"."OtherLabourMembers" USING btree ("ForestDivisionId");
 >   DROP INDEX "Labour"."IX_OtherLabourMembers_ForestDivisionId";
       Labour            postgres    false    432                       1259    36096 $   IX_OtherLabourMembers_ForestFcvVcfId    INDEX     u   CREATE INDEX "IX_OtherLabourMembers_ForestFcvVcfId" ON "Labour"."OtherLabourMembers" USING btree ("ForestFcvVcfId");
 <   DROP INDEX "Labour"."IX_OtherLabourMembers_ForestFcvVcfId";
       Labour            postgres    false    432                       1259    36097 #   IX_OtherLabourMembers_ForestRangeId    INDEX     s   CREATE INDEX "IX_OtherLabourMembers_ForestRangeId" ON "Labour"."OtherLabourMembers" USING btree ("ForestRangeId");
 ;   DROP INDEX "Labour"."IX_OtherLabourMembers_ForestRangeId";
       Labour            postgres    false    432                       1259    36098    IX_OtherLabourMembers_UnionId    INDEX     g   CREATE INDEX "IX_OtherLabourMembers_UnionId" ON "Labour"."OtherLabourMembers" USING btree ("UnionId");
 5   DROP INDEX "Labour"."IX_OtherLabourMembers_UnionId";
       Labour            postgres    false    432                       1259    36099     IX_OtherLabourMembers_UpazillaId    INDEX     m   CREATE INDEX "IX_OtherLabourMembers_UpazillaId" ON "Labour"."OtherLabourMembers" USING btree ("UpazillaId");
 8   DROP INDEX "Labour"."IX_OtherLabourMembers_UpazillaId";
       Labour            postgres    false    432                       1259    34024    IX_Marketings_DistrictId    INDEX     `   CREATE INDEX "IX_Marketings_DistrictId" ON "Marketing"."Marketings" USING btree ("DistrictId");
 3   DROP INDEX "Marketing"."IX_Marketings_DistrictId";
    	   Marketing            postgres    false    338                       1259    34025    IX_Marketings_DivisionId    INDEX     `   CREATE INDEX "IX_Marketings_DivisionId" ON "Marketing"."Marketings" USING btree ("DivisionId");
 3   DROP INDEX "Marketing"."IX_Marketings_DivisionId";
    	   Marketing            postgres    false    338            �           1259    34763    IX_MeetingFiles_MeetingId    INDEX     `   CREATE INDEX "IX_MeetingFiles_MeetingId" ON "Meeting"."MeetingFiles" USING btree ("MeetingId");
 2   DROP INDEX "Meeting"."IX_MeetingFiles_MeetingId";
       Meeting            postgres    false    386            s           1259    34764    IX_Meetings_DistrictId    INDEX     Z   CREATE INDEX "IX_Meetings_DistrictId" ON "Meeting"."Meetings" USING btree ("DistrictId");
 /   DROP INDEX "Meeting"."IX_Meetings_DistrictId";
       Meeting            postgres    false    382            t           1259    34765    IX_Meetings_DivisionId    INDEX     Z   CREATE INDEX "IX_Meetings_DivisionId" ON "Meeting"."Meetings" USING btree ("DivisionId");
 /   DROP INDEX "Meeting"."IX_Meetings_DivisionId";
       Meeting            postgres    false    382            u           1259    34766    IX_Meetings_ForestBeatId    INDEX     ^   CREATE INDEX "IX_Meetings_ForestBeatId" ON "Meeting"."Meetings" USING btree ("ForestBeatId");
 1   DROP INDEX "Meeting"."IX_Meetings_ForestBeatId";
       Meeting            postgres    false    382            v           1259    34767    IX_Meetings_ForestCircleId    INDEX     b   CREATE INDEX "IX_Meetings_ForestCircleId" ON "Meeting"."Meetings" USING btree ("ForestCircleId");
 3   DROP INDEX "Meeting"."IX_Meetings_ForestCircleId";
       Meeting            postgres    false    382            w           1259    34768    IX_Meetings_ForestDivisionId    INDEX     f   CREATE INDEX "IX_Meetings_ForestDivisionId" ON "Meeting"."Meetings" USING btree ("ForestDivisionId");
 5   DROP INDEX "Meeting"."IX_Meetings_ForestDivisionId";
       Meeting            postgres    false    382            x           1259    34769    IX_Meetings_ForestFcvVcfId    INDEX     b   CREATE INDEX "IX_Meetings_ForestFcvVcfId" ON "Meeting"."Meetings" USING btree ("ForestFcvVcfId");
 3   DROP INDEX "Meeting"."IX_Meetings_ForestFcvVcfId";
       Meeting            postgres    false    382            y           1259    34770    IX_Meetings_ForestRangeId    INDEX     `   CREATE INDEX "IX_Meetings_ForestRangeId" ON "Meeting"."Meetings" USING btree ("ForestRangeId");
 2   DROP INDEX "Meeting"."IX_Meetings_ForestRangeId";
       Meeting            postgres    false    382            z           1259    34771    IX_Meetings_MeetingTypeId    INDEX     `   CREATE INDEX "IX_Meetings_MeetingTypeId" ON "Meeting"."Meetings" USING btree ("MeetingTypeId");
 2   DROP INDEX "Meeting"."IX_Meetings_MeetingTypeId";
       Meeting            postgres    false    382            {           1259    36224    IX_Meetings_NgoId    INDEX     P   CREATE INDEX "IX_Meetings_NgoId" ON "Meeting"."Meetings" USING btree ("NgoId");
 *   DROP INDEX "Meeting"."IX_Meetings_NgoId";
       Meeting            postgres    false    382            |           1259    35710    IX_Meetings_UnionId    INDEX     T   CREATE INDEX "IX_Meetings_UnionId" ON "Meeting"."Meetings" USING btree ("UnionId");
 ,   DROP INDEX "Meeting"."IX_Meetings_UnionId";
       Meeting            postgres    false    382            }           1259    34772    IX_Meetings_UpazillaId    INDEX     Z   CREATE INDEX "IX_Meetings_UpazillaId" ON "Meeting"."Meetings" USING btree ("UpazillaId");
 /   DROP INDEX "Meeting"."IX_Meetings_UpazillaId";
       Meeting            postgres    false    382            �           1259    35421 #   IX_OtherPatrollingMember_DistrictId    INDEX     w   CREATE INDEX "IX_OtherPatrollingMember_DistrictId" ON "Patrolling"."OtherPatrollingMember" USING btree ("DistrictId");
 ?   DROP INDEX "Patrolling"."IX_OtherPatrollingMember_DistrictId";
    
   Patrolling            postgres    false    416            �           1259    35422 #   IX_OtherPatrollingMember_DivisionId    INDEX     w   CREATE INDEX "IX_OtherPatrollingMember_DivisionId" ON "Patrolling"."OtherPatrollingMember" USING btree ("DivisionId");
 ?   DROP INDEX "Patrolling"."IX_OtherPatrollingMember_DivisionId";
    
   Patrolling            postgres    false    416            �           1259    35423 $   IX_OtherPatrollingMember_EthnicityId    INDEX     y   CREATE INDEX "IX_OtherPatrollingMember_EthnicityId" ON "Patrolling"."OtherPatrollingMember" USING btree ("EthnicityId");
 @   DROP INDEX "Patrolling"."IX_OtherPatrollingMember_EthnicityId";
    
   Patrolling            postgres    false    416            �           1259    35424 %   IX_OtherPatrollingMember_ForestBeatId    INDEX     {   CREATE INDEX "IX_OtherPatrollingMember_ForestBeatId" ON "Patrolling"."OtherPatrollingMember" USING btree ("ForestBeatId");
 A   DROP INDEX "Patrolling"."IX_OtherPatrollingMember_ForestBeatId";
    
   Patrolling            postgres    false    416            �           1259    35425 '   IX_OtherPatrollingMember_ForestCircleId    INDEX        CREATE INDEX "IX_OtherPatrollingMember_ForestCircleId" ON "Patrolling"."OtherPatrollingMember" USING btree ("ForestCircleId");
 C   DROP INDEX "Patrolling"."IX_OtherPatrollingMember_ForestCircleId";
    
   Patrolling            postgres    false    416            �           1259    35426 )   IX_OtherPatrollingMember_ForestDivisionId    INDEX     �   CREATE INDEX "IX_OtherPatrollingMember_ForestDivisionId" ON "Patrolling"."OtherPatrollingMember" USING btree ("ForestDivisionId");
 E   DROP INDEX "Patrolling"."IX_OtherPatrollingMember_ForestDivisionId";
    
   Patrolling            postgres    false    416            �           1259    35427 '   IX_OtherPatrollingMember_ForestFcvVcfId    INDEX        CREATE INDEX "IX_OtherPatrollingMember_ForestFcvVcfId" ON "Patrolling"."OtherPatrollingMember" USING btree ("ForestFcvVcfId");
 C   DROP INDEX "Patrolling"."IX_OtherPatrollingMember_ForestFcvVcfId";
    
   Patrolling            postgres    false    416            �           1259    35428 &   IX_OtherPatrollingMember_ForestRangeId    INDEX     }   CREATE INDEX "IX_OtherPatrollingMember_ForestRangeId" ON "Patrolling"."OtherPatrollingMember" USING btree ("ForestRangeId");
 B   DROP INDEX "Patrolling"."IX_OtherPatrollingMember_ForestRangeId";
    
   Patrolling            postgres    false    416            �           1259    35429 #   IX_OtherPatrollingMember_UpazillaId    INDEX     w   CREATE INDEX "IX_OtherPatrollingMember_UpazillaId" ON "Patrolling"."OtherPatrollingMember" USING btree ("UpazillaId");
 ?   DROP INDEX "Patrolling"."IX_OtherPatrollingMember_UpazillaId";
    
   Patrolling            postgres    false    416            �           1259    35442 7   IX_PatrollingPaymentInformetion_OtherPatrollingMemberId    INDEX     �   CREATE INDEX "IX_PatrollingPaymentInformetion_OtherPatrollingMemberId" ON "Patrolling"."PatrollingPaymentInformetion" USING btree ("OtherPatrollingMemberId");
 S   DROP INDEX "Patrolling"."IX_PatrollingPaymentInformetion_OtherPatrollingMemberId";
    
   Patrolling            postgres    false    414            �           1259    35356 ?   IX_PatrollingPaymentInformetion_PatrollingScheduleInformetionId    INDEX     �   CREATE INDEX "IX_PatrollingPaymentInformetion_PatrollingScheduleInformetionId" ON "Patrolling"."PatrollingPaymentInformetion" USING btree ("PatrollingScheduleInformetionId");
 [   DROP INDEX "Patrolling"."IX_PatrollingPaymentInformetion_PatrollingScheduleInformetionId";
    
   Patrolling            postgres    false    414            �           1259    35357 (   IX_PatrollingPaymentInformetion_SurveyId    INDEX     �   CREATE INDEX "IX_PatrollingPaymentInformetion_SurveyId" ON "Patrolling"."PatrollingPaymentInformetion" USING btree ("SurveyId");
 D   DROP INDEX "Patrolling"."IX_PatrollingPaymentInformetion_SurveyId";
    
   Patrolling            postgres    false    414            �           1259    35358 +   IX_PatrollingScheduleInformetion_DistrictId    INDEX     �   CREATE INDEX "IX_PatrollingScheduleInformetion_DistrictId" ON "Patrolling"."PatrollingScheduleInformetion" USING btree ("DistrictId");
 G   DROP INDEX "Patrolling"."IX_PatrollingScheduleInformetion_DistrictId";
    
   Patrolling            postgres    false    412            �           1259    35359 +   IX_PatrollingScheduleInformetion_DivisionId    INDEX     �   CREATE INDEX "IX_PatrollingScheduleInformetion_DivisionId" ON "Patrolling"."PatrollingScheduleInformetion" USING btree ("DivisionId");
 G   DROP INDEX "Patrolling"."IX_PatrollingScheduleInformetion_DivisionId";
    
   Patrolling            postgres    false    412            �           1259    35360 -   IX_PatrollingScheduleInformetion_ForestBeatId    INDEX     �   CREATE INDEX "IX_PatrollingScheduleInformetion_ForestBeatId" ON "Patrolling"."PatrollingScheduleInformetion" USING btree ("ForestBeatId");
 I   DROP INDEX "Patrolling"."IX_PatrollingScheduleInformetion_ForestBeatId";
    
   Patrolling            postgres    false    412            �           1259    35361 /   IX_PatrollingScheduleInformetion_ForestCircleId    INDEX     �   CREATE INDEX "IX_PatrollingScheduleInformetion_ForestCircleId" ON "Patrolling"."PatrollingScheduleInformetion" USING btree ("ForestCircleId");
 K   DROP INDEX "Patrolling"."IX_PatrollingScheduleInformetion_ForestCircleId";
    
   Patrolling            postgres    false    412            �           1259    35362 1   IX_PatrollingScheduleInformetion_ForestDivisionId    INDEX     �   CREATE INDEX "IX_PatrollingScheduleInformetion_ForestDivisionId" ON "Patrolling"."PatrollingScheduleInformetion" USING btree ("ForestDivisionId");
 M   DROP INDEX "Patrolling"."IX_PatrollingScheduleInformetion_ForestDivisionId";
    
   Patrolling            postgres    false    412            �           1259    35363 .   IX_PatrollingScheduleInformetion_ForestRangeId    INDEX     �   CREATE INDEX "IX_PatrollingScheduleInformetion_ForestRangeId" ON "Patrolling"."PatrollingScheduleInformetion" USING btree ("ForestRangeId");
 J   DROP INDEX "Patrolling"."IX_PatrollingScheduleInformetion_ForestRangeId";
    
   Patrolling            postgres    false    412            �           1259    35364 &   IX_PatrollingScheduleInformetion_NgoId    INDEX     }   CREATE INDEX "IX_PatrollingScheduleInformetion_NgoId" ON "Patrolling"."PatrollingScheduleInformetion" USING btree ("NgoId");
 B   DROP INDEX "Patrolling"."IX_PatrollingScheduleInformetion_NgoId";
    
   Patrolling            postgres    false    412            �           1259    35420 8   IX_PatrollingScheduleInformetion_OtherPatrollingMemberId    INDEX     �   CREATE INDEX "IX_PatrollingScheduleInformetion_OtherPatrollingMemberId" ON "Patrolling"."PatrollingScheduleInformetion" USING btree ("OtherPatrollingMemberId");
 T   DROP INDEX "Patrolling"."IX_PatrollingScheduleInformetion_OtherPatrollingMemberId";
    
   Patrolling            postgres    false    412            �           1259    36113 (   IX_PatrollingScheduleInformetion_UnionId    INDEX     �   CREATE INDEX "IX_PatrollingScheduleInformetion_UnionId" ON "Patrolling"."PatrollingScheduleInformetion" USING btree ("UnionId");
 D   DROP INDEX "Patrolling"."IX_PatrollingScheduleInformetion_UnionId";
    
   Patrolling            postgres    false    412            �           1259    35365 +   IX_PatrollingScheduleInformetion_UpazillaId    INDEX     �   CREATE INDEX "IX_PatrollingScheduleInformetion_UpazillaId" ON "Patrolling"."PatrollingScheduleInformetion" USING btree ("UpazillaId");
 G   DROP INDEX "Patrolling"."IX_PatrollingScheduleInformetion_UpazillaId";
    
   Patrolling            postgres    false    412            I           1259    36352 3   IX_PatrollingSchedulingFiles_PatrollingSchedulingId    INDEX     �   CREATE INDEX "IX_PatrollingSchedulingFiles_PatrollingSchedulingId" ON "PatrollingScheduling"."PatrollingSchedulingFiles" USING btree ("PatrollingSchedulingId");
 Y   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulingFiles_PatrollingSchedulingId";
       PatrollingScheduling            postgres    false    446            L           1259    36353 >   IX_PatrollingSchedulingParticipentsMaps_PatrollingSchedulingId    INDEX     �   CREATE INDEX "IX_PatrollingSchedulingParticipentsMaps_PatrollingSchedulingId" ON "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps" USING btree ("PatrollingSchedulingId");
 d   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulingParticipentsMaps_PatrollingSchedulingId";
       PatrollingScheduling            postgres    false    448            M           1259    36354 ?   IX_PatrollingSchedulingParticipentsMaps_PatrollingSchedulingMe~    INDEX     �   CREATE INDEX "IX_PatrollingSchedulingParticipentsMaps_PatrollingSchedulingMe~" ON "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps" USING btree ("PatrollingSchedulingMemberId");
 e   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulingParticipentsMaps_PatrollingSchedulingMe~";
       PatrollingScheduling            postgres    false    448            N           1259    36355 0   IX_PatrollingSchedulingParticipentsMaps_SurveyId    INDEX     �   CREATE INDEX "IX_PatrollingSchedulingParticipentsMaps_SurveyId" ON "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps" USING btree ("SurveyId");
 V   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulingParticipentsMaps_SurveyId";
       PatrollingScheduling            postgres    false    448            =           1259    36356 #   IX_PatrollingSchedulings_DistrictId    INDEX     �   CREATE INDEX "IX_PatrollingSchedulings_DistrictId" ON "PatrollingScheduling"."PatrollingSchedulings" USING btree ("DistrictId");
 I   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulings_DistrictId";
       PatrollingScheduling            postgres    false    444            >           1259    36357 #   IX_PatrollingSchedulings_DivisionId    INDEX     �   CREATE INDEX "IX_PatrollingSchedulings_DivisionId" ON "PatrollingScheduling"."PatrollingSchedulings" USING btree ("DivisionId");
 I   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulings_DivisionId";
       PatrollingScheduling            postgres    false    444            ?           1259    36358 %   IX_PatrollingSchedulings_ForestBeatId    INDEX     �   CREATE INDEX "IX_PatrollingSchedulings_ForestBeatId" ON "PatrollingScheduling"."PatrollingSchedulings" USING btree ("ForestBeatId");
 K   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulings_ForestBeatId";
       PatrollingScheduling            postgres    false    444            @           1259    36359 '   IX_PatrollingSchedulings_ForestCircleId    INDEX     �   CREATE INDEX "IX_PatrollingSchedulings_ForestCircleId" ON "PatrollingScheduling"."PatrollingSchedulings" USING btree ("ForestCircleId");
 M   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulings_ForestCircleId";
       PatrollingScheduling            postgres    false    444            A           1259    36360 )   IX_PatrollingSchedulings_ForestDivisionId    INDEX     �   CREATE INDEX "IX_PatrollingSchedulings_ForestDivisionId" ON "PatrollingScheduling"."PatrollingSchedulings" USING btree ("ForestDivisionId");
 O   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulings_ForestDivisionId";
       PatrollingScheduling            postgres    false    444            B           1259    36361 '   IX_PatrollingSchedulings_ForestFcvVcfId    INDEX     �   CREATE INDEX "IX_PatrollingSchedulings_ForestFcvVcfId" ON "PatrollingScheduling"."PatrollingSchedulings" USING btree ("ForestFcvVcfId");
 M   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulings_ForestFcvVcfId";
       PatrollingScheduling            postgres    false    444            C           1259    36362 &   IX_PatrollingSchedulings_ForestRangeId    INDEX     �   CREATE INDEX "IX_PatrollingSchedulings_ForestRangeId" ON "PatrollingScheduling"."PatrollingSchedulings" USING btree ("ForestRangeId");
 L   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulings_ForestRangeId";
       PatrollingScheduling            postgres    false    444            D           1259    36363    IX_PatrollingSchedulings_NgoId    INDEX     w   CREATE INDEX "IX_PatrollingSchedulings_NgoId" ON "PatrollingScheduling"."PatrollingSchedulings" USING btree ("NgoId");
 D   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulings_NgoId";
       PatrollingScheduling            postgres    false    444            E           1259    36364     IX_PatrollingSchedulings_UnionId    INDEX     {   CREATE INDEX "IX_PatrollingSchedulings_UnionId" ON "PatrollingScheduling"."PatrollingSchedulings" USING btree ("UnionId");
 F   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulings_UnionId";
       PatrollingScheduling            postgres    false    444            F           1259    36365 #   IX_PatrollingSchedulings_UpazillaId    INDEX     �   CREATE INDEX "IX_PatrollingSchedulings_UpazillaId" ON "PatrollingScheduling"."PatrollingSchedulings" USING btree ("UpazillaId");
 I   DROP INDEX "PatrollingScheduling"."IX_PatrollingSchedulings_UpazillaId";
       PatrollingScheduling            postgres    false    444            �           1259    37025 %   IX_BankDeposits_RevenueDistributionId    INDEX        CREATE INDEX "IX_BankDeposits_RevenueDistributionId" ON "SocialForestry"."BankDeposits" USING btree ("RevenueDistributionId");
 E   DROP INDEX "SocialForestry"."IX_BankDeposits_RevenueDistributionId";
       SocialForestry            postgres    false    474            u           1259    37026 +   IX_CuttingPlantations_NewRaisedPlantationId    INDEX     �   CREATE INDEX "IX_CuttingPlantations_NewRaisedPlantationId" ON "SocialForestry"."CuttingPlantations" USING btree ("NewRaisedPlantationId");
 K   DROP INDEX "SocialForestry"."IX_CuttingPlantations_NewRaisedPlantationId";
       SocialForestry            postgres    false    462            �           1259    37027 ;   IX_DistributedOrRevenueDepositAmounts_RevenueDistributionId    INDEX     �   CREATE INDEX "IX_DistributedOrRevenueDepositAmounts_RevenueDistributionId" ON "SocialForestry"."DistributedOrRevenueDepositAmounts" USING btree ("RevenueDistributionId");
 [   DROP INDEX "SocialForestry"."IX_DistributedOrRevenueDepositAmounts_RevenueDistributionId";
       SocialForestry            postgres    false    476            x           1259    37039 5   IX_NewRaisedPlantationUnionMaps_NewRaisedPlantationId    INDEX     �   CREATE INDEX "IX_NewRaisedPlantationUnionMaps_NewRaisedPlantationId" ON "SocialForestry"."NewRaisedPlantationUnionMaps" USING btree ("NewRaisedPlantationId");
 U   DROP INDEX "SocialForestry"."IX_NewRaisedPlantationUnionMaps_NewRaisedPlantationId";
       SocialForestry            postgres    false    464            y           1259    37040 '   IX_NewRaisedPlantationUnionMaps_UnionId    INDEX     �   CREATE INDEX "IX_NewRaisedPlantationUnionMaps_UnionId" ON "SocialForestry"."NewRaisedPlantationUnionMaps" USING btree ("UnionId");
 G   DROP INDEX "SocialForestry"."IX_NewRaisedPlantationUnionMaps_UnionId";
       SocialForestry            postgres    false    464            |           1259    37041 8   IX_NewRaisedPlantationUpazillaMaps_NewRaisedPlantationId    INDEX     �   CREATE INDEX "IX_NewRaisedPlantationUpazillaMaps_NewRaisedPlantationId" ON "SocialForestry"."NewRaisedPlantationUpazillaMaps" USING btree ("NewRaisedPlantationId");
 X   DROP INDEX "SocialForestry"."IX_NewRaisedPlantationUpazillaMaps_NewRaisedPlantationId";
       SocialForestry            postgres    false    466            }           1259    37042 -   IX_NewRaisedPlantationUpazillaMaps_UpazillaId    INDEX     �   CREATE INDEX "IX_NewRaisedPlantationUpazillaMaps_UpazillaId" ON "SocialForestry"."NewRaisedPlantationUpazillaMaps" USING btree ("UpazillaId");
 M   DROP INDEX "SocialForestry"."IX_NewRaisedPlantationUpazillaMaps_UpazillaId";
       SocialForestry            postgres    false    466            h           1259    37028 "   IX_NewRaisedPlantations_DistrictId    INDEX     y   CREATE INDEX "IX_NewRaisedPlantations_DistrictId" ON "SocialForestry"."NewRaisedPlantations" USING btree ("DistrictId");
 B   DROP INDEX "SocialForestry"."IX_NewRaisedPlantations_DistrictId";
       SocialForestry            postgres    false    460            i           1259    37029 "   IX_NewRaisedPlantations_DivisionId    INDEX     y   CREATE INDEX "IX_NewRaisedPlantations_DivisionId" ON "SocialForestry"."NewRaisedPlantations" USING btree ("DivisionId");
 B   DROP INDEX "SocialForestry"."IX_NewRaisedPlantations_DivisionId";
       SocialForestry            postgres    false    460            j           1259    37030 $   IX_NewRaisedPlantations_ForestBeatId    INDEX     }   CREATE INDEX "IX_NewRaisedPlantations_ForestBeatId" ON "SocialForestry"."NewRaisedPlantations" USING btree ("ForestBeatId");
 D   DROP INDEX "SocialForestry"."IX_NewRaisedPlantations_ForestBeatId";
       SocialForestry            postgres    false    460            k           1259    37031 &   IX_NewRaisedPlantations_ForestCircleId    INDEX     �   CREATE INDEX "IX_NewRaisedPlantations_ForestCircleId" ON "SocialForestry"."NewRaisedPlantations" USING btree ("ForestCircleId");
 F   DROP INDEX "SocialForestry"."IX_NewRaisedPlantations_ForestCircleId";
       SocialForestry            postgres    false    460            l           1259    37032 (   IX_NewRaisedPlantations_ForestDivisionId    INDEX     �   CREATE INDEX "IX_NewRaisedPlantations_ForestDivisionId" ON "SocialForestry"."NewRaisedPlantations" USING btree ("ForestDivisionId");
 H   DROP INDEX "SocialForestry"."IX_NewRaisedPlantations_ForestDivisionId";
       SocialForestry            postgres    false    460            m           1259    37033 &   IX_NewRaisedPlantations_ForestFcvVcfId    INDEX     �   CREATE INDEX "IX_NewRaisedPlantations_ForestFcvVcfId" ON "SocialForestry"."NewRaisedPlantations" USING btree ("ForestFcvVcfId");
 F   DROP INDEX "SocialForestry"."IX_NewRaisedPlantations_ForestFcvVcfId";
       SocialForestry            postgres    false    460            n           1259    37034 %   IX_NewRaisedPlantations_ForestRangeId    INDEX        CREATE INDEX "IX_NewRaisedPlantations_ForestRangeId" ON "SocialForestry"."NewRaisedPlantations" USING btree ("ForestRangeId");
 E   DROP INDEX "SocialForestry"."IX_NewRaisedPlantations_ForestRangeId";
       SocialForestry            postgres    false    460            o           1259    37035    IX_NewRaisedPlantations_NgoId    INDEX     o   CREATE INDEX "IX_NewRaisedPlantations_NgoId" ON "SocialForestry"."NewRaisedPlantations" USING btree ("NgoId");
 =   DROP INDEX "SocialForestry"."IX_NewRaisedPlantations_NgoId";
       SocialForestry            postgres    false    460            p           1259    37036 +   IX_NewRaisedPlantations_PlantationProjectId    INDEX     �   CREATE INDEX "IX_NewRaisedPlantations_PlantationProjectId" ON "SocialForestry"."NewRaisedPlantations" USING btree ("PlantationProjectId");
 K   DROP INDEX "SocialForestry"."IX_NewRaisedPlantations_PlantationProjectId";
       SocialForestry            postgres    false    460            q           1259    37037 (   IX_NewRaisedPlantations_PlantationTypeId    INDEX     �   CREATE INDEX "IX_NewRaisedPlantations_PlantationTypeId" ON "SocialForestry"."NewRaisedPlantations" USING btree ("PlantationTypeId");
 H   DROP INDEX "SocialForestry"."IX_NewRaisedPlantations_PlantationTypeId";
       SocialForestry            postgres    false    460            r           1259    37038 #   IX_NewRaisedPlantations_StripTypeId    INDEX     {   CREATE INDEX "IX_NewRaisedPlantations_StripTypeId" ON "SocialForestry"."NewRaisedPlantations" USING btree ("StripTypeId");
 C   DROP INDEX "SocialForestry"."IX_NewRaisedPlantations_StripTypeId";
       SocialForestry            postgres    false    460            b           1259    37043 4   IX_PlantationTypeRevenuePercentages_PlantationTypeId    INDEX     �   CREATE INDEX "IX_PlantationTypeRevenuePercentages_PlantationTypeId" ON "SocialForestry"."PlantationTypeRevenuePercentages" USING btree ("PlantationTypeId");
 T   DROP INDEX "SocialForestry"."IX_PlantationTypeRevenuePercentages_PlantationTypeId";
       SocialForestry            postgres    false    456            �           1259    37044 '   IX_Reforestations_NewRaisedPlantationId    INDEX     �   CREATE INDEX "IX_Reforestations_NewRaisedPlantationId" ON "SocialForestry"."Reforestations" USING btree ("NewRaisedPlantationId");
 G   DROP INDEX "SocialForestry"."IX_Reforestations_NewRaisedPlantationId";
       SocialForestry            postgres    false    468            �           1259    37045 !   IX_RevenueDistributions_RevenueId    INDEX     w   CREATE INDEX "IX_RevenueDistributions_RevenueId" ON "SocialForestry"."RevenueDistributions" USING btree ("RevenueId");
 A   DROP INDEX "SocialForestry"."IX_RevenueDistributions_RevenueId";
       SocialForestry            postgres    false    472            �           1259    37046    IX_Revenues_CuttingPlantationId    INDEX     s   CREATE INDEX "IX_Revenues_CuttingPlantationId" ON "SocialForestry"."Revenues" USING btree ("CuttingPlantationId");
 ?   DROP INDEX "SocialForestry"."IX_Revenues_CuttingPlantationId";
       SocialForestry            postgres    false    470            e           1259    37047    IX_StripTypes_PlantationTypeId    INDEX     q   CREATE INDEX "IX_StripTypes_PlantationTypeId" ON "SocialForestry"."StripTypes" USING btree ("PlantationTypeId");
 >   DROP INDEX "SocialForestry"."IX_StripTypes_PlantationTypeId";
       SocialForestry            postgres    false    458            �           1259    35821    IX_User_DistrictId    INDEX     Q   CREATE INDEX "IX_User_DistrictId" ON "System"."User" USING btree ("DistrictId");
 *   DROP INDEX "System"."IX_User_DistrictId";
       System            postgres    false    292            �           1259    35822    IX_User_DivisionId    INDEX     Q   CREATE INDEX "IX_User_DivisionId" ON "System"."User" USING btree ("DivisionId");
 *   DROP INDEX "System"."IX_User_DivisionId";
       System            postgres    false    292            �           1259    35823    IX_User_ForestBeatId    INDEX     U   CREATE INDEX "IX_User_ForestBeatId" ON "System"."User" USING btree ("ForestBeatId");
 ,   DROP INDEX "System"."IX_User_ForestBeatId";
       System            postgres    false    292            �           1259    35824    IX_User_ForestCircleId    INDEX     Y   CREATE INDEX "IX_User_ForestCircleId" ON "System"."User" USING btree ("ForestCircleId");
 .   DROP INDEX "System"."IX_User_ForestCircleId";
       System            postgres    false    292            �           1259    35825    IX_User_ForestDivisionId    INDEX     ]   CREATE INDEX "IX_User_ForestDivisionId" ON "System"."User" USING btree ("ForestDivisionId");
 0   DROP INDEX "System"."IX_User_ForestDivisionId";
       System            postgres    false    292            �           1259    35826    IX_User_ForestFcvVcfId    INDEX     Y   CREATE INDEX "IX_User_ForestFcvVcfId" ON "System"."User" USING btree ("ForestFcvVcfId");
 .   DROP INDEX "System"."IX_User_ForestFcvVcfId";
       System            postgres    false    292            �           1259    35827    IX_User_ForestRangeId    INDEX     W   CREATE INDEX "IX_User_ForestRangeId" ON "System"."User" USING btree ("ForestRangeId");
 -   DROP INDEX "System"."IX_User_ForestRangeId";
       System            postgres    false    292            �           1259    33892    IX_User_GroupID    INDEX     K   CREATE INDEX "IX_User_GroupID" ON "System"."User" USING btree ("GroupID");
 '   DROP INDEX "System"."IX_User_GroupID";
       System            postgres    false    292            �           1259    33893    IX_User_PmsGroupID    INDEX     Q   CREATE INDEX "IX_User_PmsGroupID" ON "System"."User" USING btree ("PmsGroupID");
 *   DROP INDEX "System"."IX_User_PmsGroupID";
       System            postgres    false    292            �           1259    36230    IX_User_SurveyId    INDEX     T   CREATE UNIQUE INDEX "IX_User_SurveyId" ON "System"."User" USING btree ("SurveyId");
 (   DROP INDEX "System"."IX_User_SurveyId";
       System            postgres    false    292            �           1259    35828    IX_User_UnionId    INDEX     K   CREATE INDEX "IX_User_UnionId" ON "System"."User" USING btree ("UnionId");
 '   DROP INDEX "System"."IX_User_UnionId";
       System            postgres    false    292            �           1259    35829    IX_User_UpazillaId    INDEX     Q   CREATE INDEX "IX_User_UpazillaId" ON "System"."User" USING btree ("UpazillaId");
 *   DROP INDEX "System"."IX_User_UpazillaId";
       System            postgres    false    292            �           1259    33894    IX_User_UserRolesId    INDEX     S   CREATE INDEX "IX_User_UserRolesId" ON "System"."User" USING btree ("UserRolesId");
 +   DROP INDEX "System"."IX_User_UserRolesId";
       System            postgres    false    292            �           1259    37148 -   IX_ExpenseDetailsForCDFs_TransactionExpenseId    INDEX     �   CREATE INDEX "IX_ExpenseDetailsForCDFs_TransactionExpenseId" ON "TRANSACTION"."ExpenseDetailsForCDFs" USING btree ("TransactionExpenseId");
 J   DROP INDEX "TRANSACTION"."IX_ExpenseDetailsForCDFs_TransactionExpenseId";
       TRANSACTION            postgres    false    484            �           1259    34985     IX_TransactionDetails_FundTypeId    INDEX     r   CREATE INDEX "IX_TransactionDetails_FundTypeId" ON "TRANSACTION"."TransactionDetails" USING btree ("FundTypeId");
 =   DROP INDEX "TRANSACTION"."IX_TransactionDetails_FundTypeId";
       TRANSACTION            postgres    false    394            �           1259    34986 #   IX_TransactionDetails_TransactionId    INDEX     x   CREATE INDEX "IX_TransactionDetails_TransactionId" ON "TRANSACTION"."TransactionDetails" USING btree ("TransactionId");
 @   DROP INDEX "TRANSACTION"."IX_TransactionDetails_TransactionId";
       TRANSACTION            postgres    false    394            �           1259    37145 #   IX_TransactionExpenses_ForestBeatId    INDEX     x   CREATE INDEX "IX_TransactionExpenses_ForestBeatId" ON "TRANSACTION"."TransactionExpenses" USING btree ("ForestBeatId");
 @   DROP INDEX "TRANSACTION"."IX_TransactionExpenses_ForestBeatId";
       TRANSACTION            postgres    false    396            �           1259    37146 %   IX_TransactionExpenses_ForestFcvVcfId    INDEX     |   CREATE INDEX "IX_TransactionExpenses_ForestFcvVcfId" ON "TRANSACTION"."TransactionExpenses" USING btree ("ForestFcvVcfId");
 B   DROP INDEX "TRANSACTION"."IX_TransactionExpenses_ForestFcvVcfId";
       TRANSACTION            postgres    false    396            �           1259    37147 $   IX_TransactionExpenses_ForestRangeId    INDEX     z   CREATE INDEX "IX_TransactionExpenses_ForestRangeId" ON "TRANSACTION"."TransactionExpenses" USING btree ("ForestRangeId");
 A   DROP INDEX "TRANSACTION"."IX_TransactionExpenses_ForestRangeId";
       TRANSACTION            postgres    false    396            �           1259    34987 !   IX_TransactionExpenses_FundTypeId    INDEX     t   CREATE INDEX "IX_TransactionExpenses_FundTypeId" ON "TRANSACTION"."TransactionExpenses" USING btree ("FundTypeId");
 >   DROP INDEX "TRANSACTION"."IX_TransactionExpenses_FundTypeId";
       TRANSACTION            postgres    false    396            �           1259    34988 +   IX_TransactionExpenses_TransactionDetailsId    INDEX     �   CREATE INDEX "IX_TransactionExpenses_TransactionDetailsId" ON "TRANSACTION"."TransactionExpenses" USING btree ("TransactionDetailsId");
 H   DROP INDEX "TRANSACTION"."IX_TransactionExpenses_TransactionDetailsId";
       TRANSACTION            postgres    false    396            �           1259    34989    IX_Transactions_FinancialYearId    INDEX     p   CREATE INDEX "IX_Transactions_FinancialYearId" ON "TRANSACTION"."Transactions" USING btree ("FinancialYearId");
 <   DROP INDEX "TRANSACTION"."IX_Transactions_FinancialYearId";
       TRANSACTION            postgres    false    392            �           1259    34990    IX_Transactions_ForestCircleId    INDEX     n   CREATE INDEX "IX_Transactions_ForestCircleId" ON "TRANSACTION"."Transactions" USING btree ("ForestCircleId");
 ;   DROP INDEX "TRANSACTION"."IX_Transactions_ForestCircleId";
       TRANSACTION            postgres    false    392            �           1259    34991     IX_Transactions_ForestDivisionId    INDEX     r   CREATE INDEX "IX_Transactions_ForestDivisionId" ON "TRANSACTION"."Transactions" USING btree ("ForestDivisionId");
 =   DROP INDEX "TRANSACTION"."IX_Transactions_ForestDivisionId";
       TRANSACTION            postgres    false    392            Y           2606    35156 @   AIGBasicInformations FK_AIGBasicInformations_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "FK_AIGBasicInformations_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 m   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "FK_AIGBasicInformations_District_DistrictId";
       AIG          postgres    false    404    3991    290            Z           2606    35161 @   AIGBasicInformations FK_AIGBasicInformations_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "FK_AIGBasicInformations_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE CASCADE;
 m   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "FK_AIGBasicInformations_Division_DivisionId";
       AIG          postgres    false    404    274    3973            [           2606    35166 E   AIGBasicInformations FK_AIGBasicInformations_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "FK_AIGBasicInformations_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 r   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "FK_AIGBasicInformations_ForestBeats_ForestBeatId";
       AIG          postgres    false    404    298    4015            \           2606    35171 I   AIGBasicInformations FK_AIGBasicInformations_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "FK_AIGBasicInformations_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 v   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "FK_AIGBasicInformations_ForestCircles_ForestCircleId";
       AIG          postgres    false    248    3947    404            ]           2606    35176 M   AIGBasicInformations FK_AIGBasicInformations_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "FK_AIGBasicInformations_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 z   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "FK_AIGBasicInformations_ForestDivisions_ForestDivisionId";
       AIG          postgres    false    404    288    3988            ^           2606    35181 I   AIGBasicInformations FK_AIGBasicInformations_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "FK_AIGBasicInformations_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE CASCADE;
 v   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "FK_AIGBasicInformations_ForestFcvVcfs_ForestFcvVcfId";
       AIG          postgres    false    4018    300    404            _           2606    35186 G   AIGBasicInformations FK_AIGBasicInformations_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "FK_AIGBasicInformations_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
 t   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "FK_AIGBasicInformations_ForestRanges_ForestRangeId";
       AIG          postgres    false    294    404    4009            `           2606    35191 7   AIGBasicInformations FK_AIGBasicInformations_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "FK_AIGBasicInformations_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id") ON DELETE CASCADE;
 d   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "FK_AIGBasicInformations_Ngos_NgoId";
       AIG          postgres    false    3957    258    404            a           2606    35196 =   AIGBasicInformations FK_AIGBasicInformations_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "FK_AIGBasicInformations_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 j   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "FK_AIGBasicInformations_Surveys_SurveyId";
       AIG          postgres    false    404    4038    302            b           2606    35201 :   AIGBasicInformations FK_AIGBasicInformations_Trade_TradeId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "FK_AIGBasicInformations_Trade_TradeId" FOREIGN KEY ("TradeId") REFERENCES "BEN"."Trade"("Id") ON DELETE RESTRICT;
 g   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "FK_AIGBasicInformations_Trade_TradeId";
       AIG          postgres    false    404    4204    374            c           2606    35206 :   AIGBasicInformations FK_AIGBasicInformations_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "FK_AIGBasicInformations_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE RESTRICT;
 g   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "FK_AIGBasicInformations_Union_UnionId";
       AIG          postgres    false    404    4113    340            d           2606    35211 @   AIGBasicInformations FK_AIGBasicInformations_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."AIGBasicInformations"
    ADD CONSTRAINT "FK_AIGBasicInformations_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 m   ALTER TABLE ONLY "AIG"."AIGBasicInformations" DROP CONSTRAINT "FK_AIGBasicInformations_Upazilla_UpazillaId";
       AIG          postgres    false    296    404    4012            e           2606    35230 X   FirstSixtyPercentageLDFs FK_FirstSixtyPercentageLDFs_AIGBasicInformations_AIGBasicInfor~    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."FirstSixtyPercentageLDFs"
    ADD CONSTRAINT "FK_FirstSixtyPercentageLDFs_AIGBasicInformations_AIGBasicInfor~" FOREIGN KEY ("AIGBasicInformationId") REFERENCES "AIG"."AIGBasicInformations"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "AIG"."FirstSixtyPercentageLDFs" DROP CONSTRAINT "FK_FirstSixtyPercentageLDFs_AIGBasicInformations_AIGBasicInfor~";
       AIG          postgres    false    406    4283    404            �           2606    36214 W   GroupLDFInfoFormMembers FK_GroupLDFInfoFormMembers_GroupLDFInfoForms_GroupLDFInfoFormId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoFormMembers"
    ADD CONSTRAINT "FK_GroupLDFInfoFormMembers_GroupLDFInfoForms_GroupLDFInfoFormId" FOREIGN KEY ("GroupLDFInfoFormId") REFERENCES "AIG"."GroupLDFInfoForms"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "AIG"."GroupLDFInfoFormMembers" DROP CONSTRAINT "FK_GroupLDFInfoFormMembers_GroupLDFInfoForms_GroupLDFInfoFormId";
       AIG          postgres    false    440    4406    438            �           2606    36219 W   GroupLDFInfoFormMembers FK_GroupLDFInfoFormMembers_IndividualLDFInfoForms_IndividualLD~    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoFormMembers"
    ADD CONSTRAINT "FK_GroupLDFInfoFormMembers_IndividualLDFInfoForms_IndividualLD~" FOREIGN KEY ("IndividualLDFInfoFormId") REFERENCES "AIG"."IndividualLDFInfoForms"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "AIG"."GroupLDFInfoFormMembers" DROP CONSTRAINT "FK_GroupLDFInfoFormMembers_IndividualLDFInfoForms_IndividualLD~";
       AIG          postgres    false    440    4339    420            �           2606    36127 :   GroupLDFInfoForms FK_GroupLDFInfoForms_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms"
    ADD CONSTRAINT "FK_GroupLDFInfoForms_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 g   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms" DROP CONSTRAINT "FK_GroupLDFInfoForms_District_DistrictId";
       AIG          postgres    false    438    3991    290            �           2606    36132 :   GroupLDFInfoForms FK_GroupLDFInfoForms_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms"
    ADD CONSTRAINT "FK_GroupLDFInfoForms_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE CASCADE;
 g   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms" DROP CONSTRAINT "FK_GroupLDFInfoForms_Division_DivisionId";
       AIG          postgres    false    438    3973    274            �           2606    36137 ?   GroupLDFInfoForms FK_GroupLDFInfoForms_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms"
    ADD CONSTRAINT "FK_GroupLDFInfoForms_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 l   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms" DROP CONSTRAINT "FK_GroupLDFInfoForms_ForestBeats_ForestBeatId";
       AIG          postgres    false    438    4015    298            �           2606    36142 C   GroupLDFInfoForms FK_GroupLDFInfoForms_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms"
    ADD CONSTRAINT "FK_GroupLDFInfoForms_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 p   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms" DROP CONSTRAINT "FK_GroupLDFInfoForms_ForestCircles_ForestCircleId";
       AIG          postgres    false    438    3947    248            �           2606    36147 G   GroupLDFInfoForms FK_GroupLDFInfoForms_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms"
    ADD CONSTRAINT "FK_GroupLDFInfoForms_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 t   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms" DROP CONSTRAINT "FK_GroupLDFInfoForms_ForestDivisions_ForestDivisionId";
       AIG          postgres    false    438    3988    288            �           2606    36152 C   GroupLDFInfoForms FK_GroupLDFInfoForms_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms"
    ADD CONSTRAINT "FK_GroupLDFInfoForms_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE CASCADE;
 p   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms" DROP CONSTRAINT "FK_GroupLDFInfoForms_ForestFcvVcfs_ForestFcvVcfId";
       AIG          postgres    false    438    4018    300            �           2606    36157 A   GroupLDFInfoForms FK_GroupLDFInfoForms_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms"
    ADD CONSTRAINT "FK_GroupLDFInfoForms_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
 n   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms" DROP CONSTRAINT "FK_GroupLDFInfoForms_ForestRanges_ForestRangeId";
       AIG          postgres    false    438    4009    294            �           2606    36162 1   GroupLDFInfoForms FK_GroupLDFInfoForms_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms"
    ADD CONSTRAINT "FK_GroupLDFInfoForms_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id") ON DELETE RESTRICT;
 ^   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms" DROP CONSTRAINT "FK_GroupLDFInfoForms_Ngos_NgoId";
       AIG          postgres    false    438    3957    258            �           2606    36172 4   GroupLDFInfoForms FK_GroupLDFInfoForms_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms"
    ADD CONSTRAINT "FK_GroupLDFInfoForms_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE RESTRICT;
 a   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms" DROP CONSTRAINT "FK_GroupLDFInfoForms_Union_UnionId";
       AIG          postgres    false    438    4113    340            �           2606    36177 :   GroupLDFInfoForms FK_GroupLDFInfoForms_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms"
    ADD CONSTRAINT "FK_GroupLDFInfoForms_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 g   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms" DROP CONSTRAINT "FK_GroupLDFInfoForms_Upazilla_UpazillaId";
       AIG          postgres    false    438    4012    296            �           2606    36167 9   GroupLDFInfoForms FK_GroupLDFInfoForms_User_SubmittedById    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms"
    ADD CONSTRAINT "FK_GroupLDFInfoForms_User_SubmittedById" FOREIGN KEY ("SubmittedById") REFERENCES "System"."User"("Id") ON DELETE RESTRICT;
 f   ALTER TABLE ONLY "AIG"."GroupLDFInfoForms" DROP CONSTRAINT "FK_GroupLDFInfoForms_User_SubmittedById";
       AIG          postgres    false    438    4006    292            �           2606    35601 D   IndividualLDFInfoForms FK_IndividualLDFInfoForms_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms"
    ADD CONSTRAINT "FK_IndividualLDFInfoForms_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 q   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms" DROP CONSTRAINT "FK_IndividualLDFInfoForms_District_DistrictId";
       AIG          postgres    false    420    290    3991            �           2606    35606 D   IndividualLDFInfoForms FK_IndividualLDFInfoForms_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms"
    ADD CONSTRAINT "FK_IndividualLDFInfoForms_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE CASCADE;
 q   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms" DROP CONSTRAINT "FK_IndividualLDFInfoForms_Division_DivisionId";
       AIG          postgres    false    274    420    3973            �           2606    35611 I   IndividualLDFInfoForms FK_IndividualLDFInfoForms_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms"
    ADD CONSTRAINT "FK_IndividualLDFInfoForms_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 v   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms" DROP CONSTRAINT "FK_IndividualLDFInfoForms_ForestBeats_ForestBeatId";
       AIG          postgres    false    4015    298    420            �           2606    35616 M   IndividualLDFInfoForms FK_IndividualLDFInfoForms_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms"
    ADD CONSTRAINT "FK_IndividualLDFInfoForms_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 z   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms" DROP CONSTRAINT "FK_IndividualLDFInfoForms_ForestCircles_ForestCircleId";
       AIG          postgres    false    420    3947    248            �           2606    35621 Q   IndividualLDFInfoForms FK_IndividualLDFInfoForms_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms"
    ADD CONSTRAINT "FK_IndividualLDFInfoForms_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 ~   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms" DROP CONSTRAINT "FK_IndividualLDFInfoForms_ForestDivisions_ForestDivisionId";
       AIG          postgres    false    3988    420    288            �           2606    35626 M   IndividualLDFInfoForms FK_IndividualLDFInfoForms_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms"
    ADD CONSTRAINT "FK_IndividualLDFInfoForms_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE CASCADE;
 z   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms" DROP CONSTRAINT "FK_IndividualLDFInfoForms_ForestFcvVcfs_ForestFcvVcfId";
       AIG          postgres    false    4018    300    420            �           2606    35631 K   IndividualLDFInfoForms FK_IndividualLDFInfoForms_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms"
    ADD CONSTRAINT "FK_IndividualLDFInfoForms_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
 x   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms" DROP CONSTRAINT "FK_IndividualLDFInfoForms_ForestRanges_ForestRangeId";
       AIG          postgres    false    420    4009    294            �           2606    35673 ;   IndividualLDFInfoForms FK_IndividualLDFInfoForms_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms"
    ADD CONSTRAINT "FK_IndividualLDFInfoForms_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id") ON DELETE RESTRICT;
 h   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms" DROP CONSTRAINT "FK_IndividualLDFInfoForms_Ngos_NgoId";
       AIG          postgres    false    420    3957    258            �           2606    35636 A   IndividualLDFInfoForms FK_IndividualLDFInfoForms_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms"
    ADD CONSTRAINT "FK_IndividualLDFInfoForms_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 n   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms" DROP CONSTRAINT "FK_IndividualLDFInfoForms_Surveys_SurveyId";
       AIG          postgres    false    302    4038    420            �           2606    35641 >   IndividualLDFInfoForms FK_IndividualLDFInfoForms_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms"
    ADD CONSTRAINT "FK_IndividualLDFInfoForms_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE RESTRICT;
 k   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms" DROP CONSTRAINT "FK_IndividualLDFInfoForms_Union_UnionId";
       AIG          postgres    false    420    4113    340            �           2606    35646 D   IndividualLDFInfoForms FK_IndividualLDFInfoForms_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms"
    ADD CONSTRAINT "FK_IndividualLDFInfoForms_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 q   ALTER TABLE ONLY "AIG"."IndividualLDFInfoForms" DROP CONSTRAINT "FK_IndividualLDFInfoForms_Upazilla_UpazillaId";
       AIG          postgres    false    296    4012    420            �           2606    35491 G   LDFProgresss FK_LDFProgresss_AIGBasicInformations_AIGBasicInformationId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."LDFProgresss"
    ADD CONSTRAINT "FK_LDFProgresss_AIGBasicInformations_AIGBasicInformationId" FOREIGN KEY ("AIGBasicInformationId") REFERENCES "AIG"."AIGBasicInformations"("Id") ON DELETE CASCADE;
 t   ALTER TABLE ONLY "AIG"."LDFProgresss" DROP CONSTRAINT "FK_LDFProgresss_AIGBasicInformations_AIGBasicInformationId";
       AIG          postgres    false    418    404    4283            �           2606    35496 9   LDFProgresss FK_LDFProgresss_RepaymentLDFs_RepaymentLDFId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."LDFProgresss"
    ADD CONSTRAINT "FK_LDFProgresss_RepaymentLDFs_RepaymentLDFId" FOREIGN KEY ("RepaymentLDFId") REFERENCES "AIG"."RepaymentLDFs"("Id") ON DELETE CASCADE;
 f   ALTER TABLE ONLY "AIG"."LDFProgresss" DROP CONSTRAINT "FK_LDFProgresss_RepaymentLDFs_RepaymentLDFId";
       AIG          postgres    false    418    410    4294            �           2606    37125 C   RepaymentLDFFiles FK_RepaymentLDFFiles_RepaymentLDFs_RepaymentLDFId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."RepaymentLDFFiles"
    ADD CONSTRAINT "FK_RepaymentLDFFiles_RepaymentLDFs_RepaymentLDFId" FOREIGN KEY ("RepaymentLDFId") REFERENCES "AIG"."RepaymentLDFs"("Id") ON DELETE CASCADE;
 p   ALTER TABLE ONLY "AIG"."RepaymentLDFFiles" DROP CONSTRAINT "FK_RepaymentLDFFiles_RepaymentLDFs_RepaymentLDFId";
       AIG          postgres    false    4294    410    482            �           2606    35888 K   RepaymentLDFHistories FK_RepaymentLDFHistories_RepaymentLDFs_RepaymentLDFId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."RepaymentLDFHistories"
    ADD CONSTRAINT "FK_RepaymentLDFHistories_RepaymentLDFs_RepaymentLDFId" FOREIGN KEY ("RepaymentLDFId") REFERENCES "AIG"."RepaymentLDFs"("Id");
 x   ALTER TABLE ONLY "AIG"."RepaymentLDFHistories" DROP CONSTRAINT "FK_RepaymentLDFHistories_RepaymentLDFs_RepaymentLDFId";
       AIG          postgres    false    410    428    4294            �           2606    35883 ?   RepaymentLDFHistories FK_RepaymentLDFHistories_User_EventUserId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."RepaymentLDFHistories"
    ADD CONSTRAINT "FK_RepaymentLDFHistories_User_EventUserId" FOREIGN KEY ("EventUserId") REFERENCES "System"."User"("Id");
 l   ALTER TABLE ONLY "AIG"."RepaymentLDFHistories" DROP CONSTRAINT "FK_RepaymentLDFHistories_User_EventUserId";
       AIG          postgres    false    4006    428    292            g           2606    35461 I   RepaymentLDFs FK_RepaymentLDFs_AIGBasicInformations_AIGBasicInformationId    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."RepaymentLDFs"
    ADD CONSTRAINT "FK_RepaymentLDFs_AIGBasicInformations_AIGBasicInformationId" FOREIGN KEY ("AIGBasicInformationId") REFERENCES "AIG"."AIGBasicInformations"("Id") ON DELETE CASCADE;
 v   ALTER TABLE ONLY "AIG"."RepaymentLDFs" DROP CONSTRAINT "FK_RepaymentLDFs_AIGBasicInformations_AIGBasicInformationId";
       AIG          postgres    false    4283    404    410            h           2606    35262 M   RepaymentLDFs FK_RepaymentLDFs_FirstSixtyPercentageLDFs_FirstSixtyPercentage~    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."RepaymentLDFs"
    ADD CONSTRAINT "FK_RepaymentLDFs_FirstSixtyPercentageLDFs_FirstSixtyPercentage~" FOREIGN KEY ("FirstSixtyPercentageLDFId") REFERENCES "AIG"."FirstSixtyPercentageLDFs"("Id") ON DELETE RESTRICT;
 z   ALTER TABLE ONLY "AIG"."RepaymentLDFs" DROP CONSTRAINT "FK_RepaymentLDFs_FirstSixtyPercentageLDFs_FirstSixtyPercentage~";
       AIG          postgres    false    406    4286    410            i           2606    35267 M   RepaymentLDFs FK_RepaymentLDFs_SecondFourtyPercentageLDFs_SecondFourtyPercen~    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."RepaymentLDFs"
    ADD CONSTRAINT "FK_RepaymentLDFs_SecondFourtyPercentageLDFs_SecondFourtyPercen~" FOREIGN KEY ("SecondFourtyPercentageLDFId") REFERENCES "AIG"."SecondFourtyPercentageLDFs"("Id") ON DELETE RESTRICT;
 z   ALTER TABLE ONLY "AIG"."RepaymentLDFs" DROP CONSTRAINT "FK_RepaymentLDFs_SecondFourtyPercentageLDFs_SecondFourtyPercen~";
       AIG          postgres    false    408    4289    410            f           2606    35246 Z   SecondFourtyPercentageLDFs FK_SecondFourtyPercentageLDFs_AIGBasicInformations_AIGBasicInf~    FK CONSTRAINT     �   ALTER TABLE ONLY "AIG"."SecondFourtyPercentageLDFs"
    ADD CONSTRAINT "FK_SecondFourtyPercentageLDFs_AIGBasicInformations_AIGBasicInf~" FOREIGN KEY ("AIGBasicInformationId") REFERENCES "AIG"."AIGBasicInformations"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "AIG"."SecondFourtyPercentageLDFs" DROP CONSTRAINT "FK_SecondFourtyPercentageLDFs_AIGBasicInformations_AIGBasicInf~";
       AIG          postgres    false    4283    408    404            �           2606    33573 [   AnnualHouseholdExpenditures FK_AnnualHouseholdExpenditures_ExpenditureTypes_ExpenditureTyp~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."AnnualHouseholdExpenditures"
    ADD CONSTRAINT "FK_AnnualHouseholdExpenditures_ExpenditureTypes_ExpenditureTyp~" FOREIGN KEY ("ExpenditureTypeId") REFERENCES "BEN"."ExpenditureTypes"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "BEN"."AnnualHouseholdExpenditures" DROP CONSTRAINT "FK_AnnualHouseholdExpenditures_ExpenditureTypes_ExpenditureTyp~";
       BEN          postgres    false    244    3943    304            �           2606    33578 K   AnnualHouseholdExpenditures FK_AnnualHouseholdExpenditures_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."AnnualHouseholdExpenditures"
    ADD CONSTRAINT "FK_AnnualHouseholdExpenditures_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 x   ALTER TABLE ONLY "BEN"."AnnualHouseholdExpenditures" DROP CONSTRAINT "FK_AnnualHouseholdExpenditures_Surveys_SurveyId";
       BEN          postgres    false    4038    302    304            �           2606    33589 '   Assets FK_Assets_AssetTypes_AssetTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Assets"
    ADD CONSTRAINT "FK_Assets_AssetTypes_AssetTypeId" FOREIGN KEY ("AssetTypeId") REFERENCES "BEN"."AssetTypes"("Id") ON DELETE CASCADE;
 T   ALTER TABLE ONLY "BEN"."Assets" DROP CONSTRAINT "FK_Assets_AssetTypes_AssetTypeId";
       BEN          postgres    false    306    3931    232            �           2606    33594 !   Assets FK_Assets_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Assets"
    ADD CONSTRAINT "FK_Assets_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 N   ALTER TABLE ONLY "BEN"."Assets" DROP CONSTRAINT "FK_Assets_Surveys_SurveyId";
       BEN          postgres    false    306    302    4038            �           2606    33816 b   BFDAssociationHouseholdMembersMaps FK_BFDAssociationHouseholdMembersMaps_BFDAssociations_BFDAssoc~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."BFDAssociationHouseholdMembersMaps"
    ADD CONSTRAINT "FK_BFDAssociationHouseholdMembersMaps_BFDAssociations_BFDAssoc~" FOREIGN KEY ("BFDAssociationId") REFERENCES "BEN"."BFDAssociations"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "BEN"."BFDAssociationHouseholdMembersMaps" DROP CONSTRAINT "FK_BFDAssociationHouseholdMembersMaps_BFDAssociations_BFDAssoc~";
       BEN          postgres    false    3933    234    333            �           2606    33821 b   BFDAssociationHouseholdMembersMaps FK_BFDAssociationHouseholdMembersMaps_HouseholdMembers_Househo~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."BFDAssociationHouseholdMembersMaps"
    ADD CONSTRAINT "FK_BFDAssociationHouseholdMembersMaps_HouseholdMembers_Househo~" FOREIGN KEY ("HouseholdMemberId") REFERENCES "BEN"."HouseholdMembers"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "BEN"."BFDAssociationHouseholdMembersMaps" DROP CONSTRAINT "FK_BFDAssociationHouseholdMembersMaps_HouseholdMembers_Househo~";
       BEN          postgres    false    4071    318    333            �           2606    33605 I   Businesss FK_Businesss_BusinessIncomeSourceTypes_BusinessIncomeSourceTyp~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Businesss"
    ADD CONSTRAINT "FK_Businesss_BusinessIncomeSourceTypes_BusinessIncomeSourceTyp~" FOREIGN KEY ("BusinessIncomeSourceTypeId") REFERENCES "BEN"."BusinessIncomeSourceTypes"("Id") ON DELETE RESTRICT;
 v   ALTER TABLE ONLY "BEN"."Businesss" DROP CONSTRAINT "FK_Businesss_BusinessIncomeSourceTypes_BusinessIncomeSourceTyp~";
       BEN          postgres    false    3935    308    236            �           2606    33610 '   Businesss FK_Businesss_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Businesss"
    ADD CONSTRAINT "FK_Businesss_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 T   ALTER TABLE ONLY "BEN"."Businesss" DROP CONSTRAINT "FK_Businesss_Surveys_SurveyId";
       BEN          postgres    false    302    4038    308            �           2606    37078    CipFiles FK_CipFiles_Cips_CipId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CipFiles"
    ADD CONSTRAINT "FK_CipFiles_Cips_CipId" FOREIGN KEY ("CipId") REFERENCES "BEN"."Cips"("Id") ON DELETE CASCADE;
 L   ALTER TABLE ONLY "BEN"."CipFiles" DROP CONSTRAINT "FK_CipFiles_Cips_CipId";
       BEN          postgres    false    4445    478    450            �           2606    36751     Cips FK_Cips_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Cips"
    ADD CONSTRAINT "FK_Cips_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 M   ALTER TABLE ONLY "BEN"."Cips" DROP CONSTRAINT "FK_Cips_District_DistrictId";
       BEN          postgres    false    290    3991    450            �           2606    36756     Cips FK_Cips_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Cips"
    ADD CONSTRAINT "FK_Cips_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE CASCADE;
 M   ALTER TABLE ONLY "BEN"."Cips" DROP CONSTRAINT "FK_Cips_Division_DivisionId";
       BEN          postgres    false    450    3973    274            �           2606    36761 #   Cips FK_Cips_Ethnicitys_EthnicityId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Cips"
    ADD CONSTRAINT "FK_Cips_Ethnicitys_EthnicityId" FOREIGN KEY ("EthnicityId") REFERENCES "BEN"."Ethnicitys"("Id");
 P   ALTER TABLE ONLY "BEN"."Cips" DROP CONSTRAINT "FK_Cips_Ethnicitys_EthnicityId";
       BEN          postgres    false    450    242    3941            �           2606    36766 %   Cips FK_Cips_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Cips"
    ADD CONSTRAINT "FK_Cips_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 R   ALTER TABLE ONLY "BEN"."Cips" DROP CONSTRAINT "FK_Cips_ForestBeats_ForestBeatId";
       BEN          postgres    false    4015    298    450            �           2606    36771 )   Cips FK_Cips_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Cips"
    ADD CONSTRAINT "FK_Cips_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 V   ALTER TABLE ONLY "BEN"."Cips" DROP CONSTRAINT "FK_Cips_ForestCircles_ForestCircleId";
       BEN          postgres    false    248    450    3947            �           2606    36776 -   Cips FK_Cips_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Cips"
    ADD CONSTRAINT "FK_Cips_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 Z   ALTER TABLE ONLY "BEN"."Cips" DROP CONSTRAINT "FK_Cips_ForestDivisions_ForestDivisionId";
       BEN          postgres    false    450    288    3988            �           2606    36781 )   Cips FK_Cips_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Cips"
    ADD CONSTRAINT "FK_Cips_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE CASCADE;
 V   ALTER TABLE ONLY "BEN"."Cips" DROP CONSTRAINT "FK_Cips_ForestFcvVcfs_ForestFcvVcfId";
       BEN          postgres    false    4018    450    300            �           2606    36786 '   Cips FK_Cips_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Cips"
    ADD CONSTRAINT "FK_Cips_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
 T   ALTER TABLE ONLY "BEN"."Cips" DROP CONSTRAINT "FK_Cips_ForestRanges_ForestRangeId";
       BEN          postgres    false    294    4009    450            �           2606    36791    Cips FK_Cips_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Cips"
    ADD CONSTRAINT "FK_Cips_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id");
 G   ALTER TABLE ONLY "BEN"."Cips" DROP CONSTRAINT "FK_Cips_Union_UnionId";
       BEN          postgres    false    450    340    4113            �           2606    36796     Cips FK_Cips_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Cips"
    ADD CONSTRAINT "FK_Cips_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 M   ALTER TABLE ONLY "BEN"."Cips" DROP CONSTRAINT "FK_Cips_Upazilla_UpazillaId";
       BEN          postgres    false    296    4012    450            �           2606    37285 Y   CommitteeManagementMember FK_CommitteeManagementMember_CommitteeManagement_CommitteeMana~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagementMember"
    ADD CONSTRAINT "FK_CommitteeManagementMember_CommitteeManagement_CommitteeMana~" FOREIGN KEY ("CommitteeManagementId") REFERENCES "BEN"."CommitteeManagement"("Id");
 �   ALTER TABLE ONLY "BEN"."CommitteeManagementMember" DROP CONSTRAINT "FK_CommitteeManagementMember_CommitteeManagement_CommitteeMana~";
       BEN          postgres    false    490    488    4520            �           2606    37290 Y   CommitteeManagementMember FK_CommitteeManagementMember_OtherCommitteeMembers_OtherCommit~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagementMember"
    ADD CONSTRAINT "FK_CommitteeManagementMember_OtherCommitteeMembers_OtherCommit~" FOREIGN KEY ("OtherCommitteeMemberId") REFERENCES "BEN"."OtherCommitteeMembers"("Id");
 �   ALTER TABLE ONLY "BEN"."CommitteeManagementMember" DROP CONSTRAINT "FK_CommitteeManagementMember_OtherCommitteeMembers_OtherCommit~";
       BEN          postgres    false    490    370    4200            �           2606    37295 Y   CommitteeManagementMember FK_CommitteeManagementMember_SubCommitteeDesignations_SubCommi~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagementMember"
    ADD CONSTRAINT "FK_CommitteeManagementMember_SubCommitteeDesignations_SubCommi~" FOREIGN KEY ("SubCommitteeDesignationId") REFERENCES "GS"."SubCommitteeDesignations"("Id");
 �   ALTER TABLE ONLY "BEN"."CommitteeManagementMember" DROP CONSTRAINT "FK_CommitteeManagementMember_SubCommitteeDesignations_SubCommi~";
       BEN          postgres    false    490    4206    376                        2606    37300 G   CommitteeManagementMember FK_CommitteeManagementMember_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagementMember"
    ADD CONSTRAINT "FK_CommitteeManagementMember_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id");
 t   ALTER TABLE ONLY "BEN"."CommitteeManagementMember" DROP CONSTRAINT "FK_CommitteeManagementMember_Surveys_SurveyId";
       BEN          postgres    false    302    4038    490            �           2606    37232 >   CommitteeManagement FK_CommitteeManagement_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagement"
    ADD CONSTRAINT "FK_CommitteeManagement_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id");
 k   ALTER TABLE ONLY "BEN"."CommitteeManagement" DROP CONSTRAINT "FK_CommitteeManagement_District_DistrictId";
       BEN          postgres    false    488    290    3991            �           2606    37237 >   CommitteeManagement FK_CommitteeManagement_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagement"
    ADD CONSTRAINT "FK_CommitteeManagement_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id");
 k   ALTER TABLE ONLY "BEN"."CommitteeManagement" DROP CONSTRAINT "FK_CommitteeManagement_Division_DivisionId";
       BEN          postgres    false    274    488    3973            �           2606    37242 C   CommitteeManagement FK_CommitteeManagement_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagement"
    ADD CONSTRAINT "FK_CommitteeManagement_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id");
 p   ALTER TABLE ONLY "BEN"."CommitteeManagement" DROP CONSTRAINT "FK_CommitteeManagement_ForestBeats_ForestBeatId";
       BEN          postgres    false    4015    298    488            �           2606    37247 G   CommitteeManagement FK_CommitteeManagement_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagement"
    ADD CONSTRAINT "FK_CommitteeManagement_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id");
 t   ALTER TABLE ONLY "BEN"."CommitteeManagement" DROP CONSTRAINT "FK_CommitteeManagement_ForestCircles_ForestCircleId";
       BEN          postgres    false    248    3947    488            �           2606    37252 K   CommitteeManagement FK_CommitteeManagement_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagement"
    ADD CONSTRAINT "FK_CommitteeManagement_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id");
 x   ALTER TABLE ONLY "BEN"."CommitteeManagement" DROP CONSTRAINT "FK_CommitteeManagement_ForestDivisions_ForestDivisionId";
       BEN          postgres    false    488    3988    288            �           2606    37257 E   CommitteeManagement FK_CommitteeManagement_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagement"
    ADD CONSTRAINT "FK_CommitteeManagement_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id");
 r   ALTER TABLE ONLY "BEN"."CommitteeManagement" DROP CONSTRAINT "FK_CommitteeManagement_ForestRanges_ForestRangeId";
       BEN          postgres    false    4009    488    294            �           2606    37262 5   CommitteeManagement FK_CommitteeManagement_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagement"
    ADD CONSTRAINT "FK_CommitteeManagement_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id");
 b   ALTER TABLE ONLY "BEN"."CommitteeManagement" DROP CONSTRAINT "FK_CommitteeManagement_Ngos_NgoId";
       BEN          postgres    false    3957    258    488            �           2606    37267 8   CommitteeManagement FK_CommitteeManagement_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagement"
    ADD CONSTRAINT "FK_CommitteeManagement_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id");
 e   ALTER TABLE ONLY "BEN"."CommitteeManagement" DROP CONSTRAINT "FK_CommitteeManagement_Union_UnionId";
       BEN          postgres    false    488    4113    340            �           2606    37272 >   CommitteeManagement FK_CommitteeManagement_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."CommitteeManagement"
    ADD CONSTRAINT "FK_CommitteeManagement_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id");
 k   ALTER TABLE ONLY "BEN"."CommitteeManagement" DROP CONSTRAINT "FK_CommitteeManagement_Upazilla_UpazillaId";
       BEN          postgres    false    488    296    4012            �           2606    33831 b   DisabilityTypeHouseholdMembersMaps FK_DisabilityTypeHouseholdMembersMaps_DisabilityTypes_Disabili~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."DisabilityTypeHouseholdMembersMaps"
    ADD CONSTRAINT "FK_DisabilityTypeHouseholdMembersMaps_DisabilityTypes_Disabili~" FOREIGN KEY ("DisabilityTypeId") REFERENCES "BEN"."DisabilityTypes"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "BEN"."DisabilityTypeHouseholdMembersMaps" DROP CONSTRAINT "FK_DisabilityTypeHouseholdMembersMaps_DisabilityTypes_Disabili~";
       BEN          postgres    false    334    238    3937            �           2606    33836 b   DisabilityTypeHouseholdMembersMaps FK_DisabilityTypeHouseholdMembersMaps_HouseholdMembers_Househo~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."DisabilityTypeHouseholdMembersMaps"
    ADD CONSTRAINT "FK_DisabilityTypeHouseholdMembersMaps_HouseholdMembers_Househo~" FOREIGN KEY ("HouseholdMemberId") REFERENCES "BEN"."HouseholdMembers"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "BEN"."DisabilityTypeHouseholdMembersMaps" DROP CONSTRAINT "FK_DisabilityTypeHouseholdMembersMaps_HouseholdMembers_Househo~";
       BEN          postgres    false    318    4071    334            �           2606    33621 1   EnergyUses FK_EnergyUses_EnergyTypes_EnergyTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."EnergyUses"
    ADD CONSTRAINT "FK_EnergyUses_EnergyTypes_EnergyTypeId" FOREIGN KEY ("EnergyTypeId") REFERENCES "BEN"."EnergyTypes"("Id") ON DELETE CASCADE;
 ^   ALTER TABLE ONLY "BEN"."EnergyUses" DROP CONSTRAINT "FK_EnergyUses_EnergyTypes_EnergyTypeId";
       BEN          postgres    false    310    3939    240            �           2606    33626 )   EnergyUses FK_EnergyUses_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."EnergyUses"
    ADD CONSTRAINT "FK_EnergyUses_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 V   ALTER TABLE ONLY "BEN"."EnergyUses" DROP CONSTRAINT "FK_EnergyUses_Surveys_SurveyId";
       BEN          postgres    false    4038    302    310                       2606    34606 <   ExecutiveCommittee FK_ExecutiveCommittee_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE RESTRICT;
 i   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_District_DistrictId";
       BEN          postgres    false    3991    368    290                       2606    34611 <   ExecutiveCommittee FK_ExecutiveCommittee_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE RESTRICT;
 i   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_Division_DivisionId";
       BEN          postgres    false    368    274    3973                       2606    34392 ?   ExecutiveCommittee FK_ExecutiveCommittee_Ethnicitys_EthnicityId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_Ethnicitys_EthnicityId" FOREIGN KEY ("EthnicityId") REFERENCES "BEN"."Ethnicitys"("Id") ON DELETE RESTRICT;
 l   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_Ethnicitys_EthnicityId";
       BEN          postgres    false    3941    242    368                       2606    36704 A   ExecutiveCommittee FK_ExecutiveCommittee_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id");
 n   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_ForestBeats_ForestBeatId";
       BEN          postgres    false    368    298    4015                        2606    36709 E   ExecutiveCommittee FK_ExecutiveCommittee_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id");
 r   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_ForestCircles_ForestCircleId";
       BEN          postgres    false    248    368    3947            !           2606    34402 I   ExecutiveCommittee FK_ExecutiveCommittee_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE RESTRICT;
 v   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_ForestDivisions_ForestDivisionId";
       BEN          postgres    false    3988    288    368            "           2606    36719 E   ExecutiveCommittee FK_ExecutiveCommittee_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id");
 r   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_ForestFcvVcfs_ForestFcvVcfId";
       BEN          postgres    false    300    368    4018            #           2606    36714 C   ExecutiveCommittee FK_ExecutiveCommittee_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id");
 p   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_ForestRanges_ForestRangeId";
       BEN          postgres    false    294    4009    368            $           2606    34407 3   ExecutiveCommittee FK_ExecutiveCommittee_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id") ON DELETE RESTRICT;
 `   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_Ngos_NgoId";
       BEN          postgres    false    3957    368    258            %           2606    34562 L   ExecutiveCommittee FK_ExecutiveCommittee_OtherCommitteeMembers_OtherMemberId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_OtherCommitteeMembers_OtherMemberId" FOREIGN KEY ("OtherMemberId") REFERENCES "BEN"."OtherCommitteeMembers"("Id") ON DELETE RESTRICT;
 y   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_OtherCommitteeMembers_OtherMemberId";
       BEN          postgres    false    368    4200    370            &           2606    34584 R   ExecutiveCommittee FK_ExecutiveCommittee_SubCommitteeDesignations_SubCommitteeDes~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_SubCommitteeDesignations_SubCommitteeDes~" FOREIGN KEY ("SubCommitteeDesignationId") REFERENCES "GS"."SubCommitteeDesignations"("Id") ON DELETE RESTRICT;
    ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_SubCommitteeDesignations_SubCommitteeDes~";
       BEN          postgres    false    376    368    4206            '           2606    34412 @   ExecutiveCommittee FK_ExecutiveCommittee_Surveys_OfficeBearersId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_Surveys_OfficeBearersId" FOREIGN KEY ("OfficeBearersId") REFERENCES "BEN"."Surveys"("Id") ON DELETE RESTRICT;
 m   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_Surveys_OfficeBearersId";
       BEN          postgres    false    4038    368    302            (           2606    36102 6   ExecutiveCommittee FK_ExecutiveCommittee_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE RESTRICT;
 c   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_Union_UnionId";
       BEN          postgres    false    368    4113    340            )           2606    34616 <   ExecutiveCommittee FK_ExecutiveCommittee_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExecutiveCommittee"
    ADD CONSTRAINT "FK_ExecutiveCommittee_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE RESTRICT;
 i   ALTER TABLE ONLY "BEN"."ExecutiveCommittee" DROP CONSTRAINT "FK_ExecutiveCommittee_Upazilla_UpazillaId";
       BEN          postgres    false    4012    296    368            �           2606    33637 1   ExistingSkills FK_ExistingSkills_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ExistingSkills"
    ADD CONSTRAINT "FK_ExistingSkills_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 ^   ALTER TABLE ONLY "BEN"."ExistingSkills" DROP CONSTRAINT "FK_ExistingSkills_Surveys_SurveyId";
       BEN          postgres    false    4038    302    312                       2606    34357 E   FcvExecutiveCommitteeMember FK_FcvExecutiveCommitteeMember_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."FcvExecutiveCommitteeMember"
    ADD CONSTRAINT "FK_FcvExecutiveCommitteeMember_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id") ON DELETE RESTRICT;
 r   ALTER TABLE ONLY "BEN"."FcvExecutiveCommitteeMember" DROP CONSTRAINT "FK_FcvExecutiveCommitteeMember_Ngos_NgoId";
       BEN          postgres    false    258    3957    366            �           2606    33648 ;   FoodSecurityItems FK_FoodSecurityItems_FoodItems_FoodItemId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."FoodSecurityItems"
    ADD CONSTRAINT "FK_FoodSecurityItems_FoodItems_FoodItemId" FOREIGN KEY ("FoodItemId") REFERENCES "BEN"."FoodItems"("Id") ON DELETE CASCADE;
 h   ALTER TABLE ONLY "BEN"."FoodSecurityItems" DROP CONSTRAINT "FK_FoodSecurityItems_FoodItems_FoodItemId";
       BEN          postgres    false    314    246    3945            �           2606    33653 7   FoodSecurityItems FK_FoodSecurityItems_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."FoodSecurityItems"
    ADD CONSTRAINT "FK_FoodSecurityItems_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 d   ALTER TABLE ONLY "BEN"."FoodSecurityItems" DROP CONSTRAINT "FK_FoodSecurityItems_Surveys_SurveyId";
       BEN          postgres    false    4038    314    302            �           2606    33483 5   ForestBeats FK_ForestBeats_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ForestBeats"
    ADD CONSTRAINT "FK_ForestBeats_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
 b   ALTER TABLE ONLY "BEN"."ForestBeats" DROP CONSTRAINT "FK_ForestBeats_ForestRanges_ForestRangeId";
       BEN          postgres    false    4009    294    298            �           2606    33411 ?   ForestDivisions FK_ForestDivisions_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ForestDivisions"
    ADD CONSTRAINT "FK_ForestDivisions_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 l   ALTER TABLE ONLY "BEN"."ForestDivisions" DROP CONSTRAINT "FK_ForestDivisions_ForestCircles_ForestCircleId";
       BEN          postgres    false    248    3947    288            �           2606    33494 7   ForestFcvVcfs FK_ForestFcvVcfs_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ForestFcvVcfs"
    ADD CONSTRAINT "FK_ForestFcvVcfs_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 d   ALTER TABLE ONLY "BEN"."ForestFcvVcfs" DROP CONSTRAINT "FK_ForestFcvVcfs_ForestBeats_ForestBeatId";
       BEN          postgres    false    298    4015    300            �           2606    33461 =   ForestRanges FK_ForestRanges_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ForestRanges"
    ADD CONSTRAINT "FK_ForestRanges_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 j   ALTER TABLE ONLY "BEN"."ForestRanges" DROP CONSTRAINT "FK_ForestRanges_ForestDivisions_ForestDivisionId";
       BEN          postgres    false    288    294    3988            �           2606    33664 U   GrossMarginIncomeAndCostStatuses FK_GrossMarginIncomeAndCostStatuses_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."GrossMarginIncomeAndCostStatuses"
    ADD CONSTRAINT "FK_GrossMarginIncomeAndCostStatuses_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "BEN"."GrossMarginIncomeAndCostStatuses" DROP CONSTRAINT "FK_GrossMarginIncomeAndCostStatuses_Surveys_SurveyId";
       BEN          postgres    false    302    316    4038            �           2606    33677 A   HouseholdMembers FK_HouseholdMembers_Occupations_MainOccupationId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."HouseholdMembers"
    ADD CONSTRAINT "FK_HouseholdMembers_Occupations_MainOccupationId" FOREIGN KEY ("MainOccupationId") REFERENCES "BEN"."Occupations"("Id");
 n   ALTER TABLE ONLY "BEN"."HouseholdMembers" DROP CONSTRAINT "FK_HouseholdMembers_Occupations_MainOccupationId";
       BEN          postgres    false    260    318    3959            �           2606    33692 F   HouseholdMembers FK_HouseholdMembers_Occupations_SecondaryOccupationId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."HouseholdMembers"
    ADD CONSTRAINT "FK_HouseholdMembers_Occupations_SecondaryOccupationId" FOREIGN KEY ("SecondaryOccupationId") REFERENCES "BEN"."Occupations"("Id");
 s   ALTER TABLE ONLY "BEN"."HouseholdMembers" DROP CONSTRAINT "FK_HouseholdMembers_Occupations_SecondaryOccupationId";
       BEN          postgres    false    3959    260    318            �           2606    33682 P   HouseholdMembers FK_HouseholdMembers_RelationWithHeadHouseHoldTypes_RelationWit~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."HouseholdMembers"
    ADD CONSTRAINT "FK_HouseholdMembers_RelationWithHeadHouseHoldTypes_RelationWit~" FOREIGN KEY ("RelationWithHeadHouseHoldTypeId") REFERENCES "BEN"."RelationWithHeadHouseHoldTypes"("Id") ON DELETE CASCADE;
 }   ALTER TABLE ONLY "BEN"."HouseholdMembers" DROP CONSTRAINT "FK_HouseholdMembers_RelationWithHeadHouseHoldTypes_RelationWit~";
       BEN          postgres    false    264    318    3963            �           2606    33687 ?   HouseholdMembers FK_HouseholdMembers_SafetyNets_SafetyNetTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."HouseholdMembers"
    ADD CONSTRAINT "FK_HouseholdMembers_SafetyNets_SafetyNetTypeId" FOREIGN KEY ("SafetyNetTypeId") REFERENCES "BEN"."SafetyNets"("Id") ON DELETE CASCADE;
 l   ALTER TABLE ONLY "BEN"."HouseholdMembers" DROP CONSTRAINT "FK_HouseholdMembers_SafetyNets_SafetyNetTypeId";
       BEN          postgres    false    266    3965    318            �           2606    33697 5   HouseholdMembers FK_HouseholdMembers_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."HouseholdMembers"
    ADD CONSTRAINT "FK_HouseholdMembers_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 b   ALTER TABLE ONLY "BEN"."HouseholdMembers" DROP CONSTRAINT "FK_HouseholdMembers_Surveys_SurveyId";
       BEN          postgres    false    302    318    4038            �           2606    33708 K   ImmovableAssets FK_ImmovableAssets_ImmovableAssetTypes_ImmovableAssetTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ImmovableAssets"
    ADD CONSTRAINT "FK_ImmovableAssets_ImmovableAssetTypes_ImmovableAssetTypeId" FOREIGN KEY ("ImmovableAssetTypeId") REFERENCES "BEN"."ImmovableAssetTypes"("Id") ON DELETE CASCADE;
 x   ALTER TABLE ONLY "BEN"."ImmovableAssets" DROP CONSTRAINT "FK_ImmovableAssets_ImmovableAssetTypes_ImmovableAssetTypeId";
       BEN          postgres    false    250    320    3949            �           2606    33713 3   ImmovableAssets FK_ImmovableAssets_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ImmovableAssets"
    ADD CONSTRAINT "FK_ImmovableAssets_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 `   ALTER TABLE ONLY "BEN"."ImmovableAssets" DROP CONSTRAINT "FK_ImmovableAssets_Surveys_SurveyId";
       BEN          postgres    false    302    320    4038            �           2606    33724 3   LandOccupancies FK_LandOccupancies_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."LandOccupancies"
    ADD CONSTRAINT "FK_LandOccupancies_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 `   ALTER TABLE ONLY "BEN"."LandOccupancies" DROP CONSTRAINT "FK_LandOccupancies_Surveys_SurveyId";
       BEN          postgres    false    302    322    4038            �           2606    33735 7   LiveStocks FK_LiveStocks_LiveStockTypes_LiveStockTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."LiveStocks"
    ADD CONSTRAINT "FK_LiveStocks_LiveStockTypes_LiveStockTypeId" FOREIGN KEY ("LiveStockTypeId") REFERENCES "BEN"."LiveStockTypes"("Id") ON DELETE CASCADE;
 d   ALTER TABLE ONLY "BEN"."LiveStocks" DROP CONSTRAINT "FK_LiveStocks_LiveStockTypes_LiveStockTypeId";
       BEN          postgres    false    3951    324    252            �           2606    33740 )   LiveStocks FK_LiveStocks_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."LiveStocks"
    ADD CONSTRAINT "FK_LiveStocks_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 V   ALTER TABLE ONLY "BEN"."LiveStocks" DROP CONSTRAINT "FK_LiveStocks_Surveys_SurveyId";
       BEN          postgres    false    302    324    4038            �           2606    33751 S   ManualPhysicalWorks FK_ManualPhysicalWorks_ManualIncomeSourceTypes_ManualIncomeSou~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ManualPhysicalWorks"
    ADD CONSTRAINT "FK_ManualPhysicalWorks_ManualIncomeSourceTypes_ManualIncomeSou~" FOREIGN KEY ("ManualIncomeSourceTypeId") REFERENCES "BEN"."ManualIncomeSourceTypes"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "BEN"."ManualPhysicalWorks" DROP CONSTRAINT "FK_ManualPhysicalWorks_ManualIncomeSourceTypes_ManualIncomeSou~";
       BEN          postgres    false    3953    326    254            �           2606    33756 ;   ManualPhysicalWorks FK_ManualPhysicalWorks_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."ManualPhysicalWorks"
    ADD CONSTRAINT "FK_ManualPhysicalWorks_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 h   ALTER TABLE ONLY "BEN"."ManualPhysicalWorks" DROP CONSTRAINT "FK_ManualPhysicalWorks_Surveys_SurveyId";
       BEN          postgres    false    302    326    4038            �           2606    33767 e   NaturalResourcesIncomeAndCostStatuses FK_NaturalResourcesIncomeAndCostStatuses_NaturalIncomeSourceTy~    FK CONSTRAINT       ALTER TABLE ONLY "BEN"."NaturalResourcesIncomeAndCostStatuses"
    ADD CONSTRAINT "FK_NaturalResourcesIncomeAndCostStatuses_NaturalIncomeSourceTy~" FOREIGN KEY ("NaturalIncomeSourceTypeId") REFERENCES "BEN"."NaturalIncomeSourceTypes"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "BEN"."NaturalResourcesIncomeAndCostStatuses" DROP CONSTRAINT "FK_NaturalResourcesIncomeAndCostStatuses_NaturalIncomeSourceTy~";
       BEN          postgres    false    328    256    3955            �           2606    33772 _   NaturalResourcesIncomeAndCostStatuses FK_NaturalResourcesIncomeAndCostStatuses_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."NaturalResourcesIncomeAndCostStatuses"
    ADD CONSTRAINT "FK_NaturalResourcesIncomeAndCostStatuses_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "BEN"."NaturalResourcesIncomeAndCostStatuses" DROP CONSTRAINT "FK_NaturalResourcesIncomeAndCostStatuses_Surveys_SurveyId";
       BEN          postgres    false    4038    302    328            *           2606    34621 B   OtherCommitteeMembers FK_OtherCommitteeMembers_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers"
    ADD CONSTRAINT "FK_OtherCommitteeMembers_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 o   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers" DROP CONSTRAINT "FK_OtherCommitteeMembers_District_DistrictId";
       BEN          postgres    false    290    3991    370            +           2606    34626 B   OtherCommitteeMembers FK_OtherCommitteeMembers_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers"
    ADD CONSTRAINT "FK_OtherCommitteeMembers_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE CASCADE;
 o   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers" DROP CONSTRAINT "FK_OtherCommitteeMembers_Division_DivisionId";
       BEN          postgres    false    3973    274    370            ,           2606    34430 E   OtherCommitteeMembers FK_OtherCommitteeMembers_Ethnicitys_EthnicityId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers"
    ADD CONSTRAINT "FK_OtherCommitteeMembers_Ethnicitys_EthnicityId" FOREIGN KEY ("EthnicityId") REFERENCES "BEN"."Ethnicitys"("Id") ON DELETE RESTRICT;
 r   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers" DROP CONSTRAINT "FK_OtherCommitteeMembers_Ethnicitys_EthnicityId";
       BEN          postgres    false    370    242    3941            -           2606    34631 G   OtherCommitteeMembers FK_OtherCommitteeMembers_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers"
    ADD CONSTRAINT "FK_OtherCommitteeMembers_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 t   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers" DROP CONSTRAINT "FK_OtherCommitteeMembers_ForestBeats_ForestBeatId";
       BEN          postgres    false    298    370    4015            .           2606    34636 K   OtherCommitteeMembers FK_OtherCommitteeMembers_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers"
    ADD CONSTRAINT "FK_OtherCommitteeMembers_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 x   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers" DROP CONSTRAINT "FK_OtherCommitteeMembers_ForestCircles_ForestCircleId";
       BEN          postgres    false    370    3947    248            /           2606    34641 O   OtherCommitteeMembers FK_OtherCommitteeMembers_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers"
    ADD CONSTRAINT "FK_OtherCommitteeMembers_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 |   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers" DROP CONSTRAINT "FK_OtherCommitteeMembers_ForestDivisions_ForestDivisionId";
       BEN          postgres    false    370    288    3988            0           2606    34435 K   OtherCommitteeMembers FK_OtherCommitteeMembers_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers"
    ADD CONSTRAINT "FK_OtherCommitteeMembers_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE CASCADE;
 x   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers" DROP CONSTRAINT "FK_OtherCommitteeMembers_ForestFcvVcfs_ForestFcvVcfId";
       BEN          postgres    false    4018    300    370            1           2606    34646 I   OtherCommitteeMembers FK_OtherCommitteeMembers_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers"
    ADD CONSTRAINT "FK_OtherCommitteeMembers_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
 v   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers" DROP CONSTRAINT "FK_OtherCommitteeMembers_ForestRanges_ForestRangeId";
       BEN          postgres    false    294    370    4009            2           2606    36812 <   OtherCommitteeMembers FK_OtherCommitteeMembers_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers"
    ADD CONSTRAINT "FK_OtherCommitteeMembers_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id");
 i   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers" DROP CONSTRAINT "FK_OtherCommitteeMembers_Union_UnionId";
       BEN          postgres    false    340    4113    370            3           2606    34651 B   OtherCommitteeMembers FK_OtherCommitteeMembers_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers"
    ADD CONSTRAINT "FK_OtherCommitteeMembers_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 o   ALTER TABLE ONLY "BEN"."OtherCommitteeMembers" DROP CONSTRAINT "FK_OtherCommitteeMembers_Upazilla_UpazillaId";
       BEN          postgres    false    4012    296    370            �           2606    33783 R   OtherIncomeSources FK_OtherIncomeSources_OtherIncomeSourceTypes_OtherIncomeSource~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."OtherIncomeSources"
    ADD CONSTRAINT "FK_OtherIncomeSources_OtherIncomeSourceTypes_OtherIncomeSource~" FOREIGN KEY ("OtherIncomeSourceTypeId") REFERENCES "BEN"."OtherIncomeSourceTypes"("Id") ON DELETE RESTRICT;
    ALTER TABLE ONLY "BEN"."OtherIncomeSources" DROP CONSTRAINT "FK_OtherIncomeSources_OtherIncomeSourceTypes_OtherIncomeSource~";
       BEN          postgres    false    3961    262    330            �           2606    33788 9   OtherIncomeSources FK_OtherIncomeSources_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."OtherIncomeSources"
    ADD CONSTRAINT "FK_OtherIncomeSources_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 f   ALTER TABLE ONLY "BEN"."OtherIncomeSources" DROP CONSTRAINT "FK_OtherIncomeSources_Surveys_SurveyId";
       BEN          postgres    false    330    4038    302            �           2606    35743 3   SurveyDocuments FK_SurveyDocuments_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."SurveyDocuments"
    ADD CONSTRAINT "FK_SurveyDocuments_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id");
 `   ALTER TABLE ONLY "BEN"."SurveyDocuments" DROP CONSTRAINT "FK_SurveyDocuments_Surveys_SurveyId";
       BEN          postgres    false    424    4038    302            �           2606    37172 3   SurveyIncidents FK_SurveyIncidents_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."SurveyIncidents"
    ADD CONSTRAINT "FK_SurveyIncidents_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 `   ALTER TABLE ONLY "BEN"."SurveyIncidents" DROP CONSTRAINT "FK_SurveyIncidents_Surveys_SurveyId";
       BEN          postgres    false    4038    302    486            �           2606    37110    Surveys FK_Surveys_Cips_CipId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_Cips_CipId" FOREIGN KEY ("CipId") REFERENCES "BEN"."Cips"("Id");
 J   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_Cips_CipId";
       BEN          postgres    false    4445    450    302            �           2606    33537 /   Surveys FK_Surveys_District_PermanentDistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_District_PermanentDistrictId" FOREIGN KEY ("PermanentDistrictId") REFERENCES "GS"."District"("Id");
 \   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_District_PermanentDistrictId";
       BEN          postgres    false    302    3991    290            �           2606    33552 -   Surveys FK_Surveys_District_PresentDistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_District_PresentDistrictId" FOREIGN KEY ("PresentDistrictId") REFERENCES "GS"."District"("Id");
 Z   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_District_PresentDistrictId";
       BEN          postgres    false    3991    302    290            �           2606    33542 /   Surveys FK_Surveys_Division_PermanentDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_Division_PermanentDivisionId" FOREIGN KEY ("PermanentDivisionId") REFERENCES "GS"."Division"("Id");
 \   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_Division_PermanentDivisionId";
       BEN          postgres    false    274    302    3973            �           2606    33557 -   Surveys FK_Surveys_Division_PresentDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_Division_PresentDivisionId" FOREIGN KEY ("PresentDivisionId") REFERENCES "GS"."Division"("Id");
 Z   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_Division_PresentDivisionId";
       BEN          postgres    false    3973    302    274            �           2606    33507 4   Surveys FK_Surveys_Ethnicitys_BeneficiaryEthnicityId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_Ethnicitys_BeneficiaryEthnicityId" FOREIGN KEY ("BeneficiaryEthnicityId") REFERENCES "BEN"."Ethnicitys"("Id") ON DELETE RESTRICT;
 a   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_Ethnicitys_BeneficiaryEthnicityId";
       BEN          postgres    false    302    3941    242            �           2606    33512 +   Surveys FK_Surveys_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id");
 X   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_ForestBeats_ForestBeatId";
       BEN          postgres    false    298    302    4015            �           2606    33517 /   Surveys FK_Surveys_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id");
 \   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_ForestCircles_ForestCircleId";
       BEN          postgres    false    3947    248    302            �           2606    33522 3   Surveys FK_Surveys_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id");
 `   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_ForestDivisions_ForestDivisionId";
       BEN          postgres    false    302    288    3988            �           2606    33527 /   Surveys FK_Surveys_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id");
 \   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_ForestFcvVcfs_ForestFcvVcfId";
       BEN          postgres    false    302    300    4018            �           2606    33532 -   Surveys FK_Surveys_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id");
 Z   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_ForestRanges_ForestRangeId";
       BEN          postgres    false    294    302    4009            �           2606    35683    Surveys FK_Surveys_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id");
 J   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_Ngos_NgoId";
       BEN          postgres    false    302    3957    258            �           2606    35688 ,   Surveys FK_Surveys_Union_PermanentUnionNewId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_Union_PermanentUnionNewId" FOREIGN KEY ("PermanentUnionNewId") REFERENCES "GS"."Union"("Id");
 Y   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_Union_PermanentUnionNewId";
       BEN          postgres    false    302    4113    340            �           2606    35693 *   Surveys FK_Surveys_Union_PresentUnionNewId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_Union_PresentUnionNewId" FOREIGN KEY ("PresentUnionNewId") REFERENCES "GS"."Union"("Id");
 W   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_Union_PresentUnionNewId";
       BEN          postgres    false    302    4113    340            �           2606    33547 /   Surveys FK_Surveys_Upazilla_PermanentUpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_Upazilla_PermanentUpazillaId" FOREIGN KEY ("PermanentUpazillaId") REFERENCES "GS"."Upazilla"("Id");
 \   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_Upazilla_PermanentUpazillaId";
       BEN          postgres    false    4012    296    302            �           2606    33562 -   Surveys FK_Surveys_Upazilla_PresentUpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_Upazilla_PresentUpazillaId" FOREIGN KEY ("PresentUpazillaId") REFERENCES "GS"."Upazilla"("Id");
 Z   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_Upazilla_PresentUpazillaId";
       BEN          postgres    false    296    4012    302            �           2606    36738 4   Surveys FK_Surveys_User_BeneficiaryApproveStatusById    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."Surveys"
    ADD CONSTRAINT "FK_Surveys_User_BeneficiaryApproveStatusById" FOREIGN KEY ("BeneficiaryApproveStatusById") REFERENCES "System"."User"("Id");
 a   ALTER TABLE ONLY "BEN"."Surveys" DROP CONSTRAINT "FK_Surveys_User_BeneficiaryApproveStatusById";
       BEN          postgres    false    292    302    4006            �           2606    33801 C   VulnerabilitySituations FK_VulnerabilitySituations_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."VulnerabilitySituations"
    ADD CONSTRAINT "FK_VulnerabilitySituations_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 p   ALTER TABLE ONLY "BEN"."VulnerabilitySituations" DROP CONSTRAINT "FK_VulnerabilitySituations_Surveys_SurveyId";
       BEN          postgres    false    302    332    4038            �           2606    33806 W   VulnerabilitySituations FK_VulnerabilitySituations_VulnerabilitySituationTypes_Vulnera~    FK CONSTRAINT     �   ALTER TABLE ONLY "BEN"."VulnerabilitySituations"
    ADD CONSTRAINT "FK_VulnerabilitySituations_VulnerabilitySituationTypes_Vulnera~" FOREIGN KEY ("VulnerabilitySituationTypeId") REFERENCES "BEN"."VulnerabilitySituationTypes"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "BEN"."VulnerabilitySituations" DROP CONSTRAINT "FK_VulnerabilitySituations_VulnerabilitySituationTypes_Vulnera~";
       BEN          postgres    false    268    3967    332            M           2606    35066 4   SavingsAccount FK_SavingsAccount_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "BSA"."SavingsAccount"
    ADD CONSTRAINT "FK_SavingsAccount_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE RESTRICT;
 a   ALTER TABLE ONLY "BSA"."SavingsAccount" DROP CONSTRAINT "FK_SavingsAccount_District_DistrictId";
       BSA          postgres    false    398    290    3991            N           2606    35071 4   SavingsAccount FK_SavingsAccount_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BSA"."SavingsAccount"
    ADD CONSTRAINT "FK_SavingsAccount_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE RESTRICT;
 a   ALTER TABLE ONLY "BSA"."SavingsAccount" DROP CONSTRAINT "FK_SavingsAccount_Division_DivisionId";
       BSA          postgres    false    3973    274    398            O           2606    35076 9   SavingsAccount FK_SavingsAccount_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "BSA"."SavingsAccount"
    ADD CONSTRAINT "FK_SavingsAccount_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE RESTRICT;
 f   ALTER TABLE ONLY "BSA"."SavingsAccount" DROP CONSTRAINT "FK_SavingsAccount_ForestBeats_ForestBeatId";
       BSA          postgres    false    398    298    4015            P           2606    35081 =   SavingsAccount FK_SavingsAccount_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "BSA"."SavingsAccount"
    ADD CONSTRAINT "FK_SavingsAccount_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE RESTRICT;
 j   ALTER TABLE ONLY "BSA"."SavingsAccount" DROP CONSTRAINT "FK_SavingsAccount_ForestCircles_ForestCircleId";
       BSA          postgres    false    248    398    3947            Q           2606    35086 A   SavingsAccount FK_SavingsAccount_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BSA"."SavingsAccount"
    ADD CONSTRAINT "FK_SavingsAccount_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE RESTRICT;
 n   ALTER TABLE ONLY "BSA"."SavingsAccount" DROP CONSTRAINT "FK_SavingsAccount_ForestDivisions_ForestDivisionId";
       BSA          postgres    false    398    288    3988            R           2606    35091 ;   SavingsAccount FK_SavingsAccount_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "BSA"."SavingsAccount"
    ADD CONSTRAINT "FK_SavingsAccount_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE RESTRICT;
 h   ALTER TABLE ONLY "BSA"."SavingsAccount" DROP CONSTRAINT "FK_SavingsAccount_ForestRanges_ForestRangeId";
       BSA          postgres    false    398    4009    294            S           2606    35096 +   SavingsAccount FK_SavingsAccount_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "BSA"."SavingsAccount"
    ADD CONSTRAINT "FK_SavingsAccount_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id") ON DELETE RESTRICT;
 X   ALTER TABLE ONLY "BSA"."SavingsAccount" DROP CONSTRAINT "FK_SavingsAccount_Ngos_NgoId";
       BSA          postgres    false    258    398    3957            T           2606    35101 1   SavingsAccount FK_SavingsAccount_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "BSA"."SavingsAccount"
    ADD CONSTRAINT "FK_SavingsAccount_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE RESTRICT;
 ^   ALTER TABLE ONLY "BSA"."SavingsAccount" DROP CONSTRAINT "FK_SavingsAccount_Surveys_SurveyId";
       BSA          postgres    false    398    302    4038            U           2606    35699 .   SavingsAccount FK_SavingsAccount_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "BSA"."SavingsAccount"
    ADD CONSTRAINT "FK_SavingsAccount_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE RESTRICT;
 [   ALTER TABLE ONLY "BSA"."SavingsAccount" DROP CONSTRAINT "FK_SavingsAccount_Union_UnionId";
       BSA          postgres    false    398    4113    340            V           2606    35106 4   SavingsAccount FK_SavingsAccount_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "BSA"."SavingsAccount"
    ADD CONSTRAINT "FK_SavingsAccount_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE RESTRICT;
 a   ALTER TABLE ONLY "BSA"."SavingsAccount" DROP CONSTRAINT "FK_SavingsAccount_Upazilla_UpazillaId";
       BSA          postgres    false    296    4012    398            W           2606    35130 T   SavingsAmountInformation FK_SavingsAmountInformation_SavingsAccount_SavingsAccountId    FK CONSTRAINT     �   ALTER TABLE ONLY "BSA"."SavingsAmountInformation"
    ADD CONSTRAINT "FK_SavingsAmountInformation_SavingsAccount_SavingsAccountId" FOREIGN KEY ("SavingsAccountId") REFERENCES "BSA"."SavingsAccount"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "BSA"."SavingsAmountInformation" DROP CONSTRAINT "FK_SavingsAmountInformation_SavingsAccount_SavingsAccountId";
       BSA          postgres    false    4263    398    400            X           2606    35143 V   WithdrawAmountInformation FK_WithdrawAmountInformation_SavingsAccount_SavingsAccountId    FK CONSTRAINT     �   ALTER TABLE ONLY "BSA"."WithdrawAmountInformation"
    ADD CONSTRAINT "FK_WithdrawAmountInformation_SavingsAccount_SavingsAccountId" FOREIGN KEY ("SavingsAccountId") REFERENCES "BSA"."SavingsAccount"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "BSA"."WithdrawAmountInformation" DROP CONSTRAINT "FK_WithdrawAmountInformation_SavingsAccount_SavingsAccountId";
       BSA          postgres    false    398    402    4263            
           2606    34175 V   CommunityTrainingFiles FK_CommunityTrainingFiles_CommunityTrainings_CommunityTraining~    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainingFiles"
    ADD CONSTRAINT "FK_CommunityTrainingFiles_CommunityTrainings_CommunityTraining~" FOREIGN KEY ("CommunityTrainingId") REFERENCES "Capacity"."CommunityTrainings"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "Capacity"."CommunityTrainingFiles" DROP CONSTRAINT "FK_CommunityTrainingFiles_CommunityTrainings_CommunityTraining~";
       Capacity          postgres    false    4140    352    354            �           2606    34080 a   CommunityTrainingParticipentsMaps FK_CommunityTrainingParticipentsMaps_CommunityTrainingMembers_~    FK CONSTRAINT     
  ALTER TABLE ONLY "Capacity"."CommunityTrainingParticipentsMaps"
    ADD CONSTRAINT "FK_CommunityTrainingParticipentsMaps_CommunityTrainingMembers_~" FOREIGN KEY ("CommunityTrainingMemberId") REFERENCES "Capacity"."CommunityTrainingMembers"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Capacity"."CommunityTrainingParticipentsMaps" DROP CONSTRAINT "FK_CommunityTrainingParticipentsMaps_CommunityTrainingMembers_~";
       Capacity          postgres    false    4115    350    342            �           2606    34304 a   CommunityTrainingParticipentsMaps FK_CommunityTrainingParticipentsMaps_CommunityTrainings_Commun~    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainingParticipentsMaps"
    ADD CONSTRAINT "FK_CommunityTrainingParticipentsMaps_CommunityTrainings_Commun~" FOREIGN KEY ("CommunityTrainingId") REFERENCES "Capacity"."CommunityTrainings"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "Capacity"."CommunityTrainingParticipentsMaps" DROP CONSTRAINT "FK_CommunityTrainingParticipentsMaps_CommunityTrainings_Commun~";
       Capacity          postgres    false    4140    350    352            �           2606    34085 W   CommunityTrainingParticipentsMaps FK_CommunityTrainingParticipentsMaps_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainingParticipentsMaps"
    ADD CONSTRAINT "FK_CommunityTrainingParticipentsMaps_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Capacity"."CommunityTrainingParticipentsMaps" DROP CONSTRAINT "FK_CommunityTrainingParticipentsMaps_Surveys_SurveyId";
       Capacity          postgres    false    350    4038    302            �           2606    34309 R   CommunityTrainings FK_CommunityTrainings_CommunityTrainingTypes_CommunityTraining~    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "FK_CommunityTrainings_CommunityTrainingTypes_CommunityTraining~" FOREIGN KEY ("CommunityTrainingTypeId") REFERENCES "Capacity"."CommunityTrainingTypes"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "FK_CommunityTrainings_CommunityTrainingTypes_CommunityTraining~";
       Capacity          postgres    false    352    344    4117            �           2606    34103 <   CommunityTrainings FK_CommunityTrainings_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "FK_CommunityTrainings_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 n   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "FK_CommunityTrainings_District_DistrictId";
       Capacity          postgres    false    352    3991    290                        2606    34108 <   CommunityTrainings FK_CommunityTrainings_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "FK_CommunityTrainings_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE CASCADE;
 n   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "FK_CommunityTrainings_Division_DivisionId";
       Capacity          postgres    false    352    3973    274                       2606    34113 ?   CommunityTrainings FK_CommunityTrainings_EventTypes_EventTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "FK_CommunityTrainings_EventTypes_EventTypeId" FOREIGN KEY ("EventTypeId") REFERENCES "Capacity"."EventTypes"("Id") ON DELETE CASCADE;
 q   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "FK_CommunityTrainings_EventTypes_EventTypeId";
       Capacity          postgres    false    352    4119    346                       2606    34118 A   CommunityTrainings FK_CommunityTrainings_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "FK_CommunityTrainings_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 s   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "FK_CommunityTrainings_ForestBeats_ForestBeatId";
       Capacity          postgres    false    352    4015    298                       2606    34123 E   CommunityTrainings FK_CommunityTrainings_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "FK_CommunityTrainings_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 w   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "FK_CommunityTrainings_ForestCircles_ForestCircleId";
       Capacity          postgres    false    352    3947    248                       2606    34128 I   CommunityTrainings FK_CommunityTrainings_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "FK_CommunityTrainings_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 {   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "FK_CommunityTrainings_ForestDivisions_ForestDivisionId";
       Capacity          postgres    false    352    288    3988                       2606    34133 E   CommunityTrainings FK_CommunityTrainings_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "FK_CommunityTrainings_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE CASCADE;
 w   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "FK_CommunityTrainings_ForestFcvVcfs_ForestFcvVcfId";
       Capacity          postgres    false    4018    352    300                       2606    34138 C   CommunityTrainings FK_CommunityTrainings_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "FK_CommunityTrainings_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
 u   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "FK_CommunityTrainings_ForestRanges_ForestRangeId";
       Capacity          postgres    false    294    352    4009                       2606    34143 O   CommunityTrainings FK_CommunityTrainings_TrainingOrganizers_TrainingOrganizerId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "FK_CommunityTrainings_TrainingOrganizers_TrainingOrganizerId" FOREIGN KEY ("TrainingOrganizerId") REFERENCES "Capacity"."TrainingOrganizers"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "FK_CommunityTrainings_TrainingOrganizers_TrainingOrganizerId";
       Capacity          postgres    false    352    4121    348                       2606    35705 6   CommunityTrainings FK_CommunityTrainings_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "FK_CommunityTrainings_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE RESTRICT;
 h   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "FK_CommunityTrainings_Union_UnionId";
       Capacity          postgres    false    352    4113    340            	           2606    34148 <   CommunityTrainings FK_CommunityTrainings_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."CommunityTrainings"
    ADD CONSTRAINT "FK_CommunityTrainings_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 n   ALTER TABLE ONLY "Capacity"."CommunityTrainings" DROP CONSTRAINT "FK_CommunityTrainings_Upazilla_UpazillaId";
       Capacity          postgres    false    296    352    4012                       2606    34267 Y   DepartmentalTrainingFiles FK_DepartmentalTrainingFiles_DepartmentalTrainings_Departmenta~    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingFiles"
    ADD CONSTRAINT "FK_DepartmentalTrainingFiles_DepartmentalTrainings_Departmenta~" FOREIGN KEY ("DepartmentalTrainingId") REFERENCES "Capacity"."DepartmentalTrainings"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingFiles" DROP CONSTRAINT "FK_DepartmentalTrainingFiles_DepartmentalTrainings_Departmenta~";
       Capacity          postgres    false    360    362    4162                       2606    34908 Q   DepartmentalTrainingMembers FK_DepartmentalTrainingMembers_Ethnicitys_EthnicityId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingMembers"
    ADD CONSTRAINT "FK_DepartmentalTrainingMembers_Ethnicitys_EthnicityId" FOREIGN KEY ("EthnicityId") REFERENCES "BEN"."Ethnicitys"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingMembers" DROP CONSTRAINT "FK_DepartmentalTrainingMembers_Ethnicitys_EthnicityId";
       Capacity          postgres    false    3941    356    242                       2606    34283 d   DepartmentalTrainingParticipentsMaps FK_DepartmentalTrainingParticipentsMaps_DepartmentalTrainingMe~    FK CONSTRAINT       ALTER TABLE ONLY "Capacity"."DepartmentalTrainingParticipentsMaps"
    ADD CONSTRAINT "FK_DepartmentalTrainingParticipentsMaps_DepartmentalTrainingMe~" FOREIGN KEY ("DepartmentalTrainingMemberId") REFERENCES "Capacity"."DepartmentalTrainingMembers"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingParticipentsMaps" DROP CONSTRAINT "FK_DepartmentalTrainingParticipentsMaps_DepartmentalTrainingMe~";
       Capacity          postgres    false    356    4146    364                       2606    34278 d   DepartmentalTrainingParticipentsMaps FK_DepartmentalTrainingParticipentsMaps_DepartmentalTrainings_~    FK CONSTRAINT       ALTER TABLE ONLY "Capacity"."DepartmentalTrainingParticipentsMaps"
    ADD CONSTRAINT "FK_DepartmentalTrainingParticipentsMaps_DepartmentalTrainings_~" FOREIGN KEY ("DepartmentalTrainingId") REFERENCES "Capacity"."DepartmentalTrainings"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainingParticipentsMaps" DROP CONSTRAINT "FK_DepartmentalTrainingParticipentsMaps_DepartmentalTrainings_~";
       Capacity          postgres    false    4162    360    364                       2606    34204 U   DepartmentalTrainings FK_DepartmentalTrainings_DepartmentalTrainingTypes_Departmenta~    FK CONSTRAINT        ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "FK_DepartmentalTrainings_DepartmentalTrainingTypes_Departmenta~" FOREIGN KEY ("DepartmentalTrainingTypeId") REFERENCES "Capacity"."DepartmentalTrainingTypes"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "FK_DepartmentalTrainings_DepartmentalTrainingTypes_Departmenta~";
       Capacity          postgres    false    4148    360    358                       2606    34497 B   DepartmentalTrainings FK_DepartmentalTrainings_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "FK_DepartmentalTrainings_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE RESTRICT;
 t   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "FK_DepartmentalTrainings_District_DistrictId";
       Capacity          postgres    false    290    360    3991                       2606    34502 B   DepartmentalTrainings FK_DepartmentalTrainings_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "FK_DepartmentalTrainings_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE RESTRICT;
 t   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "FK_DepartmentalTrainings_Division_DivisionId";
       Capacity          postgres    false    274    3973    360                       2606    34219 E   DepartmentalTrainings FK_DepartmentalTrainings_EventTypes_EventTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "FK_DepartmentalTrainings_EventTypes_EventTypeId" FOREIGN KEY ("EventTypeId") REFERENCES "Capacity"."EventTypes"("Id") ON DELETE CASCADE;
 w   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "FK_DepartmentalTrainings_EventTypes_EventTypeId";
       Capacity          postgres    false    360    346    4119                       2606    34993 M   DepartmentalTrainings FK_DepartmentalTrainings_FinancialYears_FinancialYearId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "FK_DepartmentalTrainings_FinancialYears_FinancialYearId" FOREIGN KEY ("FinancialYearId") REFERENCES "GS"."FinancialYears"("Id") ON DELETE RESTRICT;
    ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "FK_DepartmentalTrainings_FinancialYears_FinancialYearId";
       Capacity          postgres    false    360    4233    388                       2606    34507 G   DepartmentalTrainings FK_DepartmentalTrainings_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "FK_DepartmentalTrainings_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE RESTRICT;
 y   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "FK_DepartmentalTrainings_ForestBeats_ForestBeatId";
       Capacity          postgres    false    4015    360    298                       2606    34512 K   DepartmentalTrainings FK_DepartmentalTrainings_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "FK_DepartmentalTrainings_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE RESTRICT;
 }   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "FK_DepartmentalTrainings_ForestCircles_ForestCircleId";
       Capacity          postgres    false    248    360    3947                       2606    34517 O   DepartmentalTrainings FK_DepartmentalTrainings_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "FK_DepartmentalTrainings_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "FK_DepartmentalTrainings_ForestDivisions_ForestDivisionId";
       Capacity          postgres    false    288    3988    360                       2606    34522 K   DepartmentalTrainings FK_DepartmentalTrainings_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "FK_DepartmentalTrainings_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE RESTRICT;
 }   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "FK_DepartmentalTrainings_ForestFcvVcfs_ForestFcvVcfId";
       Capacity          postgres    false    360    4018    300                       2606    34527 I   DepartmentalTrainings FK_DepartmentalTrainings_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "FK_DepartmentalTrainings_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE RESTRICT;
 {   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "FK_DepartmentalTrainings_ForestRanges_ForestRangeId";
       Capacity          postgres    false    294    360    4009                       2606    34249 U   DepartmentalTrainings FK_DepartmentalTrainings_TrainingOrganizers_TrainingOrganizerId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "FK_DepartmentalTrainings_TrainingOrganizers_TrainingOrganizerId" FOREIGN KEY ("TrainingOrganizerId") REFERENCES "Capacity"."TrainingOrganizers"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "FK_DepartmentalTrainings_TrainingOrganizers_TrainingOrganizerId";
       Capacity          postgres    false    360    348    4121                       2606    34532 B   DepartmentalTrainings FK_DepartmentalTrainings_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings"
    ADD CONSTRAINT "FK_DepartmentalTrainings_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE RESTRICT;
 t   ALTER TABLE ONLY "Capacity"."DepartmentalTrainings" DROP CONSTRAINT "FK_DepartmentalTrainings_Upazilla_UpazillaId";
       Capacity          postgres    false    296    4012    360            ?           2606    34737 Q   MeetingParticipantsMaps FK_MeetingParticipantsMaps_MeetingMembers_MeetingMemberId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."MeetingParticipantsMaps"
    ADD CONSTRAINT "FK_MeetingParticipantsMaps_MeetingMembers_MeetingMemberId" FOREIGN KEY ("MeetingMemberId") REFERENCES "Meeting"."MeetingMembers"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Capacity"."MeetingParticipantsMaps" DROP CONSTRAINT "FK_MeetingParticipantsMaps_MeetingMembers_MeetingMemberId";
       Capacity          postgres    false    4208    378    384            @           2606    34732 E   MeetingParticipantsMaps FK_MeetingParticipantsMaps_Meetings_MeetingId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."MeetingParticipantsMaps"
    ADD CONSTRAINT "FK_MeetingParticipantsMaps_Meetings_MeetingId" FOREIGN KEY ("MeetingId") REFERENCES "Meeting"."Meetings"("Id") ON DELETE CASCADE;
 w   ALTER TABLE ONLY "Capacity"."MeetingParticipantsMaps" DROP CONSTRAINT "FK_MeetingParticipantsMaps_Meetings_MeetingId";
       Capacity          postgres    false    382    4223    384            A           2606    34742 C   MeetingParticipantsMaps FK_MeetingParticipantsMaps_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "Capacity"."MeetingParticipantsMaps"
    ADD CONSTRAINT "FK_MeetingParticipantsMaps_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE RESTRICT;
 u   ALTER TABLE ONLY "Capacity"."MeetingParticipantsMaps" DROP CONSTRAINT "FK_MeetingParticipantsMaps_Surveys_SurveyId";
       Capacity          postgres    false    302    4038    384            �           2606    33427 (   District FK_District_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "GS"."District"
    ADD CONSTRAINT "FK_District_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE RESTRICT;
 T   ALTER TABLE ONLY "GS"."District" DROP CONSTRAINT "FK_District_Division_DivisionId";
       GS          postgres    false    290    3973    274            �           2606    34035 "   Union FK_Union_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "GS"."Union"
    ADD CONSTRAINT "FK_Union_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 N   ALTER TABLE ONLY "GS"."Union" DROP CONSTRAINT "FK_Union_Upazilla_UpazillaId";
       GS          postgres    false    4012    340    296            �           2606    33472 (   Upazilla FK_Upazilla_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "GS"."Upazilla"
    ADD CONSTRAINT "FK_Upazilla_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 T   ALTER TABLE ONLY "GS"."Upazilla" DROP CONSTRAINT "FK_Upazilla_District_DistrictId";
       GS          postgres    false    3991    290    296            �           2606    37104 \   InternalLoanInformationFiles FK_InternalLoanInformationFiles_InternalLoanInformations_Inter~    FK CONSTRAINT       ALTER TABLE ONLY "InternalLoan"."InternalLoanInformationFiles"
    ADD CONSTRAINT "FK_InternalLoanInformationFiles_InternalLoanInformations_Inter~" FOREIGN KEY ("InternalLoanInformationId") REFERENCES "InternalLoan"."InternalLoanInformations"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformationFiles" DROP CONSTRAINT "FK_InternalLoanInformationFiles_InternalLoanInformations_Inter~";
       InternalLoan          postgres    false    480    426    4357            �           2606    35755 H   InternalLoanInformations FK_InternalLoanInformations_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations"
    ADD CONSTRAINT "FK_InternalLoanInformations_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 ~   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations" DROP CONSTRAINT "FK_InternalLoanInformations_District_DistrictId";
       InternalLoan          postgres    false    3991    290    426            �           2606    35760 H   InternalLoanInformations FK_InternalLoanInformations_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations"
    ADD CONSTRAINT "FK_InternalLoanInformations_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE CASCADE;
 ~   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations" DROP CONSTRAINT "FK_InternalLoanInformations_Division_DivisionId";
       InternalLoan          postgres    false    426    274    3973            �           2606    35765 M   InternalLoanInformations FK_InternalLoanInformations_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations"
    ADD CONSTRAINT "FK_InternalLoanInformations_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations" DROP CONSTRAINT "FK_InternalLoanInformations_ForestBeats_ForestBeatId";
       InternalLoan          postgres    false    426    298    4015            �           2606    35770 Q   InternalLoanInformations FK_InternalLoanInformations_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations"
    ADD CONSTRAINT "FK_InternalLoanInformations_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations" DROP CONSTRAINT "FK_InternalLoanInformations_ForestCircles_ForestCircleId";
       InternalLoan          postgres    false    3947    248    426            �           2606    35775 U   InternalLoanInformations FK_InternalLoanInformations_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations"
    ADD CONSTRAINT "FK_InternalLoanInformations_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations" DROP CONSTRAINT "FK_InternalLoanInformations_ForestDivisions_ForestDivisionId";
       InternalLoan          postgres    false    3988    426    288            �           2606    35780 Q   InternalLoanInformations FK_InternalLoanInformations_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations"
    ADD CONSTRAINT "FK_InternalLoanInformations_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations" DROP CONSTRAINT "FK_InternalLoanInformations_ForestFcvVcfs_ForestFcvVcfId";
       InternalLoan          postgres    false    300    4018    426            �           2606    35785 O   InternalLoanInformations FK_InternalLoanInformations_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations"
    ADD CONSTRAINT "FK_InternalLoanInformations_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations" DROP CONSTRAINT "FK_InternalLoanInformations_ForestRanges_ForestRangeId";
       InternalLoan          postgres    false    294    4009    426            �           2606    35790 ?   InternalLoanInformations FK_InternalLoanInformations_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations"
    ADD CONSTRAINT "FK_InternalLoanInformations_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id") ON DELETE CASCADE;
 u   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations" DROP CONSTRAINT "FK_InternalLoanInformations_Ngos_NgoId";
       InternalLoan          postgres    false    258    426    3957            �           2606    35795 E   InternalLoanInformations FK_InternalLoanInformations_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations"
    ADD CONSTRAINT "FK_InternalLoanInformations_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE CASCADE;
 {   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations" DROP CONSTRAINT "FK_InternalLoanInformations_Surveys_SurveyId";
       InternalLoan          postgres    false    4038    302    426            �           2606    35800 B   InternalLoanInformations FK_InternalLoanInformations_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations"
    ADD CONSTRAINT "FK_InternalLoanInformations_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE RESTRICT;
 x   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations" DROP CONSTRAINT "FK_InternalLoanInformations_Union_UnionId";
       InternalLoan          postgres    false    426    340    4113            �           2606    35805 H   InternalLoanInformations FK_InternalLoanInformations_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations"
    ADD CONSTRAINT "FK_InternalLoanInformations_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 ~   ALTER TABLE ONLY "InternalLoan"."InternalLoanInformations" DROP CONSTRAINT "FK_InternalLoanInformations_Upazilla_UpazillaId";
       InternalLoan          postgres    false    296    4012    426            �           2606    35903 V   RepaymentInternalLoans FK_RepaymentInternalLoans_InternalLoanInformations_InternalLoa~    FK CONSTRAINT       ALTER TABLE ONLY "InternalLoan"."RepaymentInternalLoans"
    ADD CONSTRAINT "FK_RepaymentInternalLoans_InternalLoanInformations_InternalLoa~" FOREIGN KEY ("InternalLoanInformationId") REFERENCES "InternalLoan"."InternalLoanInformations"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "InternalLoan"."RepaymentInternalLoans" DROP CONSTRAINT "FK_RepaymentInternalLoans_InternalLoanInformations_InternalLoa~";
       InternalLoan          postgres    false    430    426    4357            �           2606    36070 K   LabourDatabaseFiles FK_LabourDatabaseFiles_LabourDatabases_LabourDatabaseId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabaseFiles"
    ADD CONSTRAINT "FK_LabourDatabaseFiles_LabourDatabases_LabourDatabaseId" FOREIGN KEY ("LabourDatabaseId") REFERENCES "Labour"."LabourDatabases"("Id") ON DELETE CASCADE;
 {   ALTER TABLE ONLY "Labour"."LabourDatabaseFiles" DROP CONSTRAINT "FK_LabourDatabaseFiles_LabourDatabases_LabourDatabaseId";
       Labour          postgres    false    4390    436    434            �           2606    35997 6   LabourDatabases FK_LabourDatabases_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "FK_LabourDatabases_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 f   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "FK_LabourDatabases_District_DistrictId";
       Labour          postgres    false    434    290    3991            �           2606    36002 6   LabourDatabases FK_LabourDatabases_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "FK_LabourDatabases_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE CASCADE;
 f   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "FK_LabourDatabases_Division_DivisionId";
       Labour          postgres    false    434    3973    274            �           2606    36007 9   LabourDatabases FK_LabourDatabases_Ethnicitys_EthnicityId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "FK_LabourDatabases_Ethnicitys_EthnicityId" FOREIGN KEY ("EthnicityId") REFERENCES "BEN"."Ethnicitys"("Id") ON DELETE RESTRICT;
 i   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "FK_LabourDatabases_Ethnicitys_EthnicityId";
       Labour          postgres    false    3941    242    434            �           2606    36012 ;   LabourDatabases FK_LabourDatabases_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "FK_LabourDatabases_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 k   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "FK_LabourDatabases_ForestBeats_ForestBeatId";
       Labour          postgres    false    434    298    4015            �           2606    36017 ?   LabourDatabases FK_LabourDatabases_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "FK_LabourDatabases_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 o   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "FK_LabourDatabases_ForestCircles_ForestCircleId";
       Labour          postgres    false    3947    434    248            �           2606    36022 C   LabourDatabases FK_LabourDatabases_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "FK_LabourDatabases_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 s   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "FK_LabourDatabases_ForestDivisions_ForestDivisionId";
       Labour          postgres    false    434    3988    288            �           2606    36027 ?   LabourDatabases FK_LabourDatabases_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "FK_LabourDatabases_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE CASCADE;
 o   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "FK_LabourDatabases_ForestFcvVcfs_ForestFcvVcfId";
       Labour          postgres    false    434    4018    300            �           2606    36032 =   LabourDatabases FK_LabourDatabases_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "FK_LabourDatabases_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
 m   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "FK_LabourDatabases_ForestRanges_ForestRangeId";
       Labour          postgres    false    434    4009    294            �           2606    36042 I   LabourDatabases FK_LabourDatabases_OtherLabourMembers_OtherLabourMemberId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "FK_LabourDatabases_OtherLabourMembers_OtherLabourMemberId" FOREIGN KEY ("OtherLabourMemberId") REFERENCES "Labour"."OtherLabourMembers"("Id") ON DELETE RESTRICT;
 y   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "FK_LabourDatabases_OtherLabourMembers_OtherLabourMemberId";
       Labour          postgres    false    434    4376    432            �           2606    36047 3   LabourDatabases FK_LabourDatabases_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "FK_LabourDatabases_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE RESTRICT;
 c   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "FK_LabourDatabases_Surveys_SurveyId";
       Labour          postgres    false    434    4038    302            �           2606    36052 0   LabourDatabases FK_LabourDatabases_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "FK_LabourDatabases_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE RESTRICT;
 `   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "FK_LabourDatabases_Union_UnionId";
       Labour          postgres    false    434    4113    340            �           2606    36057 6   LabourDatabases FK_LabourDatabases_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourDatabases"
    ADD CONSTRAINT "FK_LabourDatabases_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 f   ALTER TABLE ONLY "Labour"."LabourDatabases" DROP CONSTRAINT "FK_LabourDatabases_Upazilla_UpazillaId";
       Labour          postgres    false    434    4012    296                       2606    37326 ;   LabourWorks FK_LabourWorks_LabourDatabases_LabourDatabaseId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."LabourWorks"
    ADD CONSTRAINT "FK_LabourWorks_LabourDatabases_LabourDatabaseId" FOREIGN KEY ("LabourDatabaseId") REFERENCES "Labour"."LabourDatabases"("Id") ON DELETE CASCADE;
 k   ALTER TABLE ONLY "Labour"."LabourWorks" DROP CONSTRAINT "FK_LabourWorks_LabourDatabases_LabourDatabaseId";
       Labour          postgres    false    434    492    4390            �           2606    37184 <   OtherLabourMembers FK_OtherLabourMembers_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."OtherLabourMembers"
    ADD CONSTRAINT "FK_OtherLabourMembers_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id");
 l   ALTER TABLE ONLY "Labour"."OtherLabourMembers" DROP CONSTRAINT "FK_OtherLabourMembers_District_DistrictId";
       Labour          postgres    false    432    290    3991            �           2606    37189 <   OtherLabourMembers FK_OtherLabourMembers_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."OtherLabourMembers"
    ADD CONSTRAINT "FK_OtherLabourMembers_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id");
 l   ALTER TABLE ONLY "Labour"."OtherLabourMembers" DROP CONSTRAINT "FK_OtherLabourMembers_Division_DivisionId";
       Labour          postgres    false    432    274    3973            �           2606    35944 ?   OtherLabourMembers FK_OtherLabourMembers_Ethnicitys_EthnicityId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."OtherLabourMembers"
    ADD CONSTRAINT "FK_OtherLabourMembers_Ethnicitys_EthnicityId" FOREIGN KEY ("EthnicityId") REFERENCES "BEN"."Ethnicitys"("Id") ON DELETE RESTRICT;
 o   ALTER TABLE ONLY "Labour"."OtherLabourMembers" DROP CONSTRAINT "FK_OtherLabourMembers_Ethnicitys_EthnicityId";
       Labour          postgres    false    242    432    3941            �           2606    37194 A   OtherLabourMembers FK_OtherLabourMembers_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."OtherLabourMembers"
    ADD CONSTRAINT "FK_OtherLabourMembers_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id");
 q   ALTER TABLE ONLY "Labour"."OtherLabourMembers" DROP CONSTRAINT "FK_OtherLabourMembers_ForestBeats_ForestBeatId";
       Labour          postgres    false    4015    432    298            �           2606    37199 E   OtherLabourMembers FK_OtherLabourMembers_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."OtherLabourMembers"
    ADD CONSTRAINT "FK_OtherLabourMembers_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id");
 u   ALTER TABLE ONLY "Labour"."OtherLabourMembers" DROP CONSTRAINT "FK_OtherLabourMembers_ForestCircles_ForestCircleId";
       Labour          postgres    false    248    432    3947            �           2606    37204 I   OtherLabourMembers FK_OtherLabourMembers_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."OtherLabourMembers"
    ADD CONSTRAINT "FK_OtherLabourMembers_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id");
 y   ALTER TABLE ONLY "Labour"."OtherLabourMembers" DROP CONSTRAINT "FK_OtherLabourMembers_ForestDivisions_ForestDivisionId";
       Labour          postgres    false    432    288    3988            �           2606    37209 E   OtherLabourMembers FK_OtherLabourMembers_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."OtherLabourMembers"
    ADD CONSTRAINT "FK_OtherLabourMembers_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id");
 u   ALTER TABLE ONLY "Labour"."OtherLabourMembers" DROP CONSTRAINT "FK_OtherLabourMembers_ForestFcvVcfs_ForestFcvVcfId";
       Labour          postgres    false    432    4018    300            �           2606    37214 C   OtherLabourMembers FK_OtherLabourMembers_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."OtherLabourMembers"
    ADD CONSTRAINT "FK_OtherLabourMembers_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id");
 s   ALTER TABLE ONLY "Labour"."OtherLabourMembers" DROP CONSTRAINT "FK_OtherLabourMembers_ForestRanges_ForestRangeId";
       Labour          postgres    false    432    4009    294            �           2606    35974 6   OtherLabourMembers FK_OtherLabourMembers_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."OtherLabourMembers"
    ADD CONSTRAINT "FK_OtherLabourMembers_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE RESTRICT;
 f   ALTER TABLE ONLY "Labour"."OtherLabourMembers" DROP CONSTRAINT "FK_OtherLabourMembers_Union_UnionId";
       Labour          postgres    false    432    4113    340            �           2606    37219 <   OtherLabourMembers FK_OtherLabourMembers_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "Labour"."OtherLabourMembers"
    ADD CONSTRAINT "FK_OtherLabourMembers_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id");
 l   ALTER TABLE ONLY "Labour"."OtherLabourMembers" DROP CONSTRAINT "FK_OtherLabourMembers_Upazilla_UpazillaId";
       Labour          postgres    false    4012    296    432            �           2606    34014 ,   Marketings FK_Marketings_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "Marketing"."Marketings"
    ADD CONSTRAINT "FK_Marketings_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE RESTRICT;
 _   ALTER TABLE ONLY "Marketing"."Marketings" DROP CONSTRAINT "FK_Marketings_District_DistrictId";
    	   Marketing          postgres    false    290    338    3991            �           2606    34019 ,   Marketings FK_Marketings_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Marketing"."Marketings"
    ADD CONSTRAINT "FK_Marketings_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE RESTRICT;
 _   ALTER TABLE ONLY "Marketing"."Marketings" DROP CONSTRAINT "FK_Marketings_Division_DivisionId";
    	   Marketing          postgres    false    274    338    3973            B           2606    34755 /   MeetingFiles FK_MeetingFiles_Meetings_MeetingId    FK CONSTRAINT     �   ALTER TABLE ONLY "Meeting"."MeetingFiles"
    ADD CONSTRAINT "FK_MeetingFiles_Meetings_MeetingId" FOREIGN KEY ("MeetingId") REFERENCES "Meeting"."Meetings"("Id") ON DELETE CASCADE;
 `   ALTER TABLE ONLY "Meeting"."MeetingFiles" DROP CONSTRAINT "FK_MeetingFiles_Meetings_MeetingId";
       Meeting          postgres    false    4223    382    386            4           2606    34681 (   Meetings FK_Meetings_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "Meeting"."Meetings"
    ADD CONSTRAINT "FK_Meetings_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 Y   ALTER TABLE ONLY "Meeting"."Meetings" DROP CONSTRAINT "FK_Meetings_District_DistrictId";
       Meeting          postgres    false    290    382    3991            5           2606    34686 (   Meetings FK_Meetings_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Meeting"."Meetings"
    ADD CONSTRAINT "FK_Meetings_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE CASCADE;
 Y   ALTER TABLE ONLY "Meeting"."Meetings" DROP CONSTRAINT "FK_Meetings_Division_DivisionId";
       Meeting          postgres    false    3973    382    274            6           2606    34691 -   Meetings FK_Meetings_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "Meeting"."Meetings"
    ADD CONSTRAINT "FK_Meetings_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 ^   ALTER TABLE ONLY "Meeting"."Meetings" DROP CONSTRAINT "FK_Meetings_ForestBeats_ForestBeatId";
       Meeting          postgres    false    4015    298    382            7           2606    34696 1   Meetings FK_Meetings_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "Meeting"."Meetings"
    ADD CONSTRAINT "FK_Meetings_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 b   ALTER TABLE ONLY "Meeting"."Meetings" DROP CONSTRAINT "FK_Meetings_ForestCircles_ForestCircleId";
       Meeting          postgres    false    3947    382    248            8           2606    34701 5   Meetings FK_Meetings_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Meeting"."Meetings"
    ADD CONSTRAINT "FK_Meetings_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 f   ALTER TABLE ONLY "Meeting"."Meetings" DROP CONSTRAINT "FK_Meetings_ForestDivisions_ForestDivisionId";
       Meeting          postgres    false    382    288    3988            9           2606    34706 1   Meetings FK_Meetings_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "Meeting"."Meetings"
    ADD CONSTRAINT "FK_Meetings_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE CASCADE;
 b   ALTER TABLE ONLY "Meeting"."Meetings" DROP CONSTRAINT "FK_Meetings_ForestFcvVcfs_ForestFcvVcfId";
       Meeting          postgres    false    300    4018    382            :           2606    34711 /   Meetings FK_Meetings_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "Meeting"."Meetings"
    ADD CONSTRAINT "FK_Meetings_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
 `   ALTER TABLE ONLY "Meeting"."Meetings" DROP CONSTRAINT "FK_Meetings_ForestRanges_ForestRangeId";
       Meeting          postgres    false    4009    382    294            ;           2606    34716 /   Meetings FK_Meetings_MeetingTypes_MeetingTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "Meeting"."Meetings"
    ADD CONSTRAINT "FK_Meetings_MeetingTypes_MeetingTypeId" FOREIGN KEY ("MeetingTypeId") REFERENCES "Meeting"."MeetingTypes"("Id") ON DELETE CASCADE;
 `   ALTER TABLE ONLY "Meeting"."Meetings" DROP CONSTRAINT "FK_Meetings_MeetingTypes_MeetingTypeId";
       Meeting          postgres    false    4210    382    380            <           2606    36225    Meetings FK_Meetings_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "Meeting"."Meetings"
    ADD CONSTRAINT "FK_Meetings_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id") ON DELETE RESTRICT;
 P   ALTER TABLE ONLY "Meeting"."Meetings" DROP CONSTRAINT "FK_Meetings_Ngos_NgoId";
       Meeting          postgres    false    382    3957    258            =           2606    35711 "   Meetings FK_Meetings_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Meeting"."Meetings"
    ADD CONSTRAINT "FK_Meetings_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE RESTRICT;
 S   ALTER TABLE ONLY "Meeting"."Meetings" DROP CONSTRAINT "FK_Meetings_Union_UnionId";
       Meeting          postgres    false    382    4113    340            >           2606    34721 (   Meetings FK_Meetings_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "Meeting"."Meetings"
    ADD CONSTRAINT "FK_Meetings_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 Y   ALTER TABLE ONLY "Meeting"."Meetings" DROP CONSTRAINT "FK_Meetings_Upazilla_UpazillaId";
       Meeting          postgres    false    296    382    4012            w           2606    35375 B   OtherPatrollingMember FK_OtherPatrollingMember_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember"
    ADD CONSTRAINT "FK_OtherPatrollingMember_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 v   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember" DROP CONSTRAINT "FK_OtherPatrollingMember_District_DistrictId";
    
   Patrolling          postgres    false    290    416    3991            x           2606    35380 B   OtherPatrollingMember FK_OtherPatrollingMember_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember"
    ADD CONSTRAINT "FK_OtherPatrollingMember_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE CASCADE;
 v   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember" DROP CONSTRAINT "FK_OtherPatrollingMember_Division_DivisionId";
    
   Patrolling          postgres    false    416    274    3973            y           2606    35385 E   OtherPatrollingMember FK_OtherPatrollingMember_Ethnicitys_EthnicityId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember"
    ADD CONSTRAINT "FK_OtherPatrollingMember_Ethnicitys_EthnicityId" FOREIGN KEY ("EthnicityId") REFERENCES "BEN"."Ethnicitys"("Id") ON DELETE RESTRICT;
 y   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember" DROP CONSTRAINT "FK_OtherPatrollingMember_Ethnicitys_EthnicityId";
    
   Patrolling          postgres    false    242    3941    416            z           2606    35390 G   OtherPatrollingMember FK_OtherPatrollingMember_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember"
    ADD CONSTRAINT "FK_OtherPatrollingMember_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 {   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember" DROP CONSTRAINT "FK_OtherPatrollingMember_ForestBeats_ForestBeatId";
    
   Patrolling          postgres    false    298    4015    416            {           2606    35395 K   OtherPatrollingMember FK_OtherPatrollingMember_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember"
    ADD CONSTRAINT "FK_OtherPatrollingMember_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
    ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember" DROP CONSTRAINT "FK_OtherPatrollingMember_ForestCircles_ForestCircleId";
    
   Patrolling          postgres    false    248    3947    416            |           2606    35400 O   OtherPatrollingMember FK_OtherPatrollingMember_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember"
    ADD CONSTRAINT "FK_OtherPatrollingMember_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember" DROP CONSTRAINT "FK_OtherPatrollingMember_ForestDivisions_ForestDivisionId";
    
   Patrolling          postgres    false    416    288    3988            }           2606    35405 K   OtherPatrollingMember FK_OtherPatrollingMember_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember"
    ADD CONSTRAINT "FK_OtherPatrollingMember_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE CASCADE;
    ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember" DROP CONSTRAINT "FK_OtherPatrollingMember_ForestFcvVcfs_ForestFcvVcfId";
    
   Patrolling          postgres    false    300    416    4018            ~           2606    35410 I   OtherPatrollingMember FK_OtherPatrollingMember_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember"
    ADD CONSTRAINT "FK_OtherPatrollingMember_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
 }   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember" DROP CONSTRAINT "FK_OtherPatrollingMember_ForestRanges_ForestRangeId";
    
   Patrolling          postgres    false    294    416    4009                       2606    35415 B   OtherPatrollingMember FK_OtherPatrollingMember_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember"
    ADD CONSTRAINT "FK_OtherPatrollingMember_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 v   ALTER TABLE ONLY "Patrolling"."OtherPatrollingMember" DROP CONSTRAINT "FK_OtherPatrollingMember_Upazilla_UpazillaId";
    
   Patrolling          postgres    false    4012    416    296            t           2606    35443 \   PatrollingPaymentInformetion FK_PatrollingPaymentInformetion_OtherPatrollingMember_OtherPat~    FK CONSTRAINT       ALTER TABLE ONLY "Patrolling"."PatrollingPaymentInformetion"
    ADD CONSTRAINT "FK_PatrollingPaymentInformetion_OtherPatrollingMember_OtherPat~" FOREIGN KEY ("OtherPatrollingMemberId") REFERENCES "Patrolling"."OtherPatrollingMember"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Patrolling"."PatrollingPaymentInformetion" DROP CONSTRAINT "FK_PatrollingPaymentInformetion_OtherPatrollingMember_OtherPat~";
    
   Patrolling          postgres    false    416    414    4322            u           2606    35346 \   PatrollingPaymentInformetion FK_PatrollingPaymentInformetion_PatrollingScheduleInformetion_~    FK CONSTRAINT       ALTER TABLE ONLY "Patrolling"."PatrollingPaymentInformetion"
    ADD CONSTRAINT "FK_PatrollingPaymentInformetion_PatrollingScheduleInformetion_~" FOREIGN KEY ("PatrollingScheduleInformetionId") REFERENCES "Patrolling"."PatrollingScheduleInformetion"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Patrolling"."PatrollingPaymentInformetion" DROP CONSTRAINT "FK_PatrollingPaymentInformetion_PatrollingScheduleInformetion_~";
    
   Patrolling          postgres    false    414    4306    412            v           2606    35351 M   PatrollingPaymentInformetion FK_PatrollingPaymentInformetion_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."PatrollingPaymentInformetion"
    ADD CONSTRAINT "FK_PatrollingPaymentInformetion_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Patrolling"."PatrollingPaymentInformetion" DROP CONSTRAINT "FK_PatrollingPaymentInformetion_Surveys_SurveyId";
    
   Patrolling          postgres    false    302    414    4038            j           2606    35298 R   PatrollingScheduleInformetion FK_PatrollingScheduleInformetion_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion"
    ADD CONSTRAINT "FK_PatrollingScheduleInformetion_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion" DROP CONSTRAINT "FK_PatrollingScheduleInformetion_District_DistrictId";
    
   Patrolling          postgres    false    290    3991    412            k           2606    35303 R   PatrollingScheduleInformetion FK_PatrollingScheduleInformetion_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion"
    ADD CONSTRAINT "FK_PatrollingScheduleInformetion_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion" DROP CONSTRAINT "FK_PatrollingScheduleInformetion_Division_DivisionId";
    
   Patrolling          postgres    false    3973    412    274            l           2606    35308 W   PatrollingScheduleInformetion FK_PatrollingScheduleInformetion_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion"
    ADD CONSTRAINT "FK_PatrollingScheduleInformetion_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion" DROP CONSTRAINT "FK_PatrollingScheduleInformetion_ForestBeats_ForestBeatId";
    
   Patrolling          postgres    false    298    4015    412            m           2606    35313 [   PatrollingScheduleInformetion FK_PatrollingScheduleInformetion_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion"
    ADD CONSTRAINT "FK_PatrollingScheduleInformetion_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion" DROP CONSTRAINT "FK_PatrollingScheduleInformetion_ForestCircles_ForestCircleId";
    
   Patrolling          postgres    false    248    3947    412            n           2606    35318 ]   PatrollingScheduleInformetion FK_PatrollingScheduleInformetion_ForestDivisions_ForestDivisio~    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion"
    ADD CONSTRAINT "FK_PatrollingScheduleInformetion_ForestDivisions_ForestDivisio~" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion" DROP CONSTRAINT "FK_PatrollingScheduleInformetion_ForestDivisions_ForestDivisio~";
    
   Patrolling          postgres    false    288    3988    412            o           2606    35323 Y   PatrollingScheduleInformetion FK_PatrollingScheduleInformetion_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion"
    ADD CONSTRAINT "FK_PatrollingScheduleInformetion_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion" DROP CONSTRAINT "FK_PatrollingScheduleInformetion_ForestRanges_ForestRangeId";
    
   Patrolling          postgres    false    294    4009    412            p           2606    35328 I   PatrollingScheduleInformetion FK_PatrollingScheduleInformetion_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion"
    ADD CONSTRAINT "FK_PatrollingScheduleInformetion_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id") ON DELETE RESTRICT;
 }   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion" DROP CONSTRAINT "FK_PatrollingScheduleInformetion_Ngos_NgoId";
    
   Patrolling          postgres    false    258    412    3957            q           2606    35430 ]   PatrollingScheduleInformetion FK_PatrollingScheduleInformetion_OtherPatrollingMember_OtherPa~    FK CONSTRAINT       ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion"
    ADD CONSTRAINT "FK_PatrollingScheduleInformetion_OtherPatrollingMember_OtherPa~" FOREIGN KEY ("OtherPatrollingMemberId") REFERENCES "Patrolling"."OtherPatrollingMember"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion" DROP CONSTRAINT "FK_PatrollingScheduleInformetion_OtherPatrollingMember_OtherPa~";
    
   Patrolling          postgres    false    416    412    4322            r           2606    36114 L   PatrollingScheduleInformetion FK_PatrollingScheduleInformetion_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion"
    ADD CONSTRAINT "FK_PatrollingScheduleInformetion_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion" DROP CONSTRAINT "FK_PatrollingScheduleInformetion_Union_UnionId";
    
   Patrolling          postgres    false    412    4113    340            s           2606    35333 R   PatrollingScheduleInformetion FK_PatrollingScheduleInformetion_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion"
    ADD CONSTRAINT "FK_PatrollingScheduleInformetion_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE RESTRICT;
 �   ALTER TABLE ONLY "Patrolling"."PatrollingScheduleInformetion" DROP CONSTRAINT "FK_PatrollingScheduleInformetion_Upazilla_UpazillaId";
    
   Patrolling          postgres    false    296    412    4012            �           2606    36324 Y   PatrollingSchedulingFiles FK_PatrollingSchedulingFiles_PatrollingSchedulings_PatrollingS~    FK CONSTRAINT       ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingFiles"
    ADD CONSTRAINT "FK_PatrollingSchedulingFiles_PatrollingSchedulings_PatrollingS~" FOREIGN KEY ("PatrollingSchedulingId") REFERENCES "PatrollingScheduling"."PatrollingSchedulings"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingFiles" DROP CONSTRAINT "FK_PatrollingSchedulingFiles_PatrollingSchedulings_PatrollingS~";
       PatrollingScheduling          postgres    false    446    4424    444            �           2606    36337 d   PatrollingSchedulingParticipentsMaps FK_PatrollingSchedulingParticipentsMaps_PatrollingSchedulingMe~    FK CONSTRAINT       ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps"
    ADD CONSTRAINT "FK_PatrollingSchedulingParticipentsMaps_PatrollingSchedulingMe~" FOREIGN KEY ("PatrollingSchedulingMemberId") REFERENCES "PatrollingScheduling"."PatrollingSchedulingMembers"("Id");
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps" DROP CONSTRAINT "FK_PatrollingSchedulingParticipentsMaps_PatrollingSchedulingMe~";
       PatrollingScheduling          postgres    false    448    4412    442            �           2606    36342 d   PatrollingSchedulingParticipentsMaps FK_PatrollingSchedulingParticipentsMaps_PatrollingSchedulings_~    FK CONSTRAINT       ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps"
    ADD CONSTRAINT "FK_PatrollingSchedulingParticipentsMaps_PatrollingSchedulings_~" FOREIGN KEY ("PatrollingSchedulingId") REFERENCES "PatrollingScheduling"."PatrollingSchedulings"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps" DROP CONSTRAINT "FK_PatrollingSchedulingParticipentsMaps_PatrollingSchedulings_~";
       PatrollingScheduling          postgres    false    448    444    4424            �           2606    36347 ]   PatrollingSchedulingParticipentsMaps FK_PatrollingSchedulingParticipentsMaps_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps"
    ADD CONSTRAINT "FK_PatrollingSchedulingParticipentsMaps_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id");
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulingParticipentsMaps" DROP CONSTRAINT "FK_PatrollingSchedulingParticipentsMaps_Surveys_SurveyId";
       PatrollingScheduling          postgres    false    4038    448    302            �           2606    36266 B   PatrollingSchedulings FK_PatrollingSchedulings_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings"
    ADD CONSTRAINT "FK_PatrollingSchedulings_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings" DROP CONSTRAINT "FK_PatrollingSchedulings_District_DistrictId";
       PatrollingScheduling          postgres    false    444    3991    290            �           2606    36271 B   PatrollingSchedulings FK_PatrollingSchedulings_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings"
    ADD CONSTRAINT "FK_PatrollingSchedulings_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings" DROP CONSTRAINT "FK_PatrollingSchedulings_Division_DivisionId";
       PatrollingScheduling          postgres    false    444    3973    274            �           2606    36276 G   PatrollingSchedulings FK_PatrollingSchedulings_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings"
    ADD CONSTRAINT "FK_PatrollingSchedulings_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings" DROP CONSTRAINT "FK_PatrollingSchedulings_ForestBeats_ForestBeatId";
       PatrollingScheduling          postgres    false    444    4015    298            �           2606    36281 K   PatrollingSchedulings FK_PatrollingSchedulings_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings"
    ADD CONSTRAINT "FK_PatrollingSchedulings_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings" DROP CONSTRAINT "FK_PatrollingSchedulings_ForestCircles_ForestCircleId";
       PatrollingScheduling          postgres    false    444    3947    248            �           2606    36286 O   PatrollingSchedulings FK_PatrollingSchedulings_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings"
    ADD CONSTRAINT "FK_PatrollingSchedulings_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings" DROP CONSTRAINT "FK_PatrollingSchedulings_ForestDivisions_ForestDivisionId";
       PatrollingScheduling          postgres    false    444    3988    288            �           2606    36291 K   PatrollingSchedulings FK_PatrollingSchedulings_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings"
    ADD CONSTRAINT "FK_PatrollingSchedulings_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings" DROP CONSTRAINT "FK_PatrollingSchedulings_ForestFcvVcfs_ForestFcvVcfId";
       PatrollingScheduling          postgres    false    444    4018    300            �           2606    36296 I   PatrollingSchedulings FK_PatrollingSchedulings_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings"
    ADD CONSTRAINT "FK_PatrollingSchedulings_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings" DROP CONSTRAINT "FK_PatrollingSchedulings_ForestRanges_ForestRangeId";
       PatrollingScheduling          postgres    false    444    4009    294            �           2606    36301 9   PatrollingSchedulings FK_PatrollingSchedulings_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings"
    ADD CONSTRAINT "FK_PatrollingSchedulings_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id");
 w   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings" DROP CONSTRAINT "FK_PatrollingSchedulings_Ngos_NgoId";
       PatrollingScheduling          postgres    false    444    3957    258            �           2606    36306 <   PatrollingSchedulings FK_PatrollingSchedulings_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings"
    ADD CONSTRAINT "FK_PatrollingSchedulings_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id");
 z   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings" DROP CONSTRAINT "FK_PatrollingSchedulings_Union_UnionId";
       PatrollingScheduling          postgres    false    444    4113    340            �           2606    36311 B   PatrollingSchedulings FK_PatrollingSchedulings_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings"
    ADD CONSTRAINT "FK_PatrollingSchedulings_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "PatrollingScheduling"."PatrollingSchedulings" DROP CONSTRAINT "FK_PatrollingSchedulings_Upazilla_UpazillaId";
       PatrollingScheduling          postgres    false    444    4012    296            �           2606    37007 G   BankDeposits FK_BankDeposits_RevenueDistributions_RevenueDistributionId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."BankDeposits"
    ADD CONSTRAINT "FK_BankDeposits_RevenueDistributions_RevenueDistributionId" FOREIGN KEY ("RevenueDistributionId") REFERENCES "SocialForestry"."RevenueDistributions"("Id") ON DELETE CASCADE;
    ALTER TABLE ONLY "SocialForestry"."BankDeposits" DROP CONSTRAINT "FK_BankDeposits_RevenueDistributions_RevenueDistributionId";
       SocialForestry          postgres    false    4488    472    474            �           2606    36927 R   CuttingPlantations FK_CuttingPlantations_NewRaisedPlantations_NewRaisedPlantation~    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."CuttingPlantations"
    ADD CONSTRAINT "FK_CuttingPlantations_NewRaisedPlantations_NewRaisedPlantation~" FOREIGN KEY ("NewRaisedPlantationId") REFERENCES "SocialForestry"."NewRaisedPlantations"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."CuttingPlantations" DROP CONSTRAINT "FK_CuttingPlantations_NewRaisedPlantations_NewRaisedPlantation~";
       SocialForestry          postgres    false    4468    460    462            �           2606    37020 b   DistributedOrRevenueDepositAmounts FK_DistributedOrRevenueDepositAmounts_RevenueDistributions_Rev~    FK CONSTRAINT       ALTER TABLE ONLY "SocialForestry"."DistributedOrRevenueDepositAmounts"
    ADD CONSTRAINT "FK_DistributedOrRevenueDepositAmounts_RevenueDistributions_Rev~" FOREIGN KEY ("RevenueDistributionId") REFERENCES "SocialForestry"."RevenueDistributions"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."DistributedOrRevenueDepositAmounts" DROP CONSTRAINT "FK_DistributedOrRevenueDepositAmounts_RevenueDistributions_Rev~";
       SocialForestry          postgres    false    476    4488    472            �           2606    36938 \   NewRaisedPlantationUnionMaps FK_NewRaisedPlantationUnionMaps_NewRaisedPlantations_NewRaised~    FK CONSTRAINT       ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantationUnionMaps"
    ADD CONSTRAINT "FK_NewRaisedPlantationUnionMaps_NewRaisedPlantations_NewRaised~" FOREIGN KEY ("NewRaisedPlantationId") REFERENCES "SocialForestry"."NewRaisedPlantations"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantationUnionMaps" DROP CONSTRAINT "FK_NewRaisedPlantationUnionMaps_NewRaisedPlantations_NewRaised~";
       SocialForestry          postgres    false    4468    460    464            �           2606    36943 J   NewRaisedPlantationUnionMaps FK_NewRaisedPlantationUnionMaps_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantationUnionMaps"
    ADD CONSTRAINT "FK_NewRaisedPlantationUnionMaps_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantationUnionMaps" DROP CONSTRAINT "FK_NewRaisedPlantationUnionMaps_Union_UnionId";
       SocialForestry          postgres    false    340    464    4113            �           2606    36954 _   NewRaisedPlantationUpazillaMaps FK_NewRaisedPlantationUpazillaMaps_NewRaisedPlantations_NewRai~    FK CONSTRAINT       ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantationUpazillaMaps"
    ADD CONSTRAINT "FK_NewRaisedPlantationUpazillaMaps_NewRaisedPlantations_NewRai~" FOREIGN KEY ("NewRaisedPlantationId") REFERENCES "SocialForestry"."NewRaisedPlantations"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantationUpazillaMaps" DROP CONSTRAINT "FK_NewRaisedPlantationUpazillaMaps_NewRaisedPlantations_NewRai~";
       SocialForestry          postgres    false    466    460    4468            �           2606    36959 V   NewRaisedPlantationUpazillaMaps FK_NewRaisedPlantationUpazillaMaps_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantationUpazillaMaps"
    ADD CONSTRAINT "FK_NewRaisedPlantationUpazillaMaps_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantationUpazillaMaps" DROP CONSTRAINT "FK_NewRaisedPlantationUpazillaMaps_Upazilla_UpazillaId";
       SocialForestry          postgres    false    4012    296    466            �           2606    36866 @   NewRaisedPlantations FK_NewRaisedPlantations_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations"
    ADD CONSTRAINT "FK_NewRaisedPlantations_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE CASCADE;
 x   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations" DROP CONSTRAINT "FK_NewRaisedPlantations_District_DistrictId";
       SocialForestry          postgres    false    3991    460    290            �           2606    36871 @   NewRaisedPlantations FK_NewRaisedPlantations_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations"
    ADD CONSTRAINT "FK_NewRaisedPlantations_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE CASCADE;
 x   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations" DROP CONSTRAINT "FK_NewRaisedPlantations_Division_DivisionId";
       SocialForestry          postgres    false    274    3973    460            �           2606    36876 E   NewRaisedPlantations FK_NewRaisedPlantations_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations"
    ADD CONSTRAINT "FK_NewRaisedPlantations_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE CASCADE;
 }   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations" DROP CONSTRAINT "FK_NewRaisedPlantations_ForestBeats_ForestBeatId";
       SocialForestry          postgres    false    460    4015    298            �           2606    36881 I   NewRaisedPlantations FK_NewRaisedPlantations_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations"
    ADD CONSTRAINT "FK_NewRaisedPlantations_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations" DROP CONSTRAINT "FK_NewRaisedPlantations_ForestCircles_ForestCircleId";
       SocialForestry          postgres    false    460    3947    248            �           2606    36886 M   NewRaisedPlantations FK_NewRaisedPlantations_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations"
    ADD CONSTRAINT "FK_NewRaisedPlantations_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations" DROP CONSTRAINT "FK_NewRaisedPlantations_ForestDivisions_ForestDivisionId";
       SocialForestry          postgres    false    460    3988    288            �           2606    36891 I   NewRaisedPlantations FK_NewRaisedPlantations_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations"
    ADD CONSTRAINT "FK_NewRaisedPlantations_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations" DROP CONSTRAINT "FK_NewRaisedPlantations_ForestFcvVcfs_ForestFcvVcfId";
       SocialForestry          postgres    false    4018    300    460            �           2606    36896 G   NewRaisedPlantations FK_NewRaisedPlantations_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations"
    ADD CONSTRAINT "FK_NewRaisedPlantations_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE CASCADE;
    ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations" DROP CONSTRAINT "FK_NewRaisedPlantations_ForestRanges_ForestRangeId";
       SocialForestry          postgres    false    460    294    4009            �           2606    36901 7   NewRaisedPlantations FK_NewRaisedPlantations_Ngos_NgoId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations"
    ADD CONSTRAINT "FK_NewRaisedPlantations_Ngos_NgoId" FOREIGN KEY ("NgoId") REFERENCES "BEN"."Ngos"("Id") ON DELETE CASCADE;
 o   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations" DROP CONSTRAINT "FK_NewRaisedPlantations_Ngos_NgoId";
       SocialForestry          postgres    false    460    258    3957            �           2606    36906 S   NewRaisedPlantations FK_NewRaisedPlantations_PlantationProjects_PlantationProjectId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations"
    ADD CONSTRAINT "FK_NewRaisedPlantations_PlantationProjects_PlantationProjectId" FOREIGN KEY ("PlantationProjectId") REFERENCES "SocialForestry"."PlantationProjects"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations" DROP CONSTRAINT "FK_NewRaisedPlantations_PlantationProjects_PlantationProjectId";
       SocialForestry          postgres    false    452    460    4447            �           2606    36911 M   NewRaisedPlantations FK_NewRaisedPlantations_PlantationTypes_PlantationTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations"
    ADD CONSTRAINT "FK_NewRaisedPlantations_PlantationTypes_PlantationTypeId" FOREIGN KEY ("PlantationTypeId") REFERENCES "SocialForestry"."PlantationTypes"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations" DROP CONSTRAINT "FK_NewRaisedPlantations_PlantationTypes_PlantationTypeId";
       SocialForestry          postgres    false    454    4449    460            �           2606    36916 C   NewRaisedPlantations FK_NewRaisedPlantations_StripTypes_StripTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations"
    ADD CONSTRAINT "FK_NewRaisedPlantations_StripTypes_StripTypeId" FOREIGN KEY ("StripTypeId") REFERENCES "SocialForestry"."StripTypes"("Id");
 {   ALTER TABLE ONLY "SocialForestry"."NewRaisedPlantations" DROP CONSTRAINT "FK_NewRaisedPlantations_StripTypes_StripTypeId";
       SocialForestry          postgres    false    460    458    4455            �           2606    36840 `   PlantationTypeRevenuePercentages FK_PlantationTypeRevenuePercentages_PlantationTypes_Plantation~    FK CONSTRAINT       ALTER TABLE ONLY "SocialForestry"."PlantationTypeRevenuePercentages"
    ADD CONSTRAINT "FK_PlantationTypeRevenuePercentages_PlantationTypes_Plantation~" FOREIGN KEY ("PlantationTypeId") REFERENCES "SocialForestry"."PlantationTypes"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."PlantationTypeRevenuePercentages" DROP CONSTRAINT "FK_PlantationTypeRevenuePercentages_PlantationTypes_Plantation~";
       SocialForestry          postgres    false    454    4449    456            �           2606    36972 K   Reforestations FK_Reforestations_NewRaisedPlantations_NewRaisedPlantationId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."Reforestations"
    ADD CONSTRAINT "FK_Reforestations_NewRaisedPlantations_NewRaisedPlantationId" FOREIGN KEY ("NewRaisedPlantationId") REFERENCES "SocialForestry"."NewRaisedPlantations"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "SocialForestry"."Reforestations" DROP CONSTRAINT "FK_Reforestations_NewRaisedPlantations_NewRaisedPlantationId";
       SocialForestry          postgres    false    460    468    4468            �           2606    36994 ?   RevenueDistributions FK_RevenueDistributions_Revenues_RevenueId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."RevenueDistributions"
    ADD CONSTRAINT "FK_RevenueDistributions_Revenues_RevenueId" FOREIGN KEY ("RevenueId") REFERENCES "SocialForestry"."Revenues"("Id") ON DELETE CASCADE;
 w   ALTER TABLE ONLY "SocialForestry"."RevenueDistributions" DROP CONSTRAINT "FK_RevenueDistributions_Revenues_RevenueId";
       SocialForestry          postgres    false    4485    472    470            �           2606    36983 ;   Revenues FK_Revenues_CuttingPlantations_CuttingPlantationId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."Revenues"
    ADD CONSTRAINT "FK_Revenues_CuttingPlantations_CuttingPlantationId" FOREIGN KEY ("CuttingPlantationId") REFERENCES "SocialForestry"."CuttingPlantations"("Id") ON DELETE CASCADE;
 s   ALTER TABLE ONLY "SocialForestry"."Revenues" DROP CONSTRAINT "FK_Revenues_CuttingPlantations_CuttingPlantationId";
       SocialForestry          postgres    false    4471    470    462            �           2606    36853 9   StripTypes FK_StripTypes_PlantationTypes_PlantationTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "SocialForestry"."StripTypes"
    ADD CONSTRAINT "FK_StripTypes_PlantationTypes_PlantationTypeId" FOREIGN KEY ("PlantationTypeId") REFERENCES "SocialForestry"."PlantationTypes"("Id") ON DELETE CASCADE;
 q   ALTER TABLE ONLY "SocialForestry"."StripTypes" DROP CONSTRAINT "FK_StripTypes_PlantationTypes_PlantationTypeId";
       SocialForestry          postgres    false    454    458    4449            �           2606    35830     User FK_User_District_DistrictId    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "GS"."District"("Id") ON DELETE RESTRICT;
 P   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_District_DistrictId";
       System          postgres    false    290    3991    292            �           2606    35835     User FK_User_Division_DivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_Division_DivisionId" FOREIGN KEY ("DivisionId") REFERENCES "GS"."Division"("Id") ON DELETE RESTRICT;
 P   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_Division_DivisionId";
       System          postgres    false    274    292    3973            �           2606    35840 %   User FK_User_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id") ON DELETE RESTRICT;
 U   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_ForestBeats_ForestBeatId";
       System          postgres    false    4015    292    298            �           2606    35845 )   User FK_User_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE RESTRICT;
 Y   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_ForestCircles_ForestCircleId";
       System          postgres    false    3947    248    292            �           2606    35850 -   User FK_User_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE RESTRICT;
 ]   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_ForestDivisions_ForestDivisionId";
       System          postgres    false    3988    288    292            �           2606    35855 )   User FK_User_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id") ON DELETE RESTRICT;
 Y   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_ForestFcvVcfs_ForestFcvVcfId";
       System          postgres    false    292    300    4018            �           2606    35860 '   User FK_User_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id") ON DELETE RESTRICT;
 W   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_ForestRanges_ForestRangeId";
       System          postgres    false    4009    294    292            �           2606    33445     User FK_User_PmsGroup_PmsGroupID    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_PmsGroup_PmsGroupID" FOREIGN KEY ("PmsGroupID") REFERENCES "System"."PmsGroup"("Id") ON DELETE CASCADE;
 P   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_PmsGroup_PmsGroupID";
       System          postgres    false    292    282    3981            �           2606    36108    User FK_User_Surveys_SurveyId    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "BEN"."Surveys"("Id") ON DELETE RESTRICT;
 M   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_Surveys_SurveyId";
       System          postgres    false    292    4038    302            �           2606    35865    User FK_User_Union_UnionId    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_Union_UnionId" FOREIGN KEY ("UnionId") REFERENCES "GS"."Union"("Id") ON DELETE RESTRICT;
 J   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_Union_UnionId";
       System          postgres    false    4113    292    340            �           2606    35870     User FK_User_Upazilla_UpazillaId    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_Upazilla_UpazillaId" FOREIGN KEY ("UpazillaId") REFERENCES "GS"."Upazilla"("Id") ON DELETE RESTRICT;
 P   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_Upazilla_UpazillaId";
       System          postgres    false    292    296    4012            �           2606    33440    User FK_User_UserGroup_GroupID    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_UserGroup_GroupID" FOREIGN KEY ("GroupID") REFERENCES "System"."UserGroup"("Id") ON DELETE RESTRICT;
 N   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_UserGroup_GroupID";
       System          postgres    false    3983    292    284            �           2606    33450 "   User FK_User_UserRoles_UserRolesId    FK CONSTRAINT     �   ALTER TABLE ONLY "System"."User"
    ADD CONSTRAINT "FK_User_UserRoles_UserRolesId" FOREIGN KEY ("UserRolesId") REFERENCES "System"."UserRoles"("Id") ON DELETE RESTRICT;
 R   ALTER TABLE ONLY "System"."User" DROP CONSTRAINT "FK_User_UserRoles_UserRolesId";
       System          postgres    false    292    286    3985            �           2606    37140 U   ExpenseDetailsForCDFs FK_ExpenseDetailsForCDFs_TransactionExpenses_TransactionExpens~    FK CONSTRAINT     �   ALTER TABLE ONLY "TRANSACTION"."ExpenseDetailsForCDFs"
    ADD CONSTRAINT "FK_ExpenseDetailsForCDFs_TransactionExpenses_TransactionExpens~" FOREIGN KEY ("TransactionExpenseId") REFERENCES "TRANSACTION"."TransactionExpenses"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "TRANSACTION"."ExpenseDetailsForCDFs" DROP CONSTRAINT "FK_ExpenseDetailsForCDFs_TransactionExpenses_TransactionExpens~";
       TRANSACTION          postgres    false    484    4251    396            F           2606    34957 =   TransactionDetails FK_TransactionDetails_FundTypes_FundTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "TRANSACTION"."TransactionDetails"
    ADD CONSTRAINT "FK_TransactionDetails_FundTypes_FundTypeId" FOREIGN KEY ("FundTypeId") REFERENCES "TRANSACTION"."FundTypes"("Id") ON DELETE CASCADE;
 r   ALTER TABLE ONLY "TRANSACTION"."TransactionDetails" DROP CONSTRAINT "FK_TransactionDetails_FundTypes_FundTypeId";
       TRANSACTION          postgres    false    4235    390    394            G           2606    34962 C   TransactionDetails FK_TransactionDetails_Transactions_TransactionId    FK CONSTRAINT     �   ALTER TABLE ONLY "TRANSACTION"."TransactionDetails"
    ADD CONSTRAINT "FK_TransactionDetails_Transactions_TransactionId" FOREIGN KEY ("TransactionId") REFERENCES "TRANSACTION"."Transactions"("Id") ON DELETE CASCADE;
 x   ALTER TABLE ONLY "TRANSACTION"."TransactionDetails" DROP CONSTRAINT "FK_TransactionDetails_Transactions_TransactionId";
       TRANSACTION          postgres    false    4240    394    392            H           2606    37149 C   TransactionExpenses FK_TransactionExpenses_ForestBeats_ForestBeatId    FK CONSTRAINT     �   ALTER TABLE ONLY "TRANSACTION"."TransactionExpenses"
    ADD CONSTRAINT "FK_TransactionExpenses_ForestBeats_ForestBeatId" FOREIGN KEY ("ForestBeatId") REFERENCES "BEN"."ForestBeats"("Id");
 x   ALTER TABLE ONLY "TRANSACTION"."TransactionExpenses" DROP CONSTRAINT "FK_TransactionExpenses_ForestBeats_ForestBeatId";
       TRANSACTION          postgres    false    4015    396    298            I           2606    37154 G   TransactionExpenses FK_TransactionExpenses_ForestFcvVcfs_ForestFcvVcfId    FK CONSTRAINT     �   ALTER TABLE ONLY "TRANSACTION"."TransactionExpenses"
    ADD CONSTRAINT "FK_TransactionExpenses_ForestFcvVcfs_ForestFcvVcfId" FOREIGN KEY ("ForestFcvVcfId") REFERENCES "BEN"."ForestFcvVcfs"("Id");
 |   ALTER TABLE ONLY "TRANSACTION"."TransactionExpenses" DROP CONSTRAINT "FK_TransactionExpenses_ForestFcvVcfs_ForestFcvVcfId";
       TRANSACTION          postgres    false    300    396    4018            J           2606    37159 E   TransactionExpenses FK_TransactionExpenses_ForestRanges_ForestRangeId    FK CONSTRAINT     �   ALTER TABLE ONLY "TRANSACTION"."TransactionExpenses"
    ADD CONSTRAINT "FK_TransactionExpenses_ForestRanges_ForestRangeId" FOREIGN KEY ("ForestRangeId") REFERENCES "BEN"."ForestRanges"("Id");
 z   ALTER TABLE ONLY "TRANSACTION"."TransactionExpenses" DROP CONSTRAINT "FK_TransactionExpenses_ForestRanges_ForestRangeId";
       TRANSACTION          postgres    false    294    396    4009            K           2606    34975 ?   TransactionExpenses FK_TransactionExpenses_FundTypes_FundTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY "TRANSACTION"."TransactionExpenses"
    ADD CONSTRAINT "FK_TransactionExpenses_FundTypes_FundTypeId" FOREIGN KEY ("FundTypeId") REFERENCES "TRANSACTION"."FundTypes"("Id") ON DELETE RESTRICT;
 t   ALTER TABLE ONLY "TRANSACTION"."TransactionExpenses" DROP CONSTRAINT "FK_TransactionExpenses_FundTypes_FundTypeId";
       TRANSACTION          postgres    false    396    390    4235            L           2606    34980 R   TransactionExpenses FK_TransactionExpenses_TransactionDetails_TransactionDetailsId    FK CONSTRAINT     �   ALTER TABLE ONLY "TRANSACTION"."TransactionExpenses"
    ADD CONSTRAINT "FK_TransactionExpenses_TransactionDetails_TransactionDetailsId" FOREIGN KEY ("TransactionDetailsId") REFERENCES "TRANSACTION"."TransactionDetails"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY "TRANSACTION"."TransactionExpenses" DROP CONSTRAINT "FK_TransactionExpenses_TransactionDetails_TransactionDetailsId";
       TRANSACTION          postgres    false    396    4244    394            C           2606    34936 ;   Transactions FK_Transactions_FinancialYears_FinancialYearId    FK CONSTRAINT     �   ALTER TABLE ONLY "TRANSACTION"."Transactions"
    ADD CONSTRAINT "FK_Transactions_FinancialYears_FinancialYearId" FOREIGN KEY ("FinancialYearId") REFERENCES "GS"."FinancialYears"("Id") ON DELETE CASCADE;
 p   ALTER TABLE ONLY "TRANSACTION"."Transactions" DROP CONSTRAINT "FK_Transactions_FinancialYears_FinancialYearId";
       TRANSACTION          postgres    false    388    392    4233            D           2606    34941 9   Transactions FK_Transactions_ForestCircles_ForestCircleId    FK CONSTRAINT     �   ALTER TABLE ONLY "TRANSACTION"."Transactions"
    ADD CONSTRAINT "FK_Transactions_ForestCircles_ForestCircleId" FOREIGN KEY ("ForestCircleId") REFERENCES "BEN"."ForestCircles"("Id") ON DELETE CASCADE;
 n   ALTER TABLE ONLY "TRANSACTION"."Transactions" DROP CONSTRAINT "FK_Transactions_ForestCircles_ForestCircleId";
       TRANSACTION          postgres    false    3947    248    392            E           2606    34946 =   Transactions FK_Transactions_ForestDivisions_ForestDivisionId    FK CONSTRAINT     �   ALTER TABLE ONLY "TRANSACTION"."Transactions"
    ADD CONSTRAINT "FK_Transactions_ForestDivisions_ForestDivisionId" FOREIGN KEY ("ForestDivisionId") REFERENCES "BEN"."ForestDivisions"("Id") ON DELETE CASCADE;
 r   ALTER TABLE ONLY "TRANSACTION"."Transactions" DROP CONSTRAINT "FK_Transactions_ForestDivisions_ForestDivisionId";
       TRANSACTION          postgres    false    288    3988    392            >      x������ � �      @      x������ � �      b      x������ � �      `      x������ � �      P      x������ � �      N      x������ � �      L      x������ � �      �      x������ � �      V      x������ � �      D      x������ � �      B      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      l      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �            x������ � �      �      x������ � �      �      x������ � �            x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �            x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      R      x������ � �      �      x������ � �      �      x������ � �             x������ � �      �      x������ � �      �      x������ � �      8      x������ � �      :      x������ � �      <      x������ � �            x������ � �             x������ � �            x������ � �            x������ � �      
      x������ � �            x������ � �            x������ � �            x������ � �            x������ � �            x������ � �            x������ � �      *      x������ � �            x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      .      x������ � �      "      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      T      x������ � �      X      x������ � �      ^      x������ � �      \      x������ � �      �      x������ � �      Z      x������ � �      �      x������ � �      ,      x������ � �      $      x������ � �      &      x������ � �      (      x������ � �      J      x������ � �      H      x������ � �      F      x������ � �      h      x������ � �      d      x������ � �      j      x������ � �      f      x������ � �      �      x������ � �      x      x������ � �      �      x������ � �      z      x������ � �      |      x������ � �      v      x������ � �      n      x������ � �      r      x������ � �      p      x������ � �      ~      x������ � �      �      x������ � �      �      x������ � �      t      x������ � �            x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      0      x������ � �      4      x������ � �      6      x������ � �      2      x������ � �      �   �	  x��Y�n�8}�������tǙ|�/,�� Kt[;j���'��{Jj�MR�=d�Sd�Uu�[0!8��D*Dve��ت���_�g�Y}���G2;�m񜷜��ьy �d���0v�?��s�5.0f��e�]��p�П���Kޙ�����)Xp�"���vy���+�>�TE��о���~�6/y}����yHΙP<l���Sģl��v���ۼ��^�%:q�6������.2�r)��,7�y�|�Y1o��*�̰/�ޔ\0�2�4-�o���i���^y[��1�f�h��H�"�����:���yU�W�� /|������ly�?�&�*%�?7����*��=l��
�(dI�5p+xP.d�ev�?�����:�by��x1KX*�W��ao|?G�J�[�k^�ES�=2kc������,�o���J�:7SE¥T���ץs�vs-x�q�� �"�1�7�`�kk�:��Q�i�i�M��>9�dٝ��@|����o�I�ڸ���D�*�N�����t�֎�q�@��ro�����f)�p9�V�KU#��o7m�wM#��$�.��VǏJ�r�=+pDP��.ʧ��,5���>5�n�߈h
>9���`� �9�[��~�Vg;��wM��BK>W�ƾ�4������������?�۩M��-���g]�E����˴dp
Lc�HG�R�N1��?[��io��f�1�����"":j�n��h���,�4gG�
�]^����c]Q-:�"�Xs��=�7�|k|2�y����Y��F��/�?_�&Dh�h�;�Ρ��}P�1'L�)�N���Ͻ��wp��G���.��tgE�a�B�0���u �B����iRs��Ѷ����6wqh告D��m�y8=r��mS�X�x6� ��g��M�ֿ7Y�E�
�D���o�4AV	��"�%	�US;�y8����ė�)�oz/��e�U����om^,��^�7YY��mMX&�CR�_둻�p�sT2P5Ö(�05-޹XO���q2�e���?�ՀMew�h@�M�0)�)�0�m�� qE>�-��T�%�'~=�i1�\5.Ls�Fj��9�#�}7�V8zX��r�(_����>�2� o>@�K[_?��9�6L6�,�З�������J)R�n�3��p�q��%�_9�5�K�a�-�w���MP�R+wI��:j�>e�
`YT{=�(�N1��"䶤:\�u1��r`����h�I�H�F6���|�W"��q���u��&!bh���p��/B�d�����W��à#&'�=����"F@-b����/b1�bJ=J�1q�O��[��1\��.&h�[R�M��><�h�s��b;�B���A�E)
�"?{�Z�T�{'�h���Cg�y|�hXК�A���BQ!-S�����i=�'���_�o��)��^��Т�Ǽ3>&Ɲ�ǌ+����:Y�1ǀ���ޠ3�H�����i)0<��o�Ajr�.}
��}ԴQ��崯�����?n�Ol� ecN/�`Q��A��Lt���X�V�&��mC�.Ln f1ji&��FY���⧈[S{N�B�@(e�þ�
��]��1�f篔�j��������y����HB���pA y��S� ���6��^��)bH��%��ak���u���'T�T4${��s ��*zv�>� �1��C^b�z?҄�����/��O[��q,�2�M�`��z�*��.����O�TӖ�(nL[��W������|�P3����ו�;�0M��0�H�:�J�h�s�.%�NE��5���R_�$�^z�:�</^�O��51LM�  ����v�x0y;J¯������3����9��Ȼ}�0Ө$d.�4�Fg� �*��o����-j����1WULG�����3��'pt���BcHt�n��._����ê��RI��kZz�v���S�΂���G�M3�Q��5E5�?\P{���j���Y?�(�=�4���(2���fL���{K��yhz_��t�� R����x�Z�&Ɲ����p�@z�G`D��@��eҜ��1�B� ���Ӳڑ��;��r��,��ͩ���x����2�pieS�W~�Q/�����&�ӑ��)�V�h�!��OO���"~��A�����A��N�=`�J�X,y��{�!3N�H'�����o����h�8oM�Y�(ڟ��Ѽ��!ph(����~#7��6?9Moo<>S�Jx�h��֊�Tߜ����x�J�����yUw��ʝ�������EU����H���:�-�%��0��yL��yhk/�$��G6�	����)�$2>d��p��m��~s�=�qD�*z-��ܢ�/ Q�~KO��aIt�5N��ٴ�(��ϟ>}�?�"�<     
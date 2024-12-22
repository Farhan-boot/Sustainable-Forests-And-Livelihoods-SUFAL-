using ExcelDataReader;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Beneficiary;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations
{
    public class OLEDbDataInsert : ControllerBase
    {
        private readonly GENERICWriteOnlyCtx context;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        private const string GS_FilePath = @"D:\\PrimeTech\\Forestry\\Excel\\data_general_setup.xlsx";
        private const string SURVEY_FilePath = @"D:\\sufl_assets\\Forestry\\Excel\\data_survey_and_others.xlsx";

        public OLEDbDataInsert(GENERICWriteOnlyCtx dbContext, GENERICReadOnlyCtx readOnlyCtx)
        {
            context = dbContext;
            _readOnlyCtx = readOnlyCtx;
        }

        public static bool IsBangla(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            const int maxAnsiCode = 255;
            return str.Any(x => x > maxAnsiCode);
        }
        public static string ToEnglishNumber(string value)
        {
            var utf8Str = Encoding.UTF8.GetString(Encoding.Default.GetBytes(value));
            StringBuilder sb = new StringBuilder();

            foreach (var item in utf8Str)
            {
                switch (item)
                {
                    case '১':
                        sb.Append('1');
                        break;
                    case '২':
                        sb.Append('2');
                        break;
                    case '৩':
                        sb.Append('3');
                        break;
                    case '৪':
                        sb.Append('4');
                        break;
                    case '৫':
                        sb.Append('5');
                        break;
                    case '৬':
                        sb.Append('6');
                        break;
                    case '৭':
                        sb.Append('7');
                        break;
                    case '৮':
                        sb.Append('8');
                        break;
                    case '৯':
                        sb.Append('9');
                        break;
                    case '০':
                        sb.Append('0');
                        break;
                }
            }

            return sb.ToString();
        }

        [HttpGet("/general-setup")]
        public async Task<IActionResult> GeneralSetup()
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GS_FilePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();
            var command = $"SELECT * From [choices$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            // Save data
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>())
                {
                    var list_name = row.Field<string>("list_name");
                    if (string.IsNullOrEmpty(list_name)) continue;

                    var name = row.Field<double?>(1);
                    var label_English = row.Field<string>(2);
                    var label_BN = row.Field<string>(3);
                    var parent = row.Field<double?>(4);

                    //
                    if (list_name == "fd_cir")
                    {
                        var data = new ForestCircle
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<ForestCircle>().Add(data);
                    }

                    if (list_name == "fd_division")
                    {
                        var data = new ForestDivision
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            ForestCircleId = (long)parent,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<ForestDivision>().Add(data);
                    }

                    if (list_name == "fd_range")
                    {
                        var data = new ForestRange
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            ForestDivisionId = (long)parent,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<ForestRange>().Add(data);
                    }

                    if (list_name == "fd_beat")
                    {
                        var data = new ForestBeat
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            ForestRangeId = (long)parent,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<ForestBeat>().Add(data);
                    }

                    if (list_name == "fd_fcv")
                    {
                        var data = new ForestFcvVcf
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            ForestBeatId = (long)parent,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<ForestFcvVcf>().Add(data);
                    }

                    if (list_name == "ad_division")
                    {
                        var data = new Division
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<Division>().Add(data);
                    }

                    if (list_name == "ad_district")
                    {
                        var data = new District
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            DivisionId = (long)parent,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<District>().Add(data);
                    }

                    if (list_name == "ad_upzilla")
                    {
                        var data = new Upazilla
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            DistrictId = (long)parent,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<Upazilla>().Add(data);
                    }

                    if (list_name == "rel_hh_head")
                    {
                        var data = new RelationWithHeadHouseHoldType
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<RelationWithHeadHouseHoldType>().Add(data);
                    }

                    if (list_name == "ocupation")
                    {
                        var data = new Occupation
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<Occupation>().Add(data);
                    }

                    if (list_name == "disability")
                    {
                        var data = new DisabilityType
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<DisabilityType>().Add(data);
                    }

                    if (list_name == "safety_net")
                    {
                        var data = new SafetyNet
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<SafetyNet>().Add(data);
                    }

                    if (list_name == "ass_bfd")
                    {
                        var data = new BFDAssociation
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<BFDAssociation>().Add(data);
                    }

                    if (list_name == "li_type")
                    {
                        var data = new LiveStockType
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<LiveStockType>().Add(data);
                    }

                    if (list_name == "ass_type")
                    {
                        var data = new AssetType
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<AssetType>().Add(data);
                    }

                    if (list_name == "immovable")
                    {
                        var data = new ImmovableAssetType
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<ImmovableAssetType>().Add(data);
                    }

                    if (list_name == "use_energy")
                    {
                        var data = new EnergyType
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<EnergyType>().Add(data);
                    }

                    if (list_name == "source_income")
                    {
                        var data = new ManualIncomeSourceType
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<ManualIncomeSourceType>().Add(data);
                    }

                    if (list_name == "activity")
                    {
                        var data = new NaturalIncomeSourceType
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<NaturalIncomeSourceType>().Add(data);
                    }

                    if (list_name == "other_source")
                    {
                        var data = new OtherIncomeSourceType
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<OtherIncomeSourceType>().Add(data);
                    }

                    if (list_name == "bu_source")
                    {
                        var data = new BusinessIncomeSourceType
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<BusinessIncomeSourceType>().Add(data);
                    }

                    if (list_name == "major_item")
                    {
                        var data = new ExpenditureType
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<ExpenditureType>().Add(data);
                    }

                    if (list_name == "food_it")
                    {
                        var data = new FoodItem
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<FoodItem>().Add(data);
                    }
                    if (list_name == "ethnicity")
                    {
                        var data = new Ethnicity
                        {
                            Id = (long)name,
                            Name = label_English,
                            NameBn = label_BN,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true
                        };
                        context.Set<Ethnicity>().Add(data);
                    }
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return Ok("Done");
        }

        [HttpGet("/survey")]
        public async Task<IActionResult> Survey(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();
            var command = $"SELECT * From [Baseline Survey of Beneficia...$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            var ignoredIdList = new List<double?>();
            var surveyList = new List<Survey>();

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
                {
                    var survey = new Survey();

                    survey.CreatedAt = DateTime.Now;
                    survey.CreatedBy = 3;
                    survey.IsActive = true;

                    var _index = DataRowHelper.GetLongValue(row, "_id");
                    survey.Id = _index;

                    if (survey.Id == default)
                    {
                        continue;
                    }

                    survey.StartTime = DataRowHelper.GetDateTimeValue(row, "start") ?? DateTime.MinValue;
                    survey.EndTime = DataRowHelper.GetDateTimeValue(row, "end") ?? DateTime.MinValue;

                    survey.SurveyDate = DataRowHelper.GetDateTimeValue(row, "today") ?? DateTime.MinValue;
                    survey.Deviceid = DataRowHelper.GetStringValue(row, "deviceid");
                    survey.Subscriberid = DataRowHelper.GetStringValue(row, "subscriberid");
                    survey.Simserial = DataRowHelper.GetStringValue(row, "simserial");

                    var phonenumber = DataRowHelper.GetStringValue(row, "phonenumber");
                    survey.Phonenumber = phonenumber == "phonenumber not found" ? null : phonenumber;

                    survey.DetailsInfo = DataRowHelper.GetStringValue(row, "details_info");
                    survey.ForestCircleId = DataRowHelper.GetIntValue(row, "tloc_fd_cir");
                    survey.ForestDivisionId = DataRowHelper.GetIntValue(row, "tloc_fd_division");
                    survey.ForestRangeId = DataRowHelper.GetIntValue(row, "tloc_fd_range");
                    survey.ForestBeatId = DataRowHelper.GetIntValue(row, "tloc_fd_beat");
                    survey.ForestFcvVcfId = DataRowHelper.GetIntValue(row, "tloc_fcv");

                    var tloc_vill = DataRowHelper.GetStringValue(row, "tloc_vill")?.Trim();
                    if (IsBangla(tloc_vill!))
                    {
                        survey.ForestVillageNameBn = tloc_vill;
                    }
                    else
                    {
                        survey.ForestVillageName = tloc_vill;
                    }

                    survey.BeneficiaryHouseholdSerialNo = DataRowHelper.GetStringValue(row, "q5")?.Trim();
                    survey.BeneficiaryId = DataRowHelper.GetStringValue(row, "id")?.Trim() ?? throw new Exception("Beneficiary Id can not be empty");

                    var ben_name = DataRowHelper.GetStringValue(row, "ben_name")?.Trim();
                    if (IsBangla(ben_name!))
                    {
                        survey.BeneficiaryNameBn = ben_name;
                    }
                    else
                    {
                        survey.BeneficiaryName = ben_name;
                    }

                    survey.BeneficiaryNid = DataRowHelper.GetStringValue(row, "ben_national")?.Trim();

                    var ben_phone = DataRowHelper.GetStringValue(row, "ben_phone")?.Trim();
                    if (IsBangla(ben_phone!))
                    {
                        survey.BeneficiaryPhoneBn = ben_phone;
                    }
                    else
                    {
                        survey.BeneficiaryPhone = ben_phone;
                    }

                    survey.BeneficiaryGender = (Gender)DataRowHelper.GetIntValue(row, "ben_sex");

                    var ben_eth = DataRowHelper.GetStringValue(row, "ben_eth")?.Trim();
                    if (ben_eth != null)
                    {
                        long.TryParse(ben_eth, out var ben_eth_1);
                        survey.BeneficiaryEthnicityId = ben_eth_1 == 0 ? null : ben_eth_1;
                    }

                    survey.BeneficiaryEthnicityTxt = DataRowHelper.GetStringValue(row, "ben_eth_txt")?.Trim();

                    var ben_age = DataRowHelper.GetStringValue(row, "ben_age")?.Trim();
                    if (string.IsNullOrEmpty(ben_age))
                    {
                    }
                    else
                    {
                        if (ben_age!.Length > 3)
                        {
                        }
                        else
                        {
                            if (IsBangla(ben_age!))
                            {
                                survey.BeneficiaryAgeBn = ben_age;
                                survey.BeneficiaryAge = ToEnglishNumber(ben_age);
                            }
                            else
                            {
                                survey.BeneficiaryAge = ben_age;
                            }
                        }
                    }

                    var ben_father = DataRowHelper.GetStringValue(row, "ben_father")?.Trim();
                    if (IsBangla(ben_father!))
                    {
                        survey.BeneficiaryFatherNameBn = ben_father;
                    }
                    else
                    {
                        survey.BeneficiaryFatherName = ben_father;
                    }

                    var ben_mother = DataRowHelper.GetStringValue(row, "ben_mother")?.Trim();
                    if (IsBangla(ben_mother!))
                    {
                        survey.BeneficiaryMotherNameBn = ben_mother;
                    }
                    else
                    {
                        survey.BeneficiaryMotherName = ben_mother;
                    }

                    var ben_spouse = DataRowHelper.GetStringValue(row, "ben_spouse")?.Trim();
                    if (IsBangla(ben_spouse!))
                    {
                        survey.BeneficiarySpouseNameBn = ben_spouse;
                    }
                    else
                    {
                        survey.BeneficiarySpouseName = ben_spouse;
                    }

                    var hh_head = DataRowHelper.GetStringValue(row, "hh_head")?.Trim();
                    if (IsBangla(hh_head!))
                    {
                        survey.HeadOfHouseholdNameBn = hh_head;
                    }
                    else
                    {
                        survey.HeadOfHouseholdName = hh_head;
                    }

                    var hh_head_sex = row.Field<double?>("hh_head_sex");
                    if (hh_head_sex != null)
                    {
                        survey.HeadOfHouseholdGender = (Gender)(int)hh_head_sex;
                    }

                    var pre_vill_name = DataRowHelper.GetStringValue(row, "pre_vill_name")?.Trim();
                    if (IsBangla(pre_vill_name!))
                    {
                        survey.PresentVillageNameBn = pre_vill_name;
                    }
                    else
                    {
                        survey.PresentVillageName = pre_vill_name;
                    }

                    var pre_po_name = DataRowHelper.GetStringValue(row, "pre_po_name")?.Trim();
                    if (IsBangla(pre_po_name!))
                    {
                        survey.PresentPostOfficeNameBn = pre_po_name;
                    }
                    else
                    {
                        survey.PresentPostOfficeName = pre_po_name;
                    }

                    var pre_division = row.Field<double?>("pre_division");
                    if (pre_division != null)
                    {
                        survey.PresentDivisionId = (int)pre_division;
                    }

                    var pre_district = row.Field<double?>("pre_district");
                    if (pre_district != null)
                    {
                        survey.PresentDistrictId = (int)pre_district;
                    }

                    var pre_upazila = row.Field<double?>("pre_upazila");
                    if (pre_upazila != null)
                    {
                        survey.PresentUpazillaId = (int)pre_upazila;
                    }

                    var pre_union = DataRowHelper.GetStringValue(row, "pre_union")?.Trim();
                    survey.PresentUnion = pre_union;

                    var per_pre = row.Field<double?>("per_pre");
                    if (per_pre != null)
                    {
                        survey.IsPermanentSameAsPresent = per_pre == 1;
                    }

                    if (pre_division is null || pre_district is null || pre_upazila is null || per_pre is null)
                    {
                        ignoredIdList.Add(_index);
                        continue;
                    }

                    survey.PermanentVillageName = row.Field<string>("per_vill_name");
                    survey.PermanentPostOfficeName = row.Field<string>("per_po_name");

                    var per_division = DataRowHelper.GetStringValue(row, "per_division")?.Trim();
                    if (per_division == "NaN" || per_division == "Infinity") survey.PermanentDivisionId = null;
                    else
                    {
                        double.TryParse(per_division, out var per_division1);
                        if (per_division != null && per_division1 != default)
                        {
                            survey.PermanentDivisionId = (int)per_division1;
                        }
                    }

                    var per_district = DataRowHelper.GetStringValue(row, "per_district")?.Trim();
                    if (per_district == "NaN" || per_district == "Infinity") survey.PermanentDistrictId = null;
                    else
                    {
                        double.TryParse(per_district, out var per_district1);
                        if (per_district != null && per_district1 != default)
                        {
                            survey.PermanentDistrictId = (long)per_district1;
                        }
                    }

                    var per_upazila = DataRowHelper.GetStringValue(row, "per_upazila")?.Trim();
                    if (per_upazila == "NaN" || per_upazila == "Infinity") survey.PermanentUpazillaId = null;
                    else
                    {
                        double.TryParse(per_upazila, out var per_upazila1);
                        if (per_upazila != null && per_upazila1 != default)
                        {
                            survey.PermanentUpazillaId = (long)per_upazila1;
                        }
                    }

                    survey.PermanentUnion = DataRowHelper.GetStringValue(row, "per_union")?.Trim();
                    survey.BeneficiaryLatitude = DataRowHelper.GetDoubleValue(row, "_rsitepoint_latitude");
                    survey.BeneficiaryLongitude = DataRowHelper.GetDoubleValue(row, "_rsitepoint_longitude");
                    survey.BeneficiaryAltitude = DataRowHelper.GetDoubleValue(row, "_rsitepoint_altitude");
                    survey.BeneficiaryPrecision = DataRowHelper.GetDoubleValue(row, "_rsitepoint_precision");
                    survey.BeneficiaryHouseFrontImage = DataRowHelper.GetStringValue(row, "hh_img")?.Trim();
                    survey.BeneficiaryHouseFrontImageURL = DataRowHelper.GetStringValue(row, "hh_img_URL")?.Trim();

                    /*
                    var g_total_land = row.Field<string?>("g_total_land");
                    if (g_total_land == "NaN" || g_total_land == "Infinity") survey.GrandTotalLandOccupancy = 0;
                    else
                    {
                        double.TryParse(g_total_land, out var gTotalLand);
                        survey.GrandTotalLandOccupancy = gTotalLand;
                    }
                    */
                    var g_total_land_type = row.Table.Columns["g_total_land"]?.DataType;
                    if (g_total_land_type == typeof(double))
                    {
                        var g_total_land = row.Field<double?>("g_total_land") ?? 0;
                        if (double.IsNaN(g_total_land) || double.IsInfinity(g_total_land))
                        {
                            survey.GrandTotalLandOccupancy = 0;
                        }
                        else
                        {
                            survey.GrandTotalLandOccupancy = g_total_land;
                        }
                    }
                    else if (g_total_land_type == typeof(string))
                    {
                        var g_total_land = row.Field<string>("g_total_land");
                        if (g_total_land == "NaN" || g_total_land == "Infinity")
                        {
                            survey.GrandTotalLandOccupancy = 0;
                        }
                        else
                        {
                            double.TryParse(g_total_land, out var gTotalLand);
                            survey.GrandTotalLandOccupancy = gTotalLand;
                        }
                    }


                    var house_house = row.Field<double?>("house_house");
                    if (house_house != null)
                    {
                        survey.BeneficiaryHouseType = (HouseType)(int)house_house;
                    }

                    /*
                    var t_li_cost = row.Field<string?>("t_li_cost");
                    if (t_li_cost == "NaN" || t_li_cost == "Infinity") survey.GrandTotalLivestockCost = 0;
                    else
                    {
                        double.TryParse(t_li_cost, out var tLiCost);
                        survey.GrandTotalLivestockCost = tLiCost;
                    }
                    */
                    var t_li_cost_type = row.Table.Columns["t_li_cost"]?.DataType;
                    if (t_li_cost_type == typeof(double))
                    {
                        var t_li_cost = row.Field<double?>("t_li_cost") ?? 0;
                        if (double.IsNaN(t_li_cost) || double.IsInfinity(t_li_cost))
                        {
                            survey.GrandTotalLivestockCost = 0;
                        }
                        else
                        {
                            survey.GrandTotalLivestockCost = t_li_cost;
                        }
                    }
                    else if (t_li_cost_type == typeof(string))
                    {
                        var t_li_cost = row.Field<string>("t_li_cost");
                        if (t_li_cost == "NaN" || t_li_cost == "Infinity")
                        {
                            survey.GrandTotalLivestockCost = 0;
                        }
                        else
                        {
                            double.TryParse(t_li_cost, out var tLiCost);
                            survey.GrandTotalLivestockCost = tLiCost;
                        }
                    }


                    /*
                    var t_assets_cost = row.Field<string?>("t_assets_cost");
                    if (t_assets_cost == "NaN" || t_assets_cost == "Infinity") survey.GrandTotalAssetsCost = 0;
                    else
                    {
                        double.TryParse(t_assets_cost, out var tAssetsCost);
                        survey.GrandTotalAssetsCost = tAssetsCost;
                    }
                    */
                    var t_assets_cost_type = row.Table.Columns["t_assets_cost"]?.DataType;
                    if (t_assets_cost_type == typeof(double))
                    {
                        var t_assets_cost = row.Field<double?>("t_assets_cost") ?? 0;
                        if (double.IsNaN(t_assets_cost) || double.IsInfinity(t_assets_cost))
                        {
                            survey.GrandTotalAssetsCost = 0;
                        }
                        else
                        {
                            survey.GrandTotalAssetsCost = t_assets_cost;
                        }
                    }
                    else if (t_assets_cost_type == typeof(string))
                    {
                        var t_assets_cost = row.Field<string>("t_assets_cost");
                        if (t_assets_cost == "NaN" || t_assets_cost == "Infinity")
                        {
                            survey.GrandTotalAssetsCost = 0;
                        }
                        else
                        {
                            double.TryParse(t_assets_cost, out var tAssetsCost);
                            survey.GrandTotalAssetsCost = tAssetsCost;
                        }
                    }


                    /*
                    var t_imm_ann = row.Field<string?>("t_imm_ann");
                    if (t_imm_ann == "NaN" || t_imm_ann == "Infinity") survey.GrandTotalImmovableAnnualReturn = 0;
                    else
                    {
                        double.TryParse(t_imm_ann, out var tImmAnn);
                        survey.GrandTotalImmovableAnnualReturn = tImmAnn;
                    }
                    */
                    var t_imm_ann_type = row.Table.Columns["t_imm_ann"]?.DataType;
                    if (t_imm_ann_type == typeof(double))
                    {
                        var t_imm_ann = row.Field<double?>("t_imm_ann") ?? 0;
                        if (double.IsNaN(t_imm_ann) || double.IsInfinity(t_imm_ann))
                        {
                            survey.GrandTotalImmovableAnnualReturn = 0;
                        }
                        else
                        {
                            survey.GrandTotalImmovableAnnualReturn = t_imm_ann;
                        }
                    }
                    else if (t_imm_ann_type == typeof(string))
                    {
                        var t_imm_ann = row.Field<string>("t_imm_ann");
                        if (t_imm_ann == "NaN" || t_imm_ann == "Infinity")
                        {
                            survey.GrandTotalImmovableAnnualReturn = 0;
                        }
                        else
                        {
                            double.TryParse(t_imm_ann, out var tImmAnn);
                            survey.GrandTotalImmovableAnnualReturn = tImmAnn;
                        }
                    }


                    var access_pro_clinic = row.Field<double?>("access_pro_clinic");
                    survey.IsProblemToAccessHealthService = access_pro_clinic is null ? false : access_pro_clinic == 1;
                    survey.NearestHealthServiceLocation = row.Field<string>("access_clinic");

                    survey.NearestHealthServiceDistance = row.Field<double>("clinic_dist");

                    var drin_pro = row.Field<double?>("drin_pro");
                    survey.IsProblemToAccessDrinkingWater = drin_pro is null ? false : drin_pro == 1;

                    survey.NearestDrinkingWaterDistance = row.Field<double>("access_water");

                    var dry_water_type = row.Table.Columns["dry_water"]?.DataType;
                    if (dry_water_type is null)
                    {
                        survey.SourceofDrySeasonWaterEnumList = null;
                    }
                    else if (dry_water_type == typeof(double))
                    {
                        survey.SourceofDrySeasonWaterEnumList = row.Field<double?>("dry_water")?.ToString();
                    }
                    else if (dry_water_type == typeof(string))
                    {
                        survey.SourceofDrySeasonWaterEnumList = row.Field<string>("dry_water");
                    }

                    survey.SourceofDrySeasonWaterTxt = row.Field<string>("dry_water_text")?.Trim();

                    var wet_water_type = row.Table.Columns["wet_water"]?.DataType;
                    if (wet_water_type is null)
                    {
                        survey.SourceofWetSeasonWaterEnumList = null;
                    }
                    else if (wet_water_type == typeof(double))
                    {
                        survey.SourceofWetSeasonWaterEnumList = row.Field<double?>("wet_water")?.ToString();
                    }
                    else if (wet_water_type == typeof(string))
                    {
                        survey.SourceofWetSeasonWaterEnumList = row.Field<string>("wet_water")?.Trim();
                    }

                    survey.SourceofWetSeasonWaterTxt = row.Field<string>("wet_water_txt")?.Trim();
                    survey.NearestGrowthCenter = row.Field<string>("growth_center")?.Trim();
                    survey.NearestGrowthCenterDistance = row.Field<double>("dist_growth");

                    var acc_edu = row.Field<double?>("acc_edu");
                    survey.IsProblemToAccessEducation = acc_edu is null ? false : acc_edu == 1;

                    var edu_ava = row.Field<double?>("edu_ava");
                    survey.HasEducationalInstituteNearby = edu_ava is null ? false : edu_ava == 1;

                    survey.EducationalInstituteDistance = row.Field<double>("edu_dist");

                    var edu_access = row.Field<double?>("edu_access");
                    if (edu_access != null)
                    {
                        survey.EducationalInstituteAccessibilityEnum = (EducationalInstituteAccessibility)(int)edu_access;
                    }

                    var sanitation = row.Field<double?>("sanitation");
                    if (sanitation != null)
                    {
                        survey.SanitationFacilitiesEnum = (SanitationFacilities)(int)sanitation;
                    }

                    survey.PotentialSkillName1 = row.Field<string>("pot_skill1");
                    survey.PotentialSkillName2 = row.Field<string>("pot_skill2");
                    survey.PotentialSkillName3 = row.Field<string>("pot_skill3");
                    survey.PotentialSpecialSkill = row.Field<string>("skill_trai");
                    survey.PotentialSkillsRemarks = row.Field<string>("pot_remarks");

                    var satis_exi = row.Field<double?>("satis_exi");
                    if (satis_exi != null)
                    {
                        survey.ForestMngmtSatisfactionEnum = (SatisfactionLevel)(int)satis_exi;
                    }

                    var effec_forest = row.Field<double?>("effec_forest");
                    if (effec_forest != null)
                    {
                        survey.ForestMngmtEffectivenessEnum = (SatisfactionLevel)(int)effec_forest;
                    }

                    var depen_forest = row.Field<double?>("depen_forest");
                    if (depen_forest != null)
                    {
                        survey.ForestDependencyEnum = (ForestDependency)(int)depen_forest;
                    }

                    var awar_coll1 = DataRowHelper.GetDoubleValue(row, "awar_coll1");
                    survey.IsHearedAboutCfm = awar_coll1 == default ? false : awar_coll1 == 1;
                    var awar_coll2 = DataRowHelper.GetDoubleValue(row, "awar_coll2");
                    survey.IsParticipatedInCfm = awar_coll2 == default ? false : awar_coll2 == 1;
                    var awar_coll3 = DataRowHelper.GetDoubleValue(row, "awar_coll3");
                    survey.WillCfmImproveForestMngmnt = awar_coll3 == default ? false : awar_coll3 == 1;
                    var awar_coll4 = DataRowHelper.GetDoubleValue(row, "awar_coll4");
                    survey.WillCfmImproveWellBeing = awar_coll4 == default ? false : awar_coll4 == 1;

                    var gender_eth1 = DataRowHelper.GetDoubleValue(row, "gender_eth1");
                    survey.DicisionTakerEnum = gender_eth1 == default ? GenderMf.Male : (GenderMf)(int)gender_eth1;
                    var gender_eth3 = DataRowHelper.GetDoubleValue(row, "gender_eth3");
                    survey.ProductiveAssetsOwnerGender = gender_eth3 == default ? GenderMf.Male : (GenderMf)(int)gender_eth3;
                    var gender_eth4 = DataRowHelper.GetDoubleValue(row, "gender_eth4");
                    survey.CropTypeDecisionGender = gender_eth4 == default ? GenderMf.Male : (GenderMf)(int)gender_eth4;
                    var gender_eth5 = DataRowHelper.GetDoubleValue(row, "gender_eth5");
                    survey.DecisionToTransferAssetsGender = gender_eth5 == default ? GenderMf.Male : (GenderMf)(int)gender_eth5;
                    var gender_eth6 = DataRowHelper.GetDoubleValue(row, "gender_eth6");
                    survey.FamilyNeedsDeciderGender = gender_eth6 == default ? GenderMf.Male : (GenderMf)(int)gender_eth6;
                    var gender_eth7 = DataRowHelper.GetDoubleValue(row, "gender_eth7");
                    survey.AccessorToCreditGender = gender_eth7 == default ? GenderMf.Male : (GenderMf)(int)gender_eth7;
                    var gender_eth8 = DataRowHelper.GetDoubleValue(row, "gender_eth8");
                    survey.ControllerOfCreditGender = gender_eth8 == default ? GenderMf.Male : (GenderMf)(int)gender_eth8;
                    var gender_eth9 = DataRowHelper.GetDoubleValue(row, "gender_eth9");
                    survey.OfficeBearerGender = gender_eth9 == default ? GenderMf.Male : (GenderMf)(int)gender_eth9;
                    var gender_eth11 = DataRowHelper.GetDoubleValue(row, "gender_eth11");
                    survey.MorePaymentGetterGender = gender_eth11 == default ? GenderMf.Male : (GenderMf)(int)gender_eth11;
                    var gender_eth12 = DataRowHelper.GetDoubleValue(row, "gender_eth12");
                    survey.CanAccessLegalSupportForGbv = gender_eth12 == default ? false : gender_eth12 == 1;

                    var small_eth3 = DataRowHelper.GetDoubleValue(row, "small_eth3");
                    survey.CanUnsufructsRights = small_eth3 == default ? false : small_eth3 == 1;
                    var small_eth4 = DataRowHelper.GetDoubleValue(row, "small_eth4");
                    survey.FaceLiveAndLivelihoodChallanges = small_eth4 == default ? false : small_eth4 == 1;
                    var small_eth5 = DataRowHelper.GetDoubleValue(row, "small_eth5");
                    survey.HasLlfmInterest = small_eth5 == default ? false : small_eth5 == 1;

                    var total_income_type = row.Table.Columns["total_income"]?.DataType;
                    if (total_income_type == typeof(double))
                    {
                        var total_income = row.Field<double?>("total_income") ?? 0;
                        if (total_income == double.NaN || double.IsInfinity(total_income)) survey.GrandTotalNetIncomeAgriculture = 0;
                        else
                        {
                            survey.GrandTotalNetIncomeAgriculture = total_income;
                        }
                    }
                    else if (total_income_type == typeof(string))
                    {
                        var total_income = row.Field<string>("total_income");
                        if (total_income == "NaN" || total_income == "Infinity") survey.GrandTotalNetIncomeAgriculture = 0;
                        else
                        {
                            double.TryParse(total_income, out var total_income1);
                            survey.GrandTotalNetIncomeAgriculture = total_income1;
                        }
                    }

                    var total_up_type = row.Table.Columns["total_up"]?.DataType;
                    if (total_up_type == typeof(double))
                    {
                        var total_up = row.Field<double?>("total_up") ?? 0;
                        if (total_up == double.NaN || double.IsInfinity(total_up)) survey.GrandTotalLandArea = 0;
                        else
                        {
                            survey.GrandTotalLandArea = total_up;
                        }
                    }
                    else if (total_up_type == typeof(string))
                    {
                        var total_up = row.Field<string>("total_up");
                        if (total_up == "NaN" || total_up == "Infinity") survey.GrandTotalLandArea = 0;
                        else
                        {
                            double.TryParse(total_up, out var total_up1);
                            survey.GrandTotalLandArea = total_up1;
                        }
                    }

                    var gt_type = row.Table.Columns["gt"]?.DataType;
                    if (gt_type == typeof(double))
                    {
                        var gt = row.Field<double?>("gt") ?? 0;
                        if (gt == double.NaN || double.IsInfinity(gt)) survey.GrandTotalGrossMarginAgriculture = 0;
                        else
                        {
                            survey.GrandTotalGrossMarginAgriculture = gt;
                        }
                    }
                    else if (total_up_type == typeof(string))
                    {
                        var gt = row.Field<string>("gt");
                        if (gt == "NaN" || gt == "Infinity") survey.GrandTotalGrossMarginAgriculture = 0;
                        else
                        {
                            double.TryParse(gt, out var gt1);
                            survey.GrandTotalGrossMarginAgriculture = gt1;
                        }
                    }

                    /*
                    var t_ann_in = row.Field<string?>("t_ann_in");
                    if (t_ann_in == "NaN" || t_ann_in == "Infinity") survey.GrandTotalAnnualPhysicalIncome = 0;
                    else
                    {
                        double.TryParse(t_ann_in, out var t_ann_in1);
                        survey.GrandTotalAnnualPhysicalIncome = t_ann_in1;
                    }
                    */
                    var t_ann_in_type = row.Table.Columns["t_ann_in"]?.DataType;
                    if (t_ann_in_type == typeof(double))
                    {
                        var t_ann_in = row.Field<double?>("t_ann_in") ?? 0;
                        if (double.IsNaN(t_ann_in) || double.IsInfinity(t_ann_in))
                        {
                            survey.GrandTotalAnnualPhysicalIncome = 0;
                        }
                        else
                        {
                            survey.GrandTotalAnnualPhysicalIncome = t_ann_in;
                        }
                    }
                    else if (t_ann_in_type == typeof(string))
                    {
                        var t_ann_in = row.Field<string>("t_ann_in");
                        if (t_ann_in == "NaN" || t_ann_in == "Infinity")
                        {
                            survey.GrandTotalAnnualPhysicalIncome = 0;
                        }
                        else
                        {
                            double.TryParse(t_ann_in, out var t_ann_in1);
                            survey.GrandTotalAnnualPhysicalIncome = t_ann_in1;
                        }
                    }

                    /*
                    var st_total_net = row.Field<string?>("st_total_net");
                    if (st_total_net == "NaN" || st_total_net == "Infinity") survey.GrandTotalWildResourceIncome = 0;
                    else
                    {
                        double.TryParse(st_total_net, out var st_total_net1);
                        survey.GrandTotalWildResourceIncome = st_total_net1;
                    }
                    */
                    var st_total_net_type = row.Table.Columns["st_total_net"]?.DataType;
                    if (st_total_net_type == typeof(double))
                    {
                        var st_total_net = row.Field<double?>("st_total_net") ?? 0;
                        if (double.IsNaN(st_total_net) || double.IsInfinity(st_total_net))
                        {
                            survey.GrandTotalWildResourceIncome = 0;
                        }
                        else
                        {
                            survey.GrandTotalWildResourceIncome = st_total_net;
                        }
                    }
                    else if (st_total_net_type == typeof(string))
                    {
                        var st_total_net = row.Field<string>("st_total_net");
                        if (st_total_net == "NaN" || st_total_net == "Infinity")
                        {
                            survey.GrandTotalWildResourceIncome = 0;
                        }
                        else
                        {
                            double.TryParse(st_total_net, out var st_total_net1);
                            survey.GrandTotalWildResourceIncome = st_total_net1;
                        }
                    }


                    /*
                    var sum_ot_in = row.Field<string?>("sum_ot_in");
                    if (sum_ot_in == "NaN" || sum_ot_in == "Infinity") survey.GrandTotalOtherIncome = 0;
                    else
                    {
                        double.TryParse(sum_ot_in, out var sum_ot_in1);
                        survey.GrandTotalOtherIncome = sum_ot_in1;
                    }
                    */
                    var sum_ot_in_type = row.Table.Columns["sum_ot_in"]?.DataType;
                    if (sum_ot_in_type == typeof(double))
                    {
                        var sum_ot_in = row.Field<double?>("sum_ot_in") ?? 0;
                        if (double.IsNaN(sum_ot_in) || double.IsInfinity(sum_ot_in))
                        {
                            survey.GrandTotalOtherIncome = 0;
                        }
                        else
                        {
                            survey.GrandTotalOtherIncome = sum_ot_in;
                        }
                    }
                    else if (sum_ot_in_type == typeof(string))
                    {
                        var sum_ot_in = row.Field<string>("sum_ot_in");
                        if (sum_ot_in == "NaN" || sum_ot_in == "Infinity")
                        {
                            survey.GrandTotalOtherIncome = 0;
                        }
                        else
                        {
                            double.TryParse(sum_ot_in, out var sum_ot_in1);
                            survey.GrandTotalOtherIncome = sum_ot_in1;
                        }
                    }


                    /*
                    var sum_bu_in = row.Field<string?>("sum_bu_in");
                    if (sum_bu_in == "NaN" || sum_bu_in == "Infinity") survey.GrandTotalBusinessIncome = 0;
                    else
                    {
                        double.TryParse(sum_bu_in, out var sum_bu_in1);
                        survey.GrandTotalBusinessIncome = sum_bu_in1;
                    }
                    */
                    var sum_bu_in_type = row.Table.Columns["sum_bu_in"]?.DataType;
                    if (sum_bu_in_type == typeof(double))
                    {
                        var sum_bu_in = row.Field<double?>("sum_bu_in") ?? 0;
                        if (double.IsNaN(sum_bu_in) || double.IsInfinity(sum_bu_in))
                        {
                            survey.GrandTotalBusinessIncome = 0;
                        }
                        else
                        {
                            survey.GrandTotalBusinessIncome = sum_bu_in;
                        }
                    }
                    else if (sum_bu_in_type == typeof(string))
                    {
                        var sum_bu_in = row.Field<string>("sum_bu_in");
                        if (sum_bu_in == "NaN" || sum_bu_in == "Infinity")
                        {
                            survey.GrandTotalBusinessIncome = 0;
                        }
                        else
                        {
                            double.TryParse(sum_bu_in, out var sum_bu_in1);
                            survey.GrandTotalBusinessIncome = sum_bu_in1;
                        }
                    }


                    var in_male_no = row.Field<double?>("in_male_no");
                    survey.NoOfMaleInsideCountry = in_male_no is null ? 0 : (int)in_male_no;
                    var in_male_tk = row.Field<double?>("in_male_tk");
                    survey.SentIncomeOfMaleInYearInsideCountry = in_male_tk is null ? 0 : (double)in_male_tk;
                    var in_female_no = row.Field<double?>("in_female_no");
                    survey.NoOfFemaleInsideCountry = in_female_no is null ? 0 : (int)in_female_no;
                    var in_female_tk = row.Field<double?>("in_female_tk");
                    survey.SentIncomeOfFemaleInYearInsideCountry = in_female_tk is null ? 0 : (double)in_female_tk;
                    var out_male_no = row.Field<double?>("out_male_no");
                    survey.NoOfMaleOutsideCountry = out_male_no is null ? 0 : (int)out_male_no;
                    var out_male_tk = row.Field<double?>("out_male_tk");
                    survey.SentIncomeOfMaleInYearOutsideCountry = out_male_tk is null ? 0 : (double)out_male_tk;
                    var out_female_no = row.Field<double?>("out_female_no");
                    survey.NoOfFemaleOutsideCountry = out_female_no is null ? 0 : (int)out_female_no;
                    var out_female_tk = row.Field<double?>("out_female_tk");
                    survey.SentIncomeOfFemaleInYearOutsideCountry = out_female_tk is null ? 0 : (double)out_female_tk;

                    var per_sav = row.Field<double?>("per_sav");
                    survey.PersonalSavingsOfAllMembers = per_sav is null ? 0 : (double)per_sav;
                    var hh_sharing = row.Field<double?>("hh_sharing");
                    survey.HouseShareInSavings = hh_sharing is null ? 0 : (double)hh_sharing;
                    var b_bank = row.Field<double?>("b_bank");
                    survey.BorrowedFromBank = b_bank is null ? 0 : (double)b_bank;
                    var b_ngo = row.Field<double?>("b_ngo");
                    survey.BorrowedFromNGO = b_ngo is null ? 0 : (double)b_ngo;
                    var g_ngo = row.Field<double?>("g_ngo");
                    survey.GrantsFromNGO = g_ngo is null ? 0 : (double)g_ngo;
                    var g_gob = row.Field<double?>("g_gob");
                    survey.GrantsFromGob = g_gob is null ? 0 : (double)g_gob;
                    var b_co = row.Field<double?>("b_co");
                    survey.BorrowedFromCoOperatives = b_co is null ? 0 : (double)b_co;
                    var b_mah = row.Field<double?>("b_mah");
                    survey.BorrowedFromNonRelatives = b_mah is null ? 0 : (double)b_mah;
                    var b_rel = row.Field<double?>("b_rel");
                    survey.BorrowedFromRelatives = b_rel is null ? 0 : (double)b_rel;
                    var sal_pro = row.Field<double?>("sal_pro");
                    survey.SaleOfProducts = sal_pro is null ? 0 : (double)sal_pro;

                    survey.OtherFinanceName = row.Field<string>("other_amm_txt");
                    var other_amm = row.Field<double?>("other_amm");
                    survey.OtherFinanceAmount = other_amm is null ? 0 : (double)other_amm;

                    var sum_ex_bdt = DataRowHelper.GetStringValue(row, "sum_ex_bdt")?.Trim();
                    if (sum_ex_bdt == "NaN" || sum_ex_bdt == "Infinity") survey.GrandTotalHouseholdExpenditure = 0;
                    else
                    {
                        double.TryParse(sum_ex_bdt, out var sum_ex_bdt1);
                        survey.GrandTotalHouseholdExpenditure = sum_ex_bdt1;
                    }

                    var hh_food_con = row.Field<double?>("hh_food_con");
                    if (hh_food_con != null)
                    {
                        survey.HouseholdFoodCondition = (FoodCondition)(int)hh_food_con;
                    }

                    survey.FoodCrisisMonth = row.Field<DateTime?>("month_sea");

                    var hh_prob_feed = row.Field<double?>("hh_prob_feed");
                    if (hh_prob_feed != null)
                    {
                        survey.FoodyPersonInFoodCrisis = (FamilyMemberType)(int)hh_prob_feed;
                    }

                    survey.NotesImage = DataRowHelper.GetStringValue(row, "eco_status")?.Trim();
                    survey.NotesImageUrl = DataRowHelper.GetStringValue(row, "eco_status_URL")?.Trim();

                    survey.NameOfTheEnumerator = DataRowHelper.GetStringValue(row, "name_enu")?.Trim();
                    survey.CellPhoneNumber = DataRowHelper.GetStringValue(row, "enu_cell")?.Trim();
                    survey.DataCollectionDate = DataRowHelper.GetDateTimeValue(row, "dcollection");

                    surveyList.Add(survey);
                }

                await context.Set<Survey>().AddRangeAsync(surveyList);

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            } // transaction end

            return Ok(string.Join(", ", ignoredIdList.Where(d => d.HasValue).Select(d => d.Value)));
        }

        [HttpGet("/household-member")]
        public async Task<IActionResult> HouseHoldMember(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();
            var command = $"SELECT * From [hh_info$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
                {
                    var householdMember = new HouseholdMember();
                    householdMember.CreatedBy = 3;
                    householdMember.CreatedAt = DateTime.Now;
                    householdMember.IsActive = true;

                    var _index = row.Field<double>("_index");
                    householdMember.Id = (int)_index;

                    var _parent_index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    householdMember.SurveyId = (int)_parent_index;

                    var hh_name = row.Field<string>("hh_name");
                    if (IsBangla(hh_name!))
                        householdMember.FullNameBn = hh_name;
                    else
                        householdMember.FullName = hh_name;

                    var hh_relation = DataRowHelper.GetDoubleValue(row, "hh_relation");
                    if (hh_relation < 1)
                    {
                    }
                    else
                    {
                        householdMember.RelationWithHeadHouseHoldTypeId = (int)hh_relation;
                    }

                    var hh_relation_text = row.Field<string>("hh_relation_text");
                    householdMember.RelationWithHeadHouseHoldTypeTxt = hh_relation_text;

                    var hh_sex = DataRowHelper.GetDoubleValue(row, "hh_sex");
                    householdMember.Gender = (Gender)(int)hh_sex!;

                    var hh_age_type = row.Table.Columns["hh_age"]?.DataType;
                    if (hh_age_type == typeof(string))
                    {
                        var hh_age = row.Field<string>("hh_age");

                        if (string.IsNullOrEmpty(hh_age))
                        {
                        }
                        else
                        {
                            if (hh_age!.Length > 3)
                            {
                            }
                            else
                            {
                                if (IsBangla(hh_age!))
                                {
                                    householdMember.AgeBn = hh_age;
                                    householdMember.Age = ToEnglishNumber(hh_age);
                                }
                                else
                                {
                                    householdMember.Age = hh_age;
                                }
                            }
                        }
                    }
                    else if (hh_age_type == typeof(double))
                    {
                        var hh_age = DataRowHelper.GetDoubleValue(row, "hh_age");
                        householdMember.Age = hh_age.ToString();
                    }

                    var hh_marital = DataRowHelper.GetDoubleValue(row, "hh_marital");
                    householdMember.MaritalSatus = (MaritalStatus)(int)hh_marital!;

                    var hh_marital_text = row.Field<string>("hh_marital_text");
                    householdMember.MaritalSatusTxt = hh_marital_text;

                    var hh_edu = DataRowHelper.GetDoubleValue(row, "hh_edu");
                    householdMember.EducationLevel = (EducationLevel)(int)hh_edu!;

                    var hh_mainocu = DataRowHelper.GetDoubleValue(row, "hh_mainocu");
                    householdMember.MainOccupationId = (int)hh_mainocu;

                    var hh_mainocu_text = row.Field<string>("hh_mainocu_text");
                    householdMember.MainOccupationTxt = hh_mainocu_text;

                    var hh_secocu = DataRowHelper.GetDoubleValue(row, "hh_secocu");
                    householdMember.SecondaryOccupationId = (int)hh_secocu;

                    var hh_secocu_text = row.Field<string>("hh_secocu_text");
                    householdMember.SecondOccupationTxt = hh_secocu_text;

                    var hh_ass_bfd = row.Table.Columns["hh_ass_bfd"]?.DataType;
                    var bfdAssociationList = new List<BFDAssociationHouseholdMembersMap>();
                    if (hh_ass_bfd == typeof(double))
                    {
                        var hh_ass_bfd1 = row.Field<double?>("hh_ass_bfd");

                        if (hh_ass_bfd1 != null)
                            bfdAssociationList.Add(new BFDAssociationHouseholdMembersMap { BFDAssociationId = (int)hh_ass_bfd1, IsActive = true });
                    }
                    else if (hh_ass_bfd == typeof(string))
                    {
                        var hh_ass_bfd1 = row.Field<string>("hh_ass_bfd");

                        if (hh_ass_bfd1 != null)
                        {
                            var splits = hh_ass_bfd1.Trim().Split(' ');
                            foreach (var item in splits)
                            {
                                if (int.TryParse(item, out var bfdId))
                                    bfdAssociationList.Add(new BFDAssociationHouseholdMembersMap { BFDAssociationId = bfdId, IsActive = true });
                            }
                        }
                    }
                    householdMember.BFDAssociationHouseholdMembers = bfdAssociationList;
                    // var hh_ass_bfd_1 = row.Field<string?>("hh_ass_bfd/1");
                    // var hh_ass_bfd_2 = row.Field<string?>("hh_ass_bfd/2");
                    // var hh_ass_bfd_3 = row.Field<string?>("hh_ass_bfd/3");
                    // var hh_ass_bfd_4 = row.Field<string?>("hh_ass_bfd/4");
                    // var hh_ass_bfd_5 = row.Field<string?>("hh_ass_bfd/5");
                    // var hh_ass_bfd_6 = row.Field<string?>("hh_ass_bfd/6");
                    // var hh_ass_bfd_7 = row.Field<string?>("hh_ass_bfd/7");
                    // var hh_ass_bfd_8 = row.Field<string?>("hh_ass_bfd/8");
                    // var hh_ass_bfd_9 = row.Field<string?>("hh_ass_bfd/9");
                    // var hh_ass_bfd_10 = row.Field<string?>("hh_ass_bfd/10");
                    // var hh_ass_bfd_11 = row.Field<string?>("hh_ass_bfd/11");

                    var hh_ass_bfd_txt = row.Field<string>("hh_ass_bfd_txt");
                    householdMember.BFDAssociationTxt = hh_ass_bfd_txt;

                    var hh_disa = DataRowHelper.GetDoubleValue(row, "hh_disa");
                    householdMember.HasDisability = hh_disa == 1;

                    var hh_disa_des = row.Table.Columns["hh_disa_des"]?.DataType;
                    var disabilityTypeList = new List<DisabilityTypeHouseholdMembersMap>();
                    if (hh_disa_des == typeof(double))
                    {
                        var hh_disa_des1 = row.Field<double?>("hh_disa_des");

                        if (hh_disa_des1 != null)
                            disabilityTypeList.Add(new DisabilityTypeHouseholdMembersMap { DisabilityTypeId = (int)hh_disa_des1, IsActive = true });
                    }
                    else if (hh_disa_des == typeof(string))
                    {
                        var hh_disa_des1 = row.Field<string>("hh_disa_des");

                        if (hh_disa_des1 != null)
                        {
                            var splits = hh_disa_des1.Trim().Split(' ');
                            foreach (var item in splits)
                            {
                                if (int.TryParse(item, out var disId))
                                    disabilityTypeList.Add(new DisabilityTypeHouseholdMembersMap { DisabilityTypeId = disId, IsActive = true });
                            }
                        }
                    }
                    householdMember.DisabilityTypeHouseholdMembers = disabilityTypeList;
                    // var hh_disa_des_1 = row.Field<string?>("hh_disa_des_1");
                    // var hh_disa_des_2 = row.Field<string?>("hh_disa_des_2");
                    // var hh_disa_des_3 = row.Field<string?>("hh_disa_des_3");
                    // var hh_disa_des_4 = row.Field<string?>("hh_disa_des_4");
                    // var hh_disa_des_5 = row.Field<string?>("hh_disa_des_5");
                    // var hh_disa_des_6 = row.Field<string?>("hh_disa_des_6");
                    // var hh_disa_des_7 = row.Field<string?>("hh_disa_des_7");
                    // var hh_disa_des_8 = row.Field<string?>("hh_disa_des_8");

                    var hh_safety = DataRowHelper.GetDoubleValue(row, "hh_safety");
                    householdMember.SafetyNetTypeId = (int)hh_safety;

                    var hh_safety_other = row.Field<string>("hh_safety_other");
                    householdMember.SafetyNetTypeTxt = hh_safety_other;

                    // var _parent_table_name = row.Field<string?>("_parent_table_name");

                    // var _submission__id = row.Field<string?>("_submission__id");
                    // var _submission__uuid = row.Field<string?>("_submission__uuid");

                    var _submission__submission_time = row.Field<DateTime>("_submission__submission_time");
                    householdMember.SubmissionTime = _submission__submission_time;

                    // var _submission__validation_status = row.Field<string?>("_submission__validation_status");

                    var _submission__notes = row.Field<string>("_submission__notes");
                    householdMember.Notes = _submission__notes;

                    // var _submission__status = row.Field<string?>("_submission__status");

                    var _submission__submitted_by = row.Field<string>("_submission__submitted_by");
                    householdMember.SubmittedBy = _submission__submitted_by;

                    householdMember.Id = 0;

                    await context.Set<HouseholdMember>().AddAsync(householdMember);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return Ok("Done");
        }

        [HttpGet("/land")]
        public async Task<IActionResult> Land(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();
            var command = $"SELECT * From [land$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
                {
                    var landOccupancy = new LandOccupancy();
                    landOccupancy.CreatedBy = 3;
                    landOccupancy.CreatedAt = DateTime.Now;
                    landOccupancy.IsActive = true;

                    var _index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    landOccupancy.Id = (int)_index;

                    var land_classification = DataRowHelper.GetDoubleValue(row, "land_classification");
                    if (land_classification == 0)
                    {
                        continue;
                    }
                    landOccupancy.LandClassificationEnum = (LandClassification)(int)land_classification;

                    var land_classification_txt = row.Field<string>("land_classification_txt");
                    landOccupancy.LandClassificationTxt = land_classification_txt;

                    var land_home = DataRowHelper.GetDoubleValue(row, "land_home");
                    landOccupancy.Homesteads = land_home;

                    var land_productive = DataRowHelper.GetDoubleValue(row, "land_productive");
                    landOccupancy.ProductiveLand = land_productive;

                    var land_fallow = DataRowHelper.GetDoubleValue(row, "land_fallow");
                    landOccupancy.FallowLand = land_fallow;

                    var land_weltland = DataRowHelper.GetDoubleValue(row, "land_weltland");
                    landOccupancy.ProductiveWetland = land_weltland;

                    var land_fall_wet = DataRowHelper.GetDoubleValue(row, "land_fall_wet");
                    landOccupancy.FallowWetland = land_fall_wet;

                    var land_other = DataRowHelper.GetDoubleValue(row, "land_other");
                    landOccupancy.OthersLand = land_other;

                    var total_land = DataRowHelper.GetDoubleValue(row, "total_land");
                    landOccupancy.TotalLand = total_land;
                    /*
                    landOccupancy.TotalLand = Math.Round(landOccupancy.Homesteads
                                                         + landOccupancy.ProductiveLand
                                                         + landOccupancy.FallowLand
                                                         + landOccupancy.ProductiveWetland
                                                         + landOccupancy.FallowWetland
                                                         + landOccupancy.OthersLand, 2);
                    */

                    // var land_total = row.Field<string?>("land_total");
                    // var _parent_table_name = row.Field<string?>("_parent_table_name");

                    var _parent_index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    landOccupancy.SurveyId = (int)_parent_index;

                    // var _submission__id = row.Field<string?>("_submission__id");
                    // var _submission__uuid = row.Field<string?>("_submission__uuid");

                    var _submission__submission_time = row.Field<DateTime>("_submission__submission_time");
                    landOccupancy.SubmissionTime = _submission__submission_time;

                    // var _submission__validation_status = row.Field<string?>("_submission__validation_status");

                    var _submission__notes = row.Field<string>("_submission__notes");
                    landOccupancy.Notes = _submission__notes;

                    landOccupancy.Id = 0;

                    await context.Set<LandOccupancy>().AddAsync(landOccupancy);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return Ok("Done");
        }

        [HttpGet("/livestock")]
        public async Task<IActionResult> LiveStock(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();
            var command = $"SELECT * From [ty_li$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
                {
                    var liveStock = new LiveStock();
                    liveStock.CreatedBy = 3;
                    liveStock.CreatedAt = DateTime.Now;
                    liveStock.IsActive = true;

                    var _index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    liveStock.Id = (int)_index;

                    var livestock_type = DataRowHelper.GetDoubleValue(row, "livestock_type");
                    if (livestock_type == 0)
                    {
                        continue;
                    }
                    else
                    {
                        liveStock.LiveStockTypeId = (int)livestock_type;
                    }

                    var livestock_type_other = row.Field<string>("livestock_type_other");
                    liveStock.LivestockTypeTxt = livestock_type_other;

                    var li_qty = DataRowHelper.GetDoubleValue(row, "li_qty");
                    liveStock.LiveStockQuantity = li_qty;

                    var li_cost = DataRowHelper.GetDoubleValue(row, "li_cost");
                    liveStock.LivestockCost = li_cost;

                    // var _parent_table_name = row.Field<string?>("_parent_table_name");

                    var _parent_index = row.Field<double>("_submission__id");
                    liveStock.SurveyId = (int)_parent_index;

                    liveStock.Id = 0;

                    await context.Set<LiveStock>().AddAsync(liveStock);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return Ok("done.");
        }

        [HttpGet("/assets")]
        public async Task<IActionResult> Assets(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();
            var command = $"SELECT * From [ty_ass$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
                {
                    var asset = new Asset();
                    asset.CreatedBy = 3;
                    asset.CreatedAt = DateTime.Now;
                    asset.IsActive = true;

                    var _index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    asset.Id = (int)_index;

                    var assets_type = DataRowHelper.GetDoubleValue(row, "assets_type");
                    if (assets_type == 0)
                    {
                        continue;
                    }
                    else
                    {
                        asset.AssetTypeId = (int)assets_type;
                    }

                    var assets_type_other = row.Field<string>("assets_type_other");
                    asset.AssetTypeTxt = assets_type_other;

                    var assets_qty = DataRowHelper.GetDoubleValue(row, "assets_qty");
                    asset.AssetQuantity = assets_qty;

                    var assets_cost = DataRowHelper.GetDoubleValue(row, "assets_cost");
                    asset.AssetsCost = assets_cost;

                    // var _parent_table_name = row.Field<string?>("_parent_table_name");

                    var _parent_index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    asset.SurveyId = (int)_parent_index;

                    asset.Id = 0;

                    await context.Set<Asset>().AddAsync(asset);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return Ok("done.");
        }

        [HttpGet("/ImmovableAssets")]
        public async Task<IActionResult> ImmovableAssets(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();
            var command = $"SELECT * From [hh_imm$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
                {
                    var immovableAsset = new ImmovableAsset();
                    immovableAsset.CreatedBy = 3;
                    immovableAsset.CreatedAt = DateTime.Now;
                    immovableAsset.IsActive = true;

                    var _index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    immovableAsset.Id = (int)_index;

                    var hh_imm_category = DataRowHelper.GetDoubleValue(row, "hh_imm_category");
                    if (hh_imm_category == 0)
                    {
                        continue;
                    }
                    else
                    {
                        immovableAsset.ImmovableAssetTypeId = (int)hh_imm_category;
                    }

                    var hh_imm_category_txt = row.Field<string>("hh_imm_category_txt");
                    immovableAsset.ImmovableAssetsTypeTxt = hh_imm_category_txt;

                    var hh_imm_ann = DataRowHelper.GetDoubleValue(row, "hh_imm_ann");
                    immovableAsset.ImmovableAnnualReturn = hh_imm_ann;

                    // var hh_imm_num = row.Field<string?>("hh_imm_num");
                    // var _parent_table_name = row.Field<string?>("_parent_table_name");

                    var _parent_index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    immovableAsset.SurveyId = (int)_parent_index;

                    immovableAsset.Id = 0;

                    await context.Set<ImmovableAsset>().AddAsync(immovableAsset);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return Ok("done.");
        }

        [HttpGet("/EnergyUse")]
        public async Task<IActionResult> EnergyUse(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();
            var command = $"SELECT * From [energy$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
                {
                    var energyUse = new EnergyUse();
                    energyUse.CreatedBy = 3;
                    energyUse.CreatedAt = DateTime.Now;
                    energyUse.IsActive = true;

                    var _index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    energyUse.Id = (int)_index;

                    var energy_use = DataRowHelper.GetDoubleValue(row, "energy_use");
                    if (energy_use == 0)
                    {
                        continue;
                    }
                    else
                    {
                        energyUse.EnergyTypeId = (int)energy_use;
                    }

                    var energy_use_txt = row.Field<string>("energy_use_txt");
                    energyUse.EnergyUseTypeTxt = energy_use_txt;

                    var monthly_energy = DataRowHelper.GetDoubleValue(row, "monthly_energy");
                    energyUse.EnergyUsesMonthly = monthly_energy;

                    var _parent_index = row.Field<double>("_submission__id");
                    energyUse.SurveyId = (int)_parent_index;

                    energyUse.Id = 0;

                    await context.Set<EnergyUse>().AddAsync(energyUse);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return Ok("done.");
        }

        [HttpGet("/ExistingSkills")]
        public async Task<IActionResult> ExistingSkills(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();
            var command = $"SELECT * From [ex_skills$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
                {
                    var existingSkill = new ExistingSkill();
                    existingSkill.CreatedBy = 3;
                    existingSkill.CreatedAt = DateTime.Now;
                    existingSkill.IsActive = true;

                    var _index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    existingSkill.Id = (int)_index;

                    var exi_skill_level = DataRowHelper.GetDoubleValue(row, "exi_skill_level");
                    if (exi_skill_level != 0)
                    {
                        existingSkill.SkillLevelEnum = (SkillLevel)(int)exi_skill_level;
                    }

                    var exi_skill = row.Field<string>("exi_skill");
                    existingSkill.SkillName = exi_skill;

                    var exi_remarks = row.Field<string>("exi_remarks");
                    existingSkill.Remarks = exi_remarks;

                    // var _parent_table_name = row.Field<string?>("_parent_table_name");

                    var _parent_index = DataRowHelper.GetIntValue(row, "_submission__id");
                    existingSkill.SurveyId = _parent_index;

                    existingSkill.Id = 0;

                    await context.Set<ExistingSkill>().AddAsync(existingSkill);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return Ok("done.");
        }

        [HttpGet("/GrossIncomeCosts")]
        public async Task<IActionResult> GrossIncomeCosts(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();
            var command = $"SELECT * From [income_cost$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
                {
                    var grossMargin = new GrossMarginIncomeAndCostStatus();
                    grossMargin.CreatedBy = 3;
                    grossMargin.CreatedAt = DateTime.Now;
                    grossMargin.IsActive = true;

                    var _index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    grossMargin.Id = (int)_index;

                    // var _Income_and_cost_sta_ = row.Field<string?>("_Income_and_cost_sta_");

                    var name_products = row.Field<string>("name_products");
                    grossMargin.ProductName = name_products;

                    var up = DataRowHelper.GetDoubleValue(row, "up");
                    grossMargin.LandArea = up;

                    var pro_measure = row.Field<string>("pro_measure");
                    grossMargin.MeasurementOfProduct = pro_measure;

                    var tp = DataRowHelper.GetDoubleValue(row, "tp");
                    grossMargin.TotalProductionHousehold = tp;

                    var ic = DataRowHelper.GetDoubleValue(row, "ic");
                    grossMargin.TotalCostOfProduction = ic;

                    var qt_cons = DataRowHelper.GetDoubleValue(row, "qt_cons");
                    grossMargin.TotalConsumption = qt_cons;

                    var qs = DataRowHelper.GetDoubleValue(row, "qs");
                    grossMargin.QuantitySold = qs;

                    var vs = DataRowHelper.GetDoubleValue(row, "vs");
                    grossMargin.TotalValueSold = vs;

                    var vs_qs_type = row.Table.Columns["vs_qs"]?.DataType;
                    if (vs_qs_type is null)
                    {
                        grossMargin.ValueSoldPerQuantity = 0;
                    }
                    else if (vs_qs_type == typeof(double))
                    {
                        grossMargin.ValueSoldPerQuantity = DataRowHelper.GetDoubleValue(row, "vs_qs");
                    }
                    else if (vs_qs_type == typeof(string))
                    {
                        var vs_qs1 = row.Field<string>("vs_qs");

                        if (vs_qs1 != "NaN" && vs_qs1 != "Infinity")
                        {
                            if (double.TryParse(vs_qs1, out var vs_qs))
                                grossMargin.ValueSoldPerQuantity = vs_qs;
                            else
                                grossMargin.ValueSoldPerQuantity = 0;
                        }
                    }

                    var tp_vsqs_type = row.Table.Columns["tp_vsqs"]?.DataType;
                    if (tp_vsqs_type is null)
                    {
                        grossMargin.ProductionValueSoldPerQuantity = 0;
                    }
                    else if (tp_vsqs_type == typeof(double))
                    {
                        grossMargin.ProductionValueSoldPerQuantity = DataRowHelper.GetDoubleValue(row, "tp_vsqs");
                    }
                    else if (tp_vsqs_type == typeof(string))
                    {
                        var tp_vsqs1 = row.Field<string>("tp_vsqs");

                        if (tp_vsqs1 != "NaN" && tp_vsqs1 != "Infinity")
                        {
                            if (double.TryParse(tp_vsqs1, out var tp_vsqs))
                                grossMargin.ProductionValueSoldPerQuantity = tp_vsqs;
                            else
                                grossMargin.ProductionValueSoldPerQuantity = 0;
                        }
                    }

                    var income_type = row.Table.Columns["income"]?.DataType;
                    if (income_type is null)
                    {
                        grossMargin.TotalNetIncome = 0;
                    }
                    else if (income_type == typeof(double))
                    {
                        grossMargin.TotalNetIncome = DataRowHelper.GetDoubleValue(row, "income");
                    }
                    else if (income_type == typeof(string))
                    {
                        var income1 = row.Field<string>("income");

                        if (income1 != "NaN" && income1 != "Infinity")
                        {
                            if (double.TryParse(income1, out var income))
                                grossMargin.TotalNetIncome = income;
                            else
                                grossMargin.TotalNetIncome = 0;
                        }
                    }

                    var _parent_index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    grossMargin.SurveyId = (int)_parent_index;

                    grossMargin.Id = 0;

                    await context.Set<GrossMarginIncomeAndCostStatus>().AddAsync(grossMargin);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return Ok("done.");
        }

        [HttpGet("/ManualPhysicalWork")]
        public async Task<IActionResult> ManualPhysicalWork(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();
            var command = $"SELECT * From [manu_phy_work$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
                {
                    var physicalWork = new ManualPhysicalWork();
                    physicalWork.CreatedBy = 3;
                    physicalWork.CreatedAt = DateTime.Now;
                    physicalWork.IsActive = true;

                    var _index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    physicalWork.Id = (int)_index;

                    var income_source = DataRowHelper.GetDoubleValue(row, "income_source");
                    if (income_source != 0)
                    {
                        physicalWork.ManualIncomeSourceTypeId = (int)income_source;
                    }

                    var income_source_txt = row.Field<string>("income_source_txt");
                    physicalWork.ManualIncomeSourceTypeTxt = income_source_txt;

                    var no_male = DataRowHelper.GetDoubleValue(row, "no_male");
                    physicalWork.NoOfMale = no_male == 0 ? 0 : (int)no_male;

                    var no_female = DataRowHelper.GetDoubleValue(row, "no_female");
                    physicalWork.NoOfFemale = no_female == 0 ? 0 : (int)no_female;

                    var month_active = DataRowHelper.GetDoubleValue(row, "month_active");
                    physicalWork.NoOfActiveMonth = month_active == 0 ? 0 : (int)month_active;

                    var avg_pers = DataRowHelper.GetDoubleValue(row, "avg_pers");
                    physicalWork.AvgNoPersonActivePerMonth = avg_pers == 0 ? 0 : (int)avg_pers;

                    var avg_income = DataRowHelper.GetDoubleValue(row, "avg_income");
                    physicalWork.AvgDailyIncome = avg_income;

                    var total_per = DataRowHelper.GetDoubleValue(row, "total_per");
                    physicalWork.TotalPerson = total_per;

                    //var pers_day = row.Field<string?>("pers_day");

                    var ann_in = DataRowHelper.GetDoubleValue(row, "ann_in");
                    physicalWork.TotalAnnualIncome = ann_in;

                    var annual_income = row.Field<string>("annual_income");
                    var _parent_table_name = row.Field<string>("_parent_table_name");
                    var _parent_index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                    physicalWork.SurveyId = (int)_parent_index;

                    physicalWork.Id = 0;

                    await context.Set<ManualPhysicalWork>().AddAsync(physicalWork);

                    Console.Write("hello");
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return Ok("done.");
        }

        [HttpGet("/NaturalIncomeCost")]
        public async Task<IActionResult> NaturalIncomeCost(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();
            var command = $"SELECT * From [st_in_co$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
                {
                    var natural = new NaturalResourcesIncomeAndCostStatus();
                    natural.CreatedBy = 3;
                    natural.CreatedAt = DateTime.Now;
                    natural.IsActive = true;

                    var _index = row.Field<double>("_submission__id");
                    natural.Id = (int)_index;

                    var st_act = DataRowHelper.GetDoubleValue(row, "st_act");
                    if (st_act != 0)
                    {
                        natural.NaturalIncomeSourceTypeId = (int)st_act;
                    }

                    var st_male = DataRowHelper.GetDoubleValue(row, "st_male");
                    natural.NoOfMale = st_male == 0 ? 0 : (int)st_male;

                    var st_female = DataRowHelper.GetDoubleValue(row, "st_female");
                    natural.NoOfFemale = st_female == 0 ? 0 : (int)st_female;

                    var st_act_mont = DataRowHelper.GetDoubleValue(row, "st_act_mont");
                    natural.NoOfActiveMonth = st_act_mont == 0 ? 0 : (int)st_act_mont;

                    var st_avg_pers = DataRowHelper.GetDoubleValue(row, "st_avg_pers");
                    natural.AvgNoPersonActivePerMonth = st_avg_pers;

                    var st_f = DataRowHelper.GetDoubleValue(row, "st_f");
                    natural.TotalManDaysForCollection = st_f;

                    // var st_total_collec = row.Field<string?>("st_total_collec");

                    var st_unit = row.Field<string>("st_unit");
                    natural.Unit = st_unit;

                    var st_tp = DataRowHelper.GetDoubleValue(row, "st_tp");
                    natural.TotalProduced = st_tp;

                    var st_t_con = DataRowHelper.GetDoubleValue(row, "st_t_con");
                    natural.TotalConsumption = st_t_con;

                    var st_qs = DataRowHelper.GetDoubleValue(row, "st_qs");
                    natural.QuantitySold = st_qs;

                    var st_vs = DataRowHelper.GetDoubleValue(row, "st_vs");
                    natural.ValueProduceSold = st_vs;

                    var st_ic = DataRowHelper.GetDoubleValue(row, "st_ic");
                    natural.CostOfActivity = st_ic;

                    var st_vs_qs = DataRowHelper.GetDoubleValue(row, "st_vs_qs");
                    natural.ValueSoldPerActivity = st_vs_qs;

                    var st_tp_vsqs = DataRowHelper.GetDoubleValue(row, "st_tp_vsqs");
                    natural.ProducedValueSoldActivity = st_tp_vsqs;

                    var st_ic_vsqs = DataRowHelper.GetDoubleValue(row, "st_ic_vsqs");
                    natural.ActivityPerValueSold = st_ic_vsqs;

                    var st_income = DataRowHelper.GetDoubleValue(row, "st_income");
                    natural.TotalNetIncome = st_income;

                    // var st_net_income = row.Field<string?>("st_net_income");
                    // var _parent_table_name = row.Field<string?>("_parent_table_name");

                    var _parent_index = row.Field<double>("_submission__id");
                    natural.SurveyId = (int)_parent_index;

                    natural.Id = 0;

                    await context.Set<NaturalResourcesIncomeAndCostStatus>().AddAsync(natural);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return Ok("done.");
        }

        [HttpGet("other-income")]
        public async Task<IActionResult> OtherIncome(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();

            var command = $"SELECT * From [oth_income$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            // Save to SQL SERVER
            var transaction = await context.Database.BeginTransactionAsync();
            var otherIncomeList = new List<OtherIncomeSource>();
            foreach (var row in dt.Rows.Cast<DataRow>())
            {
                var otherIncome = new OtherIncomeSource();
                otherIncome.CreatedAt = DateTime.Now;
                otherIncome.CreatedBy = 3;
                otherIncome.IsActive = true;

                var _index = row.Field<double>("_submission__id");
                otherIncome.Id = (int)_index;

                var other_source_income = DataRowHelper.GetDoubleValue(row, "other_source_income");
                if (other_source_income != 0)
                {
                    otherIncome.OtherIncomeSourceTypeId = (int)other_source_income;
                }

                var other_source_income_txt = row.Field<string>("other_source_income_txt");
                otherIncome.OtherIncomeSourceTypeTxt = other_source_income_txt;

                var other_gross = DataRowHelper.GetDoubleValue(row, "other_gross");
                otherIncome.GrossValueOfSales = other_gross;

                var other_total_cash = DataRowHelper.GetDoubleValue(row, "other_total_cash");
                otherIncome.TotalCashCosts = other_total_cash;

                var n_in = DataRowHelper.GetDoubleValue(row, "n_in");
                otherIncome.TotalNetIncome = n_in;

                // ot_n_income

                var _parent_index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                otherIncome.SurveyId = (int)_parent_index;

                otherIncome.Id = 0;

                otherIncomeList.Add(otherIncome);
            }
            await context.Set<OtherIncomeSource>().AddRangeAsync(otherIncomeList);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok("Completed");
        }

        [HttpPost("business-income")]
        public async Task<IActionResult> BusinessIncome(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();

            var command = $"SELECT * From [bu_income$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            // Save to SQL SERVER
            var transaction = await context.Database.BeginTransactionAsync();
            var businessList = new List<Common.Entity.Beneficiary.Business>();
            foreach (var row in dt.Rows.Cast<DataRow>())
            {
                var business = new Common.Entity.Beneficiary.Business();
                business.CreatedAt = DateTime.Now;
                business.CreatedBy = 3;
                business.IsActive = true;

                var _index = row.Field<double>("_submission__id");
                business.Id = (int)_index;

                var bu_source_income = DataRowHelper.GetDoubleValue(row, "bu_source_income");
                if (bu_source_income != 0)
                {
                    business.BusinessIncomeSourceTypeId = (long)bu_source_income;
                }

                var bu_source_income_txt = row.Field<string>("bu_source_income_txt");
                business.BusinessIncomeSourceTypeTxt = bu_source_income_txt;

                var bu_gross = DataRowHelper.GetDoubleValue(row, "bu_gross");
                business.BusinessGrossValueOfSales = bu_gross;

                var bu_total_cash = DataRowHelper.GetDoubleValue(row, "bu_total_cash");
                business.BusinessTotalCashCosts = bu_total_cash;

                var bu_n_in = DataRowHelper.GetDoubleValue(row, "bu_n_in");
                business.TotalNetIncome = bu_n_in;

                var _parent_index = row.Field<double>("_submission__id");
                business.SurveyId = (int)_parent_index;

                business.Id = 0;

                businessList.Add(business);
            }
            await context.Set<Common.Entity.Beneficiary.Business>().AddRangeAsync(businessList);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok("Completed");
        }

        [HttpPost("household-expenditure")]
        public async Task<IActionResult> AnnualHouseHoldExpenditure(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();

            var command = $"SELECT * From [ann_ex_hh$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            // Save to SQL SERVER
            var transaction = await context.Database.BeginTransactionAsync();
            var expenditureList = new List<AnnualHouseholdExpenditure>();
            foreach (var row in dt.Rows.Cast<DataRow>())
            {
                var expenditure = new AnnualHouseholdExpenditure();
                expenditure.CreatedAt = DateTime.Now;
                expenditure.CreatedBy = 3;
                expenditure.IsActive = true;

                var _index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                expenditure.Id = (int)_index;

                var m_ex_iteam = DataRowHelper.GetDoubleValue(row, "m_ex_iteam");
                if (m_ex_iteam != 0)
                {
                    expenditure.ExpenditureTypeId = (int)m_ex_iteam;
                }

                var m_ex_iteam_txt = row.Field<string>("m_ex_iteam_txt");
                expenditure.ExpenditureTypeTxt = m_ex_iteam_txt;

                var ex_bdt = DataRowHelper.GetDoubleValue(row, "ex_bdt");
                expenditure.ExpenditureCost = ex_bdt;

                var rem = row.Field<string>("rem");
                expenditure.ExpenditureRemarks = rem;

                var _parent_index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                expenditure.SurveyId = (int)_parent_index;

                expenditure.Id = 0;

                expenditureList.Add(expenditure);
            }
            await context.Set<AnnualHouseholdExpenditure>().AddRangeAsync(expenditureList);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok("Completed");
        }

        [HttpPost("food-security")]
        public async Task<IActionResult> FoodSecurity(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();

            var command = $"SELECT * From [food_sec2$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            // Save to SQL SERVER
            var transaction = await context.Database.BeginTransactionAsync();
            var foodSecurityList = new List<FoodSecurityItem>();
            foreach (var row in dt.Rows.Cast<DataRow>())
            {
                var food = new FoodSecurityItem();
                food.CreatedAt = DateTime.Now;
                food.CreatedBy = 3;
                food.IsActive = true;


                var _index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                food.Id = (int)_index;

                var sec_food_it = DataRowHelper.GetDoubleValue(row, "sec_food_it");
                if (sec_food_it != 0)
                {
                    food.FoodItemId = (int)sec_food_it;
                }

                var sec_food_it_txt = row.Field<string>("sec_food_it_txt");
                food.FoodItemTxt = sec_food_it_txt;

                var sec_avail = DataRowHelper.GetDoubleValue(row, "sec_avail");
                food.FoodAvilableMonthInYear = sec_avail == 0 ? 0 : (int)sec_avail;

                var sec_rema = row.Field<string>("sec_rema");
                food.Remarks = sec_rema;

                var _parent_index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                food.SurveyId = (int)_parent_index;

                food.Id = 0;

                foodSecurityList.Add(food);
            }
            await context.Set<FoodSecurityItem>().AddRangeAsync(foodSecurityList);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok("Completed");
        }

        [HttpPost("vulnerability")]
        public async Task<IActionResult> Vulnerability(string filePath)
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();

            var command = $"SELECT * From [vul_sit$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            // Save to SQL SERVER
            var transaction = await context.Database.BeginTransactionAsync();
            var vulnerabilityList = new List<VulnerabilitySituation>();
            foreach (var row in dt.Rows.Cast<DataRow>())
            {
                var vul = new VulnerabilitySituation();
                vul.CreatedAt = DateTime.Now;
                vul.CreatedBy = 3;
                vul.IsActive = true;

                var _index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                vul.Id = (int)_index;

                var vul_situations = DataRowHelper.GetDoubleValue(row, "vul_situations");
                if (vul_situations != 0)
                {
                    vul.VulnerabilitySituationTypeId = (int)vul_situations;
                }

                var vul_situations_txt = row.Field<string>("vul_situations_txt");
                vul.VulnerabilitySituationTypeTxt = vul_situations_txt;

                var vul_event = row.Field<string>("vul_event");
                vul.EventName = vul_event;

                var vul_monetary = DataRowHelper.GetDoubleValue(row, "vul_monetary");
                vul.MonetaryLoss = vul_monetary;

                var vul_reco = row.Field<string>("vul_reco");
                vul.HowDidRecover = vul_reco;

                var vul_remarks = row.Field<string>("vul_remarks");
                vul.Remarks = vul_remarks;

                var _parent_index = DataRowHelper.GetDoubleValue(row, "_submission__id");
                vul.SurveyId = (int)_parent_index;

                vul.Id = 0;

                vulnerabilityList.Add(vul);
            }
            await context.Set<VulnerabilitySituation>().AddRangeAsync(vulnerabilityList);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok("Completed");
        }

        [HttpPost("union")]
        public async Task<IActionResult> Union()
        {
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={SURVEY_FilePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();

            var command = $"SELECT * From [surveys$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            // Save to SQL SERVER
            var transaction = await context.Database.BeginTransactionAsync();
            var unionList = new List<Union>();
            foreach (var row in dt.Rows.Cast<DataRow>())
            {
                var vul = new Union();
                vul.CreatedAt = DateTime.Now;
                vul.CreatedBy = 3;
                vul.IsActive = true;

                var _index = row.Field<double>("_index");
                vul.Id = (int)_index;

                unionList.Add(vul);
            }
            await context.Set<Union>().AddRangeAsync(unionList);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok("Completed");
        }

        [HttpGet("/departmental-training")]
        [AllowAnonymous]
        public async Task<IActionResult> DepartmentalTraining()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var filePath = @"D:\sufl_assets\training_data\dept-training.xlsx";
            using var stream = System.IO.File.OpenRead(filePath);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            var excelConiguration = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true,
                    FilterRow = (rowReader) =>
                    {
                        if (rowReader.IsDBNull(0)) return false;
                        return true;
                    },
                }
            };
            var dataSet = reader.AsDataSet(excelConiguration);

            //var trainingSheet = dataSet.Tables["training"];
            var trainingMemberSheet = dataSet.Tables["Sheet4"];

            var trainingList = new List<DepartmentalTraining>();

            foreach (var row in trainingMemberSheet.Rows.Cast<DataRow>().Skip(0))
            {
                var departmentalTraining = new DepartmentalTraining();
                departmentalTraining.CreatedBy = 3;
                departmentalTraining.CreatedAt = DateTime.Now;
                departmentalTraining.IsActive = true;
                departmentalTraining.EventTypeId = 2;
                departmentalTraining.TrainingOrganizerId = 2;

                var financialYear = row.Field<string>("FY");
                if (string.IsNullOrEmpty(financialYear)) throw new Exception("Financial year is invalid");

                var financialYearTrimmed = financialYear.Replace("FY", "").Trim();
                var financialYearId = context.Set<FinancialYear>().Where(x => x.Name.Contains(financialYearTrimmed)).FirstOrDefault();

                if (financialYearId is null) throw new Exception("Financial year is not found");
                departmentalTraining.FinancialYearId = financialYearId.Id;

                var startDate = row.Field<DateTime?>("Start Date");
                departmentalTraining.StartDate = startDate ?? DateTime.Now;

                var endDate = row.Field<DateTime?>("End Date");
                departmentalTraining.EndDate = endDate ?? DateTime.Now;

                var title = row.Field<string>("Name of the Event");
                departmentalTraining.TrainingTitle = string.IsNullOrEmpty(title) ? string.Empty : title.Trim();

                var location = row.Field<string>("Venue");
                departmentalTraining.Location = string.IsNullOrEmpty(location) ? string.Empty : location.Trim();

                trainingList.Add(departmentalTraining);
            }

            trainingList = trainingList.GroupBy(x => x.TrainingTitle).Select(x => x.First()).ToList();

            foreach (var row in trainingMemberSheet.Rows.Cast<DataRow>().Skip(0))
            {
                var member = new DepartmentalTrainingMember();
                member.CreatedBy = 3;
                member.CreatedAt = DateTime.Now;
                member.IsActive = true;

                var title = row.Field<string>("Name of the Event");
                if (string.IsNullOrEmpty(title))
                    continue;
                title = title.Trim();

                var training = trainingList.FirstOrDefault(x => x.TrainingTitle == title);
                if (training is null)
                    continue;

                // Department member
                var memberName = row.Field<string>("Name");
                member.MemberName = string.IsNullOrEmpty(memberName) ? string.Empty : memberName.Trim();

                var memberGender = row.Field<string>("Sex (M/F)");
                if (string.IsNullOrEmpty(memberGender))
                {
                    member.MemberGender = Gender.Male;
                }
                else
                {
                    if (memberGender.Trim() == "Male")
                        member.MemberGender = Gender.Male;
                    else
                        member.MemberGender = Gender.Female;
                }

                var memberEthnicity = row.Field<string>("Ethnicity ");
                if (string.IsNullOrEmpty(memberEthnicity) == false)
                {
                    var e = context.Set<Ethnicity>().Where(x => x.Name.Contains(memberEthnicity)).FirstOrDefault();
                    if (e is not null)
                    {
                        member.EthnicityId = e.Id;
                    }
                }

                var memberDesignation = row.Field<string>("Designation ");
                member.MemberDesignation = string.IsNullOrEmpty(memberDesignation) ? string.Empty : memberDesignation.Trim();

                var memberAddress = row.Field<string>("Address");
                member.MemberAddress = string.IsNullOrEmpty(memberAddress) ? string.Empty : memberAddress.Trim();

                var memberPhoneNumberType = row.Table.Columns["Cell No."]?.DataType;
                if (memberPhoneNumberType == typeof(double))
                {
                    var memberPhoneNumber = row.Field<double>("Cell No.");
                    member.MemberPhoneNumber = memberPhoneNumber.ToString();
                }
                else if (memberPhoneNumberType == typeof(string))
                {
                    var memberPhoneNumber = row.Field<string>("Cell No.");
                    member.MemberPhoneNumber = string.IsNullOrEmpty(memberPhoneNumber) ? string.Empty : memberPhoneNumber.Trim();
                }

                var memberEmail = row.Field<string>("Email");
                member.MemberEmail = string.IsNullOrEmpty(memberEmail) ? string.Empty : memberEmail.Trim();

                var nationalID = row.Field<string>("National ID  ");
                member.MemberNID = string.IsNullOrEmpty(nationalID) ? string.Empty : nationalID.Trim();

                training.DepartmentalTrainingParticipentsMaps = training.DepartmentalTrainingParticipentsMaps ?? new List<DepartmentalTrainingParticipentsMap>();
                training.DepartmentalTrainingParticipentsMaps.Add(new DepartmentalTrainingParticipentsMap
                {
                    DepartmentalTrainingMember = member,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 3,
                });
            }

            using var transaction = context.Database.BeginTransaction();
            await context.Set<DepartmentalTraining>().AddRangeAsync(trainingList);
            await context.SaveChangesAsync();
            transaction.Commit();

            /*
            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";
            var command = $"SELECT * From [training$]";
            DataTable dt = new DataTable();

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            var trainingList = new List<DepartmentalTraining>();
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
                {
                    var departmentalTraining = new DepartmentalTraining();
                    departmentalTraining.CreatedBy = 3;
                    departmentalTraining.CreatedAt = DateTime.Now;
                    departmentalTraining.IsActive = true;

                    var startDate = row.Field<DateTime?>("StartDate");
                    departmentalTraining.StartDate = startDate ?? DateTime.Now;

                    var endDate = row.Field<DateTime?>("EndDate");
                    departmentalTraining.EndDate = endDate ?? DateTime.Now;

                    var title = row.Field<string>("TrainingTitle");
                    departmentalTraining.TrainingTitle = string.IsNullOrEmpty(title) ? string.Empty : title;

                    var location = row.Field<string>("Location");
                    departmentalTraining.Location = string.IsNullOrEmpty(location) ? string.Empty : location;

                    trainingList.Add(departmentalTraining);
                    //await context.Set<DepartmentalTraining>().AddAsync(departmentalTraining);
                }

                //await context.SaveChangesAsync();
                //await transaction.CommitAsync();
            }
            */

            return Ok("Done");
        }
        [HttpGet("/departmental-training-update")]
        [AllowAnonymous]
        public async Task<IActionResult> DepartmentalTrainingUpdate()
        {
            var readOnlyContext = _readOnlyCtx.Set<DepartmentalTraining>();
            var writeOnlyContext = context.Set<DepartmentalTraining>();

            var trainings = await readOnlyContext.Include(x => x.DepartmentalTrainingParticipentsMaps).ThenInclude(x => x.DepartmentalTrainingMember).ToListAsync();

            foreach (var entity in trainings)
            {
                var total = entity.DepartmentalTrainingParticipentsMaps?.Count ?? 0;
                var totalMale = entity.DepartmentalTrainingParticipentsMaps?.Where(x => x.DepartmentalTrainingMember?.MemberGender == Gender.Male).Count() ?? 0;
                var totalFemale = entity.DepartmentalTrainingParticipentsMaps?.Where(x => x.DepartmentalTrainingMember?.MemberGender == Gender.Female).Count() ?? 0;

                entity.TotalFemale = totalFemale;
                entity.TotalMale = totalMale;
                entity.TotalMembers = total;
            }

            writeOnlyContext.UpdateRange(trainings);
            await context.SaveChangesAsync();

            return Ok("Done");
            //
        }
    }
}

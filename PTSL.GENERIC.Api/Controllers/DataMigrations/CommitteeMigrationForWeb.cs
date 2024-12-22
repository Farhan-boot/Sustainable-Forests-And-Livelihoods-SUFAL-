using System.Data;
using System.Data.OleDb;
using System.Net;
using System.Security.Cryptography;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

/*
public class CommitteeMigrationForWeb : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public CommitteeMigrationForWeb(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("committee-data-migration-web/{shouldMigrate}")]
    public async Task<IActionResult> Migrate([FromRoute] bool shouldMigrate, IFormFile excelFile)
    {
        try
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await excelFile.CopyToAsync(stream);
            }

            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            var dt = new DataTable();

            var command = $"SELECT * From [Committee$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using var sqlCommand = new OleDbCommand(command, connection);
                await connection.OpenAsync();

                using var adapter = new OleDbDataAdapter(sqlCommand);
                adapter.Fill(dt);

                await connection.CloseAsync();
            }

            // Save to SQL SERVER
            var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();
            var committeeManagementList = new List<CommitteeManagement>();
            var skippedList = new List<ValueTuple<double, string, string>>();
            var defaultDesignationId = 0;

            //var groupData = dt.Rows.Cast<DataRow>().Skip(0).GroupBy(x => x.ItemArray[0]);

            var CommitteeMigrationExcelDataList = new List<CommitteeMigrationExcelDataVM>();


            foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
            {
                var checkId = DataRowHelper.GetLongValue(row, "Sl");
                if (checkId > 0)
                {
                    var CommitteeMigrationExcelData = new CommitteeMigrationExcelDataVM();
                    var sl = DataRowHelper.GetDoubleValue(row, "Sl");
                    var forest_circle = DataRowHelper.GetStringValue(row, "ForestCircle");
                    var forest_division = DataRowHelper.GetStringValue(row, "ForestDivision");
                    var forest_range = DataRowHelper.GetStringValue(row, "ForestRange");
                    var forest_beat = DataRowHelper.GetStringValue(row, "ForestBeat");
                    var fcv_vcf = DataRowHelper.GetStringValue(row, "ForestFCV/VCF");
                    var civil_division = row.Field<string>("Division")?.Trim();
                    var civil_district = row.Field<string>("District")?.Trim();
                    var upazilla = row.Field<string>("Upazilla")?.Trim();
                    var union = row.Field<string>("Union")?.Trim();
                    //Other
                    var ngo = row.Field<string>("Ngo")?.Trim();
                    var name = row.Field<string>("Name")?.Trim();
                    var committee_type = row.Field<string>("CommitteeType")?.Trim();
                    var committee_name = row.Field<string>("CommitteeName")?.Trim();
                    var designation = row.Field<string>("Designation")?.Trim();
                    var members_type = row.Field<string>("MembersType")?.Trim();
                    var nid = row.Field<string>("NID")?.Trim();
                    var beneficiary_ID = row.Field<string>("BeneficiaryID")?.Trim();
                    var FatherOrSpouseName = row.Field<string>("FatherOrSpouseName")?.Trim();
                    var gender = row.Field<string>("Gender")?.Trim();
                    var ethnicity = row.Field<string>("Ethnicity")?.Trim();
                    var phone_number = row.Field<string>("PhoneNumber")?.Trim();
                    var address = row.Field<string>("Address")?.Trim();
                    var bank_Ac_No = row.Field<string>("BankAcNo")?.Trim();
                    var ac_name = row.Field<string>("AcName")?.Trim();
                    var ac_type = row.Field<string>("AcType")?.Trim();
                    var bank_name = row.Field<string>("BankName")?.Trim();
                    var branch_name = row.Field<string>("BranchName")?.Trim();
                    var ac_opening_date = (row.Field<string?>("AcOpeningDate"));
                    var remark = row.Field<string>("Remark")?.Trim();
                    //var address = row.Field<string>("Address")?.Trim();
                    //var phone_number = row.Field<string>("PhoneNumber")?.Trim();

                    //fill object
                    CommitteeMigrationExcelData.SL = Convert.ToString(sl);
                    CommitteeMigrationExcelData.ForestCircle = Convert.ToString(forest_circle);
                    CommitteeMigrationExcelData.ForestDivision = Convert.ToString(forest_division);
                    CommitteeMigrationExcelData.ForestRange = Convert.ToString(forest_range);
                    CommitteeMigrationExcelData.ForestBeat = Convert.ToString(forest_beat);
                    CommitteeMigrationExcelData.ForestFcvVcf = Convert.ToString(fcv_vcf);

                    CommitteeMigrationExcelData.Division = Convert.ToString(civil_division);
                    CommitteeMigrationExcelData.District = Convert.ToString(civil_district);
                    CommitteeMigrationExcelData.Upazilla = Convert.ToString(upazilla);
                    CommitteeMigrationExcelData.Union = Convert.ToString(union);

                    CommitteeMigrationExcelData.Ngo = Convert.ToString(ngo);
                    CommitteeMigrationExcelData.Name = Convert.ToString(name);
                    CommitteeMigrationExcelData.CommitteeType = Convert.ToString(committee_type);
                    CommitteeMigrationExcelData.CommitteeName = Convert.ToString(committee_name);
                    CommitteeMigrationExcelData.Designation = Convert.ToString(designation);
                    CommitteeMigrationExcelData.MembersType = Convert.ToString(members_type);
                    CommitteeMigrationExcelData.NID = Convert.ToString(nid);
                    CommitteeMigrationExcelData.BeneficiaryID = Convert.ToString(beneficiary_ID);
                    CommitteeMigrationExcelData.FatherSpouseName = Convert.ToString(FatherOrSpouseName);
                    CommitteeMigrationExcelData.Gender = Convert.ToString(gender);
                    CommitteeMigrationExcelData.Ethnicity = Convert.ToString(ethnicity);
                    CommitteeMigrationExcelData.BankAcNO = Convert.ToString(bank_Ac_No);
                    CommitteeMigrationExcelData.AcName = Convert.ToString(ac_name);
                    CommitteeMigrationExcelData.AcType = Convert.ToString(ac_type);
                    CommitteeMigrationExcelData.BankName = Convert.ToString(bank_name);
                    CommitteeMigrationExcelData.BranchName = Convert.ToString(branch_name);

                    if (!string.IsNullOrEmpty(ac_opening_date.ToString()))
                    {
                        CommitteeMigrationExcelData.AcOpeningDate = Convert.ToString(ac_opening_date);
                    }
                    else
                    {
                        CommitteeMigrationExcelData.AcOpeningDate = DateTime.Now.ToString();
                    }

                    CommitteeMigrationExcelData.Remark = Convert.ToString(remark);
                    CommitteeMigrationExcelData.Address = Convert.ToString(address);
                    CommitteeMigrationExcelData.PhoneNumber = Convert.ToString(phone_number);

                    //if (!string.IsNullOrEmpty(CommitteeMigrationExcelData.AcOpeningDate))
                    //{
                        CommitteeMigrationExcelDataList.Add(CommitteeMigrationExcelData);
                    //} 
                }
            }

            IEnumerable<IGrouping<string?, CommitteeMigrationExcelDataVM>> testData = CommitteeMigrationExcelDataList.GroupBy(x => x.SL);
            List<IGrouping<string?, CommitteeMigrationExcelDataVM>> allData = new List<IGrouping<string?, CommitteeMigrationExcelDataVM>>();
            foreach (var item in testData)
            {
                allData.Add(item);

                var cm = new CommitteeManagement();
                cm.CreatedAt = DateTime.Now;
                cm.CreatedBy = 3;
                cm.IsActive = true;

                long? forestCircleLongId = 0;
                long? forestDivisionLongId = 0;
                long? forestRangeLongId = 0;
                long? forestBeatLongId = 0;
                long? forestFcvVcfLongId = 0;

                long civilDivisionLongId = 0;
                long civilDistrictLongId = 0;
                long civilUpazillaLongId = 0;
                long? civilUnionLongId = 0;


                if (string.IsNullOrEmpty(item.FirstOrDefault().ForestFcvVcf) == false)
                {
                  
                    var survey = _writeOnlyCtx.Set<Survey>().Where(x => x.BeneficiaryId == item.FirstOrDefault().BeneficiaryID).FirstOrDefault();
               
                    if (survey != null)
                    {
                        //Forest Info
                        cm.ForestCircleId = survey.ForestCircleId == 0 ? null : survey.ForestCircleId;
                        cm.ForestDivisionId = survey.ForestDivisionId == 0 ? null : survey.ForestDivisionId;
                        cm.ForestRangeId = survey.ForestRangeId == 0 ? null : survey.ForestRangeId;
                        cm.ForestBeatId = survey.ForestBeatId == 0 ? null : survey.ForestBeatId;
                        cm.ForestFcvVcfId = survey.ForestFcvVcfId == 0 ? null : survey.ForestFcvVcfId;

                        forestCircleLongId = cm.ForestCircleId == 0 ? null : cm.ForestCircleId;
                        forestDivisionLongId = cm.ForestDivisionId == 0 ? null : cm.ForestDivisionId;
                        forestRangeLongId = cm.ForestRangeId == 0 ? null : cm.ForestRangeId;
                        forestBeatLongId = cm.ForestBeatId == 0 ? null : cm.ForestBeatId;
                        forestFcvVcfLongId = cm.ForestFcvVcfId == 0 ? null : cm.ForestFcvVcfId;



                        //Civil Info
                        cm.DivisionId = survey.PresentDivisionId == 0 ? null : survey.PresentDivisionId;
                        cm.DistrictId = survey.PresentDistrictId == 0 ? null : survey.PresentDistrictId;
                        cm.UpazillaId = survey.PresentUpazillaId == 0 ? null : survey.PresentUpazillaId;
                        cm.UnionId = survey.PresentUnionNewId ?? 0;
                        //civilUnionLongId = survey.FirstOrDefault().PresentUnionNewId;


                         civilDivisionLongId = survey.PresentDivisionId;
                         civilDistrictLongId = survey.PresentDistrictId;
                         civilUpazillaLongId = survey.PresentUpazillaId;
                         civilUnionLongId = cm.UnionId == 0 ? null : cm.UnionId;




                        //cm.CommitteeManagementMembers.Add(new CommitteeManagementMember
                        //{
                        //    CommitteeDesignationsConfigurationId =0, // _designationId,
                        //    SurveyId = survey.FirstOrDefault().Id,
                        //});

                    }
                    else
                    {

                    }
                }


               

                //if (string.IsNullOrEmpty(item.FirstOrDefault().Union) == false)
                //{
                //    var civil_div = await _writeOnlyCtx.Set<Division>()
                //        .FromSqlRaw($"select * from \"GS\".\"Division\" e where e.\"DivisionName\" ilike '%{item.FirstOrDefault().Division}%'")
                //        .FirstOrDefaultAsync();
                //    if (civil_div is null)
                //    {
                //        skippedList.Add((Convert.ToInt16(item.FirstOrDefault().SL), item.FirstOrDefault().Division, $"Division '{item.FirstOrDefault().Division}' is not found in DB"));
                //        continue;
                //    }
                //    civilDivisionLongId = civil_div.Id;

                //    var civil_dis = await _writeOnlyCtx.Set<District>()
                //        .FromSqlRaw($"select * from \"GS\".\"District\" e where e.\"Name\" ilike '%{item.FirstOrDefault().District.Replace("'", "''")}%'")
                //        .FirstOrDefaultAsync();
                //    if (civil_dis is null)
                //    {
                //        skippedList.Add((Convert.ToDouble(item.FirstOrDefault().SL), item.FirstOrDefault().District, $"District '{item.FirstOrDefault().District}' is not found in DB"));
                //        continue;
                //    }
                //    civilDistrictLongId = civil_dis.Id;

                //    var civil_upazilla = await _writeOnlyCtx.Set<Upazilla>()
                //        .FromSqlRaw($"select * from \"GS\".\"Upazilla\" e where e.\"Name\" ilike '%{item.FirstOrDefault().Upazilla}%'")
                //        .FirstOrDefaultAsync();
                //    if (civil_upazilla is null)
                //    {
                //        skippedList.Add((Convert.ToDouble(item.FirstOrDefault().SL), item.FirstOrDefault().Upazilla, $"Upazilla '{item.FirstOrDefault().Upazilla}' is not found in DB"));
                //        continue;
                //    }
                //    civilUpazillaLongId = civil_upazilla.Id;

                //    var civil_union = await _writeOnlyCtx.Set<Union>()
                //        .FromSqlRaw($"select * from \"GS\".\"Union\" e where e.\"Name\" ilike '%{item.FirstOrDefault().Union}%'")
                //        .FirstOrDefaultAsync();

                //    if (civil_union is null)
                //    {
                //        skippedList.Add((Convert.ToDouble(item.FirstOrDefault().SL), item.FirstOrDefault().Union, $"Union '{item.FirstOrDefault().Union}' is not found in DB"));
                //        continue;
                //    }
                //    civilUnionLongId = civil_union.Id;


                //    cm.DivisionId = civil_div.Id;
                //    cm.DistrictId = civil_dis.Id;
                //    cm.UpazillaId = civil_upazilla.Id;
                //    cm.UnionId = civil_union.Id;
                //    civilUnionLongId = civil_union.Id;
                //}


                //cm.ForestCircleId = forestCircleLongId;
                //cm.ForestDivisionId = forestDivisionLongId;
                //cm.ForestRangeId = forestRangeLongId;
                //cm.ForestBeatId = forestBeatLongId;
                //cm.ForestFcvVcfId = forestFcvVcfLongId;
                //cm.DivisionId = civilDivisionLongId;
                //cm.DistrictId = civilDistrictLongId;
                //cm.UpazillaId = civilUpazillaLongId;
                //cm.UnionId = civilUnionLongId;


                //Othere Info
                var ngo_db = await _writeOnlyCtx.Set<Ngo>()
                     .FromSqlRaw($"select * from \"BEN\".\"Ngos\" e where e.\"Name\" ilike '%{item.FirstOrDefault().Ngo}%'")
                     .FirstOrDefaultAsync();
                if (ngo_db is null)
                {
                    skippedList.Add((Convert.ToDouble(item.FirstOrDefault().SL), item.FirstOrDefault().Ngo, $"NGO {item.FirstOrDefault().Ngo} is not found in DB"));
                    //continue;
                }
                if (ngo_db is not null)
                {
                    cm.NgoId = ngo_db.Id;
                }

                //Bank Info
                cm.BankName = item?.FirstOrDefault()?.BankName;
                cm.NameOfBankAC = item?.FirstOrDefault()?.BankAcNO;
                cm.AccountType = item?.FirstOrDefault()?.AcType;
                cm.BranchName = item?.FirstOrDefault()?.BranchName;
                cm.AccountOpeningDate = Convert.ToDateTime(item?.FirstOrDefault()?.AcOpeningDate);
                cm.Remark = item?.FirstOrDefault()?.Remark;
                

                long _designationId = 0;
                long _committeeTypeId = 0;



                if (string.IsNullOrEmpty(item.FirstOrDefault().CommitteeType))
                {
                    skippedList.Add((Convert.ToDouble(item.FirstOrDefault().SL), item.FirstOrDefault().CommitteeType, $"Committee Type '{item.FirstOrDefault().CommitteeType}' can not be empty"));
                    //continue;
                }
                else
                {
                    var committeeType = await _writeOnlyCtx.Set<CommitteeTypeConfiguration>().Where(x => x.CommitteeTypeName.Equals(item.FirstOrDefault().CommitteeType)).FirstOrDefaultAsync();
                    if (committeeType is null)
                    {
                        skippedList.Add((Convert.ToDouble(item.FirstOrDefault().SL), item.FirstOrDefault().CommitteeType, $"Committee Type '{item.FirstOrDefault().CommitteeType}' is not found in DB"));
                        //continue;
                    }

                    cm.CommitteeTypeConfigurationId = committeeType.Id;
                    _committeeTypeId = committeeType.Id;
                }

                if (string.IsNullOrEmpty(item.FirstOrDefault().CommitteeName))
                {
                    skippedList.Add((Convert.ToDouble(item.FirstOrDefault().SL), item.FirstOrDefault().CommitteeName, $"Committee Name '{item.FirstOrDefault().CommitteeName}' can not be empty"));
                    //continue;
                }
                else
                {
                    var committeeNameEntity = await _writeOnlyCtx.Set<CommitteesConfiguration>()
                        .Where(x => x.CommitteeName.Equals(item.FirstOrDefault().CommitteeName))
                        //.Where(x => x.CommitteeTypeConfigurationId == _committeeTypeId)
                        .FirstOrDefaultAsync();
                    if (committeeNameEntity is null)
                    {
                        skippedList.Add((Convert.ToDouble(item.FirstOrDefault().SL), item.FirstOrDefault().CommitteeName, $"Committee Name '{item.FirstOrDefault().CommitteeName}' is not found in DB"));
                        //continue;
                        cm.CommitteesConfigurationId = null;
                    }
                    else
                    {
                        cm.CommitteesConfigurationId = committeeNameEntity.Id;
                    }
                }


                if (string.IsNullOrEmpty(item.FirstOrDefault().Designation))
                {
                    skippedList.Add((Convert.ToDouble(item.FirstOrDefault().SL), item.FirstOrDefault().Designation, $"Designation '{item.FirstOrDefault().Designation}' can not be null"));
                    //continue;
                }
                else
                {
                    var committeeDesignation = await _writeOnlyCtx.Set<CommitteeDesignationsConfiguration>()
                        .Where(x => x.DesignationName.Equals(item.FirstOrDefault().Designation))
                        //.Where(x => x.CommitteesConfigurationId == cm.CommitteesConfigurationId)
                        .FirstOrDefaultAsync();
                    if (committeeDesignation is null)
                    {
                        skippedList.Add((Convert.ToDouble(item.FirstOrDefault().SL), item.FirstOrDefault().Designation, $"Designation '{item.FirstOrDefault().Designation}' is not found in DB"));
                        //continue;
                    }
                    else
                    {
                        cm.CommitteeDesignationsConfigurationId = committeeDesignation.Id == 0 ? null : committeeDesignation.Id;
                        _designationId = committeeDesignation.Id;
                    }
                }


                if (cm.CommitteeManagementMembers is null)
                {
                    cm.CommitteeManagementMembers = new List<CommitteeManagementMember>();
                }


                foreach (var memberInfo in item)
                {
                    if (memberInfo.MembersType == "Beneficiary")
                    {
                        var survey = await _writeOnlyCtx.Set<Survey>()
                                //.FromSqlRaw($"SELECT * FROM \"BEN\".\"Surveys\" s WHERE s.\"BeneficiaryHouseholdSerialNo\" = '{beneficiaryHouseholdId}' AND s.\"BeneficiaryNid\" LIKE '%{nid}%' OR s.\"BeneficiaryPhone\" LIKE '%{mobileNo}%' OR s.\"BeneficiaryPhoneBn\" LIKE '%{mobileNo}%' ORDER BY CASE WHEN s.\"BeneficiaryHouseholdSerialNo\" = '{beneficiaryHouseholdId}' THEN 1 WHEN s.\"BeneficiaryNid\" LIKE '%{nid}%' THEN 2 ELSE 3 END")
                                .FromSqlRaw($"SELECT * FROM \"BEN\".\"Surveys\" s WHERE s.\"BeneficiaryNid\" = '{memberInfo.NID}'")
                                .FirstOrDefaultAsync();
                        if (survey is null)
                        {
                            skippedList.Add((Convert.ToDouble(memberInfo.SL), memberInfo.NID, $"Beneficiary NID \'{memberInfo.NID}\' and FCV/VCF \'{memberInfo.ForestFcvVcf}\' is not found in DB"));
                            //continue;
                        }
                        else
                        {
                            cm.CommitteeManagementMembers.Add(new CommitteeManagementMember
                            {
                                CommitteeDesignationsConfigurationId = _designationId == 0 ? null : _designationId,
                                SurveyId = survey.Id,
                            });
                        }
                    }
                    else
                    {
                        cm.CommitteeManagementMembers.Add(new CommitteeManagementMember
                        {
                            CommitteeDesignationsConfigurationId = _designationId == 0 ? null : _designationId,
                            OtherCommitteeMember = new OtherCommitteeMember
                            {
                                Id=0,
                                Address = memberInfo.Address ?? string.Empty,
                                NID = memberInfo.NID,
                                FatherOrSpouse = memberInfo.FatherSpouseName,
                                FullName = memberInfo.Name,
                                Gender = Gender.Male,

                                ForestCircleId = forestCircleLongId == 0 ? null : forestCircleLongId,
                                ForestDivisionId = forestDivisionLongId == 0 ? null : forestDivisionLongId,
                                ForestBeatId = forestBeatLongId == 0 ? null : forestBeatLongId,
                                ForestRangeId = forestRangeLongId == 0 ? null : forestRangeLongId,
                                ForestFcvVcfId = forestFcvVcfLongId == 0 ? null : forestFcvVcfLongId,

                                DistrictId = civilDistrictLongId == 0 ? null : civilDistrictLongId,
                                DivisionId = civilDivisionLongId == 0 ? null : civilDivisionLongId,
                                UpazillaId = civilUpazillaLongId == 0 ? null : civilUpazillaLongId,
                                UnionId = null, //civilUnionLongId ??,
                                PhoneNumber = memberInfo.PhoneNumber ?? string.Empty
                            }
                        });
                    }
                }

                committeeManagementList.Add(cm);
            }


            var abc = committeeManagementList.Where(x=>x.ForestFcvVcfId != null || x.CommitteesConfigurationId != null || x.CommitteesConfigurationId != 0).GroupBy(x => new { x.ForestFcvVcfId, x.CommitteesConfigurationId })
               .Select(group => new CommitteeManagement
               {
                   Name = group.First().Name,
                   NameBn = group.First().NameBn,
                   ForestCircleId = group.First().ForestCircleId == 0 ? null : group.First().ForestCircleId,
                   ForestDivisionId = group.First().ForestDivisionId == 0 ? null : group.First().ForestDivisionId,
                   ForestRangeId = group.First().ForestRangeId == 0 ? null : group.First().ForestRangeId,
                   ForestBeatId = group.First().ForestBeatId == 0 ? null : group.First().ForestBeatId,
                   ForestFcvVcfId = group.First().ForestFcvVcfId == 0 ? null : group.First().ForestFcvVcfId,
                   DivisionId = group.First().DivisionId == 0 ? null : group.First().DivisionId,
                   DistrictId = group.First().DistrictId == 0 ? null : group.First().DistrictId,
                   UpazillaId = group.First().UpazillaId == 0 ? null : group.First().UpazillaId,
                   UnionId =  null,//group.First().UnionId,
                   NgoId = group.First().NgoId,
                   CommitteeTypeId = group.First().CommitteeTypeId,
                   SubCommitteeTypeId = group.First().SubCommitteeTypeId,
                   CommitteeFormDate = group.First().CommitteeFormDate,
                   CommitteeEndDate = group.First().CommitteeEndDate,
                   NameOfBankAC = group.First().NameOfBankAC,
                   AccountNumber = group.First().AccountNumber,
                   AccountType = group.First().AccountType,
                   BankName = group.First().BankName,
                   BranchName = group.First().BranchName,
                   AccountOpeningDate = group.First().AccountOpeningDate,
                   Remark = group.First().Remark,
                   IsInActiveCommittee = group.First().IsInActiveCommittee,
                   CommitteeApprovalStatus = group.First().CommitteeApprovalStatus,
                   CommitteeApprovalBy = group.First().CommitteeApprovalBy,
                   CommitteeApprovalDate = group.First().CommitteeApprovalDate,
                   CommitteeTypeConfigurationId = group.First().CommitteeTypeConfigurationId,
                   CommitteesConfigurationId = group.First().CommitteesConfigurationId,
                   CommitteeDesignationsConfigurationId = group.First().CommitteeDesignationsConfigurationId,
                   ApprovalStatus = group.First().ApprovalStatus,
                   CommitteeManagementMembers = group.SelectMany(x => x.CommitteeManagementMembers).ToList()
               });



            if (shouldMigrate)
            {
                await _writeOnlyCtx.Set<CommitteeManagement>().AddRangeAsync(abc);
                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            var skippedListJsonFormat = skippedList
                .Select(x => new
                {
                    SerialNo = x.Item1,
                    Value = x.Item2,
                    Message = x.Item3
                })
                .DistinctBy(x => x.Value)
                .ToList();

            if (skippedListJsonFormat.Count > 0)
            {
                return Ok(skippedListJsonFormat);
            }

            return Ok(new List<object>()
            {
                new
                {
                    SerialNo = 0,
                    Value = "",
                    Message = "All ok"
                },
            });
        }





        catch (Exception ex)
        {
            return Ok(new List<object>()
            {
                new
                {
                    SerialNo = 0,
                    Value = "",
                    Message = ex.Message
                },
            });
        }
    }
}




public class CommitteeMigrationExcelDataVM
{
    public string? SL { get; set; }
    // Forest Administration
    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }

    // Civil Administration
    public string? Division { get; set; }
    public string? District { get; set; }
    public string? Upazilla { get; set; }
    public string? Union { get; set; }

    //Other
    public string? Ngo { get; set; }
    public string? Name { get; set; }
    public string? CommitteeType { get; set; }
    public string? CommitteeName { get; set; }
    public string? Designation { get; set; }
    public string? MembersType { get; set; }
    public string? NID { get; set; }
    public string? BeneficiaryID { get; set; }
    public string? FatherSpouseName { get; set; }
    public string? Gender { get; set; }
    public string? Ethnicity { get; set; }
    public string? BankAcNO { get; set; }
    public string? AcName { get; set; }
    public string? AcType { get; set; }
    public string? BankName { get; set; }
    public string? BranchName { get; set; }
    public string? AcOpeningDate { get; set; }
    public string? Remark { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
}
*/
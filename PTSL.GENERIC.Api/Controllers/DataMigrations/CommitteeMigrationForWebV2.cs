using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MiniExcelLibs;
using MiniExcelLibs.Attributes;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.AccountManagement;
using PTSL.GENERIC.Common.Helper;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class CommitteeMigrationForWebV2 : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public CommitteeMigrationForWebV2(GENERICWriteOnlyCtx writeOnlyCtx)
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

            // Save file
            var filePath = Path.Join(Path.GetTempPath(), excelFile.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await excelFile.CopyToAsync(stream);
            }

            // Read and save
            var rows = MiniExcel.Query<CommitteeMigrationExcelFormat>(filePath);
            var skippedList = new List<ValueTuple<double, string?, string>>();
            var committeeList = new List<CommitteeManagement>();
            var accountList = new List<Account>();

            foreach (var row in rows)
            {
                row.ForestCircle = row.ForestCircle?.Trim()?.Replace('\u00A0', ' ');
                row.ForestDivision = row.ForestDivision?.Trim()?.Replace('\u00A0', ' ');
                row.ForestRange = row.ForestRange?.Trim()?.Replace('\u00A0', ' ');
                row.ForestBeat = row.ForestBeat?.Trim()?.Replace('\u00A0', ' ');
                row.ForestFcvVcf = row.ForestFcvVcf?.Trim()?.Replace('\u00A0', ' ');
                row.Division = row.Division?.Trim()?.Replace('\u00A0', ' ');
                row.District = row.District?.Trim()?.Replace('\u00A0', ' ');
                row.Upazilla = row.Upazilla?.Trim()?.Replace('\u00A0', ' ');
                row.Union = row.Union?.Trim()?.Replace('\u00A0', ' ');
                row.Ngo = row.Ngo?.Trim()?.Replace('\u00A0', ' ');
                row.BeneficiaryName = row.BeneficiaryName?.Trim()?.Replace('\u00A0', ' ');
                row.BeneficiaryID = row.BeneficiaryID?.Trim()?.Replace('\u00A0', ' ');
                row.CommitteeType = row.CommitteeType?.Trim()?.Replace('\u00A0', ' ');
                row.CommitteeName = row.CommitteeName?.Trim()?.Replace('\u00A0', ' ');
                row.Designation = row.Designation?.Trim()?.Replace('\u00A0', ' ');
                row.MembersType = row.MembersType?.Trim()?.Replace('\u00A0', ' ');
                row.NID = row.NID?.Trim()?.Replace('\u00A0', ' ');
                row.FatherSpouseName = row.FatherSpouseName?.Trim()?.Replace('\u00A0', ' ');
                row.Ethnicity = row.Ethnicity?.Trim()?.Replace('\u00A0', ' ');
                row.PhoneNumber = row.PhoneNumber?.Trim()?.Replace('\u00A0', ' ');
                row.Address = row.Address?.Trim()?.Replace('\u00A0', ' ');
                row.BankAcNO = row.BankAcNO?.Trim()?.Replace('\u00A0', ' ');
                row.AcName = row.AcName?.Trim()?.Replace('\u00A0', ' ');
                row.BankName = row.BankName?.Trim()?.Replace('\u00A0', ' ');
                row.BranchName = row.BranchName?.Trim()?.Replace('\u00A0', ' ');
                row.AcOpeningDate = row.AcOpeningDate?.Trim()?.Replace('\u00A0', ' ');
                row.Remark = row.Remark?.Trim()?.Replace('\u00A0', ' ');
            }

            foreach (var group in rows.GroupBy(x => x.SerialNo))
            {
                var groupList = group.ToList();

                var beneficiaryIds = group.Select(x => x.BeneficiaryID).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                var beneficiaryNIDs = group.Select(x => x.NID).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                var serialNo = group.Select(x => x.SerialNo).First();

                // Beneficiary
                var surveys = await _writeOnlyCtx.Set<Survey>()
                    .Where(x => beneficiaryNIDs.Contains(x.BeneficiaryNid) || beneficiaryIds.Contains(x.BeneficiaryId))
                    .ToListAsync();
                if (surveys is null || surveys.Count == 0)
                {
                    skippedList.Add((serialNo, "", $"No beneficiaries found for this serial no. Skipping entire row"));
                    continue;
                }
                var firstBeneficiary = surveys.First();

                // Bank account
                var firstRow = group.FirstOrDefault();
                if (firstRow is null)
                {
                    skippedList.Add((-1, string.Empty, $"Empty group"));
                    continue;
                }
                _ = DateTime.TryParse(firstRow.AcOpeningDate, out DateTime accountOpeningDate);

                // CommitteeTypeConfiguration
                if (string.IsNullOrEmpty(firstRow.CommitteeType))
                {
                    skippedList.Add((firstRow.SerialNo, firstRow.CommitteeType, $"CommitteeType ->{firstRow.CommitteeType}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var committeeTypeConfigurationResult = await _writeOnlyCtx.Set<CommitteeTypeConfiguration>()
                    .Where(x => x.CommitteeTypeName == firstRow.CommitteeType)
                    .FirstOrDefaultAsync();
                if (committeeTypeConfigurationResult is null)
                {
                    skippedList.Add((firstRow.SerialNo, firstRow.CommitteeType, $"CommitteeType ->{firstRow.CommitteeType}<- is not found in DB. Skipping entire row"));
                    continue;
                }

                // CommitteesConfiguration
                if (string.IsNullOrEmpty(firstRow.CommitteeName))
                {
                    skippedList.Add((firstRow.SerialNo, firstRow.CommitteeName, $"CommitteeName ->{firstRow.CommitteeName}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var committeesConfigurationResult = await _writeOnlyCtx.Set<CommitteesConfiguration>()
                    .Where(x => x.CommitteeName == firstRow.CommitteeName)
                    .FirstOrDefaultAsync();
                if (committeesConfigurationResult is null)
                {
                    skippedList.Add((firstRow.SerialNo, firstRow.CommitteeName, $"CommitteeName ->{firstRow.CommitteeName}<- is not found in DB. Skipping entire row"));
                    continue;
                }

                // Add bank account if bank account is not exists
                if (!string.IsNullOrEmpty(firstRow.BankAcNO))
                {
                    var bankAccount = await _writeOnlyCtx.Set<Account>()
                        .Where(x => x.AccountNumber == firstRow.BankAcNO)
                        .FirstOrDefaultAsync();

                    if (bankAccount is null)
                    {
                        accountList.Add(new Account
                        {
                            ForestCircleId = firstBeneficiary.ForestCircleId,
                            ForestDivisionId = firstBeneficiary.ForestDivisionId,
                            ForestRangeId = firstBeneficiary.ForestRangeId,
                            ForestBeatId = firstBeneficiary.ForestBeatId,
                            ForestFcvVcfId = firstBeneficiary.ForestFcvVcfId,
                            CommitteeTypeId = committeeTypeConfigurationResult.Id,
                            CommitteeId = committeesConfigurationResult.Id,
                            BankAccountName = firstRow.BankName,
                            AccountNumber = firstRow.BankAcNO,
                            BranchName = firstRow.BranchName,
                            AccountType = firstRow.AcType is null ? AccountTypeForAccount.CurrentAccount : (AccountTypeForAccount)firstRow.AcType,
                            AccountOpeningDate = accountOpeningDate,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            IsActive = true,
                            IsDeleted = false,
                        });
                    }
                }

                var committee = new CommitteeManagement
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = 3,
                    IsActive = true
                };

                foreach (var committeeRow in groupList)
                {
                    // Set location from beneficiary
                    committee.ForestCircleId = firstBeneficiary.ForestCircleId;
                    committee.ForestDivisionId = firstBeneficiary.ForestDivisionId;
                    committee.ForestRangeId = firstBeneficiary.ForestRangeId;
                    committee.ForestBeatId = firstBeneficiary.ForestBeatId;
                    committee.ForestFcvVcfId = firstBeneficiary.ForestFcvVcfId;
                    committee.DivisionId = firstBeneficiary.PresentDivisionId;
                    committee.DistrictId = firstBeneficiary.PresentDistrictId;
                    committee.UpazillaId = firstBeneficiary.PresentUpazillaId;
                    if (firstBeneficiary.PresentUnionNewId is not null || firstBeneficiary.PresentUnionNewId != default)
                    {
                        committee.UnionId = firstBeneficiary.PresentUnionNewId;
                    }

                    committee.CommitteeTypeConfigurationId = committeeTypeConfigurationResult.Id;
                    committee.CommitteesConfigurationId = committeesConfigurationResult.Id;

                    // Initialize CommitteeManagementMembers
                    if (committee.CommitteeManagementMembers is null)
                    {
                        committee.CommitteeManagementMembers = new List<CommitteeManagementMember>();
                    }

                    // Ngo
                    if (string.IsNullOrEmpty(committeeRow.Ngo))
                    {
                        skippedList.Add((committeeRow.SerialNo, committeeRow.Ngo, $"Ngo ->{committeeRow.Ngo}<- can not be empty. Skipping entire row"));
                        continue;
                    }
                    var ngo = await _writeOnlyCtx.Set<Ngo>()
                        .Where(x => x.Name == committeeRow.Ngo)
                        .FirstOrDefaultAsync();
                    if (ngo is null)
                    {
                        skippedList.Add((committeeRow.SerialNo, committeeRow.Ngo, $"Ngo ->{committeeRow.Ngo}<- is not found in DB. Skipping entire row"));
                        continue;
                    }
                    committee.NgoId = ngo.Id;

                    // Designation
                    if (string.IsNullOrEmpty(committeeRow.Designation))
                    {
                        skippedList.Add((committeeRow.SerialNo, committeeRow.Designation, $"Designation ->{committeeRow.Designation}<- can not be empty. Skipping entire row"));
                        continue;
                    }
                    var committeeDesignationResult = await _writeOnlyCtx.Set<CommitteeDesignationsConfiguration>()
                        .Where(x => x.DesignationName == committeeRow.Designation)
                        .FirstOrDefaultAsync();
                    if (committeeDesignationResult is null)
                    {
                        skippedList.Add((committeeRow.SerialNo, committeeRow.Designation, $"Designation ->{committeeRow.Designation}<- is not found in DB. Skipping entire row"));
                        continue;
                    }

                    // Ethnicity
                    long? ethnicityId = default;
                    if (string.IsNullOrEmpty(committeeRow.Ethnicity) == false)
                    {
                        var ethnicity = await _writeOnlyCtx.Set<Ethnicity>()
                            .Where(x => x.Name == committeeRow.Ethnicity)
                            .FirstOrDefaultAsync();
                        if (ethnicity is null)
                        {
                            skippedList.Add((committeeRow.SerialNo, committeeRow.Ethnicity, $"Ethnicity ->{committeeRow.Ethnicity}<- is not found in DB. Skipping entire row"));
                            continue;
                        }
                        ethnicityId = ethnicity.Id;
                    }

                    foreach (var item in rows.Where(x => x.SerialNo == committeeRow.SerialNo))
                    {
                        if (item.MembersType != "Beneficiary")
                        {
                            committee.CommitteeManagementMembers.Add(new CommitteeManagementMember
                            {
                                CommitteeDesignationsConfigurationId = committeeDesignationResult.Id,
                                Name = item.BeneficiaryName,
                                OtherCommitteeMember = new OtherCommitteeMember
                                {
                                    FullName = item.BeneficiaryName,
                                    FatherOrSpouse = item.FatherSpouseName,
                                    Gender = item.Gender,
                                    PhoneNumber = string.IsNullOrEmpty(item.PhoneNumber) ? string.Empty : item.PhoneNumber,
                                    NID = item.NID,
                                    Address = item.Address,
                                    ForestCircleId = firstBeneficiary.ForestCircleId,
                                    ForestDivisionId = firstBeneficiary.ForestDivisionId,
                                    ForestRangeId = firstBeneficiary.ForestRangeId,
                                    ForestBeatId = firstBeneficiary.ForestBeatId,
                                    ForestFcvVcfId = firstBeneficiary.ForestFcvVcfId,
                                    DivisionId = firstBeneficiary.PresentDivisionId,
                                    DistrictId = firstBeneficiary.PresentDistrictId,
                                    UpazillaId = firstBeneficiary.PresentUpazillaId,
                                    UnionId = firstBeneficiary.PresentUnionNewId is null ? null : firstBeneficiary.PresentUnionNewId,
                                    EthnicityId = ethnicityId,
                                    IsActive = true,
                                    IsDeleted = false,
                                },
                                IsActive = true,
                                IsDeleted = false,
                            });
                        }
                        else
                        {
                            var survey = await _writeOnlyCtx.Set<Survey>()
                                .Where(x => x.BeneficiaryId == item.BeneficiaryID || x.BeneficiaryNid == item.NID)
                                .FirstOrDefaultAsync();
                            if (survey is null)
                            {
                                skippedList.Add((serialNo, "", $"No beneficiaries found for this serial no. Skipping entire row"));
                                continue;
                            }

                            committee.CommitteeManagementMembers.Add(new CommitteeManagementMember
                            {
                                CommitteeDesignationsConfigurationId = committeeDesignationResult.Id,
                                Name = item.BeneficiaryName,
                                SurveyId = survey.Id,
                                IsActive = true,
                                IsDeleted = false,
                            });
                        }
                    }

                }

                committeeList.Add(committee);
            }

            accountList = accountList.GroupBy(x => x.AccountNumber).Select(x => x.First()).ToList();

            if (shouldMigrate)
            {
                using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();
                await _writeOnlyCtx.Set<CommitteeManagement>().AddRangeAsync(committeeList);
                await _writeOnlyCtx.Set<Account>().AddRangeAsync(accountList);
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


public class CommitteeMigrationExcelFormat
{
    [ExcelColumnName("SL")]
    public double SerialNo { get; set; }

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

    [ExcelColumnName(excelColumnName: "Ngo", aliases: new[] { "NGO" })]
    public string? Ngo { get; set; }

    [ExcelColumnName("Name")]
    public string? BeneficiaryName { get; set; }
    public string? CommitteeType { get; set; }
    public string? CommitteeName { get; set; }
    public string? Designation { get; set; }
    public string? MembersType { get; set; }
    public string? NID { get; set; }
    public string? BeneficiaryID { get; set; }
    [ExcelColumnName("FatherOrSpouseName")]
    public string? FatherSpouseName { get; set; }
    public Gender Gender { get; set; }
    public string? Ethnicity { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? BankAcNO { get; set; }
    public string? AcName { get; set; }
    public AccountTypeForAccount? AcType { get; set; }
    public string? BankName { get; set; }
    public string? BranchName { get; set; }
    public string? AcOpeningDate { get; set; }
    public string? Remark { get; set; }
}
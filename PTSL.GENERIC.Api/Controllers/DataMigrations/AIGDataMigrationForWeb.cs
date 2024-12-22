using System.Data;
using System.Data.OleDb;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using MiniExcelLibs;
using MiniExcelLibs.Attributes;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Api.Migrations;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class AIGDataMigrationForWeb : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;
    private readonly IMemoryCache _memoryCache;

    public AIGDataMigrationForWeb(GENERICWriteOnlyCtx writeOnlyCtx, IMemoryCache memoryCache)
    {
        _writeOnlyCtx = writeOnlyCtx;
        _memoryCache = memoryCache;
    }

    [HttpPost("AIG-Data-Migration-Web/{shouldMigrate}")]
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

            var aigRows = MiniExcel.Query<AigAigExcelFormat>(filePath, sheetName: "AIG");
            var loanRepaymentsRows = MiniExcel.Query<AigLoanRepaymentsExcelFormat>(filePath, sheetName: "Loan Repayments");
            var progressRows = MiniExcel.Query<AigProgressExcelFormat>(filePath, sheetName: "Progress");
            var aigList = new List<AIGBasicInformation>();
            var skippedList = new List<ValueTuple<double, string?, string>>();

            foreach (var aig in aigRows)
            {
                aig.BeneficiaryNid = aig.BeneficiaryNid?.Trim()?.Replace('\u00A0', ' ');
                aig.BeneficiaryId = aig.BeneficiaryId?.Trim()?.Replace('\u00A0', ' ');
                aig.BankAccountNo = aig.BankAccountNo?.Trim()?.Replace('\u00A0', ' ');
                aig.Ngo = aig.Ngo?.Trim()?.Replace('\u00A0', ' ');

                if (string.IsNullOrEmpty(aig.BeneficiaryNid))
                {
                    skippedList.Add((aig.SerialNo, aig.BeneficiaryNid, $"BeneficiaryNid ->{aig.BeneficiaryNid}<- can not be empty. Skipping entire row"));
                    continue;
                }
                if (string.IsNullOrEmpty(aig.BeneficiaryId))
                {
                    skippedList.Add((aig.SerialNo, aig.BeneficiaryId, $"BeneficiaryId ->{aig.BeneficiaryId}<- can not be empty. Skipping entire row"));
                    continue;
                }
                if (string.IsNullOrEmpty(aig.BankAccountNo))
                {
                    skippedList.Add((aig.SerialNo, aig.BankAccountNo, $"BankAccountNo ->{aig.BankAccountNo}<- can not be empty. Skipping entire row"));
                    continue;
                }
                if (string.IsNullOrEmpty(aig.Ngo))
                {
                    skippedList.Add((aig.SerialNo, aig.Ngo, $"Ngo ->{aig.Ngo}<- can not be empty. Skipping entire row"));
                    continue;
                }
                if (aig.TotalLoanAmount <= 0)
                {
                    skippedList.Add((aig.SerialNo, aig.TotalLoanAmount.ToString(), $"TotalLoanAmount ->{aig.TotalLoanAmount}<- can not be zero or less. Skipping entire row"));
                    continue;
                }
                if (aig.TotalRepaymentMonth <= 0)
                {
                    skippedList.Add((aig.SerialNo, aig.TotalRepaymentMonth.ToString(), $"TotalRepaymentMonth ->{aig.TotalRepaymentMonth}<- can not be zero or less. Skipping entire row"));
                    continue;
                }
                if (aig.SecurityChargePercentage <= 0)
                {
                    skippedList.Add((aig.SerialNo, aig.SecurityChargePercentage.ToString(), $"SecurityChargePercentage ->{aig.SecurityChargePercentage}<- can not be zero or less. Skipping entire row"));
                    continue;
                }
                if (aig.ServiceChargePercentage <= 0)
                {
                    skippedList.Add((aig.SerialNo, aig.ServiceChargePercentage.ToString(), $"ServiceChargePercentage ->{aig.ServiceChargePercentage}<- can not be zero or less. Skipping entire row"));
                    continue;
                }
                if (aig.TotalGraceMonthForSixtyPercentage < 0)
                {
                    skippedList.Add((aig.SerialNo, aig.TotalGraceMonthForSixtyPercentage.ToString(), $"TotalGraceMonthForSixtyPercentage ->{aig.TotalGraceMonthForSixtyPercentage}<- can not be less than zero. Skipping entire row"));
                    continue;
                }
                if (aig.AmountForFortyPercentage < 0)
                {
                    skippedList.Add((aig.SerialNo, aig.AmountForFortyPercentage.ToString(), $"AmountForFortyPercentage ->{aig.AmountForFortyPercentage}<- can not be less than zero. Skipping entire row"));
                    continue;
                }
                if (aig.AmountForFortyPercentage >= aig.AmountForSixtyPercentage)
                {
                    skippedList.Add((aig.SerialNo, aig.AmountForFortyPercentage.ToString(), $"AmountForFortyPercentage ->{aig.AmountForFortyPercentage}<- can not be greater or equal to AmountForSixtyPercentage. Skipping entire row"));
                    continue;
                }
                if (aig.StartDate >= aig.EndDate)
                {
                    skippedList.Add((aig.SerialNo, aig.EndDate.ToString(), $"End Date can no be greater than Start Date or equal. Skipping entire row"));
                    continue;
                }

                aig.AigLoanRepaymentsExcelFormats = loanRepaymentsRows.Where(x => x.SerialNo == aig.SerialNo);
                aig.AigProgressExcelFormats = progressRows.Where(x => x.SerialNo == aig.SerialNo);
            }

            if (skippedList.Count > 0)
            {
                return Ok(skippedList
                    .Select(x => new
                    {
                        SerialNo = x.Item1,
                        Value = x.Item2,
                        Message = x.Item3
                    })
                    .DistinctBy(x => x.Value)
                    .ToList());
            }

            foreach (var row in aigRows)
            {
                var aig = new AIGBasicInformation
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = 3,
                    IsActive = true,
                };

                var survey = await _writeOnlyCtx.Set<Survey>()
                    .Where(x => x.BeneficiaryId == row.BeneficiaryId || x.BeneficiaryNid == row.BeneficiaryNid)
                    .FirstOrDefaultAsync();
                if (survey is null)
                {
                    skippedList.Add((row.SerialNo, row.BeneficiaryNid, $"No beneficiary with NID ->{row.BeneficiaryNid}<- or ID ->{row.BeneficiaryId}<- found for this serial no. Skipping entire row"));
                    continue;
                }
                aig.SurveyId = survey.Id;

                var individualLDF = await _writeOnlyCtx.Set<IndividualLDFInfoForm>()
                    .Where(x => x.SurveyId == survey.Id)
                    .FirstOrDefaultAsync();
                if (individualLDF is null)
                {
                    skippedList.Add((row.SerialNo, row.BeneficiaryNid, $"Individual LDF is not found with {row.BeneficiaryNid} or {row.BeneficiaryId}. Skipping entire row"));
                    continue;
                }
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

public class AigAigExcelFormat
{
    public double SerialNo { get; set; }
    public string? BeneficiaryNid {  get; set; }
    public string? BeneficiaryId {  get; set; }
    public string? BankAccountNo { get; set; }
    public double TotalLoanAmount { get; set; }
    public int TotalRepaymentMonth { get; set; }

    [ExcelColumn(Name = "Service Charge  Percentage", Aliases = new string[] { "ServiceChargePercentage" })]
    public int ServiceChargePercentage { get; set; }

    [ExcelColumn(Name = "Security Charge Percentage", Aliases = new string[] { "SecurityChargePercentage" })]
    public int SecurityChargePercentage { get; set; }

    [ExcelColumn(Name = "AmountFor Sixty Percentage", Aliases = new string[] { "AmountForSixtyPercentage" })]
    public double AmountForSixtyPercentage { get; set; }

    [ExcelColumn(Name = "Total Grace Mont For Sixty Percentage", Aliases = new string[] { "TotalGraceMonthForSixtyPercentage" })]
    public int TotalGraceMonthForSixtyPercentage { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public double? AmountForFortyPercentage { get; set; }
    public string? Ngo { get; set; }

    [ExcelIgnore]
    public IEnumerable<AigLoanRepaymentsExcelFormat> AigLoanRepaymentsExcelFormats { get; set; } = Enumerable.Empty<AigLoanRepaymentsExcelFormat>();
    [ExcelIgnore]
    public IEnumerable<AigProgressExcelFormat> AigProgressExcelFormats { get; set; } = Enumerable.Empty<AigProgressExcelFormat>();
}

public class AigLoanRepaymentsExcelFormat
{
    public double SerialNo { get; set; }
    public DateTime? RepaymentStartDate { get; set; }
    public DateTime? RepaymentEndDate { get; set; }
    public double RepaymentAmount { get; set; }
    public string? IsReceived { get; set; }
    public DateTime? ReceivedDate { get; set; }
}

public class AigProgressExcelFormat
{
    public double SerialNo { get; set; }
    public DateTime ProgressDate { get; set; }
    public double ProgressAmount { get; set; }
}

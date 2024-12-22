using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity;
using Microsoft.AspNetCore.Authorization;
using PTSL.GENERIC.Common.Entity.AIG;
using MiniExcelLibs;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using Microsoft.EntityFrameworkCore;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class IndividualLDFMigration : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public IndividualLDFMigration(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("individualLDF/migrate/{shouldMigrate}")]
    [AllowAnonymous]
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
            var rows = MiniExcel.Query<IndividualLDFExcelFormat>(filePath);
            var skippedList = new List<ValueTuple<double, string?, string>>();
            var individualList = new List<IndividualLDFInfoForm>();

            foreach (var row in rows)
            {
                var individualLDF = new IndividualLDFInfoForm
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = 3,
                    IsActive = true
                };

                if (row.RequestedLoanAmount <= 0)
                {
                    skippedList.Add((row.SerialNo, row.RequestedLoanAmount.ToString(), "Requested loan amount can not be less than or equal to zero. Skipping entire row"));
                    continue;
                }
                individualLDF.RequestedLoanAmount = row.RequestedLoanAmount;

                row.BeneficiaryId = row.BeneficiaryId?.Trim()?.Replace('\u00A0', ' ');
                row.BeneficiaryNid = row.BeneficiaryNid?.Trim()?.Replace('\u00A0', ' ');
                row.Ngo = row.Ngo?.Trim()?.Replace('\u00A0', ' ');

                // Beneficiary ID
                if (string.IsNullOrEmpty(row.BeneficiaryId))
                {
                    skippedList.Add((row.SerialNo, row.BeneficiaryId, $"BeneficiaryId ->{row.BeneficiaryId}<- can not be empty. Skipping entire row"));
                    continue;
                }
                if (string.IsNullOrEmpty(row.BeneficiaryNid))
                {
                    skippedList.Add((row.SerialNo, row.BeneficiaryNid, $"BeneficiaryNid ->{row.BeneficiaryNid}<- can not be empty. Skipping entire row"));
                    continue;
                }
                if (string.IsNullOrEmpty(row.Ngo))
                {
                    skippedList.Add((row.SerialNo, row.Ngo, $"Ngo ->{row.Ngo}<- can not be empty. Skipping entire row"));
                    continue;
                }

                // NGO
                var ngo = await _writeOnlyCtx.Set<Ngo>()
                    .Where(x => x.Name == row.Ngo)
                    .FirstOrDefaultAsync();
                if (ngo is null)
                {
                    skippedList.Add((row.SerialNo, row.Ngo, $"Ngo ->{row.Ngo}<- is not found in DB. Skipping entire row"));
                    continue;
                }
                individualLDF.NgoId = ngo.Id;

                // Survey
                var survey = await _writeOnlyCtx.Set<Survey>()
                    .Where(x => x.BeneficiaryId == row.BeneficiaryId || x.BeneficiaryNid == row.BeneficiaryNid)
                    .FirstOrDefaultAsync();
                if (survey is null)
                {
                    skippedList.Add((row.SerialNo, row.BeneficiaryNid, $"No beneficiary with NID ->{row.BeneficiaryNid}<- or ID ->{row.BeneficiaryId}<- found for this serial no. Skipping entire row"));
                    continue;
                }
                individualLDF.SurveyId = survey.Id;

                individualLDF.ForestCircleId = survey.ForestCircleId;
                individualLDF.ForestDivisionId = survey.ForestDivisionId;
                individualLDF.ForestRangeId = survey.ForestRangeId;
                individualLDF.ForestBeatId = survey.ForestBeatId;
                individualLDF.ForestFcvVcfId = survey.ForestFcvVcfId;
                individualLDF.DivisionId = survey.PresentDivisionId;
                individualLDF.DistrictId = survey.PresentDistrictId;
                individualLDF.UpazillaId = survey.PresentUpazillaId;
                if (survey.PresentUnionNewId is not null || survey.PresentUnionNewId != default)
                {
                    individualLDF.UnionId = survey.PresentUnionNewId;
                }

                individualLDF.DocumentInfoURL = string.Empty;
                individualLDF.SubmittedDate = DateTime.Now.AddYears(-5);

                individualList.Add(individualLDF);
            }

            if (shouldMigrate)
            {
                using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();
                await _writeOnlyCtx.Set<IndividualLDFInfoForm>().AddRangeAsync(individualList);
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
                    ex.Message
                },
            });
        }
    }
}

public class IndividualLDFExcelFormat
{
    public double SerialNo { get; set; }
    public string? BeneficiaryId { get; set; }
    public string? BeneficiaryNid { get; set; }
    public double RequestedLoanAmount { get; set; }
    public string? Ngo { get; set; }
}


using System.Data;
using System.Data.OleDb;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;

using LabourDatabaseEntity = PTSL.GENERIC.Common.Entity.Labour.LabourDatabase;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class LabourDataMigrationWeb : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;
    private readonly GENERICWriteOnlyCtx _readOnlyCtx;

    public LabourDataMigrationWeb(GENERICWriteOnlyCtx writeOnlyCtx, GENERICWriteOnlyCtx readOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
        _readOnlyCtx = readOnlyCtx;
    }


    [HttpPost("labor-migration-web/{shouldMigrate}")]
    public async Task<IActionResult> LabourMigration([FromRoute] bool shouldMigrate, IFormFile excelFile)
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

        DataTable dt = new DataTable();

        var command = $"SELECT * From [Sheet1$]";

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
        var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

        var labourList = new List<LabourDatabaseEntity>();
        var otherLabourList = new List<OtherLabourMember>();
        var skippedList = new List<ValueTuple<double, string, string>>();

        foreach (var row in dt.Rows.Cast<DataRow>())
        {
            string nid = DataRowHelper.GetDoubleValue(row, "NID no").ToString();

            bool isExist = await _readOnlyCtx.Set<Survey>().Where(x => x.BeneficiaryNid == nid).AnyAsync();
            if (!isExist)
            {
                var labour = new LabourDatabaseEntity();
                labour.CreatedAt = DateTime.Now;
                labour.CreatedBy = 3;
                labour.IsActive = true;

                var sl = DataRowHelper.GetLongValue(row, "Sl no");
                var forest_circle = DataRowHelper.GetStringValue(row, "Forest Circle")?.Trim();
                var forest_division = DataRowHelper.GetStringValue(row, "Forest Division")?.Trim();
                var forest_range = DataRowHelper.GetStringValue(row, "Range")?.Trim();
                var forest_beat = DataRowHelper.GetStringValue(row, "Beat")?.Trim();

                if (string.IsNullOrEmpty(forest_beat) == false)
                {
                    var circle = await _writeOnlyCtx.Set<ForestCircle>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestCircles\" e where e.\"Name\" like '%{forest_circle}%'")
                        .FirstOrDefaultAsync();
                    if (circle is null)
                    {
                        skippedList.Add((sl, forest_circle, $"Forest Circle '{forest_circle}' is not found in DB"));
                        continue;
                    }

                    var division = await _writeOnlyCtx.Set<ForestDivision>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestDivisions\" e where e.\"Name\" like '%{forest_division}%'")
                        .FirstOrDefaultAsync();
                    if (division is null)
                    {
                        skippedList.Add((sl, forest_division, $"Forest Division '{forest_division}' is not found in DB"));
                        continue;
                    }

                    var range = await _writeOnlyCtx.Set<ForestRange>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestRanges\" e where e.\"Name\" like '%{forest_range}%'")
                        .FirstOrDefaultAsync();
                    if (range is null)
                    {
                        var createdRange = new ForestRange();
                        createdRange.CreatedAt = DateTime.Now;
                        createdRange.CreatedBy = 3;
                        createdRange.Name = forest_range;
                        createdRange.NameBn = forest_range;
                        createdRange.ForestDivisionId = division.Id;
                        await _writeOnlyCtx.Set<ForestRange>().AddAsync(createdRange);

                        var count = await _writeOnlyCtx.SaveChangesAsync();
                        if (count > 0)
                        {
                            range = createdRange;
                        }
                        else
                        {
                            skippedList.Add((sl, forest_range, $"Forest Range '{forest_range}' is not found in DB"));
                            continue;
                        }
                    }

                    var beat = await _writeOnlyCtx.Set<ForestBeat>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestBeats\" e where e.\"Name\" like '%{forest_beat}%'")
                        .FirstOrDefaultAsync();
                    if (beat is null)
                    {
                        var createdBeat = new ForestBeat();
                        createdBeat.CreatedAt = DateTime.Now;
                        createdBeat.CreatedBy = 3;
                        createdBeat.Name = forest_beat;
                        createdBeat.NameBn = forest_beat;

                        createdBeat.ForestRangeId = range.Id;
                        await _writeOnlyCtx.Set<ForestBeat>().AddAsync(createdBeat);

                        var count = await _writeOnlyCtx.SaveChangesAsync();
                        if (count > 0)
                        {
                            beat = createdBeat;
                        }
                        else
                        {
                            skippedList.Add((sl, forest_beat, $"Forest Beat '{forest_beat}' is not found in DB"));
                            continue;
                        }
                    }
                    labour.ForestCircleId = circle.Id;
                    labour.ForestDivisionId = division.Id;
                    labour.ForestRangeId = range.Id;
                    labour.ForestBeatId = beat.Id;


                    if(labour.ForestBeatId==0 || labour.ForestRangeId==0)
                    {
                        Console.WriteLine("hello");
                    }
                }

                var civil_division = DataRowHelper.GetStringValue(row, "Division")?.Trim();
                var civil_district = DataRowHelper.GetStringValue(row, "District")?.Trim();
                var upazilla = DataRowHelper.GetStringValue(row, "Upazilla")?.Trim();
                var union = DataRowHelper.GetStringValue(row, "Union")?.Trim();

                if (string.IsNullOrEmpty(upazilla) == false)
                {
                    var civil_div = await _writeOnlyCtx.Set<Division>()
                        .FromSqlRaw($"select * from \"GS\".\"Division\" e where e.\"DivisionName\" ilike '%{civil_division}%'")
                        .FirstOrDefaultAsync();
                    if (civil_div is null)
                    {
                        skippedList.Add((sl, civil_division, $"Division '{civil_division}' is not found in DB"));
                        continue;
                    }

                    var civil_dis = await _writeOnlyCtx.Set<District>()
                        .FromSqlRaw($"select * from \"GS\".\"District\" e where e.\"Name\" ilike '%{civil_district}%' and e.\"DivisionId\" = {civil_div.Id}")
                        .FirstOrDefaultAsync();
                    if (civil_dis is null)
                    {
                        skippedList.Add((sl, civil_district, $"District '{civil_district}' is not found in DB"));
                        continue;
                    }

                    var civil_upazilla = await _writeOnlyCtx.Set<Upazilla>()
                        .FromSqlRaw($"select * from \"GS\".\"Upazilla\" e where e.\"Name\" ilike '%{upazilla}%' and e.\"DistrictId\" = {civil_dis.Id}")
                        .FirstOrDefaultAsync();
                    if (civil_upazilla is null)
                    {
                        var createdUpazilla = new Upazilla();
                        createdUpazilla.CreatedAt = DateTime.Now;
                        createdUpazilla.CreatedBy = 3;
                        createdUpazilla.Name = upazilla;
                        createdUpazilla.NameBn = upazilla;
                        createdUpazilla.DistrictId = civil_dis.Id;
                        await _writeOnlyCtx.Set<Upazilla>().AddAsync(createdUpazilla);

                        var count = await _writeOnlyCtx.SaveChangesAsync();
                        if (count > 0)
                        {
                            civil_upazilla = createdUpazilla;
                        }
                        else
                        {
                            skippedList.Add((sl, upazilla, $"Upazilla '{upazilla}' is not found in DB"));
                            continue;
                        }
                    }
                    var civil_union = await _writeOnlyCtx.Set<Union>()
                        .FromSqlRaw($"select * from \"GS\".\"Union\" e where e.\"Name\" ilike '%{union}%' and e.\"UpazillaId\" = {civil_upazilla.Id}")
                        .FirstOrDefaultAsync();
                    if (civil_union is null)
                    {
                        var createdUnion = new Union();
                        createdUnion.CreatedAt = DateTime.Now;
                        createdUnion.CreatedBy = 3;
                        createdUnion.Name = union;
                        createdUnion.NameBn = union;
                        createdUnion.UpazillaId = civil_upazilla.Id;
                        await _writeOnlyCtx.Set<Union>().AddAsync(createdUnion);

                        var count = await _writeOnlyCtx.SaveChangesAsync();
                        if (count > 0)
                        {
                            civil_union = createdUnion;
                        }
                        else
                        {
                            skippedList.Add((sl, union, $"Union '{union}' is not found in DB. Entry Created in DB"));
                        }
                        //continue;
                    }
                    labour.DivisionId = civil_div.Id;
                    labour.DistrictId = civil_dis.Id;
                    labour.UpazillaId = civil_upazilla.Id;
                    labour.UnionId = civil_union != null ? civil_union.Id : null;
                }
                var otherMember = new OtherLabourMember();
                otherMember.CreatedAt = DateTime.Now;
                otherMember.CreatedBy = 3;
                otherMember.FullName = DataRowHelper.GetStringValue(row, "Name")?.Trim();
                otherMember.PhoneNumber = DataRowHelper.GetStringValue(row, "Mobile no")?.Trim();
                otherMember.NID = DataRowHelper.GetStringValue(row, "NID no")?.Trim();
                otherMember.MotherName = DataRowHelper.GetStringValue(row, "Mothers name")?.Trim();
                var isGenderExist = DataRowHelper.GetStringValue(row, "Gender")?.Trim();
                if (isGenderExist != null && isGenderExist != string.Empty)
                {
                    otherMember.Gender = DataRowHelper.GetStringValue(row, "Gender").Equals("Male", StringComparison.InvariantCultureIgnoreCase) ? Gender.Male : Gender.Female;

                    var isMale = DataRowHelper.GetStringValue(row, "Gender").Equals("Male", StringComparison.InvariantCultureIgnoreCase);
                    if (isMale)
                    {
                        otherMember.FatherName = DataRowHelper.GetStringValue(row, "Fathers name");
                    }
                    else
                    {
                        otherMember.SpouseName = DataRowHelper.GetStringValue(row, "Fathers name");
                    }
                }
                else
                {
                    otherMember.FatherName = DataRowHelper.GetStringValue(row, "Fathers name");
                }


                labour.CodeNo = DataRowHelper.GetStringValue(row, "Code no");
                labour.Address = DataRowHelper.GetStringValue(row, "Address");

                labour.OtherLabourMember = otherMember;

                labourList.Add(labour);
            }
            else
            {
                var labour = new LabourDatabaseEntity();
                labour.CreatedAt = DateTime.Now;
                labour.CreatedBy = 3;
                labour.IsActive = true;
                var survey = await _readOnlyCtx.Set<Survey>().Where(x => x.BeneficiaryNid == nid).FirstOrDefaultAsync();

                labour.ForestCircleId = survey.ForestCircleId;
                labour.ForestDivisionId = survey.ForestDivisionId;
                labour.ForestRangeId = survey.ForestRangeId;
                labour.ForestBeatId = survey.ForestBeatId;

                labour.DivisionId = survey.PresentDivisionId;
                labour.DistrictId = survey.PresentDistrictId;
                labour.UpazillaId = survey.PresentUpazillaId;
                labour.UnionId = survey.PresentUnionNewId;
                labour.SurveyId = survey.Id;

                labour.CodeNo = DataRowHelper.GetStringValue(row, "Code no");
                labour.Address = DataRowHelper.GetStringValue(row, "Address");

                labourList.Add(labour);
            }
        }

        if (shouldMigrate)
        {
            await _writeOnlyCtx.Set<LabourDatabaseEntity>().AddRangeAsync(labourList);
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

        await System.IO.File.WriteAllTextAsync("D:\\sufl_assets\\LabourDataBase22_23\\problem-labour.txt", System.Text.Json.JsonSerializer.Serialize(skippedListJsonFormat, new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true,
        }));

        return Ok($"Completed. Skipped: {skippedList.Count}");
    }
}

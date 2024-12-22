using System.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using MiniExcelLibs;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Beneficiary;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class CIPDataMigrationForWeb : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;
    private readonly IMemoryCache _memoryCache;

    public CIPDataMigrationForWeb(GENERICWriteOnlyCtx writeOnlyCtx, IMemoryCache memoryCache)
    {
        _writeOnlyCtx = writeOnlyCtx;
        _memoryCache = memoryCache;
    }

    [HttpGet("cip-list-for-web-division/{division}")]
    [AllowAnonymous]
    public async Task<IActionResult> CipListDivision([FromRoute] string division)
    {
        var result = await _writeOnlyCtx.Set<Division>()
            .Where(x => x.Name == division)
            .FirstOrDefaultAsync();

        return Ok(result);
    }

    private string GetKey(string prefix, string value)
    {
        return $"CIP-{prefix}-{value}";
    }

    [HttpPost("cip-list-for-web/{shouldMigrate}")]
    public async Task<IActionResult> CipListV2([FromRoute] bool shouldMigrate, IFormFile excelFile)
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
            var rows = MiniExcel.Query<CipExcelFormat>(filePath);
            var skippedList = new List<ValueTuple<double, string?, string>>();
            var cipList = new List<Cip>();

            foreach (var row in rows)
            {
                var cip = new Cip
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = 3,
                    IsActive = true
                };
                
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
                row.ForestVillageName = row.ForestVillageName?.Trim()?.Replace('\u00A0', ' ');
                row.HouseholdSerialNo = row.HouseholdSerialNo?.Trim()?.Replace('\u00A0', ' ');
                row.BeneficiaryName = row.BeneficiaryName?.Trim()?.Replace('\u00A0', ' ');
                row.FatherOrSpouseName = row.FatherOrSpouseName?.Trim()?.Replace('\u00A0', ' ');
                row.Ethnicity = row.Ethnicity?.Trim()?.Replace('\u00A0', ' ');
                row.NID = row.NID?.Trim()?.Replace('\u00A0', ' ');
                row.MobileNumber = row.MobileNumber?.Trim()?.Replace('\u00A0', ' ');
                row.HouseType = row.HouseType?.Trim()?.Replace('\u00A0', ' ');

                #region Forest Administration
                // Forest Circle
                if (string.IsNullOrEmpty(row.ForestCircle))
                {
                    skippedList.Add((row.SerialNo, row.ForestCircle, $"Forest circle ->{row.ForestCircle}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var circle = await _memoryCache.GetOrCreateAsync(GetKey("ForestCircle", row.ForestCircle), async entry =>
                {
                    entry.AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                    return await _writeOnlyCtx.Set<ForestCircle>()
                                        .Where(x => x.Name == row.ForestCircle)
                                        .FirstOrDefaultAsync();
                });
                if (circle is null)
                {
                    skippedList.Add((row.SerialNo, row.ForestCircle, $"Forest circle ->{row.ForestCircle}<- is not found in DB. Skipping entire row"));
                    continue;
                }
                cip.ForestCircleId = circle.Id;

                // Forest Division
                if (string.IsNullOrEmpty(row.ForestDivision))
                {
                    skippedList.Add((row.SerialNo, row.ForestDivision, $"Forest division ->{row.ForestDivision}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var forestDivision = await _memoryCache.GetOrCreateAsync(GetKey("ForestDivision", row.ForestDivision), async entry =>
                {
                    entry.AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                    return await _writeOnlyCtx.Set<ForestDivision>()
                                        .Where(x => x.Name == row.ForestDivision && x.ForestCircleId == circle.Id)
                                        .FirstOrDefaultAsync();
                });
                if (forestDivision is null)
                {
                    skippedList.Add((row.SerialNo, row.ForestDivision, $"Forest division ->{row.ForestDivision}<- is not found in DB under Forest Circle {circle.Name}. Skipping entire row"));
                    continue;
                }
                cip.ForestDivisionId = forestDivision.Id;

                // Forest Range
                if (string.IsNullOrEmpty(row.ForestRange))
                {
                    skippedList.Add((row.SerialNo, row.ForestRange, $"Forest range ->{row.ForestRange}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var forestRange = await _memoryCache.GetOrCreateAsync(GetKey("ForestRange", row.ForestRange), async entry =>
                {
                    entry.AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                    return await _writeOnlyCtx.Set<ForestRange>()
                        .Where(x => x.Name == row.ForestRange && x.ForestDivisionId == forestDivision.Id)
                        .FirstOrDefaultAsync();
                });
                if (forestRange is null)
                {
                    skippedList.Add((row.SerialNo, row.ForestRange, $"Forest range ->{row.ForestRange}<- is not found in DB under Forest Division {forestDivision.Name}. Skipping entire row"));
                    continue;
                }
                cip.ForestRangeId = forestRange.Id;

                // Forest Beat
                if (string.IsNullOrEmpty(row.ForestBeat))
                {
                    skippedList.Add((row.SerialNo, row.ForestBeat, $"Forest beat ->{row.ForestBeat}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var beat = await _memoryCache.GetOrCreateAsync(GetKey("ForestBeat", row.ForestBeat), async entry =>
                {
                    entry.AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                    return await _writeOnlyCtx.Set<ForestBeat>()
                        .Where(x => x.Name == row.ForestBeat && x.ForestRangeId == forestRange.Id)
                        .FirstOrDefaultAsync();
                });
                if (beat is null)
                {
                    skippedList.Add((row.SerialNo, row.ForestBeat, $"Forest beat ->{row.ForestBeat}<- is not found in DB under Forest Range {forestRange.Name}. Skipping entire row"));
                    continue;
                }
                cip.ForestBeatId = beat.Id;

                // Forest FcvVcf
                if (string.IsNullOrEmpty(row.ForestFcvVcf))
                {
                    skippedList.Add((row.SerialNo, row.ForestFcvVcf, $"Forest ForestFcvVcf ->{row.ForestFcvVcf}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var forestFcvVcf = await _memoryCache.GetOrCreateAsync(GetKey("ForestFcvVcf", row.ForestFcvVcf), async entry =>
                {
                    entry.AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                    return await _writeOnlyCtx.Set<ForestFcvVcf>()
                        .Where(x => x.Name == row.ForestFcvVcf && x.ForestBeatId == beat.Id)
                        .FirstOrDefaultAsync();
                });
                if (forestFcvVcf is null)
                {
                    skippedList.Add((row.SerialNo, row.ForestFcvVcf, $"Forest ForestFcvVcf ->{row.ForestFcvVcf}<- is not found in DB under Forest Beat {beat.Name}. Skipping entire row"));
                    continue;
                }
                cip.ForestFcvVcfId = forestFcvVcf.Id;
                #endregion

                #region Civil
                // Division
                if (string.IsNullOrEmpty(row.Division))
                {
                    skippedList.Add((row.SerialNo, row.Division, $"Division ->{row.Division}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var divisionResult = await _memoryCache.GetOrCreateAsync(GetKey("Division", row.Division), async entry =>
                {
                    entry.AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                    return await _writeOnlyCtx.Set<Division>()
                        .Where(x => x.Name == row.Division)
                        .FirstOrDefaultAsync();
                });
                if (divisionResult is null)
                {
                    skippedList.Add((row.SerialNo, row.Division, $"Division ->{row.Division}<- is not found in DB. Skipping entire row"));
                    continue;
                }
                cip.DivisionId = divisionResult.Id;

                // District
                if (string.IsNullOrEmpty(row.District))
                {
                    skippedList.Add((row.SerialNo, row.District, $"District ->{row.District}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var district = await _memoryCache.GetOrCreateAsync(GetKey("District", row.District), async entry =>
                {
                    entry.AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                    return await _writeOnlyCtx.Set<District>()
                        .Where(x => x.Name == row.District && x.DivisionId == divisionResult.Id)
                        .FirstOrDefaultAsync();
                });
                if (district is null)
                {
                    skippedList.Add((row.SerialNo, row.District, $"District ->{row.District}<- is not found in DB under Division {divisionResult.Name}. Skipping entire row"));
                    continue;
                }
                cip.DistrictId = district.Id;

                // Upazilla
                if (string.IsNullOrEmpty(row.Upazilla))
                {
                    skippedList.Add((row.SerialNo, row.Upazilla, $"Upazilla ->{row.Upazilla}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var upazilla = await _memoryCache.GetOrCreateAsync(GetKey("Upazilla", row.Upazilla), async entry => {
                    entry.AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                    return await _writeOnlyCtx.Set<Upazilla>()
                        .Where(x => x.Name == row.Upazilla && x.DistrictId == district.Id)
                        .FirstOrDefaultAsync();
                });
                if (upazilla is null)
                {
                    skippedList.Add((row.SerialNo, row.Upazilla, $"Upazilla ->{row.Upazilla}<- is not found in DB under District {district.Name}. Skipping entire row"));
                    continue;
                }
                cip.UpazillaId = upazilla.Id;

                // Union
                if (string.IsNullOrEmpty(row.Union))
                {
                    skippedList.Add((row.SerialNo, row.Union, $"Union ->{row.Union}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var union = await _memoryCache.GetOrCreateAsync(GetKey("Union", row.Union), async entry =>
                {
                    entry.AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                    return await _writeOnlyCtx.Set<Union>()
                        .Where(x => x.Name == row.Union && x.UpazillaId == upazilla.Id)
                        .FirstOrDefaultAsync();
                });
                if (union is null)
                {
                    skippedList.Add((row.SerialNo, row.Union, $"Union ->{row.Union}<- is not found in DB under Upazilla {upazilla.Name}. Skipping entire row"));
                    continue;
                }
                cip.UnionId = union.Id;

                // Union
                if (string.IsNullOrEmpty(row.Ngo))
                {
                    skippedList.Add((row.SerialNo, row.Ngo, $"NGO ->{row.Ngo}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var ngo = await _writeOnlyCtx.Set<Ngo>()
                    .Where(x => x.Name == row.Ngo)
                    .FirstOrDefaultAsync();
                if (ngo is null)
                {
                    skippedList.Add((row.SerialNo, row.Ngo, $"Ngo ->{row.Ngo}<- is not found in DB. Skipping entire row"));
                    continue;
                }
                cip.NgoId = ngo.Id;
                #endregion


                // Ethnicity
                if (string.IsNullOrEmpty(row.Ethnicity) == false)
                {
                    var ethnicity = await _writeOnlyCtx.Set<Ethnicity>()
                        .Where(x => x.Name == row.Ethnicity)
                        .FirstOrDefaultAsync();
                    if (ethnicity is null)
                    {
                        skippedList.Add((row.SerialNo, row.Ethnicity, $"Ethnicity ->{row.Ethnicity}<- is not found in DB. Skipping entire row"));
                        continue;
                    }
                    cip.EthnicityId = ethnicity.Id;
                }

                // NID
                if (string.IsNullOrEmpty(row.NID) == false)
                {
                    row.NID = row.NID.Trim();

                    var cipNid = await _writeOnlyCtx.Set<Cip>()
                        .Where(x => x.NID == row.NID)
                        .FirstOrDefaultAsync();
                    if (cipNid is not null)
                    {
                        skippedList.Add((row.SerialNo, row.NID, $"NID ->{row.NID}<- is already exists. Skipping entire row"));
                        continue;
                    }
                    cip.NID = row.NID;
                }

                // House Type
                if (string.IsNullOrEmpty(row.HouseType) == false)
                {
                    row.HouseType = row.HouseType.Trim();

                    var house = await _writeOnlyCtx.Set<TypeOfHouse>()
                        .Where(x => x.Name == row.HouseType)
                        .FirstOrDefaultAsync();
                    if (house is null)
                    {
                        skippedList.Add((row.SerialNo, row.HouseType, $"HouseType ->{row.HouseType}<- is not found in DB. Skipping entire row"));
                        continue;
                    }
                    cip.TypeOfHouseNewId = house.Id;
                }

                cip.ForestVillageName = row.ForestVillageName;
                cip.FatherOrSpouseName = row.FatherOrSpouseName;
                cip.BeneficiaryName = row.BeneficiaryName;
                cip.CipWealth = row.CipWealth;
                cip.Gender = row.Gender;
                cip.HouseholdSerialNo = row.HouseholdSerialNo;
                cip.MobileNumber = row.MobileNumber;

                // Add to list
                cipList.Add(cip);
            }

            foreach (var item in cipList)
            {
                item.Id = 0;
            }

            if (shouldMigrate)
            {
                using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();
                await _writeOnlyCtx.Set<Cip>().AddRangeAsync(cipList);
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

public class CipExcelFormat
{
    public double SerialNo { get; set; }
    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }

    // Civil administration
    public string? Division { get; set; }
    public string? District { get; set; }
    public string? Upazilla { get; set; }
    public string? Union { get; set; }
    public string? Ngo { get; set; }

    public string? ForestVillageName { get; set; }
    public string? HouseholdSerialNo { get; set; }
    public string? BeneficiaryName { get; set; }
    public Gender? Gender { get; set; }
    public string? FatherOrSpouseName { get; set; }
    public string? Ethnicity { get; set; }
    public string? NID { get; set; }
    public string? MobileNumber { get; set; }
    public string? HouseType { get; set; }
    public CipWealth? CipWealth { get; set; }
}


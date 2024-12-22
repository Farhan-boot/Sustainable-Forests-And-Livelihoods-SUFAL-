using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Beneficiary;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class CIPDataMigration : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public CIPDataMigration(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }


    [HttpPost("cip-list")]
    public async Task<IActionResult> CipList(string filePath)
    {
        var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

        DataTable dt = new DataTable();

        var command = $"SELECT * From [CIP List$]";

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
        var cipList = new List<Cip>();
        var skippedList = new List<ValueTuple<double, string, string>>();
        foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
        {
            var cip = new Cip();
            cip.CreatedAt = DateTime.Now;
            cip.CreatedBy = 3;
            cip.IsActive = true;

            var sl = DataRowHelper.GetIntValue(row, "Serial No");
            //var forest_circle = row.Field<string>("ForestCircle")?.Trim();
            var forest_circle = "";
            //var forest_division = row.Field<string>("Forest Division")?.Trim();
            var forest_division = "";
            var forest_range = row.Field<string>("Name of Range")?.Trim();
            var forest_beat = row.Field<string>("Name of Beat")?.Trim();
            var fcv_vcf = row.Field<string>("Name of FCV/VCF")?.Trim();

            if (string.IsNullOrEmpty(fcv_vcf) == false)
            {
                /*
                var circle = await _writeOnlyCtx.Set<ForestCircle>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestCircles\" e where e.\"Name\" like '%{forest_circle}%'")
                    .FirstOrDefaultAsync();
                if (circle is null)
                {
                    skippedList.Add((sl, forest_circle, $"Forest Circle '{forest_circle}' is not found in DB"));
                    //continue;
                }

                var division = await _writeOnlyCtx.Set<ForestDivision>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestDivisions\" e where e.\"Name\" like '%{forest_division}%' and e.\"ForestCircleId\" = {circle?.Id ?? -1}")
                    .FirstOrDefaultAsync();
                if (division is null)
                {
                    skippedList.Add((sl, forest_division, $"Forest Division '{forest_division}' is not found in DB"));
                    continue;
                }
                */

                var range = await _writeOnlyCtx.Set<ForestRange>()
                    //.FromSqlRaw($"select * from \"BEN\".\"ForestRanges\" e where e.\"Name\" like '%{forest_range}%' and e.\"ForestDivisionId\" = {division?.Id ?? -1}")
                    .FromSqlRaw($"select * from \"BEN\".\"ForestRanges\" e where e.\"Name\" like '%{forest_range}%'")
                    .FirstOrDefaultAsync();
                if (range is null)
                {
                    skippedList.Add((sl, forest_range, $"Forest Range '{forest_range}' is not found in DB"));
                    continue;
                }

                var beat = await _writeOnlyCtx.Set<ForestBeat>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestBeats\" e where e.\"Name\" like '%{forest_beat}%' and e.\"ForestRangeId\" = {range?.Id ?? -1}")
                    .FirstOrDefaultAsync();
                if (beat is null)
                {
                    skippedList.Add((sl, forest_beat, $"Forest Beat '{forest_beat}' is not found in DB"));
                    continue;
                }

                var fcvVcf = await _writeOnlyCtx.Set<ForestFcvVcf>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestFcvVcfs\" e where e.\"Name\" like '%{fcv_vcf}%' and e.\"ForestBeatId\" = {beat?.Id ?? -1}")
                    .FirstOrDefaultAsync();
                if (fcvVcf is null)
                {
                    skippedList.Add((sl, fcv_vcf, $"Forest FCV/VCF '{fcv_vcf}' is not found in DB"));
                    continue;
                }

                //cip.ForestCircleId = division?.ForestCircleId;
                cip.ForestDivisionId = range?.ForestDivisionId;
                cip.ForestRangeId = range?.Id;
                cip.ForestBeatId = beat?.Id;
                cip.ForestFcvVcfId = fcvVcf?.Id;

                if (cip.ForestCircleId is null && cip.ForestDivisionId is null && cip.ForestRangeId is null && cip.ForestBeatId is null && cip.ForestFcvVcfId is null)
                {
                    continue;
                }
            }


            //var civil_division = DataRowHelper.GetStringValue(row, "Division").Trim();
            //var civil_district = "";//DataRowHelper.GetStringValue(row, "District").Trim();
            var upazilla = DataRowHelper.GetStringValue(row, "Name of Upazila")?.Trim();
            var union = DataRowHelper.GetStringValue(row, "Name of Union")?.Trim();

            if (string.IsNullOrEmpty(union) == false)
            {
                /*
                var civil_div = await _writeOnlyCtx.Set<Division>()
                    .FromSqlRaw($"select * from \"GS\".\"Division\" e where e.\"DivisionName\" ilike '%{civil_division}%'")
                    .FirstOrDefaultAsync();
                if (civil_div is null)
                {
                    skippedList.Add((sl, civil_division, $"Division '{civil_division}' is not found in DB"));
                    //continue;
                }

                var civil_dis = await _writeOnlyCtx.Set<District>()
                    .FromSqlRaw($"select * from \"GS\".\"District\" e where e.\"Name\" ilike '%{civil_district}%'")
                    .FirstOrDefaultAsync();
                if (civil_dis is null)
                {
                    skippedList.Add((sl, civil_district, $"District '{civil_district}' is not found in DB"));
                    //continue;
                }
                */

                var civil_upazilla = await _writeOnlyCtx.Set<Upazilla>()
                    .FromSqlRaw($"select * from \"GS\".\"Upazilla\" e where e.\"Name\" ilike '%{upazilla}%'")
                    .FirstOrDefaultAsync();
                if (civil_upazilla is null)
                {
                    skippedList.Add((sl, upazilla, $"Upazilla '{upazilla}' is not found in DB"));
                    //continue;
                }

                var civil_union = await _writeOnlyCtx.Set<Union>()
                    .FromSqlRaw($"select * from \"GS\".\"Union\" e where e.\"Name\" ilike '%{union}%'")
                    .FirstOrDefaultAsync();

                /*
                if (civil_union is null)
                {
                    var new_union = new Union
                    {
                        Name = union,
                        NameBn = union,
                        UpazillaId = civil_upazilla.Id
                    };
                    _writeOnlyCtx.Set<Union>().Add(new_union);
                    await _writeOnlyCtx.SaveChangesAsync();

                    civil_union = new_union;
                }
                */

                //cip.DivisionId = civil_div?.Id;
                //cip.DistrictId = civil_dis?.Id;
                cip.UpazillaId = civil_upazilla?.Id;
                cip.UnionId = civil_union?.Id;
            }

            cip.ForestVillageName = DataRowHelper.GetStringValue(row, "Village/Para");
            cip.HouseholdSerialNo = DataRowHelper.GetStringValue(row, "House Number (as given in Social Map)");
            cip.BeneficiaryName = DataRowHelper.GetStringValue(row, "Name of Beneficiary/Name of HH Head");

            // WARNING: Change data if necessary
            cip.NgoId = 6;

            var gender = DataRowHelper.GetStringValue(row, "Sex")?.Trim();
            if (gender is not null)
            {
                cip.Gender = gender.Equals("Male", StringComparison.InvariantCultureIgnoreCase) ? Gender.Male : Gender.Female;
            }
            cip.FatherOrSpouseName = DataRowHelper.GetStringValue(row, "Father/Spouse");

            /*
            var ethnicity = DataRowHelper.GetStringValue(row, "Ethnicity")?.Trim() ?? "-";
            var eth = await _writeOnlyCtx
                .Set<Ethnicity>()
                .FromSqlRaw($"select * from \"BEN\".\"Ethnicitys\" e where e.\"Name\" like '%${ethnicity}%'")
                .FirstOrDefaultAsync();

            cip.EthnicityId = ethnicity.Equals("-", StringComparison.InvariantCultureIgnoreCase) ? null : eth == null ? null : eth.Id;
            */
            cip.NID = DataRowHelper.GetStringValue(row, "NID");
            cip.MobileNumber = DataRowHelper.GetStringValue(row, "Mobile Number");

            var house_type = DataRowHelper.GetStringValue(row, "Type of House");

            cip.TypeOfHouse = house_type;

            if (house_type is not null)
            {
                if (house_type.Equals("Semi-Temporary", StringComparison.InvariantCultureIgnoreCase))
                {
                    cip.HouseType = CIPHouseType.SemiTemporary;
                }
                if (house_type.Equals("Semi Temporary", StringComparison.InvariantCultureIgnoreCase))
                {
                    cip.HouseType = CIPHouseType.SemiTemporary;
                }
                if (house_type.Equals("Temporary", StringComparison.InvariantCultureIgnoreCase))
                {
                    cip.HouseType = CIPHouseType.Temporary;
                }
                if (house_type.Equals("Permanent", StringComparison.InvariantCultureIgnoreCase))
                {
                    cip.HouseType = CIPHouseType.Permanent;
                }
                if (house_type.Equals("Semi-Permanent", StringComparison.InvariantCultureIgnoreCase))
                {
                    cip.HouseType = CIPHouseType.SemiPermanent;
                }
            }

            var wealth = DataRowHelper.GetStringValue(row, "Category");
            if (wealth is not null)
            {
                if (wealth.Equals("Middle Class", StringComparison.InvariantCultureIgnoreCase))
                {
                    cip.CipWealth = CipWealth.Middle;
                }
                else if (wealth.Equals("Poor", StringComparison.InvariantCultureIgnoreCase))
                {
                    cip.CipWealth = CipWealth.Poor;
                }
                else if (wealth.Equals("Rich", StringComparison.InvariantCultureIgnoreCase))
                {
                    cip.CipWealth = CipWealth.Rich;
                }
                else if (wealth.Equals("Ultra Poor", StringComparison.InvariantCultureIgnoreCase))
                {
                    cip.CipWealth = CipWealth.ExtremePoor;
                }
            }

            cipList.Add(cip);
        }

        await _writeOnlyCtx.Set<Cip>().AddRangeAsync(cipList);
        await _writeOnlyCtx.SaveChangesAsync();
        await transaction.CommitAsync();

        var skippedListJsonFormat = skippedList
            .Select(x => new
            {
                SerialNo = x.Item1,
                Value = x.Item2,
                Message = x.Item3
            })
            .DistinctBy(x => x.Value)
            .ToList();

        await System.IO.File.WriteAllTextAsync($"D:\\sufl_assets\\_Data_\\NGO_Porshika\\{Path.GetFileName(filePath)}.json", System.Text.Json.JsonSerializer.Serialize(skippedListJsonFormat, new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true,
        }));

        return Ok($"Completed. Skipped: {skippedList.Count}");
    }
}

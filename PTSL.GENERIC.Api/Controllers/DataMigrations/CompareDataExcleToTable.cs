using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Beneficiary;
using System;
using System.IO;
using System.Text;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class CompareDataExcleToTable : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public CompareDataExcleToTable(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("compare-data-excle-to-table/{shouldMigrate}")]
    public async Task<IActionResult> CompareDivDisUpaUnion([FromRoute] bool shouldMigrate, IFormFile excelFile)
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

            DataTable dt = new DataTable();

            var command = $"SELECT * From [uni_all$]";

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
            var skippedList = new List<ValueTuple<double, string, string>>();


            //Upazila
            List<string> upazillaNameList = new List<string>();
            foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
            {
                var div_name = row.Field<string>("div_name")?.Trim();
                var dist_name = row.Field<string>("dist_name")?.Trim();
                var upz_name = row.Field<string>("upz_name")?.Trim();
                var uni_name = row.Field<string>("uni_name")?.Trim();
                upazillaNameList.Add(upz_name);
            }

            var UpazillaNameDataBase = _writeOnlyCtx
                 .Set<Upazilla>().ToList();
            var notFoundUpazilla = new List<string>();
            foreach (var item in UpazillaNameDataBase)
            {
                var name = upazillaNameList.Exists(x=>x.ToLower() == item.Name.ToLower());
                if (name != true)
                {
                    notFoundUpazilla.Add(item.Name);
                }
            }



            //Division
            List<string> divisionNameList = new List<string>();
            foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
            {
                var div_name = row.Field<string>("div_name")?.Trim();
                divisionNameList.Add(div_name);
            }

            var DivisionNameDataBase = _writeOnlyCtx
              .Set<Division>().ToList();
            var notFoundDivision = new List<string>();
            foreach (var item in DivisionNameDataBase)
            {
                var name = divisionNameList.Exists(x => x.ToLower() == item.Name.ToLower());
                if (name != true)
                {
                    notFoundDivision.Add(item.Name);
                }
            }

            //District
            List<string> districtNameList = new List<string>();
            foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
            {
                var dist_name = row.Field<string>("dist_name")?.Trim();
                districtNameList.Add(dist_name);
            }

            var DistrictNameDataBase = _writeOnlyCtx
              .Set<District>().ToList();
            var notFoundDistrict = new List<string>();
            foreach (var item in DistrictNameDataBase)
            {
                var name = districtNameList.Exists(x => x.ToLower() == item.Name.ToLower());
                if (name != true)
                {
                    notFoundDistrict.Add(item.Name);
                }
            }



            //Union
            List<string> unionNameList = new List<string>();
            foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
            {
                var uni_name = row.Field<string>("uni_name")?.Trim();
                unionNameList.Add(uni_name);
            }

            var UnionNameDataBase = _writeOnlyCtx
              .Set<Union>().ToList();
            var notFoundUnion = new List<string>();
            foreach (var item in UnionNameDataBase)
            {
                var name = unionNameList.Exists(x => x?.ToLower() == item?.Name?.ToLower());
                if (name != true)
                {
                    notFoundUnion.Add(item.Name);
                }
            }








            //if (shouldMigrate)
            //{
            //    await _writeOnlyCtx.Set<Cip>().AddRangeAsync(cipList);
            //    await _writeOnlyCtx.SaveChangesAsync();
            //    await transaction.CommitAsync();
            //}

            //var skippedListJsonFormat = skippedList
            //    .Select(x => new
            //    {
            //        SerialNo = x.Item1,
            //        Value = x.Item2,
            //        Message = x.Item3
            //    })
            //    .DistinctBy(x => x.Value)
            //    .ToList();

            //if (skippedListJsonFormat.Count > 0)
            //{
            //    return Ok(skippedListJsonFormat);
            //}

            return Ok(new List<object>()
            {
                new
                {
                    SerialNo = 0,
                    Value = "",
                    Message = "All ok",
                    Data = notFoundUnion.Distinct().ToList()
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




using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Services.Implementation.Migrations;

namespace PTSL.GENERIC.Web.Core.Controllers.Migrations;

public class MigrationController : Controller
{
    private readonly MigrationService _migrationService = new();

    public MigrationController()
    {
    }

    public IActionResult Migrate()
    {
        ViewBag.MigrateType = new SelectList(EnumHelper.GetEnumDropdowns<MigrateType>(), "Id", "Name");

        return View();
    }

    public async Task<IActionResult> MigratePost([FromForm] IFormFile excelFile, [FromForm] MigrateType migrateType, [FromForm] bool shouldMigrate)
    {
        var result = migrateType switch
        {
            MigrateType.Meeting => await _migrationService.MeetingMigration(excelFile, shouldMigrate),
            MigrateType.AIG => await _migrationService.AIGDataMigration(excelFile, shouldMigrate),
            MigrateType.CIP => await _migrationService.CIPDataMigration(excelFile, shouldMigrate),
            MigrateType.CommunityTraining => await _migrationService.CommunityTraining(excelFile, shouldMigrate),
            MigrateType.Committee => await _migrationService.CommitteeMigration(excelFile, shouldMigrate),
            MigrateType.Patrolling => await _migrationService.PatrollingMigration(excelFile, shouldMigrate),
            MigrateType.Labor => await _migrationService.LaborMigration(excelFile, shouldMigrate),
            MigrateType.TransactionOnCdf => await _migrationService.TransactionOnCdfMigration(excelFile, shouldMigrate),
            MigrateType.IndividualLDF => await _migrationService.IndividualLDF(excelFile, shouldMigrate),

            _ => throw new NotImplementedException(),
        };

        return Ok(result);
    }
}

public enum MigrateType
{
    Meeting = 1,
    AIG = 2,
    CIP = 3,
    [Display(Name = "Community Training")]
    CommunityTraining = 4,
    Committee = 5,
    Patrolling = 6,
    Labor = 7,
    TransactionOnCdf = 8,
    [Display(Name = "Individual LDF")]
    IndividualLDF,
}

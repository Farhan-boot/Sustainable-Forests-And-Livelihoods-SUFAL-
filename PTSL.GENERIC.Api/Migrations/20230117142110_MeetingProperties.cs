using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.GENERIC.Api.Migrations
{
    public partial class MeetingProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                schema: "Meeting",
                table: "Meetings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                schema: "Meeting",
                table: "Meetings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MemberAddress",
                schema: "Meeting",
                table: "MeetingMembers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                schema: "Meeting",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "StartTime",
                schema: "Meeting",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "MemberAddress",
                schema: "Meeting",
                table: "MeetingMembers");
        }
    }
}

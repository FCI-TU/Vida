using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vida.Persistence.Store.Migrations
{
    /// <inheritdoc />
    public partial class AddEventAndEventRegistrationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_AspNetUsers_AppUserId1",
                table: "EventRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_AppUserId1",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "EventRegistrations");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Events",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EventDate",
                table: "Events",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "EventRegistrations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_AppUserId",
                table: "EventRegistrations",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_AspNetUsers_AppUserId",
                table: "EventRegistrations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_AspNetUsers_AppUserId",
                table: "EventRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_AppUserId",
                table: "EventRegistrations");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Events",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "EventDate",
                table: "Events",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "EventRegistrations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "EventRegistrations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_AppUserId1",
                table: "EventRegistrations",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_AspNetUsers_AppUserId1",
                table: "EventRegistrations",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

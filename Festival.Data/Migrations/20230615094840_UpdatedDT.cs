using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalHue.Data.Migrations
{
    public partial class UpdatedDT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 15, 16, 48, 39, 622, DateTimeKind.Local).AddTicks(2075));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 15, 16, 48, 39, 622, DateTimeKind.Local).AddTicks(2087));

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "IdSchedule", "CreatedDate", "Description", "Name", "TicketId" },
                values: new object[] { 1, new DateTime(2023, 6, 15, 16, 48, 39, 622, DateTimeKind.Local).AddTicks(2159), "Ok", "Star Hotel-Le Hoi Duong Pho", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "IdSchedule",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 15, 11, 0, 51, 395, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 15, 11, 0, 51, 395, DateTimeKind.Local).AddTicks(6541));
        }
    }
}

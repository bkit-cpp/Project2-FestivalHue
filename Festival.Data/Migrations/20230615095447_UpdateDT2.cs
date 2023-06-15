using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalHue.Data.Migrations
{
    public partial class UpdateDT2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 15, 16, 54, 46, 945, DateTimeKind.Local).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 15, 16, 54, 46, 945, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "IdSchedule",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 15, 16, 54, 46, 945, DateTimeKind.Local).AddTicks(9987));

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "IdVe", "Name", "Price" },
                values: new object[] { 2, "GheA2", 500000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "IdVe",
                keyValue: 2);

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

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "IdSchedule",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 15, 16, 48, 39, 622, DateTimeKind.Local).AddTicks(2159));
        }
    }
}

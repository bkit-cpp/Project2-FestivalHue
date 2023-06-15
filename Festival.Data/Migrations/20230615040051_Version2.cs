using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalHue.Data.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "status" },
                values: new object[] { new DateTime(2023, 6, 15, 11, 0, 51, 395, DateTimeKind.Local).AddTicks(6526), 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "status" },
                values: new object[] { new DateTime(2023, 6, 15, 11, 0, 51, 395, DateTimeKind.Local).AddTicks(6541), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "status" },
                values: new object[] { new DateTime(2023, 6, 15, 10, 53, 56, 338, DateTimeKind.Local).AddTicks(413), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "status" },
                values: new object[] { new DateTime(2023, 6, 15, 10, 53, 56, 338, DateTimeKind.Local).AddTicks(423), 0 });
        }
    }
}

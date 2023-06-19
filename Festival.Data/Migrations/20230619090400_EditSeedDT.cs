using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalHue.Data.Migrations
{
    public partial class EditSeedDT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 19, 16, 3, 59, 838, DateTimeKind.Local).AddTicks(1464));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 19, 16, 3, 59, 838, DateTimeKind.Local).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "IdSchedule",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 19, 16, 3, 59, 838, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "IdVe",
                keyValue: 1,
                column: "SeoDescription",
                value: "Đây là vé hạng thương gia");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "IdVe",
                keyValue: 2,
                column: "SeoDescription",
                value: "Đây là vé hạng phổ thông ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "Tickets");

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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalHue.Data.Migrations
{
    public partial class AddContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Schedules",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "798a1f4a-f899-461f-8a4f-c3d54da021a5");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a6fe49d1-8030-4686-958a-3be5afe2cb72", "AQAAAAEAACcQAAAAEICBxhTQxut7WKChbG/gy31j1hDLoY+PbPy4LcdL9dxsD243Yyno+UYk27sTyaE3Gw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 5, 22, 36, 6, 458, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 5, 22, 36, 6, 458, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "CreatedDate", "EndedDate" },
                values: new object[] { "Day la Mot Chuyen Di thu Vi", new DateTime(2023, 7, 5, 22, 36, 6, 458, DateTimeKind.Local).AddTicks(1936), new DateTime(2023, 7, 5, 22, 36, 6, 458, DateTimeKind.Local).AddTicks(1935) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "CreatedDate", "EndedDate" },
                values: new object[] { "Day la Mot Chuyen Di Tuyet Voi", new DateTime(2023, 7, 5, 22, 36, 6, 458, DateTimeKind.Local).AddTicks(1939), new DateTime(2023, 7, 5, 22, 36, 6, 458, DateTimeKind.Local).AddTicks(1938) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Schedules");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d12c8c59-ec66-4781-bf91-2c8e8b668c6f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98984b37-9b6f-4474-a7a3-1106ef4b2325", "AQAAAAEAACcQAAAAEBO/u4SPZyFpRhidLXYuuo0KlzJIbaqmhN5p3NOSir+vDc3esmF88TsK4EkwccE+Dw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 30, 14, 39, 34, 66, DateTimeKind.Local).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 30, 14, 39, 34, 66, DateTimeKind.Local).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndedDate" },
                values: new object[] { new DateTime(2023, 6, 30, 14, 39, 34, 66, DateTimeKind.Local).AddTicks(6394), new DateTime(2023, 6, 30, 14, 39, 34, 66, DateTimeKind.Local).AddTicks(6393) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndedDate" },
                values: new object[] { new DateTime(2023, 6, 30, 14, 39, 34, 66, DateTimeKind.Local).AddTicks(6397), new DateTime(2023, 6, 30, 14, 39, 34, 66, DateTimeKind.Local).AddTicks(6396) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalHue.Data.Migrations
{
    public partial class Seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a572901f-6dd9-47fa-b0e7-6352602b505c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7202517a-c42e-41e8-af2d-7bf9a28c803d", "AQAAAAEAACcQAAAAEPpbye5SyvOkUx5hRLWFfF4fPg0tNgRQupkAIS9W7j5aXVZQH/k2tdkJ/WrxCIopTw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 10, 6, 0, 796, DateTimeKind.Local).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 10, 6, 0, 796, DateTimeKind.Local).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndedDate" },
                values: new object[] { new DateTime(2023, 6, 28, 10, 6, 0, 796, DateTimeKind.Local).AddTicks(8076), new DateTime(2023, 6, 28, 10, 6, 0, 796, DateTimeKind.Local).AddTicks(8075) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndedDate" },
                values: new object[] { new DateTime(2023, 6, 28, 10, 6, 0, 796, DateTimeKind.Local).AddTicks(8079), new DateTime(2023, 6, 28, 10, 6, 0, 796, DateTimeKind.Local).AddTicks(8078) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b7d95c8b-25fb-484c-850d-4565b12e5cac");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0736c6e7-b52e-423f-8f4c-332b3fad1f96", "AQAAAAEAACcQAAAAEOi8A2xGacZV1RqesMhXhfJ8wXOo1ajeRRc25NyMQGR0jyeZSN/+x7KqPnnmYb+LXA==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 27, 23, 14, 23, 81, DateTimeKind.Local).AddTicks(54));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 27, 23, 14, 23, 81, DateTimeKind.Local).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndedDate" },
                values: new object[] { new DateTime(2023, 6, 27, 23, 14, 23, 81, DateTimeKind.Local).AddTicks(96), new DateTime(2023, 6, 27, 23, 14, 23, 81, DateTimeKind.Local).AddTicks(95) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndedDate" },
                values: new object[] { new DateTime(2023, 6, 27, 23, 14, 23, 81, DateTimeKind.Local).AddTicks(98), new DateTime(2023, 6, 27, 23, 14, 23, 81, DateTimeKind.Local).AddTicks(97) });
        }
    }
}

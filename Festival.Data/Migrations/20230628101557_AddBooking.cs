using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalHue.Data.Migrations
{
    public partial class AddBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a5df5f66-a46e-46b3-9b54-12ae84eccc1c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee45f566-1b46-4541-9250-ff3d3a1d0462", "AQAAAAEAACcQAAAAELOTi3eMaez7G7FjD4TGcJJB/KWvQubLFNK8hwWN21WiPd/1H3iqBFE90q/dZE4Smw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 17, 15, 56, 472, DateTimeKind.Local).AddTicks(9944));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 17, 15, 56, 472, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndedDate" },
                values: new object[] { new DateTime(2023, 6, 28, 17, 15, 56, 473, DateTimeKind.Local).AddTicks(8), new DateTime(2023, 6, 28, 17, 15, 56, 473, DateTimeKind.Local).AddTicks(7) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndedDate" },
                values: new object[] { new DateTime(2023, 6, 28, 17, 15, 56, 473, DateTimeKind.Local).AddTicks(10), new DateTime(2023, 6, 28, 17, 15, 56, 473, DateTimeKind.Local).AddTicks(9) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsBooked",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsBooked",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Tickets");

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
    }
}

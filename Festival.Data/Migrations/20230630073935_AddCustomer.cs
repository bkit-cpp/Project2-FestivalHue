using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalHue.Data.Migrations
{
    public partial class AddCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "IdCustomer", "Address", "City", "Name", "UserId" },
                values: new object[] { 1, "Quan 12", "HCMC", "LebaKhai", new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "IdCustomer",
                keyValue: 1);

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
        }
    }
}

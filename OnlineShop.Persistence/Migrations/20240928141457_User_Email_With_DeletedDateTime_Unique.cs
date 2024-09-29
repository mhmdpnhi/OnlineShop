using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class User_Email_With_DeletedDateTime_Unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 28, 17, 44, 47, 264, DateTimeKind.Local).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 28, 17, 44, 47, 264, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 28, 17, 44, 47, 264, DateTimeKind.Local).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 28, 17, 44, 47, 264, DateTimeKind.Local).AddTicks(5989));

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_DeleteDateTime",
                table: "Users",
                columns: new[] { "Email", "DeleteDateTime" },
                unique: true,
                filter: "[DeleteDateTime] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email_DeleteDateTime",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 28, 14, 6, 59, 623, DateTimeKind.Local).AddTicks(8518));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 28, 14, 6, 59, 623, DateTimeKind.Local).AddTicks(9085));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 28, 14, 6, 59, 623, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 28, 14, 6, 59, 623, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }
    }
}

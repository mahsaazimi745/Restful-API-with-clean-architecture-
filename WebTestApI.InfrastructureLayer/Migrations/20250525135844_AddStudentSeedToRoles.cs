using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTestApI.InfrastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentSeedToRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RuleName" },
                values: new object[] { new Guid("6a942f50-33ea-4b18-8041-65b11422f1f5"), "Student" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6a942f50-33ea-4b18-8041-65b11422f1f5"));
        }
    }
}

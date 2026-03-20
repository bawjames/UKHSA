using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UKHSA.Migrations
{
    /// <inheritdoc />
    public partial class _0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Requests",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Approvals",
                newName: "Timestamp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Requests",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Approvals",
                newName: "DateTime");
        }
    }
}

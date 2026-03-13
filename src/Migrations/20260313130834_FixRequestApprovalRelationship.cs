using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UKHSA.Migrations
{
    /// <inheritdoc />
    public partial class FixRequestApprovalRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Approvals_ApprovalId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ApprovalId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Approvals_RequestId",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "ApprovalId",
                table: "Requests");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_RequestId",
                table: "Approvals",
                column: "RequestId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Approvals_RequestId",
                table: "Approvals");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalId",
                table: "Requests",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ApprovalId",
                table: "Requests",
                column: "ApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_RequestId",
                table: "Approvals",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Approvals_ApprovalId",
                table: "Requests",
                column: "ApprovalId",
                principalTable: "Approvals",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseManagementPortal.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationContact_LoginUser",
                schema: "Reseller",
                table: "OrganizationContact");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationContact_LoginUserId",
                schema: "Reseller",
                table: "OrganizationContact");

            migrationBuilder.AlterColumn<string>(
                name: "LoginUserId",
                schema: "Reseller",
                table: "OrganizationContact",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationContact_LoginUserId",
                schema: "Reseller",
                table: "OrganizationContact",
                column: "LoginUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationContact_LoginUser",
                schema: "Reseller",
                table: "OrganizationContact",
                column: "LoginUserId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationContact_LoginUser",
                schema: "Reseller",
                table: "OrganizationContact");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationContact_LoginUserId",
                schema: "Reseller",
                table: "OrganizationContact");

            migrationBuilder.AlterColumn<string>(
                name: "LoginUserId",
                schema: "Reseller",
                table: "OrganizationContact",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationContact_LoginUserId",
                schema: "Reseller",
                table: "OrganizationContact",
                column: "LoginUserId",
                unique: true,
                filter: "[LoginUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationContact_LoginUser",
                schema: "Reseller",
                table: "OrganizationContact",
                column: "LoginUserId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

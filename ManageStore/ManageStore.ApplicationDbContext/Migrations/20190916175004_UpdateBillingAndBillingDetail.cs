using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageStore.ApplicationDbContext.Migrations
{
    public partial class UpdateBillingAndBillingDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetails_Users_CreatedById",
                table: "BillingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetails_Users_ModifiedById",
                table: "BillingDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillingDetails_CreatedById",
                table: "BillingDetails");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "BillingDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "BillingDetails");

            migrationBuilder.DropColumn(
                name: "ModifieDateTime",
                table: "BillingDetails");

            migrationBuilder.DropColumn(
                name: "RegisterStatus",
                table: "BillingDetails");

            migrationBuilder.RenameColumn(
                name: "ModifiedById",
                table: "BillingDetails",
                newName: "BillingId1");

            migrationBuilder.RenameIndex(
                name: "IX_BillingDetails_ModifiedById",
                table: "BillingDetails",
                newName: "IX_BillingDetails_BillingId1");

            migrationBuilder.AlterColumn<string>(
                name: "VoucherNumber",
                table: "Billings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetails_Billings_BillingId1",
                table: "BillingDetails",
                column: "BillingId1",
                principalTable: "Billings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetails_Billings_BillingId1",
                table: "BillingDetails");

            migrationBuilder.RenameColumn(
                name: "BillingId1",
                table: "BillingDetails",
                newName: "ModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_BillingDetails_BillingId1",
                table: "BillingDetails",
                newName: "IX_BillingDetails_ModifiedById");

            migrationBuilder.AlterColumn<int>(
                name: "VoucherNumber",
                table: "Billings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "BillingDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "BillingDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieDateTime",
                table: "BillingDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegisterStatus",
                table: "BillingDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetails_CreatedById",
                table: "BillingDetails",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetails_Users_CreatedById",
                table: "BillingDetails",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetails_Users_ModifiedById",
                table: "BillingDetails",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

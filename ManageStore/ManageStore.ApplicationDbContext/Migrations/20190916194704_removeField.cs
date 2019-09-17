using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageStore.ApplicationDbContext.Migrations
{
    public partial class removeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetails_Billings_BillingId1",
                table: "BillingDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillingDetails_BillingId1",
                table: "BillingDetails");

            migrationBuilder.DropColumn(
                name: "BillingId1",
                table: "BillingDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillingId1",
                table: "BillingDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetails_BillingId1",
                table: "BillingDetails",
                column: "BillingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetails_Billings_BillingId1",
                table: "BillingDetails",
                column: "BillingId1",
                principalTable: "Billings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

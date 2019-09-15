using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageStore.ApplicationDbContext.Migrations
{
    public partial class AddInitialTables_Products_Billing_BillingDetail_Users_and_ProductLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    LastName = table.Column<string>(maxLength: 80, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    RegisterStatus = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    ModifieDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Billing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VoucherNumber = table.Column<int>(nullable: false),
                    ReceiptType = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(maxLength: 80, nullable: false),
                    CustomerLastName = table.Column<string>(maxLength: 80, nullable: false),
                    RegisterStatus = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    ModifieDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Billing_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Billing_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    RegisterStatus = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    ModifieDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillingDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillingId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    RegisterStatus = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    ModifieDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingDetail_Billing_BillingId",
                        column: x => x.BillingId,
                        principalTable: "Billing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillingDetail_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillingDetail_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillingDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NewPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    RegisterStatus = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    ModifieDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLogs_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLogs_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLogs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Billing_CreatedById",
                table: "Billing",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Billing_ModifiedById",
                table: "Billing",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetail_BillingId",
                table: "BillingDetail",
                column: "BillingId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetail_CreatedById",
                table: "BillingDetail",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetail_ModifiedById",
                table: "BillingDetail",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetail_ProductId",
                table: "BillingDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLogs_CreatedById",
                table: "ProductLogs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLogs_ModifiedById",
                table: "ProductLogs",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLogs_ProductId",
                table: "ProductLogs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModifiedById",
                table: "Products",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedById",
                table: "Users",
                column: "ModifiedById",
                unique: true,
                filter: "[ModifiedById] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingDetail");

            migrationBuilder.DropTable(
                name: "ProductLogs");

            migrationBuilder.DropTable(
                name: "Billing");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

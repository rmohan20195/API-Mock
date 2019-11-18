using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capredv2.backend.domain.DataContexts.CapRedV2SQLContext.Migrations
{
    public partial class PO_NewTables_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.CreateTable(
                name: "PurchaseOrderHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    PurchaseOrderNumber = table.Column<string>(nullable: true),
                    ShippingAddress = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: true),
                    OrderTotal = table.Column<double>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    AccountingTotalCurrency = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeaders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLineItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    AccountingTotal = table.Column<double>(nullable: true),
                    ProjectDescription = table.Column<string>(nullable: true),
                    Commodity = table.Column<string>(nullable: true),
                    CostCode = table.Column<string>(nullable: true),
                    FixedAsset = table.Column<string>(nullable: true),
                    TargetLocationCode = table.Column<string>(nullable: true),
                    ShipTo = table.Column<string>(nullable: true),
                    RequestedBy = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    POHeaderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderLineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLineItems_PurchaseOrderHeaders_POHeaderId",
                        column: x => x.POHeaderId,
                        principalTable: "PurchaseOrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderHeaders_ProjectId",
                table: "PurchaseOrderHeaders",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLineItems_POHeaderId",
                table: "PurchaseOrderLineItems",
                column: "POHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderLineItems");

            migrationBuilder.DropTable(
                name: "PurchaseOrderHeaders");

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    AccountingTotal = table.Column<double>(nullable: false),
                    AccountingTotalCurrency = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderTotal = table.Column<double>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    PurchaseOrderNumber = table.Column<int>(nullable: false),
                    Supplier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ProjectId",
                table: "PurchaseOrders",
                column: "ProjectId");
        }
    }
}

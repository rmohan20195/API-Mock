using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capredv2.backend.domain.DataContexts.CapRedV2SQLContext.Migrations
{
    public partial class InvoiceEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_CoupaImporterJodDefinitions_ProjectId",
                table: "CoupaImporterJodDefinitions");

            migrationBuilder.CreateTable(
                name: "InvoiceHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    Supplier = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    AccountingTotalCurrency = table.Column<string>(nullable: true),
                    Billing = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceHeaders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLineItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    TotalTax = table.Column<double>(nullable: false),
                    AccountingTotal = table.Column<double>(nullable: false),
                    ProjectDescription = table.Column<string>(nullable: true),
                    Commodity = table.Column<string>(nullable: true),
                    WorkflowCode = table.Column<string>(nullable: true),
                    PONumber = table.Column<double>(nullable: false),
                    RequestedBy = table.Column<string>(nullable: true),
                    TargetLocationCode = table.Column<string>(nullable: true),
                    POShipToCity = table.Column<string>(nullable: true),
                    POShipToCountry = table.Column<string>(nullable: true),
                    POShipToName = table.Column<string>(nullable: true),
                    CurrentApprover = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Paid = table.Column<string>(nullable: true),
                    PaymentNotes = table.Column<string>(nullable: true),
                    LocalPaymentDate = table.Column<DateTime>(nullable: false),
                    ReqNumber = table.Column<int>(nullable: false),
                    ReqLineNumber = table.Column<int>(nullable: false),
                    ReqLineTotal = table.Column<int>(nullable: false),
                    POLineTotal = table.Column<int>(nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItems_InvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "InvoiceHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoupaImporterJodDefinitions_ProjectId",
                table: "CoupaImporterJodDefinitions",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_ProjectId",
                table: "InvoiceHeaders",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItems_InvoiceHeaderId",
                table: "InvoiceLineItems",
                column: "InvoiceHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLineItems");

            migrationBuilder.DropTable(
                name: "InvoiceHeaders");

            migrationBuilder.DropIndex(
                name: "IX_CoupaImporterJodDefinitions_ProjectId",
                table: "CoupaImporterJodDefinitions");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    LocalPaymentDate = table.Column<DateTime>(nullable: true),
                    Paid = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    PurchaseOrderNumber = table.Column<long>(nullable: true),
                    ReceivedOrCreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Supplier = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoupaImporterJodDefinitions_ProjectId",
                table: "CoupaImporterJodDefinitions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId");
        }
    }
}

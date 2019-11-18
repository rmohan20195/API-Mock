using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capredv2.backend.domain.DataContexts.CapRedV2SQLContext.Migrations
{
    public partial class Requisition_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requisitions");

            migrationBuilder.CreateTable(
                name: "RequisitionHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    RequisitionNumber = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    PurchaseOrderNumber = table.Column<int>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitionHeaders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionLineItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RequisitionLineNumber = table.Column<int>(nullable: false),
                    OrderTotal = table.Column<double>(nullable: true),
                    ReportingTotal = table.Column<double>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    CostCode = table.Column<string>(nullable: true),
                    ProjectDescription = table.Column<string>(nullable: true),
                    TargetLocationCode = table.Column<string>(nullable: true),
                    ShipToAddressName = table.Column<string>(nullable: true),
                    RequestedBy = table.Column<string>(nullable: true),
                    CurrentApprover = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    RequisitionHeaderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionLineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitionLineItems_RequisitionHeaders_RequisitionHeaderId",
                        column: x => x.RequisitionHeaderId,
                        principalTable: "RequisitionHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionHeaders_ProjectId",
                table: "RequisitionHeaders",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionLineItems_RequisitionHeaderId",
                table: "RequisitionLineItems",
                column: "RequisitionHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequisitionLineItems");

            migrationBuilder.DropTable(
                name: "RequisitionHeaders");

            migrationBuilder.CreateTable(
                name: "Requisitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    OrderTotal = table.Column<double>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    PurchaseOrderNumber = table.Column<int>(nullable: false),
                    ReportingTotal = table.Column<double>(nullable: false),
                    RequisitionNumber = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Supplier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisitions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_ProjectId",
                table: "Requisitions",
                column: "ProjectId");
        }
    }
}

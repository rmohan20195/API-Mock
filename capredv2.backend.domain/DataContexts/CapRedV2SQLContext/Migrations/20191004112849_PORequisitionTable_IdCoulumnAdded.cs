using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capredv2.backend.domain.DataContexts.CapRedV2SQLContext.Migrations
{
    public partial class PORequisitionTable_IdCoulumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Requisitions",
                table: "Requisitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseOrders",
                table: "PurchaseOrders");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Requisitions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PurchaseOrders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requisitions",
                table: "Requisitions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseOrders",
                table: "PurchaseOrders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_ProjectId",
                table: "Requisitions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ProjectId",
                table: "PurchaseOrders",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Requisitions",
                table: "Requisitions");

            migrationBuilder.DropIndex(
                name: "IX_Requisitions_ProjectId",
                table: "Requisitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseOrders",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_ProjectId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Requisitions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PurchaseOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requisitions",
                table: "Requisitions",
                columns: new[] { "ProjectId", "RequisitionNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseOrders",
                table: "PurchaseOrders",
                columns: new[] { "ProjectId", "PurchaseOrderNumber" });
        }
    }
}

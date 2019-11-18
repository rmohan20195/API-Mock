using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capredv2.backend.domain.DataContexts.CapRedV2SQLContext.Migrations
{
    public partial class ForeignKeyRemovedOfAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CapitalPlans",
                table: "CapitalPlans");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CapitalPlans",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CapitalPlans",
                table: "CapitalPlans",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CapitalPlans_ProjectId",
                table: "CapitalPlans",
                column: "ProjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CapitalPlans",
                table: "CapitalPlans");

            migrationBuilder.DropIndex(
                name: "IX_CapitalPlans_ProjectId",
                table: "CapitalPlans");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CapitalPlans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CapitalPlans",
                table: "CapitalPlans",
                column: "ProjectId");
        }
    }
}

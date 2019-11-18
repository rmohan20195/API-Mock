using Microsoft.EntityFrameworkCore.Migrations;

namespace capredv2.backend.domain.DataContexts.CapRedV2SQLContext.Migrations
{
    public partial class Project_JobDefination_OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoupaImporterJodDefinitions_ProjectId",
                table: "CoupaImporterJodDefinitions");

            migrationBuilder.CreateIndex(
                name: "IX_CoupaImporterJodDefinitions_ProjectId",
                table: "CoupaImporterJodDefinitions",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoupaImporterJodDefinitions_ProjectId",
                table: "CoupaImporterJodDefinitions");

            migrationBuilder.CreateIndex(
                name: "IX_CoupaImporterJodDefinitions_ProjectId",
                table: "CoupaImporterJodDefinitions",
                column: "ProjectId",
                unique: true);
        }
    }
}

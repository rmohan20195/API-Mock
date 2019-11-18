using Microsoft.EntityFrameworkCore.Migrations;

namespace capredv2.backend.domain.DataContexts.CapRedV2SQLContext.Migrations
{
    public partial class FileTypeAddedInCoupaImporterJobDefination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "CoupaImporterJodDefinitions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileType",
                table: "CoupaImporterJodDefinitions");
        }
    }
}

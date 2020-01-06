using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class fighterLevelFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10001,
                column: "Level",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10001,
                column: "Level",
                value: 0);
        }
    }
}

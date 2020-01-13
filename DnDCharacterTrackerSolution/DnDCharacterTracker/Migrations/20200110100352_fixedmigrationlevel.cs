using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class fixedmigrationlevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SubClassFeatures",
                keyColumn: "Id",
                keyValue: 10105,
                column: "Level",
                value: 18);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SubClassFeatures",
                keyColumn: "Id",
                keyValue: 10105,
                column: "Level",
                value: 7);
        }
    }
}

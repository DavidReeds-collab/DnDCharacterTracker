using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class fighterfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10001,
                column: "FK_Class",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10001,
                column: "FK_Class",
                value: 1);
        }
    }
}

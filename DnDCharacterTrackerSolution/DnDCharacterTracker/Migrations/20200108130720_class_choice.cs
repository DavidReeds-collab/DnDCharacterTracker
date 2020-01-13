using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class class_choice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FeatureChoices",
                columns: new[] { "Id", "FK_Choice", "FK_Feature" },
                values: new object[] { 10005, 10005, 10005 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FeatureChoices",
                keyColumn: "Id",
                keyValue: 10005);
        }
    }
}

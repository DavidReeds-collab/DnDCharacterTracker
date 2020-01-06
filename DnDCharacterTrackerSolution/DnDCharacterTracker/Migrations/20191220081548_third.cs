using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RaceProficiencies",
                columns: new[] { "Id", "FK_Proficiency", "FK_Race" },
                values: new object[] { 112, 38, 3 });

            migrationBuilder.InsertData(
                table: "RaceProficiencies",
                columns: new[] { "Id", "FK_Proficiency", "FK_Race" },
                values: new object[] { 113, 40, 3 });

            migrationBuilder.InsertData(
                table: "RaceProficiencies",
                columns: new[] { "Id", "FK_Proficiency", "FK_Race" },
                values: new object[] { 114, 69, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RaceProficiencies",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "RaceProficiencies",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "RaceProficiencies",
                keyColumn: "Id",
                keyValue: 114);
        }
    }
}

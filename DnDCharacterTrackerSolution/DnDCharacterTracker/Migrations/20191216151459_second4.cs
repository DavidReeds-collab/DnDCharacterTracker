using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class second4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RaceRacefeatures",
                columns: new[] { "Id", "FK_Race", "FK_RaceFeature" },
                values: new object[] { 108, 3, 108 });

            migrationBuilder.InsertData(
                table: "RaceRacefeatures",
                columns: new[] { "Id", "FK_Race", "FK_RaceFeature" },
                values: new object[] { 109, 3, 109 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RaceRacefeatures",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "RaceRacefeatures",
                keyColumn: "Id",
                keyValue: 109);
        }
    }
}

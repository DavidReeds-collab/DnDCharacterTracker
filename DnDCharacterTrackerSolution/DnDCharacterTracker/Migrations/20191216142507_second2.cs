using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class second2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "AllowedOptions", "Descriminator" },
                values: new object[] { 2, 4, "RacialProficiency" });

            migrationBuilder.InsertData(
                table: "RaceFeatures",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 108, "You have advantage on Saving Throws against poison, and you have Resistance against poison damage.", "Dwarven Combat Training" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Description", "FK_Choice", "Name", "free" },
                values: new object[,]
                {
                    { 101, null, 2, "Battleaxe", true },
                    { 102, null, 2, "Handaxe", true },
                    { 103, null, 2, "Light Hammer", true },
                    { 104, null, 2, "Warhammer", true }
                });

            migrationBuilder.InsertData(
                table: "RaceFeatureChoices",
                columns: new[] { "Id", "FK_Choice", "FK_RaceFeature" },
                values: new object[] { 108, 2, 108 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "RaceFeatureChoices",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 108);
        }
    }
}

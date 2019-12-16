using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class second3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "AllowedOptions", "Descriminator" },
                values: new object[] { 3, 1, "RacialProficiency" });

            migrationBuilder.InsertData(
                table: "RaceFeatures",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 109, "You gain proficiency with the artisan’s tools of your choice: smith’s tools, brewer’s supplies, or mason’s tools.", "Tool Proficiency" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Description", "FK_Choice", "Name", "free" },
                values: new object[,]
                {
                    { 106, null, 3, "smith’s tools", false },
                    { 107, null, 3, "brewer’s supplies", false },
                    { 108, null, 3, "mason’s tools", false }
                });

            migrationBuilder.InsertData(
                table: "RaceFeatureChoices",
                columns: new[] { "Id", "FK_Choice", "FK_RaceFeature" },
                values: new object[] { 109, 3, 109 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "RaceFeatureChoices",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 109);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class seedingtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubClasses",
                keyColumn: "Id",
                keyValue: 10001);

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 10101, "Beginning when you choose this archetype at 3rd level, your weapon attacks score a critical hit on a roll of 19 or 20.", "Improved Critical" },
                    { 10102, "Starting at 7th level, you can add half your proficiency bonus (rounded up) to any Strength, Dexterity, or Constitution check you make that doesn't already use your proficiency bonus. In addition, when you make a running long jump, the distance you can cover increases by a number of feet equal to your Strength modifier.", "Remarkable Athlete" },
                    { 10104, "Starting at 15th level, your weapon attacks score a critical hit on a roll of 18-20.", "Superior Critical" },
                    { 10105, "At 18th level, you attain the pinnacle of resilience in battle. At the start of each of your turns, you regain hit points equal to 5 + your Constitution modifier if you have no more than half of your hit points left. You don't gain this benefit if you have 0 hit points.", "Survivor" }
                });

            migrationBuilder.InsertData(
                table: "SubClasses",
                columns: new[] { "Id", "CharacterId", "Description", "FK_Class", "Name" },
                values: new object[] { 10101, null, "The archetypal Champion focuses on the development of raw physical power honed to deadly perfection. Those who model themselves on this archetype combine rigorous training with physical excellence to deal devastating blows.", 2, "Champion" });

            migrationBuilder.InsertData(
                table: "SubClassFeatures",
                columns: new[] { "Id", "FK_Feature", "FK_SubClass", "Level" },
                values: new object[,]
                {
                    { 10101, 10101, 10101, 3 },
                    { 10102, 10102, 10101, 7 },
                    { 10103, 10002, 10101, 10 },
                    { 10104, 10104, 10101, 15 },
                    { 10105, 10105, 10101, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubClassFeatures",
                keyColumn: "Id",
                keyValue: 10101);

            migrationBuilder.DeleteData(
                table: "SubClassFeatures",
                keyColumn: "Id",
                keyValue: 10102);

            migrationBuilder.DeleteData(
                table: "SubClassFeatures",
                keyColumn: "Id",
                keyValue: 10103);

            migrationBuilder.DeleteData(
                table: "SubClassFeatures",
                keyColumn: "Id",
                keyValue: 10104);

            migrationBuilder.DeleteData(
                table: "SubClassFeatures",
                keyColumn: "Id",
                keyValue: 10105);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10101);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10102);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10104);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10105);

            migrationBuilder.DeleteData(
                table: "SubClasses",
                keyColumn: "Id",
                keyValue: 10101);

            migrationBuilder.InsertData(
                table: "SubClasses",
                columns: new[] { "Id", "CharacterId", "Description", "FK_Class", "Name" },
                values: new object[] { 10001, null, "The archetypal Champion focuses on the development of raw physical power honed to deadly perfection. Those who model themselves on this archetype combine rigorous training with physical excellence to deal devastating blows.", 2, "Champion" });
        }
    }
}

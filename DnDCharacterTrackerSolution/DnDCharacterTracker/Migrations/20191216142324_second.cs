using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RaceFeatures",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 101, "Your Constitution score increases by 2.", "Ability Score Increase" },
                    { 102, "Dwarves mature at the same rate as Humans, but they’re considered young until they reach the age of 50. On average, they live about 350 years.", "Age" },
                    { 103, "Most Dwarves are lawful, believing firmly in the benefits of a well-ordered society. They tend toward good as well, with a strong sense of Fair Play and a belief that everyone deserves to share in the benefits of a just order.", "Alignment" },
                    { 104, "Dwarves stand between 4 and 5 feet tall and average about 150 pounds. Your size is Medium.", "Size" },
                    { 105, "Your base walking speed is 25 feet. Your speed is not reduced by wearing Heavy Armor.", "Speed" },
                    { 106, "Accustomed to life Underground, you have superior vision in dark and dim Conditions. You can see in dim light within 60 feet of you as if it were bright light, and in Darkness as if it were dim light. You can’t discern color in Darkness, only Shades of Gray.", "Darkvision" },
                    { 107, "You have advantage on Saving Throws against poison, and you have Resistance against poison damage.", "Dwarven Resilience" },
                    { 110, "Whenever you make an Intelligence (History) check related to the Origin of stonework, you are considered proficient in the History skill and add double your Proficiency Bonus to the check, instead of your normal Proficiency Bonus.", "Stonecunning" },
                    { 111, "You can speak, read, and write Common and Dwarvish. Dwarvish is full of hard consonants and guttural sounds, and those characteristics spill over into whatever other language a dwarf might speak.", "Languages" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "Name", "Speed" },
                values: new object[] { 3, "Dwarf", 0 });

            migrationBuilder.InsertData(
                table: "RaceRacefeatures",
                columns: new[] { "Id", "FK_Race", "FK_RaceFeature" },
                values: new object[,]
                {
                    { 101, 3, 101 },
                    { 102, 3, 102 },
                    { 103, 3, 103 },
                    { 104, 3, 104 },
                    { 105, 3, 105 },
                    { 106, 3, 106 },
                    { 107, 3, 107 },
                    { 110, 3, 110 },
                    { 111, 3, 111 }
                });

            migrationBuilder.InsertData(
                table: "raceAbilityScores",
                columns: new[] { "Id", "FK_AbilityScore", "FK_Race", "amount" },
                values: new object[] { -7, 3, 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RaceRacefeatures",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "RaceRacefeatures",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "RaceRacefeatures",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "RaceRacefeatures",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "RaceRacefeatures",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "RaceRacefeatures",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "RaceRacefeatures",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "RaceRacefeatures",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "RaceRacefeatures",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "raceAbilityScores",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

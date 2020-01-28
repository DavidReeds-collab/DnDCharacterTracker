using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class abilityScoreImprovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "AllowedOptions", "Descriminator" },
                values: new object[] { 666666, 2, "AbilityScoreImprovement" });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 666666, "You can increase one ability score of your choice by 2, or you can increase two Ability Scores of your choice by 1. As normal, you can’t increase an ability score above 20 using this feature.", "Ability Score Improvement" });

            migrationBuilder.InsertData(
                table: "ClassFeatures",
                columns: new[] { "Id", "FK_Class", "FK_Feature", "Level" },
                values: new object[] { 10006, 2, 666666, 4 });

            migrationBuilder.InsertData(
                table: "FeatureChoices",
                columns: new[] { "Id", "FK_Choice", "FK_Feature" },
                values: new object[] { 666666, 666666, 666666 });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Description", "FK_Choice", "Name", "free" },
                values: new object[,]
                {
                    { 6666661, null, 666666, "Strenght", false },
                    { 6666662, null, 666666, "Strenght", false },
                    { 6666663, null, 666666, "Dexterity", false },
                    { 6666664, null, 666666, "Dexterity", false },
                    { 6666665, null, 666666, "Constitution", false },
                    { 6666666, null, 666666, "Constitution", false },
                    { 6666667, null, 666666, "Wisdom", false },
                    { 6666668, null, 666666, "Wisdom", false },
                    { 6666669, null, 666666, "Intelligence", false },
                    { 66666610, null, 666666, "Intelligence", false },
                    { 66666611, null, 666666, "Charisma", false },
                    { 66666612, null, 666666, "Charisma", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10006);

            migrationBuilder.DeleteData(
                table: "FeatureChoices",
                keyColumn: "Id",
                keyValue: 666666);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6666661);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6666662);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6666663);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6666664);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6666665);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6666666);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6666667);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6666668);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6666669);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 66666610);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 66666611);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 66666612);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 666666);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 666666);
        }
    }
}

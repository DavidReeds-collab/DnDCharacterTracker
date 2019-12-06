using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class namingfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceFeatureChoices_Proficiencies_FK_Choice",
                table: "RaceFeatureChoices");

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descriminator",
                value: "RacialLanguage");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceFeatureChoices_Choices_FK_Choice",
                table: "RaceFeatureChoices",
                column: "FK_Choice",
                principalTable: "Choices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceFeatureChoices_Choices_FK_Choice",
                table: "RaceFeatureChoices");

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descriminator",
                value: "language");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceFeatureChoices_Proficiencies_FK_Choice",
                table: "RaceFeatureChoices",
                column: "FK_Choice",
                principalTable: "Proficiencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

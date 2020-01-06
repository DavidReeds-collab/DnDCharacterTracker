using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceProficiencies_Character_FK_Race",
                table: "RaceProficiencies");

            migrationBuilder.InsertData(
                table: "RaceProficiencies",
                columns: new[] { "Id", "FK_Proficiency", "FK_Race" },
                values: new object[] { 111, 49, 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_RaceProficiencies_Races_FK_Race",
                table: "RaceProficiencies",
                column: "FK_Race",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceProficiencies_Races_FK_Race",
                table: "RaceProficiencies");

            migrationBuilder.DeleteData(
                table: "RaceProficiencies",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceProficiencies_Character_FK_Race",
                table: "RaceProficiencies",
                column: "FK_Race",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

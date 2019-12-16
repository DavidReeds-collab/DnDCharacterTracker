using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class toolssecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceProficiency_Proficiencies_FK_Proficiency",
                table: "RaceProficiency");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceProficiency_Character_FK_Race",
                table: "RaceProficiency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceProficiency",
                table: "RaceProficiency");

            migrationBuilder.RenameTable(
                name: "RaceProficiency",
                newName: "RaceProficiencies");

            migrationBuilder.RenameIndex(
                name: "IX_RaceProficiency_FK_Race",
                table: "RaceProficiencies",
                newName: "IX_RaceProficiencies_FK_Race");

            migrationBuilder.RenameIndex(
                name: "IX_RaceProficiency_FK_Proficiency",
                table: "RaceProficiencies",
                newName: "IX_RaceProficiencies_FK_Proficiency");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceProficiencies",
                table: "RaceProficiencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceProficiencies_Proficiencies_FK_Proficiency",
                table: "RaceProficiencies",
                column: "FK_Proficiency",
                principalTable: "Proficiencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceProficiencies_Character_FK_Race",
                table: "RaceProficiencies",
                column: "FK_Race",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceProficiencies_Proficiencies_FK_Proficiency",
                table: "RaceProficiencies");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceProficiencies_Character_FK_Race",
                table: "RaceProficiencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceProficiencies",
                table: "RaceProficiencies");

            migrationBuilder.RenameTable(
                name: "RaceProficiencies",
                newName: "RaceProficiency");

            migrationBuilder.RenameIndex(
                name: "IX_RaceProficiencies_FK_Race",
                table: "RaceProficiency",
                newName: "IX_RaceProficiency_FK_Race");

            migrationBuilder.RenameIndex(
                name: "IX_RaceProficiencies_FK_Proficiency",
                table: "RaceProficiency",
                newName: "IX_RaceProficiency_FK_Proficiency");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceProficiency",
                table: "RaceProficiency",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceProficiency_Proficiencies_FK_Proficiency",
                table: "RaceProficiency",
                column: "FK_Proficiency",
                principalTable: "Proficiencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceProficiency_Character_FK_Race",
                table: "RaceProficiency",
                column: "FK_Race",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

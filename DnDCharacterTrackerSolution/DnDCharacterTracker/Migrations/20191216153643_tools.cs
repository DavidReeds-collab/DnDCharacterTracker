using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class tools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RaceProficiency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Race = table.Column<int>(nullable: false),
                    FK_Proficiency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceProficiency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceProficiency_Proficiencies_FK_Proficiency",
                        column: x => x.FK_Proficiency,
                        principalTable: "Proficiencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceProficiency_Character_FK_Race",
                        column: x => x.FK_Race,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 106,
                column: "Name",
                value: "Smith’s tools");

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 107,
                column: "Name",
                value: "Brewer’s supplies");

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 108,
                column: "Name",
                value: "Mason’s tools");

            migrationBuilder.InsertData(
                table: "Proficiencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 87, "Woodcarver’s tools" },
                    { 86, "Weaver’s tools" },
                    { 85, "Tinker’s tools" },
                    { 84, "Smith’s tools" },
                    { 83, "Potter’s tools" },
                    { 82, "Painter’s supplies" },
                    { 81, "Mason’s tools" },
                    { 79, "Jeweler’s tools" },
                    { 80, "Leatherworker’s tools" },
                    { 77, "Cook’s utensils" },
                    { 76, "Cobbler’s tools" },
                    { 75, "Cartographer’s tools" },
                    { 74, "Carpenter’s tools" },
                    { 73, "Calligrapher's Supplies" },
                    { 72, "Brewer’s supplies" },
                    { 71, "Alchemist’s supplies" },
                    { 78, "Glassblower’s tools" }
                });

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 108,
                column: "Description",
                value: " You have proficiency with the Battleaxe, Handaxe, Light Hammer, and Warhammer.");

            migrationBuilder.InsertData(
                table: "RaceProficiency",
                columns: new[] { "Id", "FK_Proficiency", "FK_Race" },
                values: new object[,]
                {
                    { 103, 40, 3 },
                    { 101, 49, 3 },
                    { 102, 38, 3 },
                    { 104, 69, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceProficiency_FK_Proficiency",
                table: "RaceProficiency",
                column: "FK_Proficiency");

            migrationBuilder.CreateIndex(
                name: "IX_RaceProficiency_FK_Race",
                table: "RaceProficiency",
                column: "FK_Race");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceProficiency");

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Proficiencies",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "AllowedOptions", "Descriminator" },
                values: new object[] { 2, 4, "RacialProficiency" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 106,
                column: "Name",
                value: "smith’s tools");

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 107,
                column: "Name",
                value: "brewer’s supplies");

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 108,
                column: "Name",
                value: "mason’s tools");

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "Id",
                keyValue: 108,
                column: "Description",
                value: "You have advantage on Saving Throws against poison, and you have Resistance against poison damage.");

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
    }
}

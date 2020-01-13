using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class fighterexpansion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FK_Class = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubClasses_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubClasses_Classes_FK_Class",
                        column: x => x.FK_Class,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "characterSubClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Character = table.Column<int>(nullable: false),
                    FK_SubClass = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characterSubClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_characterSubClasses_Character_FK_Character",
                        column: x => x.FK_Character,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_characterSubClasses_SubClasses_FK_SubClass",
                        column: x => x.FK_SubClass,
                        principalTable: "SubClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubClassFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_SubClass = table.Column<int>(nullable: false),
                    FK_Feature = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubClassFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubClassFeatures_Features_FK_Feature",
                        column: x => x.FK_Feature,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubClassFeatures_SubClasses_FK_SubClass",
                        column: x => x.FK_SubClass,
                        principalTable: "SubClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "AllowedOptions", "Descriminator" },
                values: new object[] { 10005, 1, "SubClass" });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 10003, "You have a limited well of stamina that you can draw on to protect yourself from harm. On Your Turn, you can use a Bonus Action to regain Hit Points equal to 1d10 + your Fighter level. Once you use this feature, you must finish a short or Long Rest before you can use it again.", "Second Wind" },
                    { 10004, "Starting at 2nd Level, you can push yourself beyond your normal limits for a moment. On Your Turn, you can take one additional action on top of your regular action and a possible Bonus Action. Once you use this feature, you must finish a short or Long Rest before you can use it again.Starting at 17th level, you can use it twice before a rest, but only once on the same turn.", "Action Surge" },
                    { 10005, "At 3rd Level, you choose an archetype that you strive to emulate in your Combat styles and Techniques, such as Champion. The archetype you choose grants you features at 3rd Level and again at 7th, 10th, 15th, and 18th level.", "Martial Archetype" }
                });

            migrationBuilder.InsertData(
                table: "ClassFeatures",
                columns: new[] { "Id", "FK_Class", "FK_Feature", "Level" },
                values: new object[] { 10003, 2, 10003, 1 });

            migrationBuilder.InsertData(
                table: "ClassFeatures",
                columns: new[] { "Id", "FK_Class", "FK_Feature", "Level" },
                values: new object[] { 10004, 2, 10004, 2 });

            migrationBuilder.InsertData(
                table: "ClassFeatures",
                columns: new[] { "Id", "FK_Class", "FK_Feature", "Level" },
                values: new object[] { 10005, 2, 10005, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_characterSubClasses_FK_Character",
                table: "characterSubClasses",
                column: "FK_Character");

            migrationBuilder.CreateIndex(
                name: "IX_characterSubClasses_FK_SubClass",
                table: "characterSubClasses",
                column: "FK_SubClass");

            migrationBuilder.CreateIndex(
                name: "IX_SubClasses_CharacterId",
                table: "SubClasses",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubClasses_FK_Class",
                table: "SubClasses",
                column: "FK_Class");

            migrationBuilder.CreateIndex(
                name: "IX_SubClassFeatures_FK_Feature",
                table: "SubClassFeatures",
                column: "FK_Feature");

            migrationBuilder.CreateIndex(
                name: "IX_SubClassFeatures_FK_SubClass",
                table: "SubClassFeatures",
                column: "FK_SubClass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "characterSubClasses");

            migrationBuilder.DropTable(
                name: "SubClassFeatures");

            migrationBuilder.DropTable(
                name: "SubClasses");

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 10005);

            migrationBuilder.DeleteData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10003);

            migrationBuilder.DeleteData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10004);

            migrationBuilder.DeleteData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10005);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10003);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10004);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10005);
        }
    }
}

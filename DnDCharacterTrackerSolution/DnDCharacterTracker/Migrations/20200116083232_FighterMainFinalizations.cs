using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class FighterMainFinalizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClassFeatures",
                columns: new[] { "Id", "FK_Class", "FK_Feature", "Level" },
                values: new object[,]
                {
                    { 10008, 2, 666666, 6 },
                    { 10010, 2, 666666, 10 },
                    { 10011, 2, 666666, 15 },
                    { 10012, 2, 666666, 18 }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 10007, "Beginning at 5th Level, you can Attack twice, instead of once, whenever you take the Attack action on Your Turn. The number of attacks increases to three when you reach 11th level in this class and to four when you reach 20th level in this class.", "Extra Attack" },
                    { 10009, "Beginning at 9th level, you can reroll a saving throw that you fail. If you do so, you must use the new roll, and you can't use this feature again until you finish a Long Rest. You can use this feature twice between long rests starting at 13th level and three times between long rests starting at 17th level.", "Indomitable" }
                });

            migrationBuilder.InsertData(
                table: "ClassFeatures",
                columns: new[] { "Id", "FK_Class", "FK_Feature", "Level" },
                values: new object[] { 10007, 2, 10007, 5 });

            migrationBuilder.InsertData(
                table: "ClassFeatures",
                columns: new[] { "Id", "FK_Class", "FK_Feature", "Level" },
                values: new object[] { 10009, 2, 10009, 9 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10007);

            migrationBuilder.DeleteData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10008);

            migrationBuilder.DeleteData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10009);

            migrationBuilder.DeleteData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10010);

            migrationBuilder.DeleteData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10011);

            migrationBuilder.DeleteData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10012);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10007);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10009);
        }
    }
}

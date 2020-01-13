using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class subclassFighter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubClasses",
                columns: new[] { "Id", "CharacterId", "Description", "FK_Class", "Name" },
                values: new object[] { 10001, null, "The archetypal Champion focuses on the development of raw physical power honed to deadly perfection. Those who model themselves on this archetype combine rigorous training with physical excellence to deal devastating blows.", 2, "Champion" });

            migrationBuilder.InsertData(
                table: "SubClasses",
                columns: new[] { "Id", "CharacterId", "Description", "FK_Class", "Name" },
                values: new object[] { 10002, null, "Those who emulate the archetypal Battle Master employ martial techniques passed down through generations. To a Battle Master, combat is an academic field, sometimes including subjects beyond battle such as weaponsmithing and calligraphy. Not every fighter absorbs the lessons of history, theory, and artistry that are reflected in the Battle Master archetype, but those who do are well-rounded fighters of great skill and knowledge.", 2, "Battle Master" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubClasses",
                keyColumn: "Id",
                keyValue: 10001);

            migrationBuilder.DeleteData(
                table: "SubClasses",
                keyColumn: "Id",
                keyValue: 10002);
        }
    }
}

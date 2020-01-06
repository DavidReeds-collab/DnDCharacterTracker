using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class fighterfightingstyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "AllowedOptions", "Descriminator" },
                values: new object[] { 10002, 1, "ClassFeature" });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 10002, "You adopt a particular style of fighting as your specialty. Choose a Fighting Style from the list of optional features. You can't take the same Fighting Style option more than once, even if you get to choose again.", "Fighting Style" });

            migrationBuilder.InsertData(
                table: "ClassFeatures",
                columns: new[] { "Id", "FK_Class", "FK_Feature", "Level" },
                values: new object[] { 10002, 2, 10002, 1 });

            migrationBuilder.InsertData(
                table: "FeatureChoices",
                columns: new[] { "Id", "FK_Choice", "FK_Feature" },
                values: new object[] { 10002, 10002, 10002 });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Description", "FK_Choice", "Name", "free" },
                values: new object[,]
                {
                    { 10009, "You gain a +2 bonus to Attack rolls you make with Ranged Weapons.", 10002, "Archery", false },
                    { 10010, "While you are wearing armor, you gain a +1 bonus to AC.", 10002, "Defense", false },
                    { 10011, "When you are wielding a melee weapon in one hand and no other Weapons, you gain a +2 bonus to Damage Rolls with that weapon.", 10002, "Dueling", false },
                    { 10012, "When you roll a 1 or 2 on a damage die for an Attack you make with a melee weapon that you are wielding with two hands, you can reroll the die and must use the new roll, even if the new roll is a 1 or a 2. The weapon must have the Two-Handed or Versatile property for you to gain this benefit.", 10002, "Great Weapon Fighting", false },
                    { 10013, "When a creature you can see attacks a target other than you that is within 5 feet of you, you can use your Reaction to impose disadvantage on the Attack roll. You must be wielding a Shield.", 10002, "Protection", false },
                    { 10014, "When you engage in two-weapon fighting, you can add your ability modifier to the damage of the second Attack.", 10002, "Two-Weapon Fighting", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassFeatures",
                keyColumn: "Id",
                keyValue: 10002);

            migrationBuilder.DeleteData(
                table: "FeatureChoices",
                keyColumn: "Id",
                keyValue: 10002);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 10009);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 10010);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 10011);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 10012);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 10013);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 10014);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 10002);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10002);
        }
    }
}

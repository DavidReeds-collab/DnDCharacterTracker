using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class free : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "free",
                table: "Option",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Dwarvish");

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Description", "FK_Choice", "Name", "free" },
                values: new object[] { 4, null, 1, "Common", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "free",
                table: "Option");

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Dwarfish");
        }
    }
}

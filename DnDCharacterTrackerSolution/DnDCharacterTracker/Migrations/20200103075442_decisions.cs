using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class decisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Character = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FK_Class = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decisions_Character_FK_Character",
                        column: x => x.FK_Character,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decisions_Classes_FK_Class",
                        column: x => x.FK_Class,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DecisionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Decision = table.Column<int>(nullable: false),
                    FK_Option = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DecisionOptions_Decisions_FK_Decision",
                        column: x => x.FK_Decision,
                        principalTable: "Decisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecisionOptions_Option_FK_Option",
                        column: x => x.FK_Option,
                        principalTable: "Option",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DecisionOptions_FK_Decision",
                table: "DecisionOptions",
                column: "FK_Decision");

            migrationBuilder.CreateIndex(
                name: "IX_DecisionOptions_FK_Option",
                table: "DecisionOptions",
                column: "FK_Option");

            migrationBuilder.CreateIndex(
                name: "IX_Decisions_FK_Character",
                table: "Decisions",
                column: "FK_Character");

            migrationBuilder.CreateIndex(
                name: "IX_Decisions_FK_Class",
                table: "Decisions",
                column: "FK_Class");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecisionOptions");

            migrationBuilder.DropTable(
                name: "Decisions");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterTracker.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbilityScores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityScores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowedOptions = table.Column<int>(nullable: false),
                    Descriminator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AllowedNumberOfChoices = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proficiencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proficiencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Speed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FK_AbilityScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_AbilityScores_FK_AbilityScore",
                        column: x => x.FK_AbilityScore,
                        principalTable: "AbilityScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FK_Choice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Option_Choices_FK_Choice",
                        column: x => x.FK_Choice,
                        principalTable: "Choices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceFeatureChoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_RaceFeature = table.Column<int>(nullable: false),
                    FK_Choice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceFeatureChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceFeatureChoices_Proficiencies_FK_Choice",
                        column: x => x.FK_Choice,
                        principalTable: "Proficiencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceFeatureChoices_RaceFeatures_FK_RaceFeature",
                        column: x => x.FK_RaceFeature,
                        principalTable: "RaceFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Strenght = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Constitution = table.Column<int>(nullable: false),
                    Wisdom = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Charisma = table.Column<int>(nullable: false),
                    FK_Race = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Races_FK_Race",
                        column: x => x.FK_Race,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "raceAbilityScores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Race = table.Column<int>(nullable: false),
                    FK_AbilityScore = table.Column<int>(nullable: false),
                    amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raceAbilityScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_raceAbilityScores_AbilityScores_FK_AbilityScore",
                        column: x => x.FK_AbilityScore,
                        principalTable: "AbilityScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_raceAbilityScores_Races_FK_Race",
                        column: x => x.FK_Race,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceRacefeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Race = table.Column<int>(nullable: false),
                    FK_RaceFeature = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceRacefeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceRacefeatures_Races_FK_Race",
                        column: x => x.FK_Race,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceRacefeatures_RaceFeatures_FK_RaceFeature",
                        column: x => x.FK_RaceFeature,
                        principalTable: "RaceFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureChoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Feature = table.Column<int>(nullable: false),
                    FK_Option = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureChoices_Features_FK_Feature",
                        column: x => x.FK_Feature,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureChoices_Option_FK_Option",
                        column: x => x.FK_Option,
                        principalTable: "Option",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Character = table.Column<int>(nullable: false),
                    FK_AbilityScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterAbilities_AbilityScores_FK_AbilityScore",
                        column: x => x.FK_AbilityScore,
                        principalTable: "AbilityScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterAbilities_Character_FK_Character",
                        column: x => x.FK_Character,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterProficiencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Character = table.Column<int>(nullable: false),
                    FK_Proficiency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterProficiencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterProficiencies_Character_FK_Character",
                        column: x => x.FK_Character,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterProficiencies_Proficiencies_FK_Proficiency",
                        column: x => x.FK_Proficiency,
                        principalTable: "Proficiencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterRaceFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Character = table.Column<int>(nullable: false),
                    FK_RaceFeature = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterRaceFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterRaceFeatures_Character_FK_Character",
                        column: x => x.FK_Character,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterRaceFeatures_RaceFeatures_FK_RaceFeature",
                        column: x => x.FK_RaceFeature,
                        principalTable: "RaceFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Character = table.Column<int>(nullable: false),
                    FK_Skill = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Character_FK_Character",
                        column: x => x.FK_Character,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Skills_FK_Skill",
                        column: x => x.FK_Skill,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Character = table.Column<int>(nullable: false),
                    FK_Class = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterClasses_Character_FK_Character",
                        column: x => x.FK_Character,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterClasses_Classes_FK_Class",
                        column: x => x.FK_Class,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Class = table.Column<int>(nullable: false),
                    FK_AbilityScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassAbilities_AbilityScores_FK_AbilityScore",
                        column: x => x.FK_AbilityScore,
                        principalTable: "AbilityScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassAbilities_Classes_FK_Class",
                        column: x => x.FK_Class,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Class = table.Column<int>(nullable: false),
                    FK_Feature = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassFeatures_Classes_FK_Class",
                        column: x => x.FK_Class,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassFeatures_Features_FK_Feature",
                        column: x => x.FK_Feature,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AbilityScores",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Strenght" },
                    { 2, "Dexterity" },
                    { 3, "Constitution" },
                    { 4, "Wisdom" },
                    { 5, "Intelligence" },
                    { 6, "Charisma" }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "AllowedOptions", "Descriminator" },
                values: new object[] { 1, 1, "language" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "CharacterId", "Name" },
                values: new object[,]
                {
                    { 3, null, "Paladin" },
                    { 2, null, "Fighter" },
                    { 1, null, "Not chosen yet" }
                });

            migrationBuilder.InsertData(
                table: "Proficiencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 20, "Sylvan" },
                    { 21, "Undercommon" },
                    { 22, "Artisan’s Tools" },
                    { 23, "Disguise Kit" },
                    { 24, "Forgery Kit" },
                    { 25, "Gaming Set" },
                    { 26, "Herbalism Kit" },
                    { 31, "Light Armor" },
                    { 28, "Poisoner’s Kit" },
                    { 29, "Simple Weapons" },
                    { 30, "Martial Weapons" },
                    { 19, "Primordial" },
                    { 32, "Medium Armor" },
                    { 33, "Simple Weapons" },
                    { 34, "Heavy Armor" },
                    { 27, "Musical Instrument" },
                    { 18, "Orc" },
                    { 17, "Infernal" },
                    { 16, "Ignan" },
                    { 1, "Abyssal" },
                    { 2, "Aquan" },
                    { 3, "Auran" },
                    { 5, "Common" },
                    { 6, "Deep Speech" },
                    { 7, "Draconic" },
                    { 8, "Druidic" },
                    { 4, "Celestial" },
                    { 10, "Elvish" },
                    { 11, "Giant" },
                    { 12, "Gnomish" },
                    { 13, "Goblin" },
                    { 14, "Gnoll" },
                    { 15, "Halfling" },
                    { 9, "Dwarvish" }
                });

            migrationBuilder.InsertData(
                table: "RaceFeatures",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 5, "Your base walking speed is 30 feet.", "Speed" },
                    { 1, "Your Ability Scores each increase by 1.", "Ability Score Increase" },
                    { 2, "Humans reach Adulthood in their late teens and live less than a century.", "Age" },
                    { 3, "Humans tend toward no particular Alignment. The best and the worst are found among them.", "Alignment" },
                    { 4, "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium.", "Size" },
                    { 6, "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with, including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, Dwarvish Military phrases, and so on.", "Languages" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "Name", "Speed" },
                values: new object[,]
                {
                    { 1, "Not chosen yet", 0 },
                    { 2, "Human", 30 },
                    { 3, "Dwarf", 0 }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Description", "FK_Choice", "Name" },
                values: new object[,]
                {
                    { 3, null, 1, "Dwarfish" },
                    { 2, null, 1, "Celestial" },
                    { 1, null, 1, "Infernal" }
                });

            migrationBuilder.InsertData(
                table: "RaceFeatureChoices",
                columns: new[] { "Id", "FK_Choice", "FK_RaceFeature" },
                values: new object[] { 1, 1, 6 });

            migrationBuilder.InsertData(
                table: "RaceRacefeatures",
                columns: new[] { "Id", "FK_Race", "FK_RaceFeature" },
                values: new object[,]
                {
                    { 6, 2, 6 },
                    { 5, 2, 5 },
                    { 4, 2, 4 },
                    { 3, 2, 3 },
                    { 2, 2, 2 },
                    { 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "FK_AbilityScore", "Name" },
                values: new object[,]
                {
                    { 12, 6, "Performance" },
                    { 8, 6, "Intimidation" },
                    { 5, 6, "Deception" },
                    { 13, 6, "Persuasion" },
                    { 10, 5, "Nature" },
                    { 1, 2, "Acrobatics" },
                    { 15, 2, "Sleight of Hand" },
                    { 16, 2, "Stealth" },
                    { 2, 4, "Animal handling" },
                    { 7, 4, "Insight" },
                    { 14, 5, "Religion" },
                    { 4, 1, "Athletics" },
                    { 9, 4, "Medicine" },
                    { 11, 4, "Perception" },
                    { 17, 4, "Survival" },
                    { 3, 5, "Arcana" },
                    { 6, 5, "History" }
                });

            migrationBuilder.InsertData(
                table: "raceAbilityScores",
                columns: new[] { "Id", "FK_AbilityScore", "FK_Race", "amount" },
                values: new object[,]
                {
                    { -3, 3, 2, 1 },
                    { -1, 1, 2, 1 },
                    { -5, 5, 2, 1 },
                    { -6, 6, 2, 1 },
                    { -2, 2, 2, 1 },
                    { -4, 4, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Character_FK_Race",
                table: "Character",
                column: "FK_Race");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAbilities_FK_AbilityScore",
                table: "CharacterAbilities",
                column: "FK_AbilityScore");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAbilities_FK_Character",
                table: "CharacterAbilities",
                column: "FK_Character");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClasses_FK_Character",
                table: "CharacterClasses",
                column: "FK_Character");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClasses_FK_Class",
                table: "CharacterClasses",
                column: "FK_Class");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterProficiencies_FK_Character",
                table: "CharacterProficiencies",
                column: "FK_Character");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterProficiencies_FK_Proficiency",
                table: "CharacterProficiencies",
                column: "FK_Proficiency");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRaceFeatures_FK_Character",
                table: "CharacterRaceFeatures",
                column: "FK_Character");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRaceFeatures_FK_RaceFeature",
                table: "CharacterRaceFeatures",
                column: "FK_RaceFeature");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_FK_Character",
                table: "CharacterSkills",
                column: "FK_Character");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_FK_Skill",
                table: "CharacterSkills",
                column: "FK_Skill");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAbilities_FK_AbilityScore",
                table: "ClassAbilities",
                column: "FK_AbilityScore");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAbilities_FK_Class",
                table: "ClassAbilities",
                column: "FK_Class");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CharacterId",
                table: "Classes",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeatures_FK_Class",
                table: "ClassFeatures",
                column: "FK_Class");

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeatures_FK_Feature",
                table: "ClassFeatures",
                column: "FK_Feature");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureChoices_FK_Feature",
                table: "FeatureChoices",
                column: "FK_Feature");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureChoices_FK_Option",
                table: "FeatureChoices",
                column: "FK_Option");

            migrationBuilder.CreateIndex(
                name: "IX_Option_FK_Choice",
                table: "Option",
                column: "FK_Choice");

            migrationBuilder.CreateIndex(
                name: "IX_raceAbilityScores_FK_AbilityScore",
                table: "raceAbilityScores",
                column: "FK_AbilityScore");

            migrationBuilder.CreateIndex(
                name: "IX_raceAbilityScores_FK_Race",
                table: "raceAbilityScores",
                column: "FK_Race");

            migrationBuilder.CreateIndex(
                name: "IX_RaceFeatureChoices_FK_Choice",
                table: "RaceFeatureChoices",
                column: "FK_Choice");

            migrationBuilder.CreateIndex(
                name: "IX_RaceFeatureChoices_FK_RaceFeature",
                table: "RaceFeatureChoices",
                column: "FK_RaceFeature");

            migrationBuilder.CreateIndex(
                name: "IX_RaceRacefeatures_FK_Race",
                table: "RaceRacefeatures",
                column: "FK_Race");

            migrationBuilder.CreateIndex(
                name: "IX_RaceRacefeatures_FK_RaceFeature",
                table: "RaceRacefeatures",
                column: "FK_RaceFeature");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_FK_AbilityScore",
                table: "Skills",
                column: "FK_AbilityScore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CharacterAbilities");

            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropTable(
                name: "CharacterProficiencies");

            migrationBuilder.DropTable(
                name: "CharacterRaceFeatures");

            migrationBuilder.DropTable(
                name: "CharacterSkills");

            migrationBuilder.DropTable(
                name: "ClassAbilities");

            migrationBuilder.DropTable(
                name: "ClassFeatures");

            migrationBuilder.DropTable(
                name: "FeatureChoices");

            migrationBuilder.DropTable(
                name: "raceAbilityScores");

            migrationBuilder.DropTable(
                name: "RaceFeatureChoices");

            migrationBuilder.DropTable(
                name: "RaceRacefeatures");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "Proficiencies");

            migrationBuilder.DropTable(
                name: "RaceFeatures");

            migrationBuilder.DropTable(
                name: "AbilityScores");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}

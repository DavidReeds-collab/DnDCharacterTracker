using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DnDCharacterTracker.Models;

namespace DnDCharacterTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // ...
        }

        //Can the Id be generated? Because right now this will become a huge bottleneck later if items need to be updated or removed. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Dice
            modelBuilder.Entity<Dice>().HasData(new Dice { Id = 1, Name = "D4" });
            modelBuilder.Entity<Dice>().HasData(new Dice { Id = 2, Name = "D6" });
            modelBuilder.Entity<Dice>().HasData(new Dice { Id = 3, Name = "D8" });
            modelBuilder.Entity<Dice>().HasData(new Dice { Id = 4, Name = "D10" });
            modelBuilder.Entity<Dice>().HasData(new Dice { Id = 5, Name = "D12" });
            modelBuilder.Entity<Dice>().HasData(new Dice { Id = 6, Name = "D20" });
            modelBuilder.Entity<Dice>().HasData(new Dice { Id = 7, Name = "D100" });
            #endregion
            #region Ability scores
            modelBuilder.Entity<AbilityScore>().HasData(new AbilityScore { Id = 1, Name = "Strenght" });
            modelBuilder.Entity<AbilityScore>().HasData(new AbilityScore { Id = 2, Name = "Dexterity" });
            modelBuilder.Entity<AbilityScore>().HasData(new AbilityScore { Id = 3, Name = "Constitution" });
            modelBuilder.Entity<AbilityScore>().HasData(new AbilityScore { Id = 4, Name = "Wisdom" });
            modelBuilder.Entity<AbilityScore>().HasData(new AbilityScore { Id = 5, Name = "Intelligence" });
            modelBuilder.Entity<AbilityScore>().HasData(new AbilityScore { Id = 6, Name = "Charisma" });
            #endregion
            #region Skills
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 1, Name = "Acrobatics", FK_AbilityScore = 2 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 2, Name = "Animal handling", FK_AbilityScore = 4 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 3, Name = "Arcana", FK_AbilityScore = 5 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 4, Name = "Athletics", FK_AbilityScore = 1 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 5, Name = "Deception", FK_AbilityScore = 6 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 6, Name = "History", FK_AbilityScore = 5 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 7, Name = "Insight", FK_AbilityScore = 4 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 8, Name = "Intimidation", FK_AbilityScore = 6 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 9, Name = "Medicine", FK_AbilityScore = 4 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 10, Name = "Nature", FK_AbilityScore = 5 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 11, Name = "Perception", FK_AbilityScore = 4 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 12, Name = "Performance", FK_AbilityScore = 6 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 13, Name = "Persuasion", FK_AbilityScore = 6 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 14, Name = "Religion", FK_AbilityScore = 5 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 15, Name = "Sleight of Hand", FK_AbilityScore = 2 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 16, Name = "Stealth", FK_AbilityScore = 2 });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 17, Name = "Survival", FK_AbilityScore = 4 });
            #endregion
            #region Proficiencies
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 1, Name = "Abyssal" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 2, Name = "Aquan" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 3, Name = "Auran" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 4, Name = "Celestial" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 5, Name = "Common" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 6, Name = "Deep Speech" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 7, Name = "Draconic" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 8, Name = "Druidic" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 9, Name = "Dwarvish" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 10, Name = "Elvish" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 11, Name = "Giant" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 12, Name = "Gnomish" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 13, Name = "Goblin" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 14, Name = "Gnoll" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 15, Name = "Halfling" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 16, Name = "Ignan" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 17, Name = "Infernal" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 18, Name = "Orc" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 19, Name = "Primordial" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 20, Name = "Sylvan" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 21, Name = "Undercommon" });

            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 22, Name = "Artisan’s Tools" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 23, Name = "Disguise Kit" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 24, Name = "Forgery Kit" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 25, Name = "Gaming Set" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 26, Name = "Herbalism Kit" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 27, Name = "Musical Instrument" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 28, Name = "Poisoner’s Kit" });

            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 29, Name = "Simple Weapons" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 30, Name = "Martial Weapons" });

            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 31, Name = "Light Armor" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 32, Name = "Medium Armor" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 33, Name = "Shields" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 34, Name = "Heavy Armor" });

            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 35, Name = "Club" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 36, Name = "Dagger" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 37, Name = "Greatclub" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 38, Name = "Handaxe" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 39, Name = "Javelin" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 40, Name = "Light Hammer" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 41, Name = "Mace" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 42, Name = "Quarterstaff" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 43, Name = "Sickle" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 44, Name = "Spear" });

            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 45, Name = "Crossbow, light" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 46, Name = "Dart" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 47, Name = "Shortbow" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 48, Name = "Sling" });

            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 49, Name = "Battleaxe" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 50, Name = "Flail" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 51, Name = "Greataxe" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 52, Name = "Greatsword" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 53, Name = "Halberd" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 54, Name = "Lance" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 55, Name = "Longsword" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 56, Name = "Maul" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 57, Name = "Morningstar" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 58, Name = "Pike" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 59, Name = "Rapier" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 60, Name = "Scimitar" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 61, Name = "Shortsword" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 62, Name = "Trident" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 63, Name = "War Pick" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 64, Name = "Warhammer" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 65, Name = "Whip" });

            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 66, Name = "Shortsword" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 67, Name = "Trident" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 68, Name = "War Pick" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 69, Name = "Warhammer" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 70, Name = "Whip" });

            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 71, Name = "Alchemist’s supplies" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 72, Name = "Brewer’s supplies" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 73, Name = "Calligrapher's Supplies" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 74, Name = "Carpenter’s tools" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 75, Name = "Cartographer’s tools" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 76, Name = "Cobbler’s tools" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 77, Name = "Cook’s utensils" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 78, Name = "Glassblower’s tools" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 79, Name = "Jeweler’s tools" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 80, Name = "Leatherworker’s tools" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 81, Name = "Mason’s tools" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 82, Name = "Painter’s supplies" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 83, Name = "Potter’s tools" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 84, Name = "Smith’s tools" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 85, Name = "Tinker’s tools" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 86, Name = "Weaver’s tools" });
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 87, Name = "Woodcarver’s tools" });


            #endregion
            #region Races
            modelBuilder.Entity<Race>().HasData(new Race { Id = 1, Name = "Not chosen yet" });
            #region Human
            modelBuilder.Entity<Race>().HasData(new Race { Id = 2, Name = "Human", Speed = 30 });
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -1, FK_AbilityScore = 1, FK_Race = 2, amount = 1 });
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -2, FK_AbilityScore = 2, FK_Race = 2, amount = 1 });
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -3, FK_AbilityScore = 3, FK_Race = 2, amount = 1 });
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -4, FK_AbilityScore = 4, FK_Race = 2, amount = 1 });
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -5, FK_AbilityScore = 5, FK_Race = 2, amount = 1 });
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -6, FK_AbilityScore = 6, FK_Race = 2, amount = 1 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 1, Name = "Ability Score Increase", Description = "Your Ability Scores each increase by 1." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 1, FK_Race = 2, FK_RaceFeature = 1 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 2, Name = "Age", Description = "Humans reach Adulthood in their late teens and live less than a century." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 2, FK_Race = 2, FK_RaceFeature = 2 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 3, Name = "Alignment", Description = "Humans tend toward no particular Alignment. The best and the worst are found among them." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 3, FK_Race = 2, FK_RaceFeature = 3 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 4, Name = "Size", Description = "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 4, FK_Race = 2, FK_RaceFeature = 4 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 5, Name = "Speed", Description = "Your base walking speed is 30 feet." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 5, FK_Race = 2, FK_RaceFeature = 5 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 6, Name = "Languages", Description = "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with, including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, Dwarvish Military phrases, and so on." });
            modelBuilder.Entity<Choice>().HasData(new Choice { Id = 1, AllowedOptions = 1, Descriminator = "RacialLanguage" });
            modelBuilder.Entity<RaceFeatureChoice>().HasData(new RaceFeatureChoice { Id = 1, FK_RaceFeature = 6, FK_Choice = 1 });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 1, Name = "Infernal", FK_Choice = 1 });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 2, Name = "Celestial", FK_Choice = 1 });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 3, Name = "Dwarvish", FK_Choice = 1 });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 4, Name = "Common", FK_Choice = 1, free = true });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 6, FK_Race = 2, FK_RaceFeature = 6 });
            #endregion

            #region Dwarf
            modelBuilder.Entity<Race>().HasData(new Race { Id = 3, Name = "Dwarf" });
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -7, FK_AbilityScore = 3, FK_Race = 3, amount = 2 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 101, Name = "Ability Score Increase", Description = "Your Constitution score increases by 2." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 101, FK_Race = 3, FK_RaceFeature = 101 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 102, Name = "Age", Description = "Dwarves mature at the same rate as Humans, but they’re considered young until they reach the age of 50. On average, they live about 350 years." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 102, FK_Race = 3, FK_RaceFeature = 102 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 103, Name = "Alignment", Description = "Most Dwarves are lawful, believing firmly in the benefits of a well-ordered society. They tend toward good as well, with a strong sense of Fair Play and a belief that everyone deserves to share in the benefits of a just order." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 103, FK_Race = 3, FK_RaceFeature = 103 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 104, Name = "Size", Description = "Dwarves stand between 4 and 5 feet tall and average about 150 pounds. Your size is Medium." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 104, FK_Race = 3, FK_RaceFeature = 104 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 105, Name = "Speed", Description = "Your base walking speed is 25 feet. Your speed is not reduced by wearing Heavy Armor." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 105, FK_Race = 3, FK_RaceFeature = 105 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 106, Name = "Darkvision", Description = "Accustomed to life Underground, you have superior vision in dark and dim Conditions. You can see in dim light within 60 feet of you as if it were bright light, and in Darkness as if it were dim light. You can’t discern color in Darkness, only Shades of Gray." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 106, FK_Race = 3, FK_RaceFeature = 106 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 107, Name = "Dwarven Resilience", Description = "You have advantage on Saving Throws against poison, and you have Resistance against poison damage." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 107, FK_Race = 3, FK_RaceFeature = 107 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 108, Name = "Dwarven Combat Training", Description = " You have proficiency with the Battleaxe, Handaxe, Light Hammer, and Warhammer." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 118, FK_Race = 3, FK_RaceFeature = 108 });
            modelBuilder.Entity<RaceProficiency>().HasData(new RaceProficiency { Id = 111, FK_Race = 3, FK_Proficiency = 49 });
            modelBuilder.Entity<RaceProficiency>().HasData(new RaceProficiency { Id = 112, FK_Race = 3, FK_Proficiency = 38 });
            modelBuilder.Entity<RaceProficiency>().HasData(new RaceProficiency { Id = 113, FK_Race = 3, FK_Proficiency = 40 });
            modelBuilder.Entity<RaceProficiency>().HasData(new RaceProficiency { Id = 114, FK_Race = 3, FK_Proficiency = 69 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 109, Name = "Tool Proficiency", Description = "You gain proficiency with the artisan’s tools of your choice: smith’s tools, brewer’s supplies, or mason’s tools." });
            modelBuilder.Entity<Choice>().HasData(new Choice { Id = 3, AllowedOptions = 1, Descriminator = "RacialProficiency" });
            modelBuilder.Entity<RaceFeatureChoice>().HasData(new RaceFeatureChoice { Id = 109, FK_RaceFeature = 109, FK_Choice = 3 });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 106, Name = "Smith’s tools", FK_Choice = 3 });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 107, Name = "Brewer’s supplies", FK_Choice = 3 });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 108, Name = "Mason’s tools", FK_Choice = 3 });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 109, FK_Race = 3, FK_RaceFeature = 109 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 110, Name = "Stonecunning", Description = "Whenever you make an Intelligence (History) check related to the Origin of stonework, you are considered proficient in the History skill and add double your Proficiency Bonus to the check, instead of your normal Proficiency Bonus." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 110, FK_Race = 3, FK_RaceFeature = 110 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 111, Name = "Languages", Description = "You can speak, read, and write Common and Dwarvish. Dwarvish is full of hard consonants and guttural sounds, and those characteristics spill over into whatever other language a dwarf might speak." });
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 111, FK_Race = 3, FK_RaceFeature = 111 });

            #endregion
            #endregion
            #region Classes & Shared features
            modelBuilder.Entity<Class>().HasData(new Class { Id = 1, Name = "Not chosen yet" });

            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 666666, Name = "Ability Score Improvement", Description = "You can increase one ability score of your choice by 2, or you can increase two Ability Scores of your choice by 1. As normal, you can’t increase an ability score above 20 using this feature." });
            modelBuilder.Entity<Choice>().HasData(new Choice { Id = 666666, AllowedOptions = 2, Descriminator = "AbilityScoreImprovement" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 6666661, FK_Choice = 666666, Name = "Strenght" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 6666662, FK_Choice = 666666, Name = "Strenght" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 6666663, FK_Choice = 666666, Name = "Dexterity" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 6666664, FK_Choice = 666666, Name = "Dexterity" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 6666665, FK_Choice = 666666, Name = "Constitution" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 6666666, FK_Choice = 666666, Name = "Constitution" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 6666667, FK_Choice = 666666, Name = "Wisdom" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 6666668, FK_Choice = 666666, Name = "Wisdom" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 6666669, FK_Choice = 666666, Name = "Intelligence" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 66666610, FK_Choice = 666666, Name = "Intelligence" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 66666611, FK_Choice = 666666, Name = "Charisma" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 66666612, FK_Choice = 666666, Name = "Charisma" });
            modelBuilder.Entity<FeatureChoice>().HasData(new FeatureChoice { Id = 666666, FK_Feature = 666666, FK_Choice = 666666 });

            #region Fighter
            modelBuilder.Entity<Class>().HasData(new Class { Id = 2, Name = "Fighter", FK_Dice = 4 });

            modelBuilder.Entity<ClassProficiency>().HasData(new ClassProficiency { Id = 1, FK_Class = 1, FK_Proficiency = 31 });
            modelBuilder.Entity<ClassProficiency>().HasData(new ClassProficiency { Id = 2, FK_Class = 1, FK_Proficiency = 32 });
            modelBuilder.Entity<ClassProficiency>().HasData(new ClassProficiency { Id = 3, FK_Class = 1, FK_Proficiency = 34 });
            modelBuilder.Entity<ClassProficiency>().HasData(new ClassProficiency { Id = 4, FK_Class = 1, FK_Proficiency = 33 });
            modelBuilder.Entity<ClassProficiency>().HasData(new ClassProficiency { Id = 5, FK_Class = 1, FK_Proficiency = 29 });
            modelBuilder.Entity<ClassProficiency>().HasData(new ClassProficiency { Id = 6, FK_Class = 1, FK_Proficiency = 30 });

            modelBuilder.Entity<ClassAbilities>().HasData(new ClassAbilities { Id = 1, FK_Class = 1, FK_AbilityScore = 1 });
            modelBuilder.Entity<ClassAbilities>().HasData(new ClassAbilities { Id = 2, FK_Class = 1, FK_AbilityScore = 3 });

            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 10001, Name = "Skills", Description = "Choose two Skills from Acrobatics, Animal Handling, Athletics, History, Insight, Intimidation, Perception, and Survival." });
            modelBuilder.Entity<ClassFeature>().HasData(new ClassFeature { Id = 10001, FK_Class = 2, FK_Feature = 10001, Level = 1 });
            modelBuilder.Entity<Choice>().HasData(new Choice { Id = 10001, AllowedOptions = 2, Descriminator = "ClassSkillChoice" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10001, FK_Choice = 10001, Name = "Acrobatics" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10002, FK_Choice = 10001, Name = "Animal Handling" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10003, FK_Choice = 10001, Name = "Athletics" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10004, FK_Choice = 10001, Name = "History" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10005, FK_Choice = 10001, Name = "Insight" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10006, FK_Choice = 10001, Name = "Intimidation" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10007, FK_Choice = 10001, Name = "Perception" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10008, FK_Choice = 10001, Name = "Survival" });
            modelBuilder.Entity<FeatureChoice>().HasData(new FeatureChoice { Id = 10001, FK_Feature = 10001, FK_Choice = 10001 });

            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 10002, Name = "Fighting Style", Description = "You adopt a particular style of fighting as your specialty. Choose a Fighting Style from the list of optional features. You can't take the same Fighting Style option more than once, even if you get to choose again." });
            modelBuilder.Entity<ClassFeature>().HasData(new ClassFeature { Id = 10002, FK_Class = 2, FK_Feature = 10002, Level = 1 });
            modelBuilder.Entity<Choice>().HasData(new Choice { Id = 10002, AllowedOptions = 1, Descriminator = "ClassFeature" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10009, FK_Choice = 10002, Name = "Archery", Description = "You gain a +2 bonus to Attack rolls you make with Ranged Weapons." });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10010, FK_Choice = 10002, Name = "Defense", Description = "While you are wearing armor, you gain a +1 bonus to AC." });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10011, FK_Choice = 10002, Name = "Dueling", Description = "When you are wielding a melee weapon in one hand and no other Weapons, you gain a +2 bonus to Damage Rolls with that weapon." });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10012, FK_Choice = 10002, Name = "Great Weapon Fighting", Description = "When you roll a 1 or 2 on a damage die for an Attack you make with a melee weapon that you are wielding with two hands, you can reroll the die and must use the new roll, even if the new roll is a 1 or a 2. The weapon must have the Two-Handed or Versatile property for you to gain this benefit." });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10013, FK_Choice = 10002, Name = "Protection", Description = "When a creature you can see attacks a target other than you that is within 5 feet of you, you can use your Reaction to impose disadvantage on the Attack roll. You must be wielding a Shield." });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 10014, FK_Choice = 10002, Name = "Two-Weapon Fighting", Description = "When you engage in two-weapon fighting, you can add your ability modifier to the damage of the second Attack." });
            modelBuilder.Entity<FeatureChoice>().HasData(new FeatureChoice { Id = 10002, FK_Feature = 10002, FK_Choice = 10002 });

            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 10003, Name = "Second Wind", Description = "You have a limited well of stamina that you can draw on to protect yourself from harm. On Your Turn, you can use a Bonus Action to regain Hit Points equal to 1d10 + your Fighter level. Once you use this feature, you must finish a short or Long Rest before you can use it again." });
            modelBuilder.Entity<ClassFeature>().HasData(new ClassFeature { Id = 10003, FK_Class = 2, FK_Feature = 10003, Level = 1 });

            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 10004, Name = "Action Surge", Description = "Starting at 2nd Level, you can push yourself beyond your normal limits for a moment. On Your Turn, you can take one additional action on top of your regular action and a possible Bonus Action. Once you use this feature, you must finish a short or Long Rest before you can use it again.Starting at 17th level, you can use it twice before a rest, but only once on the same turn." });
            modelBuilder.Entity<ClassFeature>().HasData(new ClassFeature { Id = 10004, FK_Class = 2, FK_Feature = 10004, Level = 2 });

            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 10005, Name = "Martial Archetype", Description = "At 3rd Level, you choose an archetype that you strive to emulate in your Combat styles and Techniques, such as Champion. The archetype you choose grants you features at 3rd Level and again at 7th, 10th, 15th, and 18th level." });
            modelBuilder.Entity<ClassFeature>().HasData(new ClassFeature { Id = 10005, FK_Class = 2, FK_Feature = 10005, Level = 3 });
            modelBuilder.Entity<Choice>().HasData(new Choice { Id = 10005, AllowedOptions = 1, Descriminator = "SubClass" });
            modelBuilder.Entity<FeatureChoice>().HasData(new FeatureChoice { Id = 10005, FK_Feature = 10005, FK_Choice = 10005 });

            modelBuilder.Entity<ClassFeature>().HasData(new ClassFeature { Id = 10006, FK_Class = 2, FK_Feature = 666666, Level = 4 });

            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 10007, Name = "Extra Attack", Description = "Beginning at 5th Level, you can Attack twice, instead of once, whenever you take the Attack action on Your Turn. The number of attacks increases to three when you reach 11th level in this class and to four when you reach 20th level in this class." });
            modelBuilder.Entity<ClassFeature>().HasData(new ClassFeature { Id = 10007, FK_Class = 2, FK_Feature = 10007, Level = 5 });

            modelBuilder.Entity<ClassFeature>().HasData(new ClassFeature { Id = 10008, FK_Class = 2, FK_Feature = 666666, Level = 6 });

            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 10009, Name = "Indomitable", Description = "Beginning at 9th level, you can reroll a saving throw that you fail. If you do so, you must use the new roll, and you can't use this feature again until you finish a Long Rest. You can use this feature twice between long rests starting at 13th level and three times between long rests starting at 17th level." });
            modelBuilder.Entity<ClassFeature>().HasData(new ClassFeature { Id = 10009, FK_Class = 2, FK_Feature = 10009, Level = 9 });

            modelBuilder.Entity<ClassFeature>().HasData(new ClassFeature { Id = 10010, FK_Class = 2, FK_Feature = 666666, Level = 10 });

            modelBuilder.Entity<ClassFeature>().HasData(new ClassFeature { Id = 10011, FK_Class = 2, FK_Feature = 666666, Level = 15 });

            modelBuilder.Entity<ClassFeature>().HasData(new ClassFeature { Id = 10012, FK_Class = 2, FK_Feature = 666666, Level = 18 });



            #region Subclasses
            #region Champion
            modelBuilder.Entity<SubClass>().HasData(new SubClass { Id = 10101, Name = "Champion", Description = "The archetypal Champion focuses on the development of raw physical power honed to deadly perfection. Those who model themselves on this archetype combine rigorous training with physical excellence to deal devastating blows.", FK_Class = 2 });

            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 10101, Name = "Improved Critical", Description = "Beginning when you choose this archetype at 3rd level, your weapon attacks score a critical hit on a roll of 19 or 20." });
            modelBuilder.Entity<SubClassFeature>().HasData(new SubClassFeature { Id = 10101, FK_Feature = 10101, FK_SubClass = 10101, Level = 3 });

            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 10102, Name = "Remarkable Athlete", Description = "Starting at 7th level, you can add half your proficiency bonus (rounded up) to any Strength, Dexterity, or Constitution check you make that doesn't already use your proficiency bonus. In addition, when you make a running long jump, the distance you can cover increases by a number of feet equal to your Strength modifier." });
            modelBuilder.Entity<SubClassFeature>().HasData(new SubClassFeature { Id = 10102, FK_Feature = 10102, FK_SubClass = 10101, Level = 7 });

            modelBuilder.Entity<SubClassFeature>().HasData(new SubClassFeature { Id = 10103, FK_Feature = 10002, FK_SubClass = 10101, Level = 10 });

            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 10104, Name = "Superior Critical", Description = "Starting at 15th level, your weapon attacks score a critical hit on a roll of 18-20." });
            modelBuilder.Entity<SubClassFeature>().HasData(new SubClassFeature { Id = 10104, FK_Feature = 10104, FK_SubClass = 10101, Level = 15 });

            modelBuilder.Entity<Feature>().HasData(new Feature { Id = 10105, Name = "Survivor", Description = "At 18th level, you attain the pinnacle of resilience in battle. At the start of each of your turns, you regain hit points equal to 5 + your Constitution modifier if you have no more than half of your hit points left. You don't gain this benefit if you have 0 hit points." });
            modelBuilder.Entity<SubClassFeature>().HasData(new SubClassFeature { Id = 10105, FK_Feature = 10105, FK_SubClass = 10101, Level = 18 });
            #endregion


            modelBuilder.Entity<SubClass>().HasData(new SubClass { Id = 10002, Name = "Battle Master", Description = "Those who emulate the archetypal Battle Master employ martial techniques passed down through generations. To a Battle Master, combat is an academic field, sometimes including subjects beyond battle such as weaponsmithing and calligraphy. Not every fighter absorbs the lessons of history, theory, and artistry that are reflected in the Battle Master archetype, but those who do are well-rounded fighters of great skill and knowledge.", FK_Class = 2 });


            #endregion
            #endregion



            modelBuilder.Entity<Class>().HasData(new Class { Id = 3, Name = "Paladin" });
            #endregion

        }

        public DbSet<DnDCharacterTracker.Models.LogItem> Log { get; set; }
        public DbSet<DnDCharacterTracker.Models.Character> Character { get; set; }
        public DbSet<DnDCharacterTracker.Models.Race> Races { get; set; }
        public DbSet<DnDCharacterTracker.Models.RaceRacefeature> RaceRacefeatures { get; set; }
        public DbSet<DnDCharacterTracker.Models.Class> Classes { get; set; }
        public DbSet<DnDCharacterTracker.Models.CharacterClass> CharacterClasses { get; set; }
        public DbSet<DnDCharacterTracker.Models.AbilityScore> AbilityScores { get; set; }
        public DbSet<DnDCharacterTracker.Models.CharacterAbilities> CharacterAbilities { get; set; }
        public DbSet<DnDCharacterTracker.Models.CharacterRaceFeature> CharacterRaceFeatures { get; set; }
        public DbSet<DnDCharacterTracker.Models.ClassAbilities> ClassAbilities { get; set; }
        public DbSet<DnDCharacterTracker.Models.ClassFeature> ClassFeatures { get; set; }
        public DbSet<DnDCharacterTracker.Models.Feature> Features { get; set; }
        public DbSet<DnDCharacterTracker.Models.FeatureChoice> FeatureChoices { get; set; }
        public DbSet<DnDCharacterTracker.Models.Option> Options { get; set; }
        public DbSet<DnDCharacterTracker.Models.Skill> Skills { get; set; }
        public DbSet<DnDCharacterTracker.Models.CharacterSkill> CharacterSkills { get; set; }
        public DbSet<DnDCharacterTracker.Models.RaceFeature> RaceFeatures { get; set; }
        public DbSet<DnDCharacterTracker.Models.RaceAbilityScores> raceAbilityScores { get; set; }
        public DbSet<DnDCharacterTracker.Models.Proficiency> Proficiencies { get; set; }
        public DbSet<DnDCharacterTracker.Models.CharacterProficiency> CharacterProficiencies { get; set; }
        public DbSet<DnDCharacterTracker.Models.Choice> Choices { get; set; }
        public DbSet<DnDCharacterTracker.Models.Option> Option { get; set; }
        public DbSet<DnDCharacterTracker.Models.RaceFeatureChoice> RaceFeatureChoices { get; set; }
        public DbSet<DnDCharacterTracker.Models.RaceProficiency>  RaceProficiencies { get; set; }
        public DbSet<DnDCharacterTracker.Models.ClassProficiency> ClassProficiencies { get; set; }
        public DbSet<DnDCharacterTracker.Models.Decision> Decisions { get; set; }
        public DbSet<DnDCharacterTracker.Models.DecisionOption> DecisionOptions { get; set; }
        public DbSet<DnDCharacterTracker.Models.SubClass> SubClasses { get; set; }
        public DbSet<DnDCharacterTracker.Models.SubClassFeature> SubClassFeatures { get; set; }
        public DbSet<DnDCharacterTracker.Models.CharacterSubClass> characterSubClasses { get; set; }

    }
}

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
            modelBuilder.Entity<Proficiency>().HasData(new Proficiency { Id = 33, Name = "Simple Weapons" });
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
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -1, FK_AbilityScore = 1, FK_Race = 2, amount = 1});
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -2, FK_AbilityScore = 2, FK_Race = 2, amount = 1 });
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -3, FK_AbilityScore = 3, FK_Race = 2, amount = 1 });
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -4, FK_AbilityScore = 4, FK_Race = 2, amount = 1 });
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -5, FK_AbilityScore = 5, FK_Race = 2, amount = 1 });
            modelBuilder.Entity<RaceAbilityScores>().HasData(new RaceAbilityScores { Id = -6, FK_AbilityScore = 6, FK_Race = 2, amount = 1 });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature { Id = 1, Name = "Ability Score Increase", Description = "Your Ability Scores each increase by 1."});
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 1, FK_Race = 2, FK_RaceFeature = 1});

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
            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 108, FK_Race = 3, FK_RaceFeature = 108 });
            modelBuilder.Entity<RaceProficiency>().HasData(new RaceProficiency { Id = 101, FK_Race = 3, FK_Proficiency = 49 });
            modelBuilder.Entity<RaceProficiency>().HasData(new RaceProficiency { Id = 102, FK_Race = 3, FK_Proficiency = 38 });
            modelBuilder.Entity<RaceProficiency>().HasData(new RaceProficiency { Id = 103, FK_Race = 3, FK_Proficiency = 40 });
            modelBuilder.Entity<RaceProficiency>().HasData(new RaceProficiency { Id = 104, FK_Race = 3, FK_Proficiency =  69});

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
            modelBuilder.Entity<Class>().HasData(new Class { Id = 1, Name = "Not chosen yet" });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 2, Name = "Fighter" });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 3, Name = "Paladin" });
        }

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



    }
}

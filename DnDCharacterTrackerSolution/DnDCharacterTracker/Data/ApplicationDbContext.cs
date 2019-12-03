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
            modelBuilder.Entity<RaceFeatureChoice>().HasData(new RaceFeatureChoice { Id = 1, FK_RaceFeature = 6, FK_Choice = 1 });
            modelBuilder.Entity<Choice>().HasData(new Choice { Id = 1,  AllowedOptions = 1, Descriminator = "language"});
            modelBuilder.Entity<Option>().HasData(new Option { Id = 1, Name = "Infernal", FK_Choice = 1 });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 2, Name = "Celestial", FK_Choice = 1 });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 3, Name = "Dwarfish", FK_Choice = 1 });


            modelBuilder.Entity<RaceRacefeature>().HasData(new RaceRacefeature { Id = 6, FK_Race = 2, FK_RaceFeature = 6 });
            #endregion


            modelBuilder.Entity<Race>().HasData(new Race { Id = 3, Name = "Dwarf" });
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



    }
}

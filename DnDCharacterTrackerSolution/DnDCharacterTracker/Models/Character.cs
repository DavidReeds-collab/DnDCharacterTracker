using DnDCharacterTracker.Data;
using DnDCharacterTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }

        [NotMapped]
        public Dictionary<string, int> AbilityScores
        {
            get
            {
                return new Dictionary<string, int>()
                {
                    { "Strenght", this.Strenght },
                    { "Dexterity", this.Dexterity },
                    { "Constitution", this.Constitution },
                    { "Wisdom", this.Wisdom },
                    { "Intelligence", this.Intelligence },
                    { "Charisma", this.Charisma }
                };
            }
        }

        [ForeignKey("Race")]
        public int FK_Race { get; set; }
        public Race Race { get; set; }
        [NotMapped]
        public List<RaceFeature> RaceFeatures { get; set; } = new List<RaceFeature>();
        [NotMapped]
        public List<Feature> ClassFeatures { get; set; } = new List<Feature>();
        public List<Class> Classes { get; set; } = new List<Class>();
        public List<SubClass> SubClasses { get; set; } = new List<SubClass>();
        [NotMapped]
        public List<CharacterClass> ClassIntermediaries { get; set; } = new List<CharacterClass>();
        [NotMapped]
        public List<Proficiency> Proficiencies { get; set; } = new List<Proficiency>();
        [NotMapped]
        public List<CharacterSkill> SkillProficiencies { get; set; } = new List<CharacterSkill>();



        public Character()
        {

        }
    }
}

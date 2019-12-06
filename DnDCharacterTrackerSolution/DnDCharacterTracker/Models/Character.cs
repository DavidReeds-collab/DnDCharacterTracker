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
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        [ForeignKey("Race")]
        public int FK_Race { get; set; }
        public Race Race { get; set; }
        [NotMapped]
        public List<RaceFeature> RaceFeatures { get; set; } = new List<RaceFeature>();
        public List<Class> Classes { get; set; } = new List<Class>();
        [NotMapped]
        public List<CharacterClass> ClassIntermediaries { get; set; } = new List<CharacterClass>();
        [NotMapped]
        public List<Proficiency> Proficiencies { get; set; } = new List<Proficiency>();


        public Character()
        {

        }
    }
}

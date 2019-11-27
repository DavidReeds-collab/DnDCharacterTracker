using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DnDCharacterTracker.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Race Race { get; set; }
        [ForeignKey("Race")]
        [Required]
        public int RaceFK { get; set; }

        [Required]
        public ICollection<CharacterClass> Classes { get; set; }


        [Required]
        public int Strenght { get; set; }
        [Required]
        public int Dexterity { get; set; }
        [Required]
        public int Constitution { get; set; }
        [Required]
        public int Wisdom { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]

        public int Charisma { get; set; }
    }
}
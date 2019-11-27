using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DnDCharacterTracker.Models
{
    public class CharacterClass
    {
        public int Id { get; set; }
        [Required]
        public Character Character { get; set; }
        [ForeignKey("Character")]
        [Required]
        public int CharacterFK { get; set; }
        [ForeignKey("Class")]
        [Required]
        public int ClassFK { get; set; }
        [Required]
        public Class Class { get; set; }
        [Required]
        [Range(1, 19)]
        public int Level { get; set; }
    }
}
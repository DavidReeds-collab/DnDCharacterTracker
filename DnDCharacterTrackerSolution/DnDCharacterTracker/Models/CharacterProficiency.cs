using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class CharacterProficiency
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Character")]
        public int FK_Character { get; set; }
        public Character Character { get; set; }
        [ForeignKey("Proficiency")]
        public int FK_Proficiency { get; set; }
        public Proficiency Proficiency { get; set; }
    }
}

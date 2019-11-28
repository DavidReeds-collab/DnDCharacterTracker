using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class CharacterSkill
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Character")]
        public int FK_Character { get; set; }        
        public Character Character { get; set; }
        [ForeignKey("Skill")]
        public int FK_Skill { get; set; }
        public Skill Skill { get; set; }
    }
}

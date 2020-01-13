using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class CharacterSubClass
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Character")]
        public int FK_Character { get; set; }
        public Character Character { get; set; }
        [ForeignKey("SubClass")]
        public int FK_SubClass { get; set; }
        public SubClass SubClass { get; set; }
    }
}

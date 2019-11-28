using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class CharacterClass
    {
        public int Id { get; set; }
        [ForeignKey("Character")]
        public int FK_Character { get; set; }
        public Character Character { get; set; }
        [ForeignKey("Class")]
        public int FK_Class { get; set; }
        public Class Class { get; set; }
        public int Level { get; set; }
    }
}

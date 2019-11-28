using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class CharacterAbilities
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Character")]
        public int FK_Character { get; set; }
        public Character Character { get; set; }
        [ForeignKey("AbilityScore")]
        public int FK_AbilityScore { get; set; }
        public AbilityScore AbilityScore { get; set; }

    }
}

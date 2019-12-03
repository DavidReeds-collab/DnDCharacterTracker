using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class RaceAbilityScores
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Race")]
        public int FK_Race { get; set; }
        public Race Race { get; set; }
        [ForeignKey("AbilityScore")]
        public int FK_AbilityScore { get; set; }
        public AbilityScore AbilityScore { get; set; }
        public int amount { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class CharacterRaceFeature
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Character")]
        public int FK_Character { get; set; }
        [ForeignKey("RaceFeature")]
        public int FK_RaceFeature { get; set; }
        public Character Character { get; set; }
        public RaceFeature RaceFeature { get; set; }
    }
}

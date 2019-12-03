using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class RaceRacefeature
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Race")]
        public int FK_Race { get; set; }
        [ForeignKey("RaceFeature")]
        public int FK_RaceFeature { get; set; }
        public Race Race { get; set; }
        public RaceFeature RaceFeature { get; set; }
    }
}

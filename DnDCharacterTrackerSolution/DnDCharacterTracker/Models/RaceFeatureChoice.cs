using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class RaceFeatureChoice
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RaceFeature")]
        public int FK_RaceFeature { get; set; }
        public RaceFeature RaceFeature { get; set; }
        [ForeignKey("Choice")]
        public int FK_Choice { get; set; }
        public Choice Choice { get; set; }
    }
}

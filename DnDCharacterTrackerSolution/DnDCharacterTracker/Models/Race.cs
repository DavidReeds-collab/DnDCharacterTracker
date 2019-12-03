using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class Race
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int Speed { get; set; }
        [NotMapped]
        public List<RaceFeature> raceFeatures { get; set; } = new List<RaceFeature>();
    }
}

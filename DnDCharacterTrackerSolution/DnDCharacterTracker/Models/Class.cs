using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Dice")]
        public int FK_Dice { get; set; }
        public Dice HitDice { get; set; }
        [NotMapped]
        public List<Feature> classFeatures = new List<Feature>();
    }
}

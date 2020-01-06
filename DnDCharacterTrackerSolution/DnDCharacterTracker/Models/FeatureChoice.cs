using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class FeatureChoice
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Feature")]
        public int FK_Feature { get; set; }
        public Feature Feature { get; set; }
        [ForeignKey("Choice")]
        public int FK_Choice { get; set; }
        public Choice Choice { get; set; }
    }
}

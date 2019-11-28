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
        [ForeignKey("Option")]
        public int FK_Option { get; set; }
        public Option Option { get; set; }
    }
}

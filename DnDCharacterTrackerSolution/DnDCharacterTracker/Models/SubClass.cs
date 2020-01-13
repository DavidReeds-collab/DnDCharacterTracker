using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class SubClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Class")]
        public int FK_Class { get; set; }
        public Class Class { get; set; }
        [NotMapped]
        public List<Feature> SubClassFeatures = new List<Feature>();

    }
}

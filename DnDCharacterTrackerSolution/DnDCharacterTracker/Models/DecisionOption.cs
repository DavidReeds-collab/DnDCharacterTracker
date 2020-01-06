using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class DecisionOption
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Decision")]
        public int FK_Decision { get; set; }
        public Decision Decision { get; set; }
        [ForeignKey("Option")]
        public int FK_Option { get; set; }
        public Option Option { get; set; }
    }
}

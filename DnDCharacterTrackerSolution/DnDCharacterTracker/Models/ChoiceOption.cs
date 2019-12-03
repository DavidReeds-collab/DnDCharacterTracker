using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class ChoiceOption
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Choice")]
        public int FK_Choice { get; set; }
        public Choice Choice { get; set; }
        [ForeignKey("Option")]
        public int FK_Option { get; set; }
        public Option Option { get; set; }
    }
}

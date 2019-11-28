using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("AbilityScore")]
        public int FK_AbilityScore { get; set; }
        public AbilityScore AbilityScore { get; set; }
    }
}

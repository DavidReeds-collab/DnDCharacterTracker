using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class RaceProficiency
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Race")]
        public int FK_Race { get; set; }
        public Race Race { get; set; }
        [ForeignKey("Proficiency")]
        public int FK_Proficiency { get; set; }
        public Proficiency Proficiency { get; set; }
    }
}

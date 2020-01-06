using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class ClassProficiency
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Class")]
        public int FK_Class { get; set; }
        public Class Class { get; set; }
        [ForeignKey("Proficiency")]
        public int FK_Proficiency { get; set; }
        public Proficiency Proficiency { get; set; }
    }
}

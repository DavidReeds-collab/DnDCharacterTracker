using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class LogItem
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateLogged { get; set; }
        public string Message { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class Choice
    {
        [Key]
        public int Id { get; set; }
        public int AllowedOptions { get; set; }
        public string Descriminator { get; set; }
        public List<Option> AvailableOptions { get; set; }


    }
}

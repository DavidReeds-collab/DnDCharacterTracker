using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class ChoiceViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AllowedNumberOfChoices { get; set; }
        public List<string> OptionNames = new List<string>();
        public List<string> OptionDescriptions = new List<string>();
        public string Descriminator { get; set; }

        
    }

    public class ChoicesCollection
    {
        public List<ChoiceViewModel> Choices { get; set; }
        public Character Character { get; set; }
    }
}

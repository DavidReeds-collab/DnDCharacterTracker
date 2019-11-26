using System;
using System.Collections.Generic;

namespace DnDCharacterTracker.Models
{
    public partial class Race
    {
        public Race()
        {
            Character = new HashSet<Character>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Character> Character { get; set; }
    }
}

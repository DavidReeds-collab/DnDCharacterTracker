using System;
using System.Collections.Generic;

namespace DnDCharacterTracker.Models
{
    public partial class Class
    {
        public Class()
        {
            CharacterClass = new HashSet<CharacterClass>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CharacterClass> CharacterClass { get; set; }
    }
}

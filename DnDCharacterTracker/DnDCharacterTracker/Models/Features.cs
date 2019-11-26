using System;
using System.Collections.Generic;

namespace DnDCharacterTracker.Models
{
    public partial class Features
    {
        public Features()
        {
            CharacterFeature = new HashSet<CharacterFeature>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Feature { get; set; }

        public virtual ICollection<CharacterFeature> CharacterFeature { get; set; }
    }
}

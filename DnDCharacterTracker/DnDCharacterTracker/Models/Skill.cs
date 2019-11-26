using System;
using System.Collections.Generic;

namespace DnDCharacterTracker.Models
{
    public partial class Skill
    {
        public Skill()
        {
            CharacterSkills = new HashSet<CharacterSkills>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CharacterSkills> CharacterSkills { get; set; }
    }
}

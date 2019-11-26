using System;
using System.Collections.Generic;

namespace DnDCharacterTracker.Models
{
    public partial class CharacterSkills
    {
        public long Id { get; set; }
        public long FkCharacter { get; set; }
        public long FkSkill { get; set; }
        public bool Expertise { get; set; }

        public virtual Character FkCharacterNavigation { get; set; }
        public virtual Skill FkSkillNavigation { get; set; }
    }
}

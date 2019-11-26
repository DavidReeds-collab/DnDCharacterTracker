using System;
using System.Collections.Generic;

namespace DnDCharacterTracker.Models
{
    public partial class CharacterClass
    {
        public long Id { get; set; }
        public long FkCharacter { get; set; }
        public long FkClass { get; set; }

        public virtual Character FkCharacterNavigation { get; set; }
        public virtual Class FkClassNavigation { get; set; }
    }
}

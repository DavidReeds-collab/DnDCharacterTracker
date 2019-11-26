using System;
using System.Collections.Generic;

namespace DnDCharacterTracker.Models
{
    public partial class CharacterFeature
    {
        public long Id { get; set; }
        public long FkCharacter { get; set; }
        public long FkFeature { get; set; }

        public virtual Character FkCharacterNavigation { get; set; }
        public virtual Features FkFeatureNavigation { get; set; }
    }
}

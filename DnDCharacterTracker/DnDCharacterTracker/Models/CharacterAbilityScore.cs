using System;
using System.Collections.Generic;

namespace DnDCharacterTracker.Models
{
    public partial class CharacterAbilityScore
    {
        public long Id { get; set; }
        public long FkCharacter { get; set; }
        public long FkAbilityScore { get; set; }
        public long Amount { get; set; }

        public virtual AbilityScore FkAbilityScoreNavigation { get; set; }
        public virtual Character FkCharacterNavigation { get; set; }
    }
}

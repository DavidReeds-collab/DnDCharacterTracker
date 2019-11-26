using System;
using System.Collections.Generic;

namespace DnDCharacterTracker.Models
{
    public partial class AbilityScore
    {
        public AbilityScore()
        {
            CharacterAbilityScore = new HashSet<CharacterAbilityScore>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CharacterAbilityScore> CharacterAbilityScore { get; set; }
    }
}

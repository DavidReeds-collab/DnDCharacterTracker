using System;
using System.Collections.Generic;

namespace DnDCharacterTracker.Models
{
    public partial class Character
    {
        public Character()
        {
            CharacterAbilityScore = new HashSet<CharacterAbilityScore>();
            CharacterClass = new HashSet<CharacterClass>();
            CharacterFeature = new HashSet<CharacterFeature>();
            CharacterSkills = new HashSet<CharacterSkills>();
        }

        public long Id { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public long FkRace { get; set; }

        public virtual Race FkRaceNavigation { get; set; }
        public virtual ICollection<CharacterAbilityScore> CharacterAbilityScore { get; set; }
        public virtual ICollection<CharacterClass> CharacterClass { get; set; }
        public virtual ICollection<CharacterFeature> CharacterFeature { get; set; }
        public virtual ICollection<CharacterSkills> CharacterSkills { get; set; }
    }
}

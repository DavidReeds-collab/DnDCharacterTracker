using DnDCharacterTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Services
{
    public interface ICharacterServices
    {
        Character GetCharacterFromId(int id);

        int GetCharacterLevel(int id);

        void SetCharacterRace(int id, Character character);

        void AddCharacterClass(int id, Character character);

        void RetrieveClassIntermediaries(Character character);

        void ApplyAbilityScoreImprovements(Character character, RaceAbilityScores raceAbilityScores);

    }
}

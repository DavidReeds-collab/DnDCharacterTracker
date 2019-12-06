using DnDCharacterTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Services
{
    public interface IChoiceServices
    {
        bool DetectChoiceInFeature(Feature feature);
        bool DetectChoiceInFeature(RaceFeature feature);

        bool DetectChoiceInRace(Race race);

        ChoiceViewModel CreateChoiceViewModelFromDB(Choice choice);

        ChoicesCollection CreateChoiceCollection(List<RaceFeature> raceFeatures, Character character);

        void ResolveChoice(int Id, ChoicesCollection choicesCollection);
    }
}

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

        bool DetectChoicesInClass(Class _class, int Level);

        ChoiceViewModel CreateChoiceViewModelFromDB(Choice choice);

        ChoicesCollection CreateChoiceCollection(List<RaceFeature> raceFeatures, Character character);

        ChoicesCollection CreateChoiceCollection(List<Feature> ClassFeatures, Character character);

        void ResolveChoice(int Id, ChoicesCollection choicesCollection);
    }
}

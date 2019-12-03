using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDCharacterTracker.Data;
using DnDCharacterTracker.Models;

namespace DnDCharacterTracker.Services
{
    public class ChoiceServices : IChoiceServices
    {
        private readonly ApplicationDbContext _context;
        public ChoiceServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public ChoiceViewModel CreateChoiceViewModelFromDB(Choice choice)
        {
            ChoiceViewModel returnChoiceViewModel = new ChoiceViewModel();

            returnChoiceViewModel.AllowedNumberOfChoices = choice.AllowedOptions;

            List<Option> availableOptions = _context.Options.Where(o => o.FK_Choice == choice.Id).ToList();

            for (int i = 0; i < availableOptions.Count; i++)
            {
                returnChoiceViewModel.OptionNames[i] = availableOptions[i].Name;
                returnChoiceViewModel.OptionDescriptions[i] = availableOptions[i].Description;
            }

            returnChoiceViewModel.Descriminator = choice.Descriminator;

            return returnChoiceViewModel;
        }

        public bool DetectChoiceInFeature(Feature feature)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DetectChoiceInFeature(RaceFeature feature)
        {
            return _context.RaceFeatureChoices.Where(rfc => rfc.FK_RaceFeature == feature.Id).Any();
        }

        public bool DetectChoiceInRace(Race race)
        {
            race.raceFeatures = _context.RaceRacefeatures.Where(rrf => rrf.FK_Race == race.Id).Select(c => c.RaceFeature).ToList();
            foreach (var raceFeature in race.raceFeatures)
            {
                if (await DetectChoiceInFeature(raceFeature))
                {
                    return true;
                }
            }

            return false;
        }

        public ChoicesCollection CreateChoiceCollection(List<RaceFeature> raceFeatures, Character character)
        {
            ChoicesCollection returnChoiceCollection = new ChoicesCollection();

            foreach (var raceFeature in raceFeatures)
            {
                if (DetectChoiceInFeature(raceFeature))
                {
                    returnChoiceCollection.Choices.Add(CreateChoiceViewModelFromDB(
                        _context.RaceFeatureChoices
                        .Where(c => c.FK_RaceFeature == raceFeature.Id)
                        .Select(c => c.Choice).FirstOrDefault()
                        ));
                }
            }

            returnChoiceCollection.Character = character;

            return returnChoiceCollection;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDCharacterTracker.Data;
using DnDCharacterTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace DnDCharacterTracker.Services
{
    public class ChoiceServices : IChoiceServices
    {
        private readonly ApplicationDbContext _context;
        private ICharacterServices _characterServices;
        public ChoiceServices(ApplicationDbContext context, ICharacterServices characterServices)
        {
            _context = context;
            _characterServices = characterServices;
        }

        public ChoiceViewModel CreateChoiceViewModelFromDB(Choice choice)
        {
            ChoiceViewModel returnChoiceViewModel = new ChoiceViewModel();

            returnChoiceViewModel.AllowedNumberOfChoices = choice.AllowedOptions;

            List<Option> availableOptions = _context.Options.Where(o => o.FK_Choice == choice.Id).ToList();


            returnChoiceViewModel.Description = _context.RaceFeatureChoices.Where(c => c.FK_Choice == choice.Id).Select(c => c.RaceFeature).FirstOrDefault().Description;
            returnChoiceViewModel.Name = _context.RaceFeatureChoices.Where(c => c.FK_Choice == choice.Id).Select(c => c.RaceFeature).FirstOrDefault().Name;

            returnChoiceViewModel.OptionNames = availableOptions.Select(i => i.Name).ToList();
            returnChoiceViewModel.OptionNames = availableOptions.Select(i => i.Description).ToList();

            for (int i = 0; i < availableOptions.Count; i++)
            {
                if (availableOptions[i].free)
                {
                    returnChoiceViewModel.FreeOptions.Add(true);
                }
                else
                {
                    returnChoiceViewModel.FreeOptions.Add(false);
                }
                
                if (availableOptions[i].Name != null)
                {
                    returnChoiceViewModel.OptionNames[i] = availableOptions[i].Name;
                }
                if (availableOptions[i].Description != null)
                {
                    returnChoiceViewModel.OptionDescriptions[i] = availableOptions[i].Description;
                }
                
            }
            ChoiceType choiceType;

             Enum.TryParse(choice.Descriminator, out choiceType);
            returnChoiceViewModel.Descriminator = choiceType;

            return returnChoiceViewModel;
        }

        public bool DetectChoiceInFeature(Feature feature)
        {
            throw new NotImplementedException();
        }

        public bool DetectChoiceInFeature(RaceFeature feature)
        {
            bool returnbool = false;

            returnbool = _context.RaceFeatureChoices.Where(rfc => rfc.FK_RaceFeature == feature.Id).Any();

            return returnbool;
        }

        public bool DetectChoiceInRace(Race race)
        {
            race.raceFeatures = _context.RaceRacefeatures.Where(rrf => rrf.FK_Race == race.Id).Select(c => c.RaceFeature).ToList();
            foreach (var raceFeature in race.raceFeatures)
            {
                if (DetectChoiceInFeature(raceFeature))
                {
                    return true;
                }
            }

            return false;
        }

        public ChoicesCollection CreateChoiceCollection(List<RaceFeature> raceFeatures, Character character)
        {
            ChoicesCollection returnChoiceCollection = new ChoicesCollection();

            returnChoiceCollection.Choices = new List<ChoiceViewModel>();

            foreach (var raceFeature in raceFeatures)
            {
                bool choicePresent = false;

                choicePresent = DetectChoiceInFeature(raceFeature);

                if (choicePresent)
                {
                    returnChoiceCollection.Choices.Add(CreateChoiceViewModelFromDB(
                        
                        _context.RaceFeatureChoices
                        .Where(c => c.FK_RaceFeature == raceFeature.Id)
                        .Select(c => c.Choice).Include(c => c.AvailableOptions).FirstOrDefault()
                        ));
                }

            }

            returnChoiceCollection.Character = character;

            return returnChoiceCollection;
        }

        public void ResolveChoice(int Id, ChoicesCollection choicesCollection)
        {
            choicesCollection.Character = _characterServices.GetCharacterFromId(Id);

            foreach (var choice in choicesCollection.Choices)
            {
                List<Option> options = new List<Option>();

                for (int i = 0; i < choice.OptionsChosen.Count; i++)
                {
                    if (choice.OptionsChosen[i])
                    {
                        options.Add(new Option { Name = choice.OptionNames[i] });
                    }
                    if (choice.OptionDescriptions.Count - 1 > i)
                    {
                        options[i].Description = choice.OptionDescriptions[i];
                    }
                }

                switch (choice.Descriminator)
                {
                    case ChoiceType.RacialLanguage:
                        foreach (var option in options)
                        {
                            _context.CharacterProficiencies.Add(new CharacterProficiency
                            {
                                FK_Character = Id,
                                FK_Proficiency = _context.Proficiencies.Where(p => p.Name == option.Name).Select(p => p.Id).FirstOrDefault()                                
                            }); ;
                        }                        
                        break;
                    default:
                        break;
                }
            }

            

            _context.SaveChanges();
        }
    }
}


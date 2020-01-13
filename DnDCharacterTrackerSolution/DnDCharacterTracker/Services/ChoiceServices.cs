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

        //creates an universal choice view model for all available options. This model is then returned to the view. 
        public ChoiceViewModel CreateChoiceViewModelFromDB(Choice choice)
        {
            ChoiceViewModel returnChoiceViewModel = new ChoiceViewModel();

            returnChoiceViewModel.AllowedNumberOfChoices = choice.AllowedOptions;

            List<Option> availableOptions = _context.Options.Where(o => o.FK_Choice == choice.Id).ToList();

            //Seperates the choice by type to the proper tables can be referenced. 
            ChoiceType _choiceType;

            Enum.TryParse(choice.Descriminator, out _choiceType);
            returnChoiceViewModel.Descriminator = _choiceType;

            //retreives info from the right table. Cases refer to eachother with goto to prevent duplicate code. 
            switch (_choiceType)
            {
                case ChoiceType.RacialLanguage:
                    goto case ChoiceType.RacialProficiency;
                case ChoiceType.RacialProficiency:
                    returnChoiceViewModel.Description = _context.RaceFeatureChoices.Where(c => c.FK_Choice == choice.Id).Select(c => c.RaceFeature).FirstOrDefault().Description;

                    returnChoiceViewModel.Name = _context.RaceFeatureChoices.Where(c => c.FK_Choice == choice.Id).Select(c => c.RaceFeature).FirstOrDefault().Name;
                    break;
                case ChoiceType.ClassSkillChoice:
                    goto case ChoiceType.ClassFeature;
                case ChoiceType.ClassFeature:
                    returnChoiceViewModel.Description = _context.FeatureChoices.Where(c => c.FK_Choice == choice.Id).Select(c => c.Feature).FirstOrDefault().Description;

                    returnChoiceViewModel.Name = _context.FeatureChoices.Where(c => c.FK_Choice == choice.Id).Select(c => c.Feature).FirstOrDefault().Name;
                    break;
                case ChoiceType.SubClass:
                    returnChoiceViewModel.Description = _context.FeatureChoices.Where(c => c.FK_Choice == choice.Id).Select(c => c.Feature).FirstOrDefault().Description;

                    returnChoiceViewModel.Name = _context.FeatureChoices.Where(c => c.FK_Choice == choice.Id).Select(c => c.Feature).FirstOrDefault().Name;

                    Feature feature = _context.FeatureChoices.Where(c => c.FK_Choice == choice.Id).Select(c => c.Feature).FirstOrDefault();

                    Class _class = _context.ClassFeatures.Where(cf => cf.FK_Feature == feature.Id).Select(cf => cf.Class).FirstOrDefault();

                    returnChoiceViewModel.OptionNames = _context.SubClasses.Where(sc => sc.FK_Class == _class.Id).Select(c => c.Name).ToList();

                    returnChoiceViewModel.OptionNames = _context.SubClasses.Where(sc => sc.FK_Class == _class.Id).Select(c => c.Name).ToList();

                    returnChoiceViewModel.OptionDescriptions = _context.SubClasses.Where(sc => sc.FK_Class == _class.Id).Select(c => c.Description).ToList();

                    foreach (var option in returnChoiceViewModel.OptionNames)
                    {
                        returnChoiceViewModel.FreeOptions.Add(false);
                    }

                    returnChoiceViewModel.OptionIds = _context.SubClasses.Where(sc => sc.FK_Class == _class.Id).Select(c => c.Id).ToList();

                    return returnChoiceViewModel;
                default:
                    break;
            }


            returnChoiceViewModel.OptionNames = availableOptions.Select(i => i.Name).ToList();
            returnChoiceViewModel.OptionDescriptions = availableOptions.Select(i => i.Description).ToList();

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

                returnChoiceViewModel.OptionIds = _context.Options.Where(c => c.FK_Choice == choice.Id).Select(c => c.Id).ToList();
                
            }



            return returnChoiceViewModel;
        }

        public bool DetectChoiceInFeature(Feature feature)
        {
            bool returnbool = false;

            returnbool = _context.FeatureChoices.Where(fc => fc.FK_Feature == feature.Id).Any();

            return returnbool;
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

        public ChoicesCollection CreateChoiceCollection(List<Feature> ClassFeatures, Character character)
        {
            ChoicesCollection returnChoiceCollection = new ChoicesCollection();

            returnChoiceCollection.Choices = new List<ChoiceViewModel>();

            foreach (var classFeature in ClassFeatures)
            {
                bool choicePresent = false;

                choicePresent = DetectChoiceInFeature(classFeature);

                if (choicePresent)
                {
                    returnChoiceCollection.Choices.Add(CreateChoiceViewModelFromDB(

                        _context.FeatureChoices
                        .Where(fc => fc.FK_Feature == classFeature.Id)
                        .Select(c => c.Choice).Include(c => c.AvailableOptions).FirstOrDefault()
                        ));
                }


            }

            returnChoiceCollection.Character = character;

            returnChoiceCollection.FK_Class = _context.ClassFeatures.Where(cf => cf.FK_Feature == ClassFeatures[0].Id).FirstOrDefault().FK_Class;

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
                        options.Add(new Option { Name = choice.OptionNames[i], Id = choice.OptionIds[i] });
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
                    case ChoiceType.RacialProficiency:
                        foreach (var option in options)
                        {
                            _context.CharacterProficiencies.Add(new CharacterProficiency
                            {
                                FK_Character = Id,
                                FK_Proficiency = _context.Proficiencies.Where(p => p.Name == option.Name).Select(p => p.Id).FirstOrDefault()                                
                            }); ;
                        }                        
                        break;
                    case ChoiceType.ClassSkillChoice:
                        foreach (var option in options)
                        {
                            _context.CharacterSkills.Add(new CharacterSkill
                            {
                                FK_Character = Id,
                                FK_Skill = _context.Skills.Where(s => s.Name == option.Name).Select(p => p.Id).FirstOrDefault(),
                            }); ;
                        }
                        break;
                    case ChoiceType.ClassFeature:

                        _context.Decisions.Add(new Decision
                        {
                            FK_Character = Id,
                            Description = choice.Description,
                            Name = choice.Name,
                            FK_Class = choicesCollection.FK_Class

                        });

                        //Is this really needed? Investigate this. 
                        _context.SaveChanges();

                        foreach (var option in options)
                        {
                            _context.DecisionOptions.Add(new DecisionOption
                            {
                                //FK_Decision = _context.Decisions.Count() +1,
                                FK_Decision = _context.Decisions.Where(d => d.FK_Character == Id && d.Description == choice.Description && d.Name == choice.Name).FirstOrDefault().Id,
                                FK_Option = option.Id
                            });;
                        }
                        break;
                    case ChoiceType.SubClass:
                        SubClass subClass = _context.SubClasses.Where(sc => sc.Id == options[0].Id).FirstOrDefault();

                        choicesCollection.Character.SubClasses.Add(subClass);

                        _context.characterSubClasses.Add(new CharacterSubClass { FK_Character = choicesCollection.Character.Id, FK_SubClass = subClass.Id });

                        _context.Log.Add(new LogItem { DateLogged = DateTime.Now, Message = $"Added subclass {subClass.Name} to {choicesCollection.Character.Name}, id {choicesCollection.Character.Id}." });
                        break;
                    default:
                        break;
                }
            }

            _context.Log.Add(new LogItem { DateLogged = DateTime.Now, Message = $"resolved {choicesCollection.Character.Name} choice, id {choicesCollection.Character.Id}." });

            _context.SaveChanges();
        }

        public bool DetectChoicesInClass(Class _class, int Level)
        {
            List<Feature> features = _context.ClassFeatures.Where(c => c.Level == Level && c.FK_Class == _class.Id).Select(c => c.Feature).ToList();

            if (features.Count() == 0)
            {
                features.AddRange(_context.SubClassFeatures.Where(c => c.Level == Level && c.SubClass.FK_Class == _class.Id).Select(c => c.Feature).ToList());
            }

            foreach (var feature in features)
            {
                if (_context.FeatureChoices.Where(c => c.FK_Feature == feature.Id).Any())
                {
                    return true;
                }
            }

            return false;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDCharacterTracker.Data;
using DnDCharacterTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace DnDCharacterTracker.Services
{
    public class CharacterServices : ICharacterServices
    {
        private readonly ApplicationDbContext _context;
        private IClassServices _classServices;
        public CharacterServices(ApplicationDbContext context, IClassServices classServices)
        {
            _context = context;
            _classServices = classServices;
        }

        public void AddCharacterClass(int id, Character character)
        {
            Class newClass = _context.Classes.Where(c => c.Id == id).FirstOrDefault();

            if (_context.CharacterClasses.Where(c => c.FK_Class == id && c.FK_Character == character.Id).Any())
            {
                _classServices.LevelExistingClass(character, newClass);
            }
            else
            {
                _classServices.AddNewClass(character, newClass);
            }

            _context.Update(character);
            _context.SaveChanges();
        }

        //split this up into getcharacter, getrace and getclass. Right now it does everything and that is poor form. 
        public Character GetCharacterFromId(int id)
        {
            Character returnCharacter = _context.Character.Where(c => c.Id == id).FirstOrDefault();

            returnCharacter.Race = _context.Races.Where(r => r.Id == returnCharacter.FK_Race).FirstOrDefault();

            returnCharacter.Classes = _context.CharacterClasses.Where(cc => cc.FK_Character == returnCharacter.Id).Select(c => c.Class).ToList();

            foreach (var @class in returnCharacter.Classes)
            {
                List<ClassFeature> features = _context.ClassFeatures.Include(c => c.Feature).Where(cf => cf.FK_Class == @class.Id).ToList();
                int classLevel = _context.CharacterClasses.Where(c => c.FK_Character == id && c.FK_Class == @class.Id).FirstOrDefault().Level;
                @class.classFeatures = features.Where(c => c.Level <= classLevel).Select(c => c.Feature).ToList();
            }

            returnCharacter.ClassIntermediaries = _context.CharacterClasses.Where(cc => cc.FK_Character == returnCharacter.Id).ToList();

            returnCharacter.RaceFeatures = _context.CharacterRaceFeatures.Where(c => c.FK_Character == returnCharacter.Id).Select(C => C.RaceFeature).ToList();

            returnCharacter.Proficiencies = _context.CharacterProficiencies.Where(cp => cp.FK_Character == returnCharacter.Id).Select(cp => cp.Proficiency).ToList();

            returnCharacter.SkillProficiencies = _context.CharacterSkills.Where(s => s.FK_Character == returnCharacter.Id).Include(c => c.Skill).ToList();

            List<Feature> classFeatures = new List<Feature>();

            List<ClassFeature> classFeaturesIntermiediaries = new List<ClassFeature>();

            foreach (var characterClass in returnCharacter.ClassIntermediaries)
            {
                classFeatures.AddRange(_context.ClassFeatures.Where(cf => cf.FK_Class == characterClass.FK_Class).Select(cf => cf.Feature).ToList());
                classFeaturesIntermiediaries.AddRange(_context.ClassFeatures.Where(cf => cf.FK_Class == characterClass.FK_Class).ToList());
            }

            for (int i = 0; i < classFeaturesIntermiediaries.Count; i++)
            {
                if (_context.Decisions.Where(d => d.Name == classFeatures[i].Name && d.Description == classFeatures[i].Description).Any())
                {
                    Decision decision = _context.Decisions.Where(d => d.Name == classFeatures[i].Name && d.Description == classFeatures[i].Description).FirstOrDefault();

                    List<Option> options = _context.DecisionOptions.Where(d => d.FK_Decision == decision.Id).Select(d => d.Option).ToList();

                    Feature newFeature = new Feature
                    {
                        Name = decision.Name,
                        Description = decision.Description

                    };

                    foreach (var option in options)
                    {
                        newFeature.Description += (" " + option.Name + ": " + option.Description);
                    }

                    returnCharacter.ClassFeatures.Add(newFeature);
                }
                else
                {
                    returnCharacter.ClassFeatures.Add(classFeatures[i]);
                }
            }

            _context.Log.Add(new LogItem { DateLogged = DateTime.Now, Message = $"Retrieved {returnCharacter.Name}, id {returnCharacter.Id} from Database." });

            //returnCharacter.Classes =

            return returnCharacter;
        }

        public int GetCharacterLevel(int Id)
        {
            int levelInt = 0;

            Character character = _context.Character.Where(c => c.Id == Id).FirstOrDefault();

            List<CharacterClass> characterClasses = _context.CharacterClasses.Where(cc => cc.FK_Character == character.Id).ToList();

            foreach (CharacterClass characterClass in characterClasses)
            {
                levelInt += characterClass.Level;
            }

            return levelInt;
        }

        public void RetrieveClassIntermediaries(Character character)
        {
            character.ClassIntermediaries = _context.CharacterClasses.Where(cc => cc.FK_Character == character.Id).ToList();
            foreach (var item in character.ClassIntermediaries)
            {
                item.Class = _context.Classes.Where(c => c.Id == item.FK_Class).FirstOrDefault();
            }
        }

        public void SetCharacterRace(int id, Character character)
        {
            character.FK_Race = id;

            character.Race = _context.Races.Where(r => r.Id == id).FirstOrDefault();

            character.Proficiencies.AddRange(_context.RaceProficiencies.Where(r => r.FK_Race == id).Select(r => r.Proficiency).ToList());

            foreach (var proficiency in character.Proficiencies)
            {
                _context.CharacterProficiencies.Add(new CharacterProficiency
                {
                    FK_Character = character.Id,
                    FK_Proficiency = proficiency.Id
                }); ;
            }

            //applies all the ability scores from the race to the character.
            foreach (var raceAbilityScores in _context.raceAbilityScores.Where(ra => ra.FK_Race == character.Race.Id).ToList())
            {
                ApplyAbilityScoreImprovements(character, raceAbilityScores);
            }

            foreach (var RaceFeature in _context.RaceRacefeatures.Where(rf => rf.FK_Race == character.Race.Id).ToList())
            {
                CharacterRaceFeature characterRaceFeature = new CharacterRaceFeature { Character = character, FK_Character = character.Id, FK_RaceFeature = RaceFeature.FK_RaceFeature };
                _context.Add(characterRaceFeature);
            }

            _context.Log.Add(new LogItem { DateLogged = DateTime.Now, Message = $"Set {character.Name} race to {character.Race.Name}, id {character.Id}." });

            _context.Update(character);
            _context.SaveChanges();
        }

        public void ApplyAbilityScoreImprovements(Character character, RaceAbilityScores raceAbilityScores)
        {
            switch (raceAbilityScores.FK_AbilityScore)
            {
                case 1:
                    character.Strenght += raceAbilityScores.amount;
                    break;
                case 2:
                    character.Dexterity += raceAbilityScores.amount;
                    break;
                case 3:
                    character.Constitution += raceAbilityScores.amount;
                    break;
                case 4:
                    character.Wisdom += raceAbilityScores.amount;
                    break;
                case 5:
                    character.Intelligence += raceAbilityScores.amount;
                    break;
                case 6:
                    character.Charisma += raceAbilityScores.amount;
                    break;
                default:
                    //maybe an exception?
                    break;
            }


        }

        public int GetClassLevel(Character character, Class _class)
        {
            if (character.Classes.Where(c => c.Id == _class.Id).Any())
            {
                return character.ClassIntermediaries.Where(c => c.FK_Class == _class.Id).FirstOrDefault().Level;
            }
            else
            {
                return 0;
            }
        }
    }
}

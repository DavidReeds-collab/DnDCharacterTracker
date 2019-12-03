using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDCharacterTracker.Data;
using DnDCharacterTracker.Models;

namespace DnDCharacterTracker.Services
{
    public class CharacterServices : ICharacterServices
    {
        private readonly ApplicationDbContext _context;
        public CharacterServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCharacterClass(int id, Character character)
        {
            Class newClass = _context.Classes.Where(c => c.Id == id).FirstOrDefault();
            character.Classes.Add(newClass);

            _context.CharacterClasses.Add(new CharacterClass
            {
                FK_Character = character.Id,
                FK_Class = id,
                Character = character,
                Class = newClass
            });

            _context.Update(character);
            _context.SaveChangesAsync();
        }

        public Character GetCharacterFromId(int id)
        {
            Character returnCharacter = _context.Character.Where(c => c.Id == id).FirstOrDefault();

            returnCharacter.Race = _context.Races.Where(r => r.Id == returnCharacter.FK_Race).FirstOrDefault();

            returnCharacter.Classes = _context.CharacterClasses.Where(cc => cc.FK_Character == returnCharacter.Id).Select(c => c.Class).ToList();

            returnCharacter.ClassIntermediaries = _context.CharacterClasses.Where(cc => cc.FK_Character == returnCharacter.Id).ToList();

            returnCharacter.RaceFeatures = _context.CharacterRaceFeatures.Where(c => c.FK_Character == returnCharacter.Id).Select(C => C.RaceFeature).ToList();

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

            _context.Update(character);
            _context.SaveChangesAsync();
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
    }
}

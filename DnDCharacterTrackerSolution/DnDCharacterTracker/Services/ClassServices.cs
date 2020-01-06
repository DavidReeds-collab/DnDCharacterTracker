using DnDCharacterTracker.Data;
using DnDCharacterTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Services
{
    public class ClassServices : IClassServices
    {
        private readonly ApplicationDbContext _context;
        public ClassServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddNewClass(Character character, Class _class)
        {
            character.Classes.Add(_class);

            character.Level += 1;

            _context.CharacterClasses.Add(new CharacterClass
            {
                FK_Character = character.Id,
                FK_Class = _class.Id,
                Character = character,
                Class = _class,
                Level = 1

            }) ;

            _context.Log.Add(new LogItem { DateLogged = DateTime.Now, Message = $"Added the first {_class.Name} to {character.Name}, id {character.Id}" });

            _context.SaveChanges();
        }

        public void LevelExistingClass(Character character, Class _class)
        {
            character.Level += 1;

            character.ClassIntermediaries.Where(ci => ci.FK_Class == _class.Id).FirstOrDefault().Level += 1;

            CharacterClass characterClass = _context.CharacterClasses.Where(cc => cc.FK_Class == _class.Id && cc.FK_Character == character.Id).FirstOrDefault();

            _context.Update(character);

            _context.Update(characterClass);

            _context.Log.Add(new LogItem { DateLogged = DateTime.Now, Message = $"Added a level in {_class.Name} to {character.Name}, id {character.Id}" });

            _context.SaveChanges();
        }
    }
}

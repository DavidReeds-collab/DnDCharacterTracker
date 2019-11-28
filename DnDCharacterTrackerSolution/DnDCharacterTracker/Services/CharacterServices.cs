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

        public Character GetCharacterFromId(int id)
        {
            Character returnCharacter = _context.Character.Where(c => c.Id == id).FirstOrDefault();

            List<Class> Classes = _context.CharacterClasses.Where(cc => cc.FK_Character == returnCharacter.Id).ToList();

            returnCharacter.Classes =

            return returnCharacter;
        }
    }
}

using DnDCharacterTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Services
{
    public interface IClassServices
    {
        void LevelExistingClass(Character character, Class _class);
        void AddNewClass(Character character, Class _class);
    }
}

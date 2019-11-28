using DnDCharacterTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Services
{
    interface ICharacterServices
    {
        Character GetCharacterFromId(int id);


    }
}

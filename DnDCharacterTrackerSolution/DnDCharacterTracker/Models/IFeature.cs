using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public interface IFeature
    {
        int Id { get; set; }

        string Name { get; set; }
        string Description { get; set; }
    }
}

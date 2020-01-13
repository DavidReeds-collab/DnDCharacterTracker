using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public interface IFeatureIntermediary
    {
        int Id { get; set; }

        int Level { get; set; }

        int FK_Feature { get; set; }
    }
}

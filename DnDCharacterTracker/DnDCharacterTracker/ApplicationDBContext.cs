using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DnDCharacterTracker
{
    public class ApplicationDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ApplicationDBContext() : base("name=ApplicationDBContext")
        {
        }

        public System.Data.Entity.DbSet<DnDCharacterTracker.Models.CharacterClass> CharacterClasses { get; set; }
        public System.Data.Entity.DbSet<DnDCharacterTracker.Models.Class> Classes { get; set; }
        public System.Data.Entity.DbSet<DnDCharacterTracker.Models.Character> Characters { get; set; }

        public System.Data.Entity.DbSet<DnDCharacterTracker.Models.Race> Races { get; set; }
    }
}

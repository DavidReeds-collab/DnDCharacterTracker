using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DnDCharacterTracker.Models;

namespace DnDCharacterTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DnDCharacterTracker.Models.Character> Character { get; set; }
        public DbSet<DnDCharacterTracker.Models.Race> Races { get; set; }
        public DbSet<DnDCharacterTracker.Models.Class> Classes { get; set; }
        public DbSet<DnDCharacterTracker.Models.CharacterClass> CharacterClasses { get; set; }
        public DbSet<DnDCharacterTracker.Models.AbilityScore> AbilityScores { get; set; }
        public DbSet<DnDCharacterTracker.Models.CharacterAbilities> CharacterAbilities { get; set; }
        public DbSet<DnDCharacterTracker.Models.ClassAbilities> ClassAbilities { get; set; }
        public DbSet<DnDCharacterTracker.Models.Skill> Skills { get; set; }
        public DbSet<DnDCharacterTracker.Models.CharacterSkill> CharacterSkills { get; set; }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DnDCharacterTracker.Models
{
    public partial class CharacterRollerContext : DbContext
    {
        public CharacterRollerContext()
        {
        }

        public CharacterRollerContext(DbContextOptions<CharacterRollerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbilityScore> AbilityScore { get; set; }
        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<CharacterAbilityScore> CharacterAbilityScore { get; set; }
        public virtual DbSet<CharacterClass> CharacterClass { get; set; }
        public virtual DbSet<CharacterFeature> CharacterFeature { get; set; }
        public virtual DbSet<CharacterSkills> CharacterSkills { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Features> Features { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CharacterRoller;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbilityScore>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FkRace).HasColumnName("FK_Race");

                entity.HasOne(d => d.FkRaceNavigation)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.FkRace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Character_Race");
            });

            modelBuilder.Entity<CharacterAbilityScore>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkAbilityScore).HasColumnName("FK_AbilityScore");

                entity.Property(e => e.FkCharacter).HasColumnName("FK_Character");

                entity.HasOne(d => d.FkAbilityScoreNavigation)
                    .WithMany(p => p.CharacterAbilityScore)
                    .HasForeignKey(d => d.FkAbilityScore)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterAbilityScore_AbilityScore");

                entity.HasOne(d => d.FkCharacterNavigation)
                    .WithMany(p => p.CharacterAbilityScore)
                    .HasForeignKey(d => d.FkCharacter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterAbilityScore_Character");
            });

            modelBuilder.Entity<CharacterClass>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FkCharacter).HasColumnName("FK_Character");

                entity.Property(e => e.FkClass).HasColumnName("FK_Class");

                entity.HasOne(d => d.FkCharacterNavigation)
                    .WithMany(p => p.CharacterClass)
                    .HasForeignKey(d => d.FkCharacter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterClass_Character");

                entity.HasOne(d => d.FkClassNavigation)
                    .WithMany(p => p.CharacterClass)
                    .HasForeignKey(d => d.FkClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterClass_Class");
            });

            modelBuilder.Entity<CharacterFeature>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FkCharacter).HasColumnName("FK_Character");

                entity.Property(e => e.FkFeature).HasColumnName("FK_Feature");

                entity.HasOne(d => d.FkCharacterNavigation)
                    .WithMany(p => p.CharacterFeature)
                    .HasForeignKey(d => d.FkCharacter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterFeature_Character");

                entity.HasOne(d => d.FkFeatureNavigation)
                    .WithMany(p => p.CharacterFeature)
                    .HasForeignKey(d => d.FkFeature)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterFeature_Features");
            });

            modelBuilder.Entity<CharacterSkills>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FkCharacter).HasColumnName("FK_Character");

                entity.Property(e => e.FkSkill).HasColumnName("FK_Skill");

                entity.HasOne(d => d.FkCharacterNavigation)
                    .WithMany(p => p.CharacterSkills)
                    .HasForeignKey(d => d.FkCharacter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterSkills_Character");

                entity.HasOne(d => d.FkSkillNavigation)
                    .WithMany(p => p.CharacterSkills)
                    .HasForeignKey(d => d.FkSkill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterSkills_Skill");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Features>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Feature)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

namespace DnDCharacterTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterFK = c.Int(nullable: false),
                        ClassFK = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterFK, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.ClassFK, cascadeDelete: true)
                .Index(t => t.CharacterFK)
                .Index(t => t.ClassFK);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        RaceFK = c.Int(nullable: false),
                        Strenght = c.Int(nullable: false),
                        Dexterity = c.Int(nullable: false),
                        Constitution = c.Int(nullable: false),
                        Wisdom = c.Int(nullable: false),
                        Intelligence = c.Int(nullable: false),
                        Charisma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.RaceFK, cascadeDelete: true)
                .Index(t => t.RaceFK);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharacterClasses", "ClassFK", "dbo.Classes");
            DropForeignKey("dbo.CharacterClasses", "CharacterFK", "dbo.Characters");
            DropForeignKey("dbo.Characters", "RaceFK", "dbo.Races");
            DropIndex("dbo.Characters", new[] { "RaceFK" });
            DropIndex("dbo.CharacterClasses", new[] { "ClassFK" });
            DropIndex("dbo.CharacterClasses", new[] { "CharacterFK" });
            DropTable("dbo.Classes");
            DropTable("dbo.Races");
            DropTable("dbo.Characters");
            DropTable("dbo.CharacterClasses");
        }
    }
}

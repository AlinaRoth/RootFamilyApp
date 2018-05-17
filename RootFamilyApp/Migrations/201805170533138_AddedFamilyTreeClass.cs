namespace RootFamilyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFamilyTreeClass : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
            CreateTable(
                "dbo.FamilyTrees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ChangeDate = c.DateTime(nullable: false),
                        FilePath = c.String(),
                        FileContents = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TreeHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GedcomId = c.String(),
                        FamilyTreeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyTrees", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.TreeNotes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GedcomId = c.String(),
                        FamilyTreeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyTrees", t => t.FamilyTreeId, cascadeDelete: true)
                .Index(t => t.FamilyTreeId);
            
            CreateTable(
                "dbo.TreeRepositories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GedcomId = c.String(),
                        FamilyTreeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyTrees", t => t.FamilyTreeId, cascadeDelete: true)
                .Index(t => t.FamilyTreeId);
            
            CreateTable(
                "dbo.TreeSources",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GedcomId = c.String(),
                        FamilyTreeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyTrees", t => t.FamilyTreeId, cascadeDelete: true)
                .Index(t => t.FamilyTreeId);
            
            CreateTable(
                "dbo.TreeSubmitters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GedcomId = c.String(),
                        FamilyTreeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyTrees", t => t.FamilyTreeId, cascadeDelete: true)
                .Index(t => t.FamilyTreeId);
            
            AddColumn("dbo.Families", "FamilyTreeId", c => c.Guid(nullable: false));
            AddColumn("dbo.Individuals", "FamilyTreeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Families", "FamilyTreeId");
            CreateIndex("dbo.Individuals", "FamilyTreeId");
            AddForeignKey("dbo.Families", "FamilyTreeId", "dbo.FamilyTrees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Individuals", "FamilyTreeId", "dbo.FamilyTrees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TreeSubmitters", "FamilyTreeId", "dbo.FamilyTrees");
            DropForeignKey("dbo.TreeSources", "FamilyTreeId", "dbo.FamilyTrees");
            DropForeignKey("dbo.TreeRepositories", "FamilyTreeId", "dbo.FamilyTrees");
            DropForeignKey("dbo.TreeNotes", "FamilyTreeId", "dbo.FamilyTrees");
            DropForeignKey("dbo.Individuals", "FamilyTreeId", "dbo.FamilyTrees");
            DropForeignKey("dbo.TreeHeaders", "Id", "dbo.FamilyTrees");
            DropForeignKey("dbo.Families", "FamilyTreeId", "dbo.FamilyTrees");
            DropIndex("dbo.TreeSubmitters", new[] { "FamilyTreeId" });
            DropIndex("dbo.TreeSources", new[] { "FamilyTreeId" });
            DropIndex("dbo.TreeRepositories", new[] { "FamilyTreeId" });
            DropIndex("dbo.TreeNotes", new[] { "FamilyTreeId" });
            DropIndex("dbo.TreeHeaders", new[] { "Id" });
            DropIndex("dbo.Individuals", new[] { "FamilyTreeId" });
            DropIndex("dbo.Families", new[] { "FamilyTreeId" });
            DropColumn("dbo.Individuals", "FamilyTreeId");
            DropColumn("dbo.Families", "FamilyTreeId");
            DropTable("dbo.TreeSubmitters");
            DropTable("dbo.TreeSources");
            DropTable("dbo.TreeRepositories");
            DropTable("dbo.TreeNotes");
            DropTable("dbo.TreeHeaders");
            DropTable("dbo.FamilyTrees");
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
        }
    }
}

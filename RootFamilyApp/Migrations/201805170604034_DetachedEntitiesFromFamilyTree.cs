namespace RootFamilyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetachedEntitiesFromFamilyTree : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TreeHeaders", "Id", "dbo.FamilyTrees");
            DropForeignKey("dbo.TreeNotes", "FamilyTreeId", "dbo.FamilyTrees");
            DropForeignKey("dbo.TreeRepositories", "FamilyTreeId", "dbo.FamilyTrees");
            DropForeignKey("dbo.TreeSources", "FamilyTreeId", "dbo.FamilyTrees");
            DropForeignKey("dbo.TreeSubmitters", "FamilyTreeId", "dbo.FamilyTrees");
            DropIndex("dbo.TreeHeaders", new[] { "Id" });
            DropIndex("dbo.TreeNotes", new[] { "FamilyTreeId" });
            DropIndex("dbo.TreeRepositories", new[] { "FamilyTreeId" });
            DropIndex("dbo.TreeSources", new[] { "FamilyTreeId" });
            DropIndex("dbo.TreeSubmitters", new[] { "FamilyTreeId" });
            DropColumn("dbo.TreeHeaders", "FamilyTreeId");
            DropColumn("dbo.TreeNotes", "FamilyTreeId");
            DropColumn("dbo.TreeRepositories", "FamilyTreeId");
            DropColumn("dbo.TreeSources", "FamilyTreeId");
            DropColumn("dbo.TreeSubmitters", "FamilyTreeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TreeSubmitters", "FamilyTreeId", c => c.Guid(nullable: false));
            AddColumn("dbo.TreeSources", "FamilyTreeId", c => c.Guid(nullable: false));
            AddColumn("dbo.TreeRepositories", "FamilyTreeId", c => c.Guid(nullable: false));
            AddColumn("dbo.TreeNotes", "FamilyTreeId", c => c.Guid(nullable: false));
            AddColumn("dbo.TreeHeaders", "FamilyTreeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.TreeSubmitters", "FamilyTreeId");
            CreateIndex("dbo.TreeSources", "FamilyTreeId");
            CreateIndex("dbo.TreeRepositories", "FamilyTreeId");
            CreateIndex("dbo.TreeNotes", "FamilyTreeId");
            CreateIndex("dbo.TreeHeaders", "Id");
            AddForeignKey("dbo.TreeSubmitters", "FamilyTreeId", "dbo.FamilyTrees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TreeSources", "FamilyTreeId", "dbo.FamilyTrees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TreeRepositories", "FamilyTreeId", "dbo.FamilyTrees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TreeNotes", "FamilyTreeId", "dbo.FamilyTrees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TreeHeaders", "Id", "dbo.FamilyTrees", "Id");
        }
    }
}

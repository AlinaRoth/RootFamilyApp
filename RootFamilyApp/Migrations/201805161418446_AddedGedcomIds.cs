namespace RootFamilyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGedcomIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Families", "GedcomId", c => c.String());
            AddColumn("dbo.Individuals", "GedcomId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Individuals", "GedcomId");
            DropColumn("dbo.Families", "GedcomId");
        }
    }
}

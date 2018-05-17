namespace RootFamilyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFamilyName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Families", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Families", "Name");
        }
    }
}

namespace RootFamilyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDateToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IndividualEvents", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IndividualEvents", "Date", c => c.DateTime(nullable: false));
        }
    }
}

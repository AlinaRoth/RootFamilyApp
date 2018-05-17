namespace RootFamilyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicFamilyStructure : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WifeId = c.Guid(),
                        HusbandId = c.Guid(),
                        NumberOfChildren = c.Int(nullable: false),
                        Individual_Id = c.Guid(),
                        Individual_Id1 = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Individuals", t => t.Individual_Id)
                .ForeignKey("dbo.Individuals", t => t.Individual_Id1)
                .ForeignKey("dbo.Individuals", t => t.HusbandId)
                .ForeignKey("dbo.Individuals", t => t.WifeId)
                .Index(t => t.WifeId)
                .Index(t => t.HusbandId)
                .Index(t => t.Individual_Id)
                .Index(t => t.Individual_Id1);
            
            CreateTable(
                "dbo.Individuals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Sex = c.Int(nullable: false),
                        Family_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.Family_Id)
                .Index(t => t.Family_Id);
            
            CreateTable(
                "dbo.IndividualAttributes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Text = c.String(),
                        Location = c.String(),
                        Date = c.DateTime(nullable: false),
                        Individual_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Individuals", t => t.Individual_Id)
                .Index(t => t.Individual_Id);
            
            CreateTable(
                "dbo.IndividualEvents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IndividualId = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Location = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Individuals", t => t.IndividualId, cascadeDelete: true)
                .Index(t => t.IndividualId);
            
            CreateTable(
                "dbo.IndividualNames",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IndividualId = c.Guid(nullable: false),
                        FullName = c.String(),
                        Type = c.Int(nullable: false),
                        Prefix = c.String(),
                        Given = c.String(),
                        Nickname = c.String(),
                        SurnamePrefix = c.String(),
                        Surname = c.String(),
                        Suffix = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Individuals", t => t.IndividualId, cascadeDelete: true)
                .Index(t => t.IndividualId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Families", "WifeId", "dbo.Individuals");
            DropForeignKey("dbo.Families", "HusbandId", "dbo.Individuals");
            DropForeignKey("dbo.Individuals", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.Families", "Individual_Id1", "dbo.Individuals");
            DropForeignKey("dbo.IndividualNames", "IndividualId", "dbo.Individuals");
            DropForeignKey("dbo.IndividualEvents", "IndividualId", "dbo.Individuals");
            DropForeignKey("dbo.Families", "Individual_Id", "dbo.Individuals");
            DropForeignKey("dbo.IndividualAttributes", "Individual_Id", "dbo.Individuals");
            DropIndex("dbo.IndividualNames", new[] { "IndividualId" });
            DropIndex("dbo.IndividualEvents", new[] { "IndividualId" });
            DropIndex("dbo.IndividualAttributes", new[] { "Individual_Id" });
            DropIndex("dbo.Individuals", new[] { "Family_Id" });
            DropIndex("dbo.Families", new[] { "Individual_Id1" });
            DropIndex("dbo.Families", new[] { "Individual_Id" });
            DropIndex("dbo.Families", new[] { "HusbandId" });
            DropIndex("dbo.Families", new[] { "WifeId" });
            DropTable("dbo.IndividualNames");
            DropTable("dbo.IndividualEvents");
            DropTable("dbo.IndividualAttributes");
            DropTable("dbo.Individuals");
            DropTable("dbo.Families");
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
        }
    }
}

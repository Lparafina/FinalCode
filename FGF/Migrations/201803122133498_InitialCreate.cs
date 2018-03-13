namespace FGF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Int(nullable: false),
                        Title = c.String(),
                        NumofEvents = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Register",
                c => new
                    {
                        RegisterID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Types = c.Int(),
                    })
                .PrimaryKey(t => t.RegisterID)
                .ForeignKey("dbo.Event", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        Secret = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Register", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Register", "EventID", "dbo.Event");
            DropIndex("dbo.Register", new[] { "StudentID" });
            DropIndex("dbo.Register", new[] { "EventID" });
            DropTable("dbo.Student");
            DropTable("dbo.Register");
            DropTable("dbo.Event");
        }
    }
}

namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParentStudent1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FamilyName = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        MotherName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        HomePhone = c.Int(nullable: false),
                        Mobile1 = c.String(nullable: false),
                        Mobile2 = c.String(nullable: false),
                        Email1 = c.String(nullable: false),
                        Email2 = c.String(),
                        FatherWillVolunteer = c.Boolean(nullable: false),
                        FatherWillTeach = c.Boolean(nullable: false),
                        MotherWillVolunteer = c.Boolean(nullable: false),
                        MotherWillTeach = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(),
                        MobileNo = c.String(),
                        ParentID = c.Byte(nullable: false),
                        parent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Parents", t => t.parent_ID)
                .Index(t => t.parent_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "parent_ID", "dbo.Parents");
            DropIndex("dbo.Students", new[] { "parent_ID" });
            DropTable("dbo.Students");
            DropTable("dbo.Parents");
        }
    }
}

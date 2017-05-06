namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudentUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.StudentID)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentUsers", "StudentID", "dbo.Students");
            DropIndex("dbo.StudentUsers", new[] { "UserId" });
            DropIndex("dbo.StudentUsers", new[] { "StudentID" });
            DropTable("dbo.StudentUsers");
        }
    }
}

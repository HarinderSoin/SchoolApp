namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudentAttendence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentAttendences",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StudentAssignmentID = c.Int(nullable: false),
                        AttendenceDate = c.DateTime(nullable: false),
                        IsPresent = c.Boolean(nullable: false),
                        InsertUser = c.String(),
                        InsertDate = c.DateTime(nullable: false),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.StudentAssignments", t => t.StudentAssignmentID)
                .Index(t => t.StudentAssignmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAttendences", "StudentAssignmentID", "dbo.StudentAssignments");
            DropIndex("dbo.StudentAttendences", new[] { "StudentAssignmentID" });
            DropTable("dbo.StudentAttendences");
        }
    }
}

namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassRoomGradeSubjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassPeriods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Period = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClassGrade = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mandatory = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoomDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.Grades", new[] { "SubjectID" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Subjects");
            DropTable("dbo.Grades");
            DropTable("dbo.ClassPeriods");
        }
    }
}

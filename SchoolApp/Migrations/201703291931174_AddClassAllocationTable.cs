using System.Data.SqlClient;

namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassAllocationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassAllocations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GradeID = c.Int(nullable: false),
                        ClassPeriodID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                        AcademicYearID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearID, cascadeDelete: true)
                .ForeignKey("dbo.ClassPeriods", t => t.ClassPeriodID, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.GradeID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.GradeID)
                .Index(t => t.ClassPeriodID)
                .Index(t => t.SubjectID)
                .Index(t => t.RoomID)
                .Index(t => t.AcademicYearID) ;
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassAllocations", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.ClassAllocations", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.ClassAllocations", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.ClassAllocations", "ClassPeriodID", "dbo.ClassPeriods");
            DropForeignKey("dbo.ClassAllocations", "AcademicYearID", "dbo.AcademicYears");
            DropIndex("dbo.ClassAllocations", new[] { "AcademicYearID" });
            DropIndex("dbo.ClassAllocations", new[] { "RoomID" });
            DropIndex("dbo.ClassAllocations", new[] { "SubjectID" });
            DropIndex("dbo.ClassAllocations", new[] { "ClassPeriodID" });
            DropIndex("dbo.ClassAllocations", new[] { "GradeID" });
            DropTable("dbo.ClassAllocations");
        }
    }
}

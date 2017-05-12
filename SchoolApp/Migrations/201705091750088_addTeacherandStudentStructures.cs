namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTeacherandStudentStructures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentAssignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        GradeID = c.Int(nullable: false),
                        InsertDate = c.DateTime(nullable: false),
                        InsertUser = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Grades", t => t.GradeID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.SubjectID)
                .Index(t => t.GradeID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        AcademicYearID = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        InsertDate = c.DateTime(nullable: false),
                        InsertUser = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.AcademicYearID)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TeacherAssignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        GradeID = c.Int(nullable: false),
                        InsertDate = c.DateTime(nullable: false),
                        InsertUser = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Grades", t => t.GradeID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.SubjectID)
                .Index(t => t.GradeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherAssignments", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.TeacherAssignments", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.TeacherAssignments", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.Teachers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Teachers", "AcademicYearID", "dbo.AcademicYears");
            DropForeignKey("dbo.StudentAssignments", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.StudentAssignments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentAssignments", "GradeID", "dbo.Grades");
            DropIndex("dbo.TeacherAssignments", new[] { "GradeID" });
            DropIndex("dbo.TeacherAssignments", new[] { "SubjectID" });
            DropIndex("dbo.TeacherAssignments", new[] { "TeacherID" });
            DropIndex("dbo.Teachers", new[] { "UserId" });
            DropIndex("dbo.Teachers", new[] { "AcademicYearID" });
            DropIndex("dbo.StudentAssignments", new[] { "GradeID" });
            DropIndex("dbo.StudentAssignments", new[] { "SubjectID" });
            DropIndex("dbo.StudentAssignments", new[] { "StudentID" });
            DropTable("dbo.TeacherAssignments");
            DropTable("dbo.Teachers");
            DropTable("dbo.StudentAssignments");
        }
    }
}

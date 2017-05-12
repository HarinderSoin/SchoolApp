namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudentAssessment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentAssessments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        AssessmentGradesID = c.Int(nullable: false),
                        AcademicYearID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearID, cascadeDelete: true)
                .ForeignKey("dbo.AssessmentGrades", t => t.AssessmentGradesID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.AssessmentGradesID)
                .Index(t => t.AcademicYearID);
            
            CreateTable(
                "dbo.AssessmentGrades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssessmentGrade = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAssessments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentAssessments", "AssessmentGradesID", "dbo.AssessmentGrades");
            DropForeignKey("dbo.StudentAssessments", "AcademicYearID", "dbo.AcademicYears");
            DropIndex("dbo.StudentAssessments", new[] { "AcademicYearID" });
            DropIndex("dbo.StudentAssessments", new[] { "AssessmentGradesID" });
            DropIndex("dbo.StudentAssessments", new[] { "StudentID" });
            DropTable("dbo.AssessmentGrades");
            DropTable("dbo.StudentAssessments");
        }
    }
}

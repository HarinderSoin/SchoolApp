namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixStudentAssessment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentAssessments", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.StudentAssessments", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.StudentAssessments", new[] { "SubjectID" });
            DropIndex("dbo.StudentAssessments", new[] { "GradeID" });
            AddColumn("dbo.StudentAssessments", "ClassAllocationID", c => c.Int(nullable: false, defaultValue:10));
            CreateIndex("dbo.StudentAssessments", "ClassAllocationID");
            AddForeignKey("dbo.StudentAssessments", "ClassAllocationID", "dbo.ClassAllocations", "ID");
            DropColumn("dbo.StudentAssessments", "SubjectID");
            DropColumn("dbo.StudentAssessments", "GradeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentAssessments", "GradeID", c => c.Int(nullable: false));
            AddColumn("dbo.StudentAssessments", "SubjectID", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentAssessments", "ClassAllocationID", "dbo.ClassAllocations");
            DropIndex("dbo.StudentAssessments", new[] { "ClassAllocationID" });
            DropColumn("dbo.StudentAssessments", "ClassAllocationID");
            CreateIndex("dbo.StudentAssessments", "GradeID");
            CreateIndex("dbo.StudentAssessments", "SubjectID");
            AddForeignKey("dbo.StudentAssessments", "SubjectID", "dbo.Subjects", "ID");
            AddForeignKey("dbo.StudentAssessments", "GradeID", "dbo.Grades", "ID");
        }
    }
}

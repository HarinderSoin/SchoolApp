namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeStudentAssignment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentAssignments", "AcademicYearID", "dbo.AcademicYears");
            DropForeignKey("dbo.StudentAssignments", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.StudentAssignments", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.StudentAssignments", new[] { "SubjectID" });
            DropIndex("dbo.StudentAssignments", new[] { "GradeID" });
            DropIndex("dbo.StudentAssignments", new[] { "AcademicYearID" });
            AddColumn("dbo.StudentAssignments", "ClassAllocationID", c => c.Int(nullable: false, defaultValue:10));
            CreateIndex("dbo.StudentAssignments", "ClassAllocationID");
            AddForeignKey("dbo.StudentAssignments", "ClassAllocationID", "dbo.ClassAllocations", "ID");
            DropColumn("dbo.StudentAssignments", "SubjectID");
            DropColumn("dbo.StudentAssignments", "GradeID");
            DropColumn("dbo.StudentAssignments", "AcademicYearID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentAssignments", "AcademicYearID", c => c.Int(nullable: false));
            AddColumn("dbo.StudentAssignments", "GradeID", c => c.Int(nullable: false));
            AddColumn("dbo.StudentAssignments", "SubjectID", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentAssignments", "ClassAllocationID", "dbo.ClassAllocations");
            DropIndex("dbo.StudentAssignments", new[] { "ClassAllocationID" });
            DropColumn("dbo.StudentAssignments", "ClassAllocationID");
            CreateIndex("dbo.StudentAssignments", "AcademicYearID");
            CreateIndex("dbo.StudentAssignments", "GradeID");
            CreateIndex("dbo.StudentAssignments", "SubjectID");
            AddForeignKey("dbo.StudentAssignments", "SubjectID", "dbo.Subjects", "ID");
            AddForeignKey("dbo.StudentAssignments", "GradeID", "dbo.Grades", "ID");
            AddForeignKey("dbo.StudentAssignments", "AcademicYearID", "dbo.AcademicYears", "ID");
        }
    }
}

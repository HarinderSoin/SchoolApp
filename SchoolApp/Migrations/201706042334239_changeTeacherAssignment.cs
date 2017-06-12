namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTeacherAssignment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherAssignments", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.TeacherAssignments", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.TeacherAssignments", new[] { "SubjectID" });
            DropIndex("dbo.TeacherAssignments", new[] { "GradeID" });
            AddColumn("dbo.TeacherAssignments", "ClassAllocationID", c => c.Int(nullable: false, defaultValue:10));
            CreateIndex("dbo.TeacherAssignments", "ClassAllocationID");
            AddForeignKey("dbo.TeacherAssignments", "ClassAllocationID", "dbo.ClassAllocations", "ID");
            DropColumn("dbo.TeacherAssignments", "SubjectID");
            DropColumn("dbo.TeacherAssignments", "GradeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TeacherAssignments", "GradeID", c => c.Int(nullable: false));
            AddColumn("dbo.TeacherAssignments", "SubjectID", c => c.Int(nullable: false));
            DropForeignKey("dbo.TeacherAssignments", "ClassAllocationID", "dbo.ClassAllocations");
            DropIndex("dbo.TeacherAssignments", new[] { "ClassAllocationID" });
            DropColumn("dbo.TeacherAssignments", "ClassAllocationID");
            CreateIndex("dbo.TeacherAssignments", "GradeID");
            CreateIndex("dbo.TeacherAssignments", "SubjectID");
            AddForeignKey("dbo.TeacherAssignments", "SubjectID", "dbo.Subjects", "ID");
            AddForeignKey("dbo.TeacherAssignments", "GradeID", "dbo.Grades", "ID");
        }
    }
}

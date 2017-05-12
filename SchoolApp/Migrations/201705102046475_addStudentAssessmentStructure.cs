namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudentAssessmentStructure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentAssessments", "SubjectID", c => c.Int(nullable: false));
            AddColumn("dbo.StudentAssessments", "GradeID", c => c.Int(nullable: false));
            AddColumn("dbo.StudentAssessments", "InsertDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.StudentAssessments", "InsertUser", c => c.String());
            AddColumn("dbo.StudentAssessments", "UpdateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.StudentAssessments", "UpdateUser", c => c.String());
            CreateIndex("dbo.StudentAssessments", "SubjectID");
            CreateIndex("dbo.StudentAssessments", "GradeID");
            AddForeignKey("dbo.StudentAssessments", "GradeID", "dbo.Grades", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentAssessments", "SubjectID", "dbo.Subjects", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAssessments", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.StudentAssessments", "GradeID", "dbo.Grades");
            DropIndex("dbo.StudentAssessments", new[] { "GradeID" });
            DropIndex("dbo.StudentAssessments", new[] { "SubjectID" });
            DropColumn("dbo.StudentAssessments", "UpdateUser");
            DropColumn("dbo.StudentAssessments", "UpdateDate");
            DropColumn("dbo.StudentAssessments", "InsertUser");
            DropColumn("dbo.StudentAssessments", "InsertDate");
            DropColumn("dbo.StudentAssessments", "GradeID");
            DropColumn("dbo.StudentAssessments", "SubjectID");
        }
    }
}

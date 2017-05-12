namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAssessmentDateToStudentAssessments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentAssessments", "AssessmentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentAssessments", "AssessmentDate");
        }
    }
}

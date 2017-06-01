namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAcademicYearToStudentAssignments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentAssignments", "AcademicYearID", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentAssignments", "AcademicYearID");
            AddForeignKey("dbo.StudentAssignments", "AcademicYearID", "dbo.AcademicYears", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAssignments", "AcademicYearID", "dbo.AcademicYears");
            DropIndex("dbo.StudentAssignments", new[] { "AcademicYearID" });
            DropColumn("dbo.StudentAssignments", "AcademicYearID");
        }
    }
}

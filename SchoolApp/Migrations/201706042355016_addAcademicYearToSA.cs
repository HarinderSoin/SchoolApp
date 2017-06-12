namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAcademicYearToSA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentAssignments", "AcademicYearID", c => c.Int(nullable: false, defaultValue:1));
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

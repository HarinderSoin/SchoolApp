namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAcademicYearToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "AcademicYearID", c => c.Int(nullable: false, defaultValue:1));
            CreateIndex("dbo.Students", "AcademicYearID");
            AddForeignKey("dbo.Students", "AcademicYearID", "dbo.AcademicYears", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "AcademicYearID", "dbo.AcademicYears");
            DropIndex("dbo.Students", new[] { "AcademicYearID" });
            DropColumn("dbo.Students", "AcademicYearID");
        }
    }
}

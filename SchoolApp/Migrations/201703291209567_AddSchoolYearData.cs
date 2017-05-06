namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSchoolYearData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicYears",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SchoolYear = c.String(),
                    })
                .PrimaryKey(t => t.ID);

            // Insert Prelim Data
            Sql("Insert into AcademicYears values('2017-2018')");
            Sql("Insert into AcademicYears values('2018-2019')");

        }
        
        public override void Down()
        {
            DropTable("dbo.AcademicYears");
        }
    }
}

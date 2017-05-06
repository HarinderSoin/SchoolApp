namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyGrades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grades", "ClassDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grades", "ClassDescription");
        }
    }
}

namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makedatesoptionalTeachers : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Teachers ALTER COLUMN InsertDate DateTime NULL");
            Sql("ALTER TABLE Teachers ALTER COLUMN UpdateDate DateTime NULL");
        }
        
        public override void Down()
        {
        }
    }
}

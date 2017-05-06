namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClassPeriods : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into ClassPeriods values (1, '10:30 am - 11:20 am')");
            Sql("Insert into ClassPeriods values (2, '11:20 am - 12:00 pm')");
            Sql("Insert into ClassPeriods values (3, '12:00 pm - 12:40 pm')");
            Sql("Insert into ClassPeriods values (4, '12:40 pm - 01:20 pm')");
        }
        
        public override void Down()
        {
        }
    }
}

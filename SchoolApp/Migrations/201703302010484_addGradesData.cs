namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGradesData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Grades values(1,'Level 1')");
            Sql("Insert into Grades values(2,'Level 2')");
            Sql("Insert into Grades values(3,'Level 3')");
            Sql("Insert into Grades values(4,'Level 4')");
            Sql("Insert into Grades values(5,'Level 5')");
            Sql("Insert into Grades values(6,'Level 6')");
            Sql("Insert into Grades values(7,'Level 7')");
            Sql("Insert into Grades values(8,'Level 8')");
            Sql("Insert into Grades values(9,'Level 9')");
        }
        
        public override void Down()
        {
        }
    }
}

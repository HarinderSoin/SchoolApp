namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGradesSubjectRoomData : DbMigration
    {
        public override void Up()
        {
            //Add Subject Data
            Sql("Insert into Subjects values('Gurmukhi', 'True')");
            Sql("Insert into Subjects values('Kirtan', 'True')");
            Sql("Insert into Subjects values('History', 'True')");

            //Add Grades Data
                // Add Gurmukhi Data
            Sql("Insert into Grades values('Grades 1', 1)");
            Sql("Insert into Grades values('Grades 2', 1)");
            Sql("Insert into Grades values('Grades 3', 1)");
            Sql("Insert into Grades values('Grades 4', 1)");
            Sql("Insert into Grades values('Grades 5', 1)");
            Sql("Insert into Grades values('Grades 6', 1)");
            Sql("Insert into Grades values('Grades 7', 1)");

                //Add Kirtan Data
            Sql("Insert into Grades values('Level 1', 2)");
            Sql("Insert into Grades values('Level 2', 2)");
            Sql("Insert into Grades values('Level 3', 2)");
            Sql("Insert into Grades values('Level 4', 2)");
            Sql("Insert into Grades values('Level 5', 2)");
            Sql("Insert into Grades values('Level 6', 2)");
            Sql("Insert into Grades values('Level 7', 2)");
            Sql("Insert into Grades values('Level 8', 2)");
            Sql("Insert into Grades values('Level 9', 2)");

                //Add History Data
            Sql("Insert into Grades values('Grades 1', 3)");
            Sql("Insert into Grades values('Grades 2', 3)");
            Sql("Insert into Grades values('Grades 3', 3)");
            Sql("Insert into Grades values('Grades 4', 3)");
            Sql("Insert into Grades values('Grades 5', 3)");
            Sql("Insert into Grades values('Grades 6', 3)");
            Sql("Insert into Grades values('Grades 7', 3)");
            Sql("Insert into Grades values('Grades 8', 3)");

            //Add Rooms
            Sql("Insert into Rooms values('Mata Gujri')");
            Sql("Insert into Rooms values('Mai Bhago')");
        }
        
        public override void Down()
        {
        }
    }
}

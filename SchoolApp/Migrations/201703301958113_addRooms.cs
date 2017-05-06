namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRooms : DbMigration
    {
        public override void Up()
        {
            Sql("Insert  into Rooms values('Bhai Sahib Singh')");
            Sql("Insert  into Rooms values('Bhai Dharam Singh')");
            Sql("Insert  into Rooms values('Bhai Himmat Singh')");
            Sql("Insert  into Rooms values('Bhai Mohkam Singh')");
            Sql("Insert  into Rooms values('Bhai Daya Singh')");
            Sql("Insert  into Rooms values('Bibi Bhani')");
            Sql("Insert  into Rooms values('Bebe Nanaki')");
            Sql("Insert  into Rooms values('Mata Sundri')");
            Sql("Insert  into Rooms values('Mai Bhago')");
            Sql("Insert  into Rooms values('Mata Gujri')");
        }
        
        public override void Down()
        {
        }
    }
}

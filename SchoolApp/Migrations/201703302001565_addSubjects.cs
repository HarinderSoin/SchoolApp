namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubjects : DbMigration
    {
        public override void Up()
        {
            Sql("Insert  into Subjects values('Kirtan', 'true')");
            Sql("Insert  into Subjects values('Gurmukhi', 'true')");
            Sql("Insert  into Subjects values('Sikh History', 'true')");

        }
        
        public override void Down()
        {
        }
    }
}

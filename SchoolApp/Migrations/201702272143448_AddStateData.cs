namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStateData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into States (Id, Name, StateAbbr) values (1, 'Massachusetts', 'MA')");
            Sql("Insert into States (Id, Name, StateAbbr) values (2, 'Connecticut', 'CT')");
            Sql("Insert into States (Id, Name, StateAbbr) values (3, 'New Hampshire', 'NH')");
            Sql("Insert into States (Id, Name, StateAbbr) values (4, 'Rhode Island', 'RI')");
        }
        
        public override void Down()
        {
        }
    }
}

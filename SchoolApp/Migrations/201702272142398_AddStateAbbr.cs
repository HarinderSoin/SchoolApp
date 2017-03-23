namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStateAbbr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.States", "StateAbbr", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.States", "StateAbbr");
        }
    }
}

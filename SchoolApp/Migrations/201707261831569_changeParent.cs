namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeParent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parents", "Parent2Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Parents", "Parent2LastName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parents", "Parent2LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Parents", "Parent2Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

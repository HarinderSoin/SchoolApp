namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixParentStructure : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parents", "Zip", c => c.String(maxLength: 20));
            AlterColumn("dbo.Parents", "HomePhone", c => c.String(maxLength: 20));
            AlterColumn("dbo.Parents", "Mobile1", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Parents", "Mobile2", c => c.String(maxLength: 20));
            AlterColumn("dbo.Parents", "Email1", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Parents", "Email2", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parents", "Email2", c => c.String());
            AlterColumn("dbo.Parents", "Email1", c => c.String(nullable: false));
            AlterColumn("dbo.Parents", "Mobile2", c => c.String());
            AlterColumn("dbo.Parents", "Mobile1", c => c.String(nullable: false));
            AlterColumn("dbo.Parents", "HomePhone", c => c.Int(nullable: false));
            AlterColumn("dbo.Parents", "Zip", c => c.Int(nullable: false));
        }
    }
}

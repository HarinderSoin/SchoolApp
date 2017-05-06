namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequiredUserIdToParent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parents", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Parents", new[] { "UserId" });
            AlterColumn("dbo.Parents", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Parents", "UserId");
            AddForeignKey("dbo.Parents", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parents", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Parents", new[] { "UserId" });
            AlterColumn("dbo.Parents", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Parents", "UserId");
            AddForeignKey("dbo.Parents", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}

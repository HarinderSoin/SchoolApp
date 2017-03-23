namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Parents", "StateID", c => c.Byte(nullable: false));
            AlterColumn("dbo.Parents", "FamilyName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Parents", "FatherName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Parents", "MotherName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Parents", "Address", c => c.String(maxLength: 100));
            AlterColumn("dbo.Parents", "City", c => c.String(maxLength: 50));
            CreateIndex("dbo.Parents", "StateID");
            AddForeignKey("dbo.Parents", "StateID", "dbo.States", "ID", cascadeDelete: true);
            DropColumn("dbo.Parents", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parents", "State", c => c.String());
            DropForeignKey("dbo.Parents", "StateID", "dbo.States");
            DropIndex("dbo.Parents", new[] { "StateID" });
            AlterColumn("dbo.Parents", "City", c => c.String());
            AlterColumn("dbo.Parents", "Address", c => c.String());
            AlterColumn("dbo.Parents", "MotherName", c => c.String());
            AlterColumn("dbo.Parents", "FatherName", c => c.String(nullable: false));
            AlterColumn("dbo.Parents", "FamilyName", c => c.String(nullable: false));
            DropColumn("dbo.Parents", "StateID");
            DropTable("dbo.States");
        }
    }
}

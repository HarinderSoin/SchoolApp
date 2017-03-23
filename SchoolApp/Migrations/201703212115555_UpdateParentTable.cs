namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateParentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "Parent1Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Parents", "Parent1LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Parents", "Parent2Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Parents", "Parent2LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Parents", "Parent1WillVolunteer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parents", "Parent1WillTeach", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parents", "Parent2WillVolunteer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parents", "Parent2WillTeach", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Parents", "Mobile2", c => c.String());
            DropColumn("dbo.Parents", "FamilyName");
            DropColumn("dbo.Parents", "FatherName");
            DropColumn("dbo.Parents", "MotherName");
            DropColumn("dbo.Parents", "FatherWillVolunteer");
            DropColumn("dbo.Parents", "FatherWillTeach");
            DropColumn("dbo.Parents", "MotherWillVolunteer");
            DropColumn("dbo.Parents", "MotherWillTeach");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parents", "MotherWillTeach", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parents", "MotherWillVolunteer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parents", "FatherWillTeach", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parents", "FatherWillVolunteer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parents", "MotherName", c => c.String(maxLength: 50));
            AddColumn("dbo.Parents", "FatherName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Parents", "FamilyName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Parents", "Mobile2", c => c.String(nullable: false));
            DropColumn("dbo.Parents", "Parent2WillTeach");
            DropColumn("dbo.Parents", "Parent2WillVolunteer");
            DropColumn("dbo.Parents", "Parent1WillTeach");
            DropColumn("dbo.Parents", "Parent1WillVolunteer");
            DropColumn("dbo.Parents", "Parent2LastName");
            DropColumn("dbo.Parents", "Parent2Name");
            DropColumn("dbo.Parents", "Parent1LastName");
            DropColumn("dbo.Parents", "Parent1Name");
        }
    }
}

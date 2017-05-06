namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'324dda50-f336-4b53-a44b-145bc07b0e4d', N'guest@schoolapp.com', 0, N'AJAsO4PQnbS/6mq6PNzuOzuXUTA7yxi6E74hl98fS6MSagJmGSu2ddJnhkqa93FqLA==', N'47e9d636-bff8-4ef1-b0d4-023294f87bb9', NULL, 0, 0, NULL, 1, 0, N'guest@schoolapp.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'50dca3c2-6b22-4787-ba2b-091f58358253', N'admin@schoolapp.com', 0, N'ADDksJJ7LsEzQCLrQOzrZUYRSYJOqefS7DwRk2Sx86KJG89v1MzkRy/MPixDezoJiw==', N'3cfc85b0-f762-40c1-ba21-101ed35fac67', NULL, 0, 0, NULL, 1, 0, N'admin@schoolapp.com')
                INSERT INTO[dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'd840e22e-7f7b-419a-a03b-d13cc47d9f54', N'CanManageEverything')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'50dca3c2-6b22-4787-ba2b-091f58358253', N'd840e22e-7f7b-419a-a03b-d13cc47d9f54')

        ");
        }

    public override void Down()
        {
        }
    }
}

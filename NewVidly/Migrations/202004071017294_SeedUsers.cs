namespace NewVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'09c26487-638f-4ada-a7af-eec3540fbca5', N'guest@vidly.com', 0, N'AL9iIjOYZN+xxzpa4ZI12PbsfL5pb+wAFatWYWamGz4dX7Nn9h5DmVBq8+4eTJetZA==', N'342e79fd-5780-4c37-a1c9-16993a2411df', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8896e21e-3bc8-44cc-9b19-7ed6d33bdc0f', N'admin@vidly.com', 0, N'AOQIZPP51hHEoGx4UiBdiS30s84qX+N0IsOjHcyq5RDAZu2pSeItKv7F90hpSsByAQ==', N'6b8f0d19-95bb-4b22-9a05-581f3225edb5', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7ac9df14-82bd-4935-a0df-3c38b48737e7', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8896e21e-3bc8-44cc-9b19-7ed6d33bdc0f', N'7ac9df14-82bd-4935-a0df-3c38b48737e7')");
        }
        
        public override void Down()
        {
        }
    }
}

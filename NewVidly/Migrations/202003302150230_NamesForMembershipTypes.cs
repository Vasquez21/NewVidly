namespace NewVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamesForMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as you go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarter' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Yearly' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}

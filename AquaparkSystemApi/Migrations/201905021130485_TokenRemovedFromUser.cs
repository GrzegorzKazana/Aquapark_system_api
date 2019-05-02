namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenRemovedFromUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "Token");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Token", c => c.String());
        }
    }
}

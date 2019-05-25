namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Login", c => c.String(maxLength: 30));
        }
    }
}

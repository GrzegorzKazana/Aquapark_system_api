namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attraction", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Zone", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.SocialClassDiscount", "SocialClassName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Ticket", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Ticket", "Type", c => c.String(maxLength: 30));
            AlterColumn("dbo.User", "Login", c => c.String(maxLength: 30));
            AlterColumn("dbo.User", "Email", c => c.String(maxLength: 30));
            AlterColumn("dbo.User", "Password", c => c.String(maxLength: 40));
            AlterColumn("dbo.User", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.User", "Surname", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Surname", c => c.String());
            AlterColumn("dbo.User", "Name", c => c.String());
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "Login", c => c.String());
            AlterColumn("dbo.Ticket", "Type", c => c.String());
            AlterColumn("dbo.Ticket", "Name", c => c.String());
            AlterColumn("dbo.SocialClassDiscount", "SocialClassName", c => c.String());
            AlterColumn("dbo.Zone", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Attraction", "Name", c => c.String());
        }
    }
}

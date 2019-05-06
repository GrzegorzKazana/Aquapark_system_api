namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTimePropertiesToTicketModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ticket", "StartHour", c => c.Double(nullable: false));
            AddColumn("dbo.Ticket", "EndHour", c => c.Double(nullable: false));
            AddColumn("dbo.Ticket", "Days", c => c.Int(nullable: false));
            AddColumn("dbo.Ticket", "Months", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ticket", "Months");
            DropColumn("dbo.Ticket", "Days");
            DropColumn("dbo.Ticket", "EndHour");
            DropColumn("dbo.Ticket", "StartHour");
        }
    }
}

namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketModelChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ticket", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ticket", "Type", c => c.String(maxLength: 30));
        }
    }
}

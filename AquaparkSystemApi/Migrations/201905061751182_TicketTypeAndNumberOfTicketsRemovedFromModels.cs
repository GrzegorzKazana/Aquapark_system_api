namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketTypeAndNumberOfTicketsRemovedFromModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ticket", "TicketType_Id", "dbo.TicketType");
            DropIndex("dbo.Ticket", new[] { "TicketType_Id" });
            DropColumn("dbo.Ticket", "Number");
            DropColumn("dbo.Ticket", "TicketType_Id");
            DropTable("dbo.TicketType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TicketType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Ticket", "TicketType_Id", c => c.Int());
            AddColumn("dbo.Ticket", "Number", c => c.Int(nullable: false));
            CreateIndex("dbo.Ticket", "TicketType_Id");
            AddForeignKey("dbo.Ticket", "TicketType_Id", "dbo.TicketType", "Id");
        }
    }
}

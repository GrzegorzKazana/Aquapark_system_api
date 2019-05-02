namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketTypeAdded : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.Ticket", "TicketType_Id");
            AddForeignKey("dbo.Ticket", "TicketType_Id", "dbo.TicketType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "TicketType_Id", "dbo.TicketType");
            DropIndex("dbo.Ticket", new[] { "TicketType_Id" });
            DropColumn("dbo.Ticket", "TicketType_Id");
            DropTable("dbo.TicketType");
        }
    }
}

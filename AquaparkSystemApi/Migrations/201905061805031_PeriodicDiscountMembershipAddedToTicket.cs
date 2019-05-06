namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeriodicDiscountMembershipAddedToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ticket", "PeriodicDiscount_Id", c => c.Int());
            CreateIndex("dbo.Ticket", "PeriodicDiscount_Id");
            AddForeignKey("dbo.Ticket", "PeriodicDiscount_Id", "dbo.PeriodicDiscount", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "PeriodicDiscount_Id", "dbo.PeriodicDiscount");
            DropIndex("dbo.Ticket", new[] { "PeriodicDiscount_Id" });
            DropColumn("dbo.Ticket", "PeriodicDiscount_Id");
        }
    }
}

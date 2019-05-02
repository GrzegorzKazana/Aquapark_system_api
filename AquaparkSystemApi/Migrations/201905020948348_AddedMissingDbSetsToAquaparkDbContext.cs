namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMissingDbSetsToAquaparkDbContext : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PositionOrder", newName: "OrderPosition");
            DropPrimaryKey("dbo.OrderPosition");
            AddPrimaryKey("dbo.OrderPosition", new[] { "Order_Id", "Position_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.OrderPosition");
            AddPrimaryKey("dbo.OrderPosition", new[] { "Position_Id", "Order_Id" });
            RenameTable(name: "dbo.OrderPosition", newName: "PositionOrder");
        }
    }
}

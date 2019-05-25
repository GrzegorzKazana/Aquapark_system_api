namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderAddedToPosition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderPosition", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.OrderPosition", "Position_Id", "dbo.Position");
            DropIndex("dbo.OrderPosition", new[] { "Order_Id" });
            DropIndex("dbo.OrderPosition", new[] { "Position_Id" });
            AddColumn("dbo.Position", "Order_Id", c => c.Int());
            AddColumn("dbo.Position", "Order_Id1", c => c.Int());
            AddColumn("dbo.Order", "Position_Id", c => c.Int());
            CreateIndex("dbo.Position", "Order_Id");
            CreateIndex("dbo.Position", "Order_Id1");
            CreateIndex("dbo.Order", "Position_Id");
            AddForeignKey("dbo.Position", "Order_Id", "dbo.Order", "Id");
            AddForeignKey("dbo.Position", "Order_Id1", "dbo.Order", "Id");
            AddForeignKey("dbo.Order", "Position_Id", "dbo.Position", "Id");
            DropTable("dbo.OrderPosition");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderPosition",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Position_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Position_Id });
            
            DropForeignKey("dbo.Order", "Position_Id", "dbo.Position");
            DropForeignKey("dbo.Position", "Order_Id1", "dbo.Order");
            DropForeignKey("dbo.Position", "Order_Id", "dbo.Order");
            DropIndex("dbo.Order", new[] { "Position_Id" });
            DropIndex("dbo.Position", new[] { "Order_Id1" });
            DropIndex("dbo.Position", new[] { "Order_Id" });
            DropColumn("dbo.Order", "Position_Id");
            DropColumn("dbo.Position", "Order_Id1");
            DropColumn("dbo.Position", "Order_Id");
            CreateIndex("dbo.OrderPosition", "Position_Id");
            CreateIndex("dbo.OrderPosition", "Order_Id");
            AddForeignKey("dbo.OrderPosition", "Position_Id", "dbo.Position", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderPosition", "Order_Id", "dbo.Order", "Id", cascadeDelete: true);
        }
    }
}

namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderAndPositionFixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Position", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.Position", "Order_Id1", "dbo.Order");
            DropForeignKey("dbo.Order", "Position_Id", "dbo.Position");
            DropIndex("dbo.Position", new[] { "Order_Id" });
            DropIndex("dbo.Position", new[] { "Order_Id1" });
            DropIndex("dbo.Order", new[] { "Position_Id" });
            CreateTable(
                "dbo.OrderPosition",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Position_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Position_Id })
                .ForeignKey("dbo.Order", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Position", t => t.Position_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Position_Id);
            
            DropColumn("dbo.Position", "Order_Id");
            DropColumn("dbo.Position", "Order_Id1");
            DropColumn("dbo.Order", "Position_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Position_Id", c => c.Int());
            AddColumn("dbo.Position", "Order_Id1", c => c.Int());
            AddColumn("dbo.Position", "Order_Id", c => c.Int());
            DropForeignKey("dbo.OrderPosition", "Position_Id", "dbo.Position");
            DropForeignKey("dbo.OrderPosition", "Order_Id", "dbo.Order");
            DropIndex("dbo.OrderPosition", new[] { "Position_Id" });
            DropIndex("dbo.OrderPosition", new[] { "Order_Id" });
            DropTable("dbo.OrderPosition");
            CreateIndex("dbo.Order", "Position_Id");
            CreateIndex("dbo.Position", "Order_Id1");
            CreateIndex("dbo.Position", "Order_Id");
            AddForeignKey("dbo.Order", "Position_Id", "dbo.Position", "Id");
            AddForeignKey("dbo.Position", "Order_Id1", "dbo.Order", "Id");
            AddForeignKey("dbo.Position", "Order_Id", "dbo.Order", "Id");
        }
    }
}

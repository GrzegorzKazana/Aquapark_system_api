namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfOrder = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        UserGuid = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Token = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PositionOrder",
                c => new
                    {
                        Position_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Position_Id, t.Order_Id })
                .ForeignKey("dbo.Position", t => t.Position_Id, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Position_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "User_Id", "dbo.User");
            DropForeignKey("dbo.PositionOrder", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.PositionOrder", "Position_Id", "dbo.Position");
            DropIndex("dbo.PositionOrder", new[] { "Order_Id" });
            DropIndex("dbo.PositionOrder", new[] { "Position_Id" });
            DropIndex("dbo.Order", new[] { "User_Id" });
            DropTable("dbo.PositionOrder");
            DropTable("dbo.User");
            DropTable("dbo.Position");
            DropTable("dbo.Order");
        }
    }
}

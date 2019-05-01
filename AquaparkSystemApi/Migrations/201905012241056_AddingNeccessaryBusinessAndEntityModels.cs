namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNeccessaryBusinessAndEntityModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttractionHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        FinishTime = c.DateTime(),
                        Attraction_Id = c.Int(),
                        Position_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attraction", t => t.Attraction_Id)
                .ForeignKey("dbo.Position", t => t.Position_Id)
                .Index(t => t.Attraction_Id)
                .Index(t => t.Position_Id);
            
            CreateTable(
                "dbo.Attraction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Zone_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zone", t => t.Zone_Id)
                .Index(t => t.Zone_Id);
            
            CreateTable(
                "dbo.Zone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PeriodicDiscount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        FinishTime = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialClassDiscount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SocialClassName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.String(),
                        Zone_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zone", t => t.Zone_Id)
                .Index(t => t.Zone_Id);
            
            CreateTable(
                "dbo.ZoneHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        FinishTime = c.DateTime(),
                        Position_Id = c.Int(),
                        Zone_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Position", t => t.Position_Id)
                .ForeignKey("dbo.Zone", t => t.Zone_Id)
                .Index(t => t.Position_Id)
                .Index(t => t.Zone_Id);
            
            AddColumn("dbo.Position", "PeriodicDiscount_Id", c => c.Int());
            AddColumn("dbo.Position", "SocialClassDiscount_Id", c => c.Int());
            AddColumn("dbo.Position", "Ticket_Id", c => c.Int());
            CreateIndex("dbo.Position", "PeriodicDiscount_Id");
            CreateIndex("dbo.Position", "SocialClassDiscount_Id");
            CreateIndex("dbo.Position", "Ticket_Id");
            AddForeignKey("dbo.Position", "PeriodicDiscount_Id", "dbo.PeriodicDiscount", "Id");
            AddForeignKey("dbo.Position", "SocialClassDiscount_Id", "dbo.SocialClassDiscount", "Id");
            AddForeignKey("dbo.Position", "Ticket_Id", "dbo.Ticket", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZoneHistory", "Zone_Id", "dbo.Zone");
            DropForeignKey("dbo.ZoneHistory", "Position_Id", "dbo.Position");
            DropForeignKey("dbo.Position", "Ticket_Id", "dbo.Ticket");
            DropForeignKey("dbo.Ticket", "Zone_Id", "dbo.Zone");
            DropForeignKey("dbo.Position", "SocialClassDiscount_Id", "dbo.SocialClassDiscount");
            DropForeignKey("dbo.Position", "PeriodicDiscount_Id", "dbo.PeriodicDiscount");
            DropForeignKey("dbo.AttractionHistory", "Position_Id", "dbo.Position");
            DropForeignKey("dbo.AttractionHistory", "Attraction_Id", "dbo.Attraction");
            DropForeignKey("dbo.Attraction", "Zone_Id", "dbo.Zone");
            DropIndex("dbo.ZoneHistory", new[] { "Zone_Id" });
            DropIndex("dbo.ZoneHistory", new[] { "Position_Id" });
            DropIndex("dbo.Ticket", new[] { "Zone_Id" });
            DropIndex("dbo.Attraction", new[] { "Zone_Id" });
            DropIndex("dbo.AttractionHistory", new[] { "Position_Id" });
            DropIndex("dbo.AttractionHistory", new[] { "Attraction_Id" });
            DropIndex("dbo.Position", new[] { "Ticket_Id" });
            DropIndex("dbo.Position", new[] { "SocialClassDiscount_Id" });
            DropIndex("dbo.Position", new[] { "PeriodicDiscount_Id" });
            DropColumn("dbo.Position", "Ticket_Id");
            DropColumn("dbo.Position", "SocialClassDiscount_Id");
            DropColumn("dbo.Position", "PeriodicDiscount_Id");
            DropTable("dbo.ZoneHistory");
            DropTable("dbo.Ticket");
            DropTable("dbo.SocialClassDiscount");
            DropTable("dbo.PeriodicDiscount");
            DropTable("dbo.Zone");
            DropTable("dbo.Attraction");
            DropTable("dbo.AttractionHistory");
        }
    }
}

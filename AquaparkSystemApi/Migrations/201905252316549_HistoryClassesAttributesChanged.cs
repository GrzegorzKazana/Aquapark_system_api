namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryClassesAttributesChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AttractionHistory", "Attraction_Id", "dbo.Attraction");
            DropForeignKey("dbo.AttractionHistory", "Position_Id", "dbo.Position");
            DropForeignKey("dbo.ZoneHistory", "Position_Id", "dbo.Position");
            DropForeignKey("dbo.ZoneHistory", "Zone_Id", "dbo.Zone");
            DropIndex("dbo.AttractionHistory", new[] { "Attraction_Id" });
            DropIndex("dbo.AttractionHistory", new[] { "Position_Id" });
            DropIndex("dbo.ZoneHistory", new[] { "Position_Id" });
            DropIndex("dbo.ZoneHistory", new[] { "Zone_Id" });
            AlterColumn("dbo.AttractionHistory", "Attraction_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.AttractionHistory", "Position_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ZoneHistory", "Position_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ZoneHistory", "Zone_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.AttractionHistory", "Attraction_Id");
            CreateIndex("dbo.AttractionHistory", "Position_Id");
            CreateIndex("dbo.ZoneHistory", "Position_Id");
            CreateIndex("dbo.ZoneHistory", "Zone_Id");
            AddForeignKey("dbo.AttractionHistory", "Attraction_Id", "dbo.Attraction", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AttractionHistory", "Position_Id", "dbo.Position", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ZoneHistory", "Position_Id", "dbo.Position", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ZoneHistory", "Zone_Id", "dbo.Zone", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZoneHistory", "Zone_Id", "dbo.Zone");
            DropForeignKey("dbo.ZoneHistory", "Position_Id", "dbo.Position");
            DropForeignKey("dbo.AttractionHistory", "Position_Id", "dbo.Position");
            DropForeignKey("dbo.AttractionHistory", "Attraction_Id", "dbo.Attraction");
            DropIndex("dbo.ZoneHistory", new[] { "Zone_Id" });
            DropIndex("dbo.ZoneHistory", new[] { "Position_Id" });
            DropIndex("dbo.AttractionHistory", new[] { "Position_Id" });
            DropIndex("dbo.AttractionHistory", new[] { "Attraction_Id" });
            AlterColumn("dbo.ZoneHistory", "Zone_Id", c => c.Int());
            AlterColumn("dbo.ZoneHistory", "Position_Id", c => c.Int());
            AlterColumn("dbo.AttractionHistory", "Position_Id", c => c.Int());
            AlterColumn("dbo.AttractionHistory", "Attraction_Id", c => c.Int());
            CreateIndex("dbo.ZoneHistory", "Zone_Id");
            CreateIndex("dbo.ZoneHistory", "Position_Id");
            CreateIndex("dbo.AttractionHistory", "Position_Id");
            CreateIndex("dbo.AttractionHistory", "Attraction_Id");
            AddForeignKey("dbo.ZoneHistory", "Zone_Id", "dbo.Zone", "Id");
            AddForeignKey("dbo.ZoneHistory", "Position_Id", "dbo.Position", "Id");
            AddForeignKey("dbo.AttractionHistory", "Position_Id", "dbo.Position", "Id");
            AddForeignKey("dbo.AttractionHistory", "Attraction_Id", "dbo.Attraction", "Id");
        }
    }
}

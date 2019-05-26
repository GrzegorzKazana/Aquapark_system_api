namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTicketsZonesAndAttractions : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Ticket");
            Sql("DELETE FROM Attraction");
            Sql("DELETE FROM Zone");
        }
        
        public override void Down()
        {
        }
    }
}

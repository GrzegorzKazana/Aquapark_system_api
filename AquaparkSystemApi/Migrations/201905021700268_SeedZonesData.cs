namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedZonesData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Zone(Name) VALUES ('Baseny')");
            Sql("INSERT INTO Zone(Name) VALUES ('Sauny')");
        }
        
        public override void Down()
        {
        }
    }
}

namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNewZones : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Zone(Name) VALUES ('Strefa saun')");
            Sql("INSERT INTO Zone(Name) VALUES ('Strefa basen�w')");
            Sql("INSERT INTO Zone(Name) VALUES ('Strefa spa')");
        }
        
        public override void Down()
        {
        }
    }
}

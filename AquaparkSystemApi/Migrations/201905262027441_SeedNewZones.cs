namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNewZones : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Zone(Name) VALUES ('Strefa saun')");
            Sql("INSERT INTO Zone(Name) VALUES ('Strefa basenów')");
            Sql("INSERT INTO Zone(Name) VALUES ('Strefa spa')");
        }
        
        public override void Down()
        {
        }
    }
}

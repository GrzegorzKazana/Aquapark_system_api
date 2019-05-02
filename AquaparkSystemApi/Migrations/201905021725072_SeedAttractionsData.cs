namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAttractionsData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Baseny otwarte', 1)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Bicze wodne', 1)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sztuczne fale', 1)");

            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna fiñska', 2)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna rosyjska', 2)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna parowa', 2)");

        }
        
        public override void Down()
        {
        }
    }
}

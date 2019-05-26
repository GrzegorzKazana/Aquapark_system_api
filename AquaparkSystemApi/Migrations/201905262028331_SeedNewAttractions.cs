namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNewAttractions : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 1', 10)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 2', 10)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 3', 10)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 4', 10)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 5', 10)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 6', 10)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 7', 10)");

            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Basen 1', 11)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Basen 2', 11)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Basen 3', 11)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Basen 4', 11)");

            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Spa 1', 12)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Spa 2', 12)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Spa 3', 12)");
        }
        
        public override void Down()
        {
        }
    }
}

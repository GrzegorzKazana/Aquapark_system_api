namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNewAttractions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attraction", "MaxAmountOfPeople", c => c.Int(nullable: false));
            AddColumn("dbo.Zone", "MaxAmountOfPeople", c => c.Int(nullable: false));
            AlterColumn("dbo.Ticket", "Name", c => c.String(maxLength: 50));
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 1', 3)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 2', 3)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 3', 3)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 4', 3)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 5', 3)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 6', 3)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Sauna 7', 3)");

            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Basen 1', 4)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Basen 2', 4)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Basen 3', 4)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Basen 4', 4)");

            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Spa 1', 5)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Spa 2', 5)");
            Sql("INSERT INTO Attraction(Name, Zone_Id) VALUES ('Spa 3', 5)");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ticket", "Name", c => c.String(maxLength: 30));
            DropColumn("dbo.Zone", "MaxAmountOfPeople");
            DropColumn("dbo.Attraction", "MaxAmountOfPeople");
        }
    }
}

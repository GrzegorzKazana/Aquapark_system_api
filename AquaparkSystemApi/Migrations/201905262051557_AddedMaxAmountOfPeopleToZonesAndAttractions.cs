namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMaxAmountOfPeopleToZonesAndAttractions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attraction", "MaxAmountOfPeople", c => c.Int(nullable: false));
            AddColumn("dbo.Zone", "MaxAmountOfPeople", c => c.Int(nullable: false));
            Sql(@"UPDATE Zone SET MaxAmountOfPeople = 100 WHERE Id = 11");
            Sql(@"UPDATE Zone SET MaxAmountOfPeople = 35 WHERE Id = 10");
            Sql(@"UPDATE Zone SET MaxAmountOfPeople = 20 WHERE Id = 12");

            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 5 WHERE Id = 19");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 5 WHERE Id = 20");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 5 WHERE Id = 21");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 7 WHERE Id = 22");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 3 WHERE Id = 23");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 2 WHERE Id = 24");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 8 WHERE Id = 25");

            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 25 WHERE Id = 26");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 25 WHERE Id = 27");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 30 WHERE Id = 28");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 20 WHERE Id = 29");

            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 5 WHERE Id = 30");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 5 WHERE Id = 31");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 10 WHERE Id = 32");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zone", "MaxAmountOfPeople");
            DropColumn("dbo.Attraction", "MaxAmountOfPeople");
        }
    }
}

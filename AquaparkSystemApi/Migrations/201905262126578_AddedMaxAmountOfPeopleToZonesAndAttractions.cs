namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMaxAmountOfPeopleToZonesAndAttractions : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE Zone SET MaxAmountOfPeople = 100 WHERE Id = 4");
            Sql(@"UPDATE Zone SET MaxAmountOfPeople = 35 WHERE Id = 3");
            Sql(@"UPDATE Zone SET MaxAmountOfPeople = 20 WHERE Id = 5");

            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 5 WHERE Id = 7");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 5 WHERE Id = 8");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 5 WHERE Id = 9");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 7 WHERE Id = 10");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 3 WHERE Id = 11");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 2 WHERE Id = 12");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 8 WHERE Id = 13");

            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 25 WHERE Id = 14");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 25 WHERE Id = 15");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 30 WHERE Id = 16");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 20 WHERE Id = 17");

            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 5 WHERE Id = 18");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 5 WHERE Id = 19");
            Sql(@"UPDATE Attraction SET MaxAmountOfPeople = 10 WHERE Id = 20");






        }

        public override void Down()
        {
        }
    }
}

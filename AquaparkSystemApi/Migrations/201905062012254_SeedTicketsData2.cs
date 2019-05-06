namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTicketsData2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE Ticket SET StartHour = 12.00, EndHour = 18.00, Days = 1, Months = 0" +
                " WHERE Id = 6");
            Sql(@"UPDATE Ticket SET StartHour = 18.00, EndHour = 24.00, Days = 1, Months = 0" +
                " WHERE Id = 7");
            Sql(@"UPDATE Ticket SET StartHour = 00.00, EndHour = 24.00, Days = 0, Months = 1" +
                " WHERE Id = 8");
        }
        
        public override void Down()
        {
        }
    }
}

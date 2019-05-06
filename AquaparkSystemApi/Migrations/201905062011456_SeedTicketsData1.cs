namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTicketsData1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE Ticket SET PeriodicDiscount_Id = 1, StartHour = 6.00, EndHour = 12.00, Days = 1, Months = 0" +
                " WHERE Id = 5");
        }
        
        public override void Down()
        {
        }
    }
}

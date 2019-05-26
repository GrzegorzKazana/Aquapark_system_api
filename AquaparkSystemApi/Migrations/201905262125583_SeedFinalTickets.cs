namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedFinalTickets : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ticket(Name, Price, Zone_Id, PeriodicDiscount_Id, StartHour, EndHour, Days, Months) " +
                "VALUES ('Basen - Bilet poranny 6:00-12:00', 30, 4, 1, 6.00, 12.00, 1, 0)");
            Sql("INSERT INTO Ticket(Name, Price, Zone_Id, PeriodicDiscount_Id, StartHour, EndHour, Days, Months) " +
                "VALUES ('Basen - Bilet popo³udniowy 12:00-18:00', 35, 4, 1, 12.00, 18.00, 1, 0)");
            Sql("INSERT INTO Ticket(Name, Price, Zone_Id, PeriodicDiscount_Id, StartHour, EndHour, Days, Months) " +
                "VALUES ('Basen - Bilet wieczorny 18:00-24:00', 40, 4, 1, 18.00, 24.00, 1, 0)");
            Sql("INSERT INTO Ticket(Name, Price, Zone_Id, PeriodicDiscount_Id, StartHour, EndHour, Days, Months) " +
                "VALUES ('Basen - Bilet ca³odniowy', 60, 4, 1, 00.00, 24.00, 1, 0)");
            Sql("INSERT INTO Ticket(Name, Price, Zone_Id, PeriodicDiscount_Id, StartHour, EndHour, Days, Months) " +
                "VALUES ('Sauna - Bilet ca³odniowy', 70, 3, 1, 00.00, 24.00, 1, 0)");
            Sql("INSERT INTO Ticket(Name, Price, Zone_Id, PeriodicDiscount_Id, StartHour, EndHour, Days, Months) " +
                "VALUES ('Spa - Bilet ca³odniowy', 70, 5, 1, 00.00, 24.00, 1, 0)");
        }
        
        public override void Down()
        {
        }
    }
}

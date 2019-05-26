namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedFinalTickets : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ticket", "Name", c => c.String(maxLength: 50));
            Sql("INSERT INTO Ticket(Name, Price, Zone_Id, PeriodicDiscount_Id, StartHour, EndHour, Days, Months) " +
                "VALUES ('Basen - Bilet poranny 6:00-12:00', 30, 11, 1, 6.00, 12.00, 1, 0)");
            Sql("INSERT INTO Ticket(Name, Price, Zone_Id, PeriodicDiscount_Id, StartHour, EndHour, Days, Months) " +
                "VALUES ('Basen - Bilet popo³udniowy 12:00-18:00', 35, 11, 1, 12.00, 18.00, 1, 0)");
            Sql("INSERT INTO Ticket(Name, Price, Zone_Id, PeriodicDiscount_Id, StartHour, EndHour, Days, Months) " +
                "VALUES ('Basen - Bilet wieczorny 18:00-24:00', 40, 11, 1, 18.00, 24.00, 1, 0)");
            Sql("INSERT INTO Ticket(Name, Price, Zone_Id, PeriodicDiscount_Id, StartHour, EndHour, Days, Months) " +
                "VALUES ('Basen - Bilet ca³odniowy', 60, 11, 1, 00.00, 24.00, 1, 0)");
            Sql("INSERT INTO Ticket(Name, Price, Zone_Id, PeriodicDiscount_Id, StartHour, EndHour, Days, Months) " +
                "VALUES ('Sauna - Bilet ca³odniowy', 70, 10, 1, 00.00, 24.00, 1, 0)");
            Sql("INSERT INTO Ticket(Name, Price, Zone_Id, PeriodicDiscount_Id, StartHour, EndHour, Days, Months) " +
                "VALUES ('Spa - Bilet ca³odniowy', 70, 12, 1, 00.00, 24.00, 1, 0)");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ticket", "Name", c => c.String(maxLength: 30));
        }
    }
}

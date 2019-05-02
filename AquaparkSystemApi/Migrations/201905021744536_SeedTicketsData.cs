namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTicketsData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ticket(Number, Name, Price, Zone_Id, TicketType_Id) " +
                "VALUES (1, 'Bilet poranny 6:00-12:00', 30, 1, 1)");
            Sql("INSERT INTO Ticket(Number, Name, Price, Zone_Id, TicketType_Id) " +
                "VALUES (1, 'Bilet popo³udniowy 12:00-18:00', 35, 1, 1)");
            Sql("INSERT INTO Ticket(Number, Name, Price, Zone_Id, TicketType_Id) " +
                "VALUES (1, 'Bilet wieczorny 18:00-24:00', 40, 1, 1)");
        }
        
        public override void Down()
        {
        }
    }
}

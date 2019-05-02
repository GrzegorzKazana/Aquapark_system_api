namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTicketTypesData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TicketType(Name) " +
                "VALUES ('Time ticket')");
            Sql("INSERT INTO TicketType(Name) " +
                "VALUES ('Entry ticket')");
        }
        
        public override void Down()
        {
        }
    }
}

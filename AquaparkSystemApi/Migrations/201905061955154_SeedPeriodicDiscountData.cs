namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedPeriodicDiscountData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PeriodicDiscount(StartTime, FinishTime, Value) " +
                "VALUES ('2019-05-07', '2019-05-15', 0.80)");
        }
        
        public override void Down()
        {
        }
    }
}

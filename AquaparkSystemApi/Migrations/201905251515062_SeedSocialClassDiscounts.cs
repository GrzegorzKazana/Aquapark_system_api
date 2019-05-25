namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedSocialClassDiscounts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SocialClassDiscount(Value, SocialClassName) " +
                "VALUES (0.50,'Emeryt 50%')");
            Sql("INSERT INTO SocialClassDiscount(Value, SocialClassName) " +
                "VALUES (0.20,'Student 80%')");
            Sql("INSERT INTO SocialClassDiscount(Value, SocialClassName) " +
                "VALUES (0.75,'Weteran 25%')");
            Sql("INSERT INTO SocialClassDiscount(Value, SocialClassName) " +
                "VALUES (0.90,'Dzieci 10%')");
        }
        
        public override void Down()
        {
        }
    }
}

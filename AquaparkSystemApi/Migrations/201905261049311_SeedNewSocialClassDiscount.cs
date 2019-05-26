namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNewSocialClassDiscount : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SocialClassDiscount(Value, SocialClassName) " +
                "VALUES (0.00,'Normalny 100%')");
        }
        
        public override void Down()
        {
        }
    }
}

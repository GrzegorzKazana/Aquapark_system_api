namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmountOfPositionsRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Position", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Position", "Number", c => c.Int(nullable: false));
        }
    }
}

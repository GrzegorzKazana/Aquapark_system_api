namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CanBeUsedFieldAddedToPosition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Position", "CanBeUsed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Position", "CanBeUsed");
        }
    }
}

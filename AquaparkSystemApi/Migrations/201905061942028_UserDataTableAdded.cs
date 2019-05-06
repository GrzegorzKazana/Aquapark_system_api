namespace AquaparkSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDataTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 30),
                        Name = c.String(maxLength: 30),
                        Surname = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Order", "UserData_Id", c => c.Int());
            CreateIndex("dbo.Order", "UserData_Id");
            AddForeignKey("dbo.Order", "UserData_Id", "dbo.UserData", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "UserData_Id", "dbo.UserData");
            DropIndex("dbo.Order", new[] { "UserData_Id" });
            DropColumn("dbo.Order", "UserData_Id");
            DropTable("dbo.UserData");
        }
    }
}

namespace CarDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAuthentication : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logs", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            DropIndex("dbo.Logins", new[] { "User_Id" });
            DropIndex("dbo.Logs", new[] { "Owner_Id" });
            DropTable("dbo.Logins");
            DropTable("dbo.Users");
            DropTable("dbo.Logs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Operation = c.String(nullable: false),
                        ModifiedTable = c.String(nullable: false),
                        TimeLogged = c.DateTime(nullable: false),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Logs", "Owner_Id");
            CreateIndex("dbo.Logins", "User_Id");
            AddForeignKey("dbo.Logins", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Logs", "Owner_Id", "dbo.Users", "Id");
        }
    }
}

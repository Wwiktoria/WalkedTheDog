namespace WalkedTheDog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Three : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WalkerAdvertUsers", "WalkerAdvert_WalkerAdvertId", "dbo.WalkerAdverts");
            DropForeignKey("dbo.WalkerAdvertUsers", "User_UserId", "dbo.Users");
            DropIndex("dbo.WalkerAdvertUsers", new[] { "WalkerAdvert_WalkerAdvertId" });
            DropIndex("dbo.WalkerAdvertUsers", new[] { "User_UserId" });
            AddColumn("dbo.WalkerAdverts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.WalkerAdverts", "UserId");
            AddForeignKey("dbo.WalkerAdverts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            DropTable("dbo.WalkerAdvertUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WalkerAdvertUsers",
                c => new
                    {
                        WalkerAdvert_WalkerAdvertId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WalkerAdvert_WalkerAdvertId, t.User_UserId });
            
            DropForeignKey("dbo.WalkerAdverts", "UserId", "dbo.Users");
            DropIndex("dbo.WalkerAdverts", new[] { "UserId" });
            DropColumn("dbo.WalkerAdverts", "UserId");
            CreateIndex("dbo.WalkerAdvertUsers", "User_UserId");
            CreateIndex("dbo.WalkerAdvertUsers", "WalkerAdvert_WalkerAdvertId");
            AddForeignKey("dbo.WalkerAdvertUsers", "User_UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.WalkerAdvertUsers", "WalkerAdvert_WalkerAdvertId", "dbo.WalkerAdverts", "WalkerAdvertId", cascadeDelete: true);
        }
    }
}

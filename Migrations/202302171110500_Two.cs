namespace WalkedTheDog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Two : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OwnerAdvertUsers", "OwnerAdvert_OwnerAdvertId", "dbo.OwnerAdverts");
            DropForeignKey("dbo.OwnerAdvertUsers", "User_UserId", "dbo.Users");
            DropIndex("dbo.OwnerAdvertUsers", new[] { "OwnerAdvert_OwnerAdvertId" });
            DropIndex("dbo.OwnerAdvertUsers", new[] { "User_UserId" });
            AddColumn("dbo.OwnerAdverts", "DogId", c => c.Int(nullable: false));
            CreateIndex("dbo.OwnerAdverts", "DogId");
            AddForeignKey("dbo.OwnerAdverts", "DogId", "dbo.Dogs", "DogId", cascadeDelete: true);
            DropTable("dbo.OwnerAdvertUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OwnerAdvertUsers",
                c => new
                    {
                        OwnerAdvert_OwnerAdvertId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OwnerAdvert_OwnerAdvertId, t.User_UserId });
            
            DropForeignKey("dbo.OwnerAdverts", "DogId", "dbo.Dogs");
            DropIndex("dbo.OwnerAdverts", new[] { "DogId" });
            DropColumn("dbo.OwnerAdverts", "DogId");
            CreateIndex("dbo.OwnerAdvertUsers", "User_UserId");
            CreateIndex("dbo.OwnerAdvertUsers", "OwnerAdvert_OwnerAdvertId");
            AddForeignKey("dbo.OwnerAdvertUsers", "User_UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.OwnerAdvertUsers", "OwnerAdvert_OwnerAdvertId", "dbo.OwnerAdverts", "OwnerAdvertId", cascadeDelete: true);
        }
    }
}

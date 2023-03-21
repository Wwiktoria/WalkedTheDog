namespace WalkedTheDog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        DogId = c.Int(nullable: false, identity: true),
                        DogName = c.String(),
                        DogDescription = c.String(),
                        DogSize = c.Int(nullable: false),
                        DogActivityDemand = c.Int(nullable: false),
                        DogGender = c.Int(nullable: false),
                        DogBreed = c.String(),
                        DogDateOfBirth = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DogId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserSurname = c.String(),
                        UserGender = c.Int(nullable: false),
                        UserEmail = c.String(),
                        UserPassword = c.String(),
                        UserDateOfBirth = c.DateTime(nullable: false),
                        UserPhone = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.OwnerAdverts",
                c => new
                    {
                        OwnerAdvertId = c.Int(nullable: false, identity: true),
                        OwnerAdvertCity = c.String(),
                        OwnerAdvertTitle = c.String(),
                        OwnerAdvertDescription = c.String(),
                        OwnerAdvertAmount = c.String(),
                        OwnerAdvertDateAdded = c.DateTime(nullable: false),
                        OwnerAdvertDateOfSerice = c.DateTime(nullable: false),
                        OwnerAdvertWalkingTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OwnerAdvertId);
            
            CreateTable(
                "dbo.WalkerAdverts",
                c => new
                    {
                        WalkerAdvertId = c.Int(nullable: false, identity: true),
                        WalkerAdvertTitle = c.String(),
                        WalkerAdvertCity = c.String(),
                        WalkerAdvertAmount = c.String(),
                        WalkerAdvertDescription = c.String(),
                        WalkerAdvertDateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WalkerAdvertId);
            
            CreateTable(
                "dbo.OwnerAdvertUsers",
                c => new
                    {
                        OwnerAdvert_OwnerAdvertId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OwnerAdvert_OwnerAdvertId, t.User_UserId })
                .ForeignKey("dbo.OwnerAdverts", t => t.OwnerAdvert_OwnerAdvertId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.OwnerAdvert_OwnerAdvertId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.WalkerAdvertUsers",
                c => new
                    {
                        WalkerAdvert_WalkerAdvertId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WalkerAdvert_WalkerAdvertId, t.User_UserId })
                .ForeignKey("dbo.WalkerAdverts", t => t.WalkerAdvert_WalkerAdvertId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.WalkerAdvert_WalkerAdvertId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WalkerAdvertUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.WalkerAdvertUsers", "WalkerAdvert_WalkerAdvertId", "dbo.WalkerAdverts");
            DropForeignKey("dbo.OwnerAdvertUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.OwnerAdvertUsers", "OwnerAdvert_OwnerAdvertId", "dbo.OwnerAdverts");
            DropForeignKey("dbo.Dogs", "UserId", "dbo.Users");
            DropIndex("dbo.WalkerAdvertUsers", new[] { "User_UserId" });
            DropIndex("dbo.WalkerAdvertUsers", new[] { "WalkerAdvert_WalkerAdvertId" });
            DropIndex("dbo.OwnerAdvertUsers", new[] { "User_UserId" });
            DropIndex("dbo.OwnerAdvertUsers", new[] { "OwnerAdvert_OwnerAdvertId" });
            DropIndex("dbo.Dogs", new[] { "UserId" });
            DropTable("dbo.WalkerAdvertUsers");
            DropTable("dbo.OwnerAdvertUsers");
            DropTable("dbo.WalkerAdverts");
            DropTable("dbo.OwnerAdverts");
            DropTable("dbo.Users");
            DropTable("dbo.Dogs");
        }
    }
}

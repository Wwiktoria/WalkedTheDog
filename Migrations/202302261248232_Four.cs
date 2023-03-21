namespace WalkedTheDog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Four : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OwnerAdverts", "OwnerAdvertAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OwnerAdverts", "OwnerAdvertAmount", c => c.String());
        }
    }
}

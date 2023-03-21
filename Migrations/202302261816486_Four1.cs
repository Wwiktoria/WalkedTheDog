namespace WalkedTheDog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Four1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WalkerAdverts", "WalkerAdvertAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WalkerAdverts", "WalkerAdvertAmount", c => c.String());
        }
    }
}

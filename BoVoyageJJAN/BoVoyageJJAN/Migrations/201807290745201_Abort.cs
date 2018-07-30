namespace BoVoyageJJAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Abort : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}

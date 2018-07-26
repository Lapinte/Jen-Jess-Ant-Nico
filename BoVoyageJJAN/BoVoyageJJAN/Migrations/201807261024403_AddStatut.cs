namespace BoVoyageJJAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Statut", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Statut");
        }
    }
}

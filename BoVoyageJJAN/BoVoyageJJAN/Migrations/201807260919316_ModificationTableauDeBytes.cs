namespace BoVoyageJJAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificationTableauDeBytes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DestinationFiles", "Content", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DestinationFiles", "Content", c => c.Byte(nullable: false));
        }
    }
}

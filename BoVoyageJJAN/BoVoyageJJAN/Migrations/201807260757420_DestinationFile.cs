namespace BoVoyageJJAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DestinationFile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TripFiles", "TripID", "dbo.Trips");
            DropIndex("dbo.TripFiles", new[] { "TripID" });
            CreateTable(
                "dbo.DestinationFiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 254),
                        ContentType = c.String(nullable: false, maxLength: 100),
                        Content = c.Byte(nullable: false),
                        DestinationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Destinations", t => t.DestinationID, cascadeDelete: true)
                .Index(t => t.DestinationID);
            
            DropTable("dbo.TripFiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TripFiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 254),
                        ContentType = c.String(nullable: false, maxLength: 100),
                        Content = c.Byte(nullable: false),
                        TripID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.DestinationFiles", "DestinationID", "dbo.Destinations");
            DropIndex("dbo.DestinationFiles", new[] { "DestinationID" });
            DropTable("dbo.DestinationFiles");
            CreateIndex("dbo.TripFiles", "TripID");
            AddForeignKey("dbo.TripFiles", "TripID", "dbo.Trips", "ID", cascadeDelete: true);
        }
    }
}

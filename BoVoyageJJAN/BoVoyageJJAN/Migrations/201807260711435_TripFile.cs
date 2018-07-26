namespace BoVoyageJJAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TripFile : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Trips", t => t.TripID, cascadeDelete: true)
                .Index(t => t.TripID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TripFiles", "TripID", "dbo.Trips");
            DropIndex("dbo.TripFiles", new[] { "TripID" });
            DropTable("dbo.TripFiles");
        }
    }
}

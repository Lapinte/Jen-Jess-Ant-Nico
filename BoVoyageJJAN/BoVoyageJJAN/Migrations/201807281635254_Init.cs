namespace BoVoyageJJAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Civilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Commercials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Lastname = c.String(nullable: false, maxLength: 50),
                        Firstname = c.String(nullable: false, maxLength: 50),
                        Mail = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mail = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Lastname = c.String(nullable: false, maxLength: 50),
                        Firstname = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false),
                        CivilityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Civilities", t => t.CivilityID, cascadeDelete: false)
                .Index(t => t.CivilityID);
            
            CreateTable(
                "dbo.DestinationFiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 254),
                        ContentType = c.String(nullable: false, maxLength: 100),
                        Content = c.Binary(nullable: false),
                        DestinationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Destinations", t => t.DestinationID, cascadeDelete: false)
                .Index(t => t.DestinationID);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Continent = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        Region = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReservationID = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Lastname = c.String(nullable: false, maxLength: 50),
                        Firstname = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false),
                        CivilityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Civilities", t => t.CivilityID, cascadeDelete: false)
                .ForeignKey("dbo.Reservations", t => t.ReservationID, cascadeDelete: false)
                .Index(t => t.ReservationID)
                .Index(t => t.CivilityID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreditCardNumber = c.String(nullable: false, maxLength: 25),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Insurance = c.Boolean(nullable: false),
                        ParticipantNumber = c.Int(nullable: false),
                        ParticipantUnderTwelveNumber = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Statut = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        TripID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: false)
                .ForeignKey("dbo.Trips", t => t.TripID, cascadeDelete: false)
                .Index(t => t.CustomerID)
                .Index(t => t.TripID);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartureDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        PlaceNumber = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DestinationID = c.Int(nullable: false),
                        AgencyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Agencies", t => t.AgencyID, cascadeDelete: false)
                .ForeignKey("dbo.Destinations", t => t.DestinationID, cascadeDelete: false)
                .Index(t => t.DestinationID)
                .Index(t => t.AgencyID);
            
            CreateTable(
                "dbo.UserDemands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Lastname = c.String(nullable: false, maxLength: 50),
                        Firstname = c.String(nullable: false),
                        Mail = c.String(nullable: false, maxLength: 255),
                        Demand = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "TripID", "dbo.Trips");
            DropForeignKey("dbo.Trips", "DestinationID", "dbo.Destinations");
            DropForeignKey("dbo.Trips", "AgencyID", "dbo.Agencies");
            DropForeignKey("dbo.Participants", "ReservationID", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Participants", "CivilityID", "dbo.Civilities");
            DropForeignKey("dbo.DestinationFiles", "DestinationID", "dbo.Destinations");
            DropForeignKey("dbo.Customers", "CivilityID", "dbo.Civilities");
            DropIndex("dbo.Trips", new[] { "AgencyID" });
            DropIndex("dbo.Trips", new[] { "DestinationID" });
            DropIndex("dbo.Reservations", new[] { "TripID" });
            DropIndex("dbo.Reservations", new[] { "CustomerID" });
            DropIndex("dbo.Participants", new[] { "CivilityID" });
            DropIndex("dbo.Participants", new[] { "ReservationID" });
            DropIndex("dbo.DestinationFiles", new[] { "DestinationID" });
            DropIndex("dbo.Customers", new[] { "CivilityID" });
            DropTable("dbo.UserDemands");
            DropTable("dbo.Trips");
            DropTable("dbo.Reservations");
            DropTable("dbo.Participants");
            DropTable("dbo.Destinations");
            DropTable("dbo.DestinationFiles");
            DropTable("dbo.Customers");
            DropTable("dbo.Commercials");
            DropTable("dbo.Civilities");
            DropTable("dbo.Agencies");
        }
    }
}

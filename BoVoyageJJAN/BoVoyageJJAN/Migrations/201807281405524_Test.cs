namespace BoVoyageJJAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.UserDemands");
        }
    }
}

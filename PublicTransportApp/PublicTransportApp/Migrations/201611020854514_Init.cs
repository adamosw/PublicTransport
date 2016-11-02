namespace PublicTransportApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteID = c.Int(nullable: false, identity: true),
                        Start_Longitude = c.Double(nullable: false),
                        Start_Latitude = c.Double(nullable: false),
                        End_Longitude = c.Double(nullable: false),
                        End_Latitude = c.Double(nullable: false),
                        isStartingRoute = c.Boolean(nullable: false),
                        Vehicle_VehicleID = c.Int(),
                    })
                .PrimaryKey(t => t.RouteID)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_VehicleID)
                .Index(t => t.Vehicle_VehicleID);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionID = c.Int(nullable: false, identity: true),
                        Start_Longitude = c.Double(nullable: false),
                        Start_Latitude = c.Double(nullable: false),
                        End_Longitude = c.Double(nullable: false),
                        End_Latitude = c.Double(nullable: false),
                        Order = c.Int(nullable: false),
                        Route_RouteID = c.Int(),
                    })
                .PrimaryKey(t => t.SectionID)
                .ForeignKey("dbo.Routes", t => t.Route_RouteID)
                .Index(t => t.Route_RouteID);
            
            CreateTable(
                "dbo.Stops",
                c => new
                    {
                        StopID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StopID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        isLowerDeck = c.Boolean(nullable: false),
                        isAirConditioned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID);
            
            CreateTable(
                "dbo.VehicleStops",
                c => new
                    {
                        Vehicle_VehicleID = c.Int(nullable: false),
                        Stop_StopID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vehicle_VehicleID, t.Stop_StopID })
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_VehicleID, cascadeDelete: true)
                .ForeignKey("dbo.Stops", t => t.Stop_StopID, cascadeDelete: true)
                .Index(t => t.Vehicle_VehicleID)
                .Index(t => t.Stop_StopID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleStops", "Stop_StopID", "dbo.Stops");
            DropForeignKey("dbo.VehicleStops", "Vehicle_VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Routes", "Vehicle_VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Sections", "Route_RouteID", "dbo.Routes");
            DropIndex("dbo.VehicleStops", new[] { "Stop_StopID" });
            DropIndex("dbo.VehicleStops", new[] { "Vehicle_VehicleID" });
            DropIndex("dbo.Sections", new[] { "Route_RouteID" });
            DropIndex("dbo.Routes", new[] { "Vehicle_VehicleID" });
            DropTable("dbo.VehicleStops");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Stops");
            DropTable("dbo.Sections");
            DropTable("dbo.Routes");
        }
    }
}

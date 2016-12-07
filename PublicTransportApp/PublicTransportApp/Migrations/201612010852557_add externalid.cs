namespace PublicTransportApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addexternalid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "ExternalID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "ExternalID");
        }
    }
}

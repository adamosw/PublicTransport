namespace PublicTransportApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Line", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Line");
        }
    }
}

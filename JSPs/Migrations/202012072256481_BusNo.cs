namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buses", "BusNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buses", "BusNo");
        }
    }
}

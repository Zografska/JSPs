namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedBusClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buses", "StartTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buses", "StartTime", c => c.String(nullable: false));
        }
    }
}

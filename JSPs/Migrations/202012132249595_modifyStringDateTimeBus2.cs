namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyStringDateTimeBus2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buses", "StartTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buses", "StartTime", c => c.String());
        }
    }
}

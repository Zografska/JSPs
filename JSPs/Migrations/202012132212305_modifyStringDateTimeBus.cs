namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyStringDateTimeBus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buses", "StartTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buses", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}

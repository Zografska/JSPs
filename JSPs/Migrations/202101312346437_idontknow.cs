namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idontknow : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buses", "BusLine", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buses", "BusLine", c => c.String());
        }
    }
}

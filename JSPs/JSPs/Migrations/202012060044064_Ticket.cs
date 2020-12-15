namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ticket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Bus_ID", c => c.Int());
            CreateIndex("dbo.Tickets", "Bus_ID");
            AddForeignKey("dbo.Tickets", "Bus_ID", "dbo.Buses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Bus_ID", "dbo.Buses");
            DropIndex("dbo.Tickets", new[] { "Bus_ID" });
            DropColumn("dbo.Tickets", "Bus_ID");
        }
    }
}

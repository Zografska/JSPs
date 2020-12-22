namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticketfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "BusId_ID", "dbo.Buses");
            DropForeignKey("dbo.Tickets", "EndId_ID", "dbo.BusStops");
            DropForeignKey("dbo.Tickets", "StartId_ID", "dbo.BusStops");
            DropForeignKey("dbo.Tickets", "Bus_ID", "dbo.Buses");
            DropIndex("dbo.Tickets", new[] { "Bus_ID" });
            DropIndex("dbo.Tickets", new[] { "BusId_ID" });
            DropIndex("dbo.Tickets", new[] { "EndId_ID" });
            DropIndex("dbo.Tickets", new[] { "StartId_ID" });
            RenameColumn(table: "dbo.Tickets", name: "Bus_ID", newName: "BusId");
            AddColumn("dbo.Tickets", "StartId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "EndId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "BusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "BusId");
            AddForeignKey("dbo.Tickets", "BusId", "dbo.Buses", "ID", cascadeDelete: true);
            DropColumn("dbo.Tickets", "BusId_ID");
            DropColumn("dbo.Tickets", "EndId_ID");
            DropColumn("dbo.Tickets", "StartId_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "StartId_ID", c => c.Int());
            AddColumn("dbo.Tickets", "EndId_ID", c => c.Int());
            AddColumn("dbo.Tickets", "BusId_ID", c => c.Int());
            DropForeignKey("dbo.Tickets", "BusId", "dbo.Buses");
            DropIndex("dbo.Tickets", new[] { "BusId" });
            AlterColumn("dbo.Tickets", "BusId", c => c.Int());
            DropColumn("dbo.Tickets", "EndId");
            DropColumn("dbo.Tickets", "StartId");
            RenameColumn(table: "dbo.Tickets", name: "BusId", newName: "Bus_ID");
            CreateIndex("dbo.Tickets", "StartId_ID");
            CreateIndex("dbo.Tickets", "EndId_ID");
            CreateIndex("dbo.Tickets", "BusId_ID");
            CreateIndex("dbo.Tickets", "Bus_ID");
            AddForeignKey("dbo.Tickets", "Bus_ID", "dbo.Buses", "ID");
            AddForeignKey("dbo.Tickets", "StartId_ID", "dbo.BusStops", "ID");
            AddForeignKey("dbo.Tickets", "EndId_ID", "dbo.BusStops", "ID");
            AddForeignKey("dbo.Tickets", "BusId_ID", "dbo.Buses", "ID");
        }
    }
}

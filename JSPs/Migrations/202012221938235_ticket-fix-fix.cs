namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticketfixfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "BusId", "dbo.Buses");
            DropIndex("dbo.Tickets", new[] { "BusId" });
            RenameColumn(table: "dbo.Tickets", name: "BusId", newName: "Bus_ID");
            AddColumn("dbo.Tickets", "ChosenBusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "Bus_ID", c => c.Int());
            CreateIndex("dbo.Tickets", "Bus_ID");
            AddForeignKey("dbo.Tickets", "Bus_ID", "dbo.Buses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Bus_ID", "dbo.Buses");
            DropIndex("dbo.Tickets", new[] { "Bus_ID" });
            AlterColumn("dbo.Tickets", "Bus_ID", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "ChosenBusId");
            RenameColumn(table: "dbo.Tickets", name: "Bus_ID", newName: "BusId");
            CreateIndex("dbo.Tickets", "BusId");
            AddForeignKey("dbo.Tickets", "BusId", "dbo.Buses", "ID", cascadeDelete: true);
        }
    }
}

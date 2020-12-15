namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketClassBackToNormal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "DateOfReservation", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "DateOfReservation", c => c.String());
        }
    }
}

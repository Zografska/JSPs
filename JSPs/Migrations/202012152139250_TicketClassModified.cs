namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketClassModified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "DateOfReservation", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "DateOfReservation", c => c.DateTime(nullable: false));
        }
    }
}

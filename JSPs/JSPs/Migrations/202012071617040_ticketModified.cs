namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticketModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "DateOfReservation", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "DateOfReservation");
        }
    }
}

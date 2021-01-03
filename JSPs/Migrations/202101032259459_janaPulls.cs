namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class janaPulls : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tickets", name: "ApplicationUser_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Tickets", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            AddColumn("dbo.Tickets", "StartId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "EndId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "ChosenBusId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "ChosenBusId");
            DropColumn("dbo.Tickets", "EndId");
            DropColumn("dbo.Tickets", "StartId");
            RenameIndex(table: "dbo.Tickets", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Tickets", name: "User_Id", newName: "ApplicationUser_Id");
        }
    }
}

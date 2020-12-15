namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusEdit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BusStops", "BusLine_ID", "dbo.BusLines");
            DropIndex("dbo.BusStops", new[] { "BusLine_ID" });
            DropColumn("dbo.BusStops", "BusLine_ID");
            DropTable("dbo.BusLines");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BusLines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.BusStops", "BusLine_ID", c => c.Int());
            CreateIndex("dbo.BusStops", "BusLine_ID");
            AddForeignKey("dbo.BusStops", "BusLine_ID", "dbo.BusLines", "ID");
        }
    }
}

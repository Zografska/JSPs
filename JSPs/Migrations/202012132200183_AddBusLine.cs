namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBusLine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BusStops", "BusLine_Id", c => c.Int());
            CreateIndex("dbo.BusStops", "BusLine_Id");
            AddForeignKey("dbo.BusStops", "BusLine_Id", "dbo.BusLines", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusStops", "BusLine_Id", "dbo.BusLines");
            DropIndex("dbo.BusStops", new[] { "BusLine_Id" });
            DropColumn("dbo.BusStops", "BusLine_Id");
            DropTable("dbo.BusLines");
        }
    }
}

namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Capacity = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BusStops",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BusLine_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BusLines", t => t.BusLine_ID)
                .Index(t => t.BusLine_ID);
            
            CreateTable(
                "dbo.BusLines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EndDestination_ID = c.Int(),
                        StartDestination_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BusStops", t => t.EndDestination_ID)
                .ForeignKey("dbo.BusStops", t => t.StartDestination_ID)
                .Index(t => t.EndDestination_ID)
                .Index(t => t.StartDestination_ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BusStopBus",
                c => new
                    {
                        BusStop_ID = c.Int(nullable: false),
                        Bus_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusStop_ID, t.Bus_ID })
                .ForeignKey("dbo.BusStops", t => t.BusStop_ID, cascadeDelete: true)
                .ForeignKey("dbo.Buses", t => t.Bus_ID, cascadeDelete: true)
                .Index(t => t.BusStop_ID)
                .Index(t => t.Bus_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "StartDestination_ID", "dbo.BusStops");
            DropForeignKey("dbo.Tickets", "EndDestination_ID", "dbo.BusStops");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BusStops", "BusLine_ID", "dbo.BusLines");
            DropForeignKey("dbo.BusStopBus", "Bus_ID", "dbo.Buses");
            DropForeignKey("dbo.BusStopBus", "BusStop_ID", "dbo.BusStops");
            DropIndex("dbo.BusStopBus", new[] { "Bus_ID" });
            DropIndex("dbo.BusStopBus", new[] { "BusStop_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Tickets", new[] { "StartDestination_ID" });
            DropIndex("dbo.Tickets", new[] { "EndDestination_ID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.BusStops", new[] { "BusLine_ID" });
            DropTable("dbo.BusStopBus");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tickets");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.BusLines");
            DropTable("dbo.BusStops");
            DropTable("dbo.Buses");
        }
    }
}

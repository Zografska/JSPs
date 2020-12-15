namespace JSPs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUserProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "UserProfilePic", c => c.String());
            CreateIndex("dbo.Tickets", "ApplicationUser_Id");
            AddForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "UserProfilePic");
            DropColumn("dbo.Tickets", "ApplicationUser_Id");
        }
    }
}

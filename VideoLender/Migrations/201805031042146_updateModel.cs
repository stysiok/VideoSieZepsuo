namespace VideoLender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lends", "Movie_Id", c => c.Int());
            AddColumn("dbo.Lends", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Lends", "Movie_Id");
            CreateIndex("dbo.Lends", "User_Id");
            AddForeignKey("dbo.Lends", "Movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.Lends", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Lends", "MovieId");
            DropColumn("dbo.Lends", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lends", "ApplicationUserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Lends", "MovieId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Lends", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Lends", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Lends", new[] { "User_Id" });
            DropIndex("dbo.Lends", new[] { "Movie_Id" });
            DropColumn("dbo.Lends", "User_Id");
            DropColumn("dbo.Lends", "Movie_Id");
        }
    }
}

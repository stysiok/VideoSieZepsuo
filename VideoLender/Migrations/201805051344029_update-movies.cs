namespace VideoLender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "VoteAverage", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "VoteAverage");
        }
    }
}

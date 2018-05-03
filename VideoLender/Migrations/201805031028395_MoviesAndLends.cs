namespace VideoLender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesAndLends : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        ApplicationUserId = c.Guid(nullable: false),
                        PeriodOfLending = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "IsReserved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movies", "IsLended", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "IsLended");
            DropColumn("dbo.Movies", "IsReserved");
            DropTable("dbo.Lends");
        }
    }
}

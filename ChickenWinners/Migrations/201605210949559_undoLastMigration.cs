namespace ChickenWinners.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undoLastMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MyLeaguesViewModels", "Sport_Id", "dbo.Sports");
            DropIndex("dbo.MyLeaguesViewModels", new[] { "Sport_Id" });
            DropTable("dbo.MyLeaguesViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MyLeaguesViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartWeek = c.Int(nullable: false),
                        LeagueStateId = c.Int(nullable: false),
                        LeagueState = c.Int(nullable: false),
                        Sport_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.MyLeaguesViewModels", "Sport_Id");
            AddForeignKey("dbo.MyLeaguesViewModels", "Sport_Id", "dbo.Sports", "Id");
        }
    }
}

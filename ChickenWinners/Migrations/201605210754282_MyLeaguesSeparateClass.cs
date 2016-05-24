namespace ChickenWinners.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyLeaguesSeparateClass : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sports", t => t.Sport_Id)
                .Index(t => t.Sport_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyLeaguesViewModels", "Sport_Id", "dbo.Sports");
            DropIndex("dbo.MyLeaguesViewModels", new[] { "Sport_Id" });
            DropTable("dbo.MyLeaguesViewModels");
        }
    }
}

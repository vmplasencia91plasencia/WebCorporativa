namespace WebCujae.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        AwardId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        name = c.String(nullable: false),
                        año = c.String(nullable: false),
                        facultad = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AwardId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Awards");
        }
    }
}

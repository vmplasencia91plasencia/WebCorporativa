namespace WebCujae.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Event_Url_Added_27062018 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 4000),
                        description = c.String(nullable: false, maxLength: 4000),
                        time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Urls",
                c => new
                    {
                        UrlId = c.Int(nullable: false, identity: true),
                        url = c.String(nullable: false, maxLength: 4000),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.UrlId)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .Index(t => t.Event_EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Urls", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Urls", new[] { "Event_EventId" });
            DropTable("dbo.Urls");
            DropTable("dbo.Events");
        }
    }
}

namespace WebCujae.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Se_incorporo_la_eliminacion_en_cascada_de_Evento : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Urls", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Urls", new[] { "Event_EventId" });
            AlterColumn("dbo.Urls", "Event_EventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Urls", "Event_EventId");
            AddForeignKey("dbo.Urls", "Event_EventId", "dbo.Events", "EventId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Urls", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Urls", new[] { "Event_EventId" });
            AlterColumn("dbo.Urls", "Event_EventId", c => c.Int());
            CreateIndex("dbo.Urls", "Event_EventId");
            AddForeignKey("dbo.Urls", "Event_EventId", "dbo.Events", "EventId");
        }
    }
}

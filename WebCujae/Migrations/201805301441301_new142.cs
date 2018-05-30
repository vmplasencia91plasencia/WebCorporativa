namespace WebCujae.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new142 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Awards", "autores", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Awards", "autores");
        }
    }
}

namespace WebCujae.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Specialties", "zone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Specialties", "zone", c => c.Int(nullable: false));
        }
    }
}

namespace WebCujae.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new141 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Specialties", "actualizacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Specialties", "actualizacion", c => c.String(nullable: false));
        }
    }
}

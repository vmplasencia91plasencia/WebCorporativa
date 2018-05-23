namespace WebCujae.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Specialties");
            CreateTable(
                "dbo.Coordinates",
                c => new
                    {
                        CoordinateId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        mail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CoordinateId);
            
            AlterColumn("dbo.Specialties", "SpecialtyId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Specialties", "SpecialtyId");
            CreateIndex("dbo.Specialties", "SpecialtyId");
            AddForeignKey("dbo.Specialties", "SpecialtyId", "dbo.Coordinates", "CoordinateId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specialties", "SpecialtyId", "dbo.Coordinates");
            DropIndex("dbo.Specialties", new[] { "SpecialtyId" });
            DropPrimaryKey("dbo.Specialties");
            AlterColumn("dbo.Specialties", "SpecialtyId", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Coordinates");
            AddPrimaryKey("dbo.Specialties", "SpecialtyId");
        }
    }
}

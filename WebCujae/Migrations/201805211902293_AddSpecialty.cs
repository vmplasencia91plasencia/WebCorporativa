namespace WebCujae.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecialty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        SpecialtyId = c.Int(nullable: false),
                        zone = c.Int(nullable: false),
                        name = c.String(),
                        actualizacion = c.DateTime(nullable: false),
                        category = c.String(),
                    })
                .PrimaryKey(t => t.SpecialtyId)
                .ForeignKey("dbo.Sites", t => t.SpecialtyId)
                .Index(t => t.SpecialtyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specialties", "SpecialtyId", "dbo.Sites");
            DropIndex("dbo.Specialties", new[] { "SpecialtyId" });
            DropTable("dbo.Specialties");
        }
    }
}

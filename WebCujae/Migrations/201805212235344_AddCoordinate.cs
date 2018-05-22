namespace WebCujae.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoordinate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coordinates",
                c => new
                    {
                        CoordinateId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        phone = c.String(),
                        mail = c.String(),
                        Specialty_SpecialtyId = c.Int(),
                    })
                .PrimaryKey(t => t.CoordinateId)
                .ForeignKey("dbo.Specialties", t => t.Specialty_SpecialtyId)
                .Index(t => t.Specialty_SpecialtyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coordinates", "Specialty_SpecialtyId", "dbo.Specialties");
            DropIndex("dbo.Coordinates", new[] { "Specialty_SpecialtyId" });
            DropTable("dbo.Coordinates");
        }
    }
}

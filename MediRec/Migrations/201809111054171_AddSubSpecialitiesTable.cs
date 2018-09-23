namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubSpecialitiesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubSpecialities",
                c => new
                    {
                        SubSpecialitiesId = c.Int(nullable: false, identity: true),
                        SubSpecialitiesCode = c.String(maxLength: 5),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(nullable: false, maxLength: 50),
                        SpecialtyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubSpecialitiesId)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyId)
                .Index(t => t.SpecialtyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubSpecialities", "SpecialtyId", "dbo.Specialties");
            DropIndex("dbo.SubSpecialities", new[] { "SpecialtyId" });
            DropTable("dbo.SubSpecialities");
        }
    }
}

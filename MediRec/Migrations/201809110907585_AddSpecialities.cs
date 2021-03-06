namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecialities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        SpecialtyId = c.Int(nullable: false, identity: true),
                        SpecialtyCode = c.String(maxLength: 4),
                        NameAr = c.String(nullable: false, maxLength: 100),
                        NameEn = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(maxLength: 225),
                        CreadtedDateTime = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 225),
                        ModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.SpecialtyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Specialties");
        }
    }
}

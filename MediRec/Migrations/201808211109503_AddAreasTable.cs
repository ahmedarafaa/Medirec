namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAreasTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(maxLength: 4),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(maxLength: 225),
                        CreadtedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 225),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AreaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Areas");
        }
    }
}

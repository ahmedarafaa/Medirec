namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCitiesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(maxLength: 4),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(maxLength: 225),
                        CreadtedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 225),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            AlterColumn("dbo.Doctors", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Doctors", "AreaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "AreaId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Doctors", "CityId", c => c.Byte(nullable: false));
            DropTable("dbo.Cities");
        }
    }
}

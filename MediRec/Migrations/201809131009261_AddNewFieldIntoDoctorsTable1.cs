namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldIntoDoctorsTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Doctors", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Doctors", "CountryId", "dbo.Countries");
            DropIndex("dbo.Doctors", new[] { "CountryId" });
            DropIndex("dbo.Doctors", new[] { "CityId" });
            DropIndex("dbo.Doctors", new[] { "AreaId" });
            DropColumn("dbo.Doctors", "CountryId");
            DropColumn("dbo.Doctors", "CityId");
            DropColumn("dbo.Doctors", "AreaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "AreaId", c => c.Int(nullable: false));
            AddColumn("dbo.Doctors", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Doctors", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "AreaId");
            CreateIndex("dbo.Doctors", "CityId");
            CreateIndex("dbo.Doctors", "CountryId");
            AddForeignKey("dbo.Doctors", "CountryId", "dbo.Countries", "CountryId");
            AddForeignKey("dbo.Doctors", "CityId", "dbo.Cities", "CityId");
            AddForeignKey("dbo.Doctors", "AreaId", "dbo.Areas", "AreaId");
        }
    }
}

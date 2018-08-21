namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenCitiesAndAreas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Areas", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Areas", "CityId");
            AddForeignKey("dbo.Areas", "CityId", "dbo.Cities", "CityId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Areas", "CityId", "dbo.Cities");
            DropIndex("dbo.Areas", new[] { "CityId" });
            DropColumn("dbo.Areas", "CityId");
        }
    }
}

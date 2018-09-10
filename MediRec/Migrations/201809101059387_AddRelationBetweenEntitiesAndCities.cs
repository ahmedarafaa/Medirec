namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenEntitiesAndCities : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Entities", "CityId");
            AddForeignKey("dbo.Entities", "CityId", "dbo.Cities", "CityId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entities", "CityId", "dbo.Cities");
            DropIndex("dbo.Entities", new[] { "CityId" });
        }
    }
}

namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenEntitiesAndCountries1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Entities", "CountryId");
            AddForeignKey("dbo.Entities", "CountryId", "dbo.Countries", "CountryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entities", "CountryId", "dbo.Countries");
            DropIndex("dbo.Entities", new[] { "CountryId" });
        }
    }
}

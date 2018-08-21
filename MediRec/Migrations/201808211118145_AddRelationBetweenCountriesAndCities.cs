namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenCountriesAndCities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cities", "CountryId");
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropColumn("dbo.Cities", "CountryId");
        }
    }
}

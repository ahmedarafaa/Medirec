namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldsToEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entities", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Entities", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Entities", "AreaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entities", "AreaId");
            DropColumn("dbo.Entities", "CityId");
            DropColumn("dbo.Entities", "CountryId");
        }
    }
}

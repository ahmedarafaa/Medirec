namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenEntitiesAndEntitiesTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entities", "EntitiesTypesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Entities", "EntitiesTypesId");
            AddForeignKey("dbo.Entities", "EntitiesTypesId", "dbo.EntitiesTypes", "EntitiesTypesId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entities", "EntitiesTypesId", "dbo.EntitiesTypes");
            DropIndex("dbo.Entities", new[] { "EntitiesTypesId" });
            DropColumn("dbo.Entities", "EntitiesTypesId");
        }
    }
}

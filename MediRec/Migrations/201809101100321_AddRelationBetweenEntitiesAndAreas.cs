namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenEntitiesAndAreas : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Entities", "AreaId");
            AddForeignKey("dbo.Entities", "AreaId", "dbo.Areas", "AreaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entities", "AreaId", "dbo.Areas");
            DropIndex("dbo.Entities", new[] { "AreaId" });
        }
    }
}

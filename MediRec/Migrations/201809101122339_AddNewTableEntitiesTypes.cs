namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableEntitiesTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntitiesTypes",
                c => new
                    {
                        EntitiesTypesId = c.Int(nullable: false, identity: true),
                        EntitiesTypesCode = c.String(nullable: false, maxLength: 4),
                        NameAr = c.String(nullable: false),
                        NameEn = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EntitiesTypesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EntitiesTypes");
        }
    }
}

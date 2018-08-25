namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entities",
                c => new
                    {
                        EntityId = c.Int(nullable: false, identity: true),
                        EntityCode = c.String(nullable: false, maxLength: 4),
                        NameAr = c.String(nullable: false),
                        NameEn = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EntityId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Entities");
        }
    }
}

namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableResources : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourcesId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        ImageUrl = c.String(maxLength: 1500),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResourcesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Resources");
        }
    }
}

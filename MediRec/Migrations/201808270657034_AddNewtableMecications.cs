namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewtableMecications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        MedicationsId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicationsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medications");
        }
    }
}

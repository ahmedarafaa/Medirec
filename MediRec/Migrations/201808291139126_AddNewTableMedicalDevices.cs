namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableMedicalDevices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalDevices",
                c => new
                    {
                        MedicalDevicesId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicalDevicesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MedicalDevices");
        }
    }
}

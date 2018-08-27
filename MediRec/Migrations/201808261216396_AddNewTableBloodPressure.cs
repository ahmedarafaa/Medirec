namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableBloodPressure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodPressures",
                c => new
                    {
                        BloodPressureId = c.Int(nullable: false, identity: true),
                        Systolic = c.Double(nullable: false),
                        Diastolic = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BloodPressureId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BloodPressures");
        }
    }
}

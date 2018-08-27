namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTablePatients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PatientCode = c.String(maxLength: 4),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                        InsuranceId = c.Int(nullable: false),
                        ImageURL = c.String(maxLength: 1500),
                        CreatedBy = c.String(maxLength: 225),
                        CreadtedDateTime = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 225),
                        ModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            AddColumn("dbo.Doctors", "ModifiedDateTime", c => c.DateTime());
            AlterColumn("dbo.Doctors", "CreadtedDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "CreadtedDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Doctors", "ModifiedDateTime");
            DropTable("dbo.Patients");
        }
    }
}

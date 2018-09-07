namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameFieldsIntoPatientsTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "FullName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Patients", "NameAr");
            DropColumn("dbo.Patients", "NameEn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "NameEn", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Patients", "NameAr", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Patients", "FullName");
        }
    }
}

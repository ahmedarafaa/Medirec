namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameFieldsIntoPatientsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "NameAr", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Patients", "NameEn", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "NameEn");
            DropColumn("dbo.Patients", "NameAr");
        }
    }
}

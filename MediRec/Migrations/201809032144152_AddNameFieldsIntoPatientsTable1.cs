namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameFieldsIntoPatientsTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Gender", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.Patients", "Address", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Patients", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "BirthDate");
            DropColumn("dbo.Patients", "Address");
            DropColumn("dbo.Patients", "Gender");
        }
    }
}

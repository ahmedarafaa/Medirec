namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberFieldsIntoPatientsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "PhoneNumber", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "PhoneNumber");
        }
    }
}

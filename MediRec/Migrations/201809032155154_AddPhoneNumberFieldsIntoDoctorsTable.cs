namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberFieldsIntoDoctorsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "PhoneNumber", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "PhoneNumber");
        }
    }
}

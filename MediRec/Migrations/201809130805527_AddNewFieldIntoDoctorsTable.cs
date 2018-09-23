namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldIntoDoctorsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "AboutDoctorShortDescriptionEn", c => c.String(maxLength: 100));
            AddColumn("dbo.Doctors", "AboutDoctorLongDescriptionEn", c => c.String(maxLength: 1000));
            AddColumn("dbo.Doctors", "AboutDoctorShortDescriptionAr", c => c.String(maxLength: 100));
            AddColumn("dbo.Doctors", "AboutDoctorLongDescriptionAr", c => c.String(maxLength: 1000));
            AddColumn("dbo.DoctorsEntities", "TicketPrice", c => c.Int(nullable: false));
            AddColumn("dbo.Entities", "AddressEn", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.Entities", "AddressAr", c => c.String(nullable: false, maxLength: 1000));
            DropColumn("dbo.Doctors", "TickerPrice");
            DropColumn("dbo.Doctors", "AboutDoctorShortDescription");
            DropColumn("dbo.Doctors", "AboutDoctorLongDescription");
            DropColumn("dbo.Entities", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entities", "Address", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.Doctors", "AboutDoctorLongDescription", c => c.String(maxLength: 1000));
            AddColumn("dbo.Doctors", "AboutDoctorShortDescription", c => c.String(maxLength: 100));
            AddColumn("dbo.Doctors", "TickerPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Entities", "AddressAr");
            DropColumn("dbo.Entities", "AddressEn");
            DropColumn("dbo.DoctorsEntities", "TicketPrice");
            DropColumn("dbo.Doctors", "AboutDoctorLongDescriptionAr");
            DropColumn("dbo.Doctors", "AboutDoctorShortDescriptionAr");
            DropColumn("dbo.Doctors", "AboutDoctorLongDescriptionEn");
            DropColumn("dbo.Doctors", "AboutDoctorShortDescriptionEn");
        }
    }
}

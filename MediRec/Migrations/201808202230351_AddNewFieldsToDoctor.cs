namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldsToDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "DoctorCode", c => c.String(nullable: false, maxLength: 5));
            AddColumn("dbo.Doctors", "SpecialtyId", c => c.Byte(nullable: false));
            AddColumn("dbo.Doctors", "AreaId", c => c.Byte(nullable: false));
            AddColumn("dbo.Doctors", "Gender", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.Doctors", "TickerPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Doctors", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "RegisterDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "CreatedBy", c => c.String(maxLength: 225));
            AddColumn("dbo.Doctors", "CreadtedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "ModifiedBy", c => c.String(maxLength: 225));
            AddColumn("dbo.Doctors", "ModifiedDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "ModifiedDateTime");
            DropColumn("dbo.Doctors", "ModifiedBy");
            DropColumn("dbo.Doctors", "CreadtedDateTime");
            DropColumn("dbo.Doctors", "CreatedBy");
            DropColumn("dbo.Doctors", "RegisterDate");
            DropColumn("dbo.Doctors", "BirthDate");
            DropColumn("dbo.Doctors", "TickerPrice");
            DropColumn("dbo.Doctors", "Gender");
            DropColumn("dbo.Doctors", "AreaId");
            DropColumn("dbo.Doctors", "SpecialtyId");
            DropColumn("dbo.Doctors", "DoctorCode");
        }
    }
}

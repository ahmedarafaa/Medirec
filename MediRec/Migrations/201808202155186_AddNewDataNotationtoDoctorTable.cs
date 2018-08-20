namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewDataNotationtoDoctorTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "NameAr", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Doctors", "NameEn", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Doctors", "SearchName", c => c.String(nullable: false, maxLength: 225));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "SearchName", c => c.String());
            AlterColumn("dbo.Doctors", "NameEn", c => c.String());
            AlterColumn("dbo.Doctors", "NameAr", c => c.String());
        }
    }
}

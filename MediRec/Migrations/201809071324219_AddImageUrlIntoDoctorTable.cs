namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlIntoDoctorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "ImageURL", c => c.String(maxLength: 1500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "ImageURL");
        }
    }
}

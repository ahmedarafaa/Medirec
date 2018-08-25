namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UploadtoGodaddy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "AboutDoctorShortDescription", c => c.String(maxLength: 100));
            AddColumn("dbo.Doctors", "AboutDoctorLongDescription", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "AboutDoctorLongDescription");
            DropColumn("dbo.Doctors", "AboutDoctorShortDescription");
        }
    }
}

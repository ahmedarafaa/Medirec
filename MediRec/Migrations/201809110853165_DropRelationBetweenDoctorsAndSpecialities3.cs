namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropRelationBetweenDoctorsAndSpecialities3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Doctors", "Address");
            DropColumn("dbo.Doctors", "WaitingTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "WaitingTime", c => c.Int(nullable: false));
            AddColumn("dbo.Doctors", "Address", c => c.String(nullable: false, maxLength: 100));
        }
    }
}

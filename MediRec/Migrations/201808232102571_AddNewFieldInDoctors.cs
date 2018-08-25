namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldInDoctors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Address", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Doctors", "WaitingTime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "WaitingTime");
            DropColumn("dbo.Doctors", "Address");
        }
    }
}

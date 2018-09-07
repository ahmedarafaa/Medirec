namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveFieldInDoctorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "IsActive");
        }
    }
}

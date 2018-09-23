namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenDoctorsAndSpecialities1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "SpecialtyId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "SpecialtyId");
        }
    }
}

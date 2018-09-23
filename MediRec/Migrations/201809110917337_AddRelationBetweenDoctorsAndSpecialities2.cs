namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenDoctorsAndSpecialities2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "SpecialtyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "SpecialtyId");
            AddForeignKey("dbo.Doctors", "SpecialtyId", "dbo.Specialties", "SpecialtyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "SpecialtyId", "dbo.Specialties");
            DropIndex("dbo.Doctors", new[] { "SpecialtyId" });
            DropColumn("dbo.Doctors", "SpecialtyId");
        }
    }
}

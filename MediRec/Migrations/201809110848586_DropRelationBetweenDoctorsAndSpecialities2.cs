namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropRelationBetweenDoctorsAndSpecialities2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Specialties_SpecialtyId", "dbo.Specialties");
            DropIndex("dbo.Doctors", new[] { "Specialties_SpecialtyId" });
            DropColumn("dbo.Doctors", "SpecialtyId");
            DropColumn("dbo.Doctors", "Specialties_SpecialtyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Specialties_SpecialtyId", c => c.Int());
            AddColumn("dbo.Doctors", "SpecialtyId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Doctors", "Specialties_SpecialtyId");
            AddForeignKey("dbo.Doctors", "Specialties_SpecialtyId", "dbo.Specialties", "SpecialtyId");
        }
    }
}

namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenDoctorsAndSpecialities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Specialties_SpecialtyId", c => c.Int());
            CreateIndex("dbo.Doctors", "Specialties_SpecialtyId");
            AddForeignKey("dbo.Doctors", "Specialties_SpecialtyId", "dbo.Specialties", "SpecialtyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "Specialties_SpecialtyId", "dbo.Specialties");
            DropIndex("dbo.Doctors", new[] { "Specialties_SpecialtyId" });
            DropColumn("dbo.Doctors", "Specialties_SpecialtyId");
        }
    }
}

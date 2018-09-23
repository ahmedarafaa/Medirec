namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropRelationBetweenDoctorsAndSpecialities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecialtiesDoctors", "Specialties_SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.SpecialtiesDoctors", "Doctors_DoctorId", "dbo.Doctors");
            DropIndex("dbo.SpecialtiesDoctors", new[] { "Specialties_SpecialtyId" });
            DropIndex("dbo.SpecialtiesDoctors", new[] { "Doctors_DoctorId" });
            AddColumn("dbo.Specialties", "Doctors_DoctorId", c => c.Int());
            CreateIndex("dbo.Specialties", "Doctors_DoctorId");
            AddForeignKey("dbo.Specialties", "Doctors_DoctorId", "dbo.Doctors", "DoctorId");
            DropTable("dbo.SpecialtiesDoctors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SpecialtiesDoctors",
                c => new
                    {
                        Specialties_SpecialtyId = c.Int(nullable: false),
                        Doctors_DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Specialties_SpecialtyId, t.Doctors_DoctorId });
            
            DropForeignKey("dbo.Specialties", "Doctors_DoctorId", "dbo.Doctors");
            DropIndex("dbo.Specialties", new[] { "Doctors_DoctorId" });
            DropColumn("dbo.Specialties", "Doctors_DoctorId");
            CreateIndex("dbo.SpecialtiesDoctors", "Doctors_DoctorId");
            CreateIndex("dbo.SpecialtiesDoctors", "Specialties_SpecialtyId");
            AddForeignKey("dbo.SpecialtiesDoctors", "Doctors_DoctorId", "dbo.Doctors", "DoctorId");
            AddForeignKey("dbo.SpecialtiesDoctors", "Specialties_SpecialtyId", "dbo.Specialties", "SpecialtyId");
        }
    }
}

namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMantToMantRelationBetweenDoctorsAndSpeciality : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecialtiesDoctors",
                c => new
                    {
                        Specialties_SpecialtyId = c.Int(nullable: false),
                        Doctors_DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Specialties_SpecialtyId, t.Doctors_DoctorId })
                .ForeignKey("dbo.Specialties", t => t.Specialties_SpecialtyId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctors_DoctorId, cascadeDelete: true)
                .Index(t => t.Specialties_SpecialtyId)
                .Index(t => t.Doctors_DoctorId);
            
            DropColumn("dbo.Doctors", "ModifiedDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "ModifiedDateTime", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.SpecialtiesDoctors", "Doctors_DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.SpecialtiesDoctors", "Specialties_SpecialtyId", "dbo.Specialties");
            DropIndex("dbo.SpecialtiesDoctors", new[] { "Doctors_DoctorId" });
            DropIndex("dbo.SpecialtiesDoctors", new[] { "Specialties_SpecialtyId" });
            DropTable("dbo.SpecialtiesDoctors");
        }
    }
}

namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropRelationBetweenDoctorsAndSpecialities1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Specialties", "Doctors_DoctorId", "dbo.Doctors");
            DropIndex("dbo.Specialties", new[] { "Doctors_DoctorId" });
            DropColumn("dbo.Specialties", "Doctors_DoctorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Specialties", "Doctors_DoctorId", c => c.Int());
            CreateIndex("dbo.Specialties", "Doctors_DoctorId");
            AddForeignKey("dbo.Specialties", "Doctors_DoctorId", "dbo.Doctors", "DoctorId");
        }
    }
}

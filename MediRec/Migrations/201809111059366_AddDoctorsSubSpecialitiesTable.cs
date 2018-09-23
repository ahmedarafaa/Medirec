namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorsSubSpecialitiesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorsSubSpecialities",
                c => new
                    {
                        DoctorId = c.Int(nullable: false),
                        SubSpecialitiesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorId, t.SubSpecialitiesId })
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.SubSpecialities", t => t.SubSpecialitiesId)
                .Index(t => t.DoctorId)
                .Index(t => t.SubSpecialitiesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorsSubSpecialities", "SubSpecialitiesId", "dbo.SubSpecialities");
            DropForeignKey("dbo.DoctorsSubSpecialities", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.DoctorsSubSpecialities", new[] { "SubSpecialitiesId" });
            DropIndex("dbo.DoctorsSubSpecialities", new[] { "DoctorId" });
            DropTable("dbo.DoctorsSubSpecialities");
        }
    }
}

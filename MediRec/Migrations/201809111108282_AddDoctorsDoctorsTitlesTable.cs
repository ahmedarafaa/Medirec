namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorsDoctorsTitlesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorsDoctorsTitles",
                c => new
                    {
                        DoctorId = c.Int(nullable: false),
                        DoctorsTitlesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorId, t.DoctorsTitlesId })
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.DoctorsTitles", t => t.DoctorsTitlesId)
                .Index(t => t.DoctorId)
                .Index(t => t.DoctorsTitlesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorsDoctorsTitles", "DoctorsTitlesId", "dbo.DoctorsTitles");
            DropForeignKey("dbo.DoctorsDoctorsTitles", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.DoctorsDoctorsTitles", new[] { "DoctorsTitlesId" });
            DropIndex("dbo.DoctorsDoctorsTitles", new[] { "DoctorId" });
            DropTable("dbo.DoctorsDoctorsTitles");
        }
    }
}

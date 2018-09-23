namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorsEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorsEntities",
                c => new
                    {
                        DoctorId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorId, t.EntityId })
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Entities", t => t.EntityId)
                .Index(t => t.DoctorId)
                .Index(t => t.EntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorsEntities", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.DoctorsEntities", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.DoctorsEntities", new[] { "EntityId" });
            DropIndex("dbo.DoctorsEntities", new[] { "DoctorId" });
            DropTable("dbo.DoctorsEntities");
        }
    }
}

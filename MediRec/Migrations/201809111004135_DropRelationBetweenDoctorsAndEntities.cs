namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropRelationBetweenDoctorsAndEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EntitiesDoctors", "Entities_EntityId", "dbo.Entities");
            DropForeignKey("dbo.EntitiesDoctors", "Doctors_DoctorId", "dbo.Doctors");
            DropIndex("dbo.EntitiesDoctors", new[] { "Entities_EntityId" });
            DropIndex("dbo.EntitiesDoctors", new[] { "Doctors_DoctorId" });
            DropTable("dbo.EntitiesDoctors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EntitiesDoctors",
                c => new
                    {
                        Entities_EntityId = c.Int(nullable: false),
                        Doctors_DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Entities_EntityId, t.Doctors_DoctorId });
            
            CreateIndex("dbo.EntitiesDoctors", "Doctors_DoctorId");
            CreateIndex("dbo.EntitiesDoctors", "Entities_EntityId");
            AddForeignKey("dbo.EntitiesDoctors", "Doctors_DoctorId", "dbo.Doctors", "DoctorId");
            AddForeignKey("dbo.EntitiesDoctors", "Entities_EntityId", "dbo.Entities", "EntityId");
        }
    }
}

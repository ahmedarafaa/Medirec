namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenEntitiesAndDoctors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntitiesDoctors",
                c => new
                    {
                        Entities_EntityId = c.Int(nullable: false),
                        Doctors_DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Entities_EntityId, t.Doctors_DoctorId })
                .ForeignKey("dbo.Entities", t => t.Entities_EntityId)
                .ForeignKey("dbo.Doctors", t => t.Doctors_DoctorId)
                .Index(t => t.Entities_EntityId)
                .Index(t => t.Doctors_DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntitiesDoctors", "Doctors_DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.EntitiesDoctors", "Entities_EntityId", "dbo.Entities");
            DropIndex("dbo.EntitiesDoctors", new[] { "Doctors_DoctorId" });
            DropIndex("dbo.EntitiesDoctors", new[] { "Entities_EntityId" });
            DropTable("dbo.EntitiesDoctors");
        }
    }
}

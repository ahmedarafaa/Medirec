namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableCalenders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calenders",
                c => new
                    {
                        CalendersId = c.Int(nullable: false, identity: true),
                        TimeFrom = c.Time(precision: 7),
                        TimeTo = c.Time(precision: 7),
                        DayName = c.String(nullable: false, maxLength: 10),
                        GenerateEveryXMin = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CalendersId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Entities", t => t.EntityId)
                .Index(t => t.DoctorId)
                .Index(t => t.EntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calenders", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Calenders", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Calenders", new[] { "EntityId" });
            DropIndex("dbo.Calenders", new[] { "DoctorId" });
            DropTable("dbo.Calenders");
        }
    }
}

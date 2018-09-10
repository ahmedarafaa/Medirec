namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableCalendersDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalendersDetails",
                c => new
                    {
                        CalendersDetailsId = c.Int(nullable: false, identity: true),
                        CalendersId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        TimeFrom = c.Time(precision: 7),
                        TimeTo = c.Time(precision: 7),
                        DayName = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.CalendersDetailsId)
                .ForeignKey("dbo.Calenders", t => t.CalendersId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Entities", t => t.EntityId)
                .Index(t => t.CalendersId)
                .Index(t => t.DoctorId)
                .Index(t => t.EntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CalendersDetails", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.CalendersDetails", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.CalendersDetails", "CalendersId", "dbo.Calenders");
            DropIndex("dbo.CalendersDetails", new[] { "EntityId" });
            DropIndex("dbo.CalendersDetails", new[] { "DoctorId" });
            DropIndex("dbo.CalendersDetails", new[] { "CalendersId" });
            DropTable("dbo.CalendersDetails");
        }
    }
}

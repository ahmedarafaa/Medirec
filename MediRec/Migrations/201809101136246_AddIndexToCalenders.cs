namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexToCalenders : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Calenders", new[] { "DoctorId" });
            DropIndex("dbo.Calenders", new[] { "EntityId" });
            CreateIndex("dbo.Calenders", new[] { "TimeFrom", "TimeTo", "DayName", "GenerateEveryXMin", "DoctorId", "EntityId" }, unique: true, name: "IX_Calenders");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Calenders", "IX_Calenders");
            CreateIndex("dbo.Calenders", "EntityId");
            CreateIndex("dbo.Calenders", "DoctorId");
        }
    }
}

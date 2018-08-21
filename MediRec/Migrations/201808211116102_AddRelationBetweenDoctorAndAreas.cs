namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenDoctorAndAreas : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Doctors", "AreaId");
            AddForeignKey("dbo.Doctors", "AreaId", "dbo.Areas", "AreaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "AreaId", "dbo.Areas");
            DropIndex("dbo.Doctors", new[] { "AreaId" });
        }
    }
}

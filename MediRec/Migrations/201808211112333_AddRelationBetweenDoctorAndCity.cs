namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenDoctorAndCity : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Doctors", "CityId");
            AddForeignKey("dbo.Doctors", "CityId", "dbo.Cities", "CityId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "CityId", "dbo.Cities");
            DropIndex("dbo.Doctors", new[] { "CityId" });
        }
    }
}

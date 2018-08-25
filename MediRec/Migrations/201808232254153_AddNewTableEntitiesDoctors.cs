namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableEntitiesDoctors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntitiesDoctors",
                c => new
                    {
                        EntitiesDoctorsId = c.Int(nullable: false, identity: true),
                        DoctorId = c.String(),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntitiesDoctorsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EntitiesDoctors");
        }
    }
}

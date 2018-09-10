namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropEntitiesDoctors : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.EntitiesDoctors");
        }
        
        public override void Down()
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
    }
}

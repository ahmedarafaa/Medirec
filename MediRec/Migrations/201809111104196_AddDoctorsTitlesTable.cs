namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorsTitlesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorsTitles",
                c => new
                    {
                        DoctorsTitlesId = c.Int(nullable: false, identity: true),
                        DoctorsTitlesCode = c.Int(nullable: false),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DoctorsTitlesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DoctorsTitles");
        }
    }
}

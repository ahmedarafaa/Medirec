namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableImmunizations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Immunizations",
                c => new
                    {
                        ImmunizationId = c.Int(nullable: false, identity: true),
                        VaccineId = c.Int(nullable: false),
                        DateGiven = c.DateTime(nullable: false),
                        AdministratedBy = c.String(maxLength: 25),
                        NextDoesDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImmunizationId)
                .ForeignKey("dbo.Vaccines", t => t.VaccineId, cascadeDelete: true)
                .Index(t => t.VaccineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Immunizations", "VaccineId", "dbo.Vaccines");
            DropIndex("dbo.Immunizations", new[] { "VaccineId" });
            DropTable("dbo.Immunizations");
        }
    }
}

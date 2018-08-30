namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableVaccines : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vaccines",
                c => new
                    {
                        VaccineId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.VaccineId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vaccines");
        }
    }
}

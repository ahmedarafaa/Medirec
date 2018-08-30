namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVaccineCodeToVaccineTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vaccines", "VaccineCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vaccines", "VaccineCode");
        }
    }
}

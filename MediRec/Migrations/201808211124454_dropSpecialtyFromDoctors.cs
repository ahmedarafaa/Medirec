namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropSpecialtyFromDoctors : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Doctors", "Specialty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Specialty", c => c.Byte(nullable: false));
        }
    }
}

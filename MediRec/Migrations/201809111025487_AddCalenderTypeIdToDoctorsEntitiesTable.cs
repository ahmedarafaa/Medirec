namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCalenderTypeIdToDoctorsEntitiesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoctorsEntities", "CalenderTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DoctorsEntities", "CalenderTypeId");
        }
    }
}

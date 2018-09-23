namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWaitingTimeIntoDoctorsEntitiesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoctorsEntities", "WaitingTime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DoctorsEntities", "WaitingTime");
        }
    }
}

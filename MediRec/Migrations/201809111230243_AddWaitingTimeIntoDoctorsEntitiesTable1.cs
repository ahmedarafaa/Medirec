namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWaitingTimeIntoDoctorsEntitiesTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DoctorsTitles", "DoctorsTitlesCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DoctorsTitles", "DoctorsTitlesCode", c => c.Int(nullable: false));
        }
    }
}

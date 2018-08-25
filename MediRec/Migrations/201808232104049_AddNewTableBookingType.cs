namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableBookingType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingTypes",
                c => new
                    {
                        BookingTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BookingTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookingTypes");
        }
    }
}

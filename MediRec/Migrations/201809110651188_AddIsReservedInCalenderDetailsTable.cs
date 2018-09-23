namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsReservedInCalenderDetailsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalendersDetails", "IsReserved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CalendersDetails", "IsReserved");
        }
    }
}

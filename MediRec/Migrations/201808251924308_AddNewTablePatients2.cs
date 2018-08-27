namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTablePatients2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Areas", "AreaCode", c => c.String(maxLength: 4));
            DropColumn("dbo.Areas", "CountryCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Areas", "CountryCode", c => c.String(maxLength: 4));
            DropColumn("dbo.Areas", "AreaCode");
        }
    }
}
